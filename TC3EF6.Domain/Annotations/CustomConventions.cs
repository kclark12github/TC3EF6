using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace TC3EF6.Domain.Annotations
{
    public static class CustomConventions
    {
        public static void Add(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(new AttributeToColumnAnnotationConvention<ColumnDescriptionAttribute, string>("ColumnDescription", (p, attributes) => attributes.Single().Value));
            modelBuilder.Conventions.Add(new AttributeToColumnAnnotationConvention<MinLengthAttribute, int>("MinLength", (p, attributes) => attributes.Single().Length));
            modelBuilder.Conventions.Add(new AttributeToColumnAnnotationConvention<SqlDefaultValueAttribute, string>("SqlDefaultValue", (p, attributes) => attributes.Single().DefaultValue));
            modelBuilder.Conventions.Add(new AttributeToTableAnnotationConvention<TableDescriptionAttribute, string>("TableDescription", (p, attributes) => attributes.Single().Value));

            modelBuilder.Properties<decimal>().Configure(config => config.HasPrecision(18, 4));
        }
    }
}
