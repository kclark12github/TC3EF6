using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.Migrations.Design;
using System.Data.Entity.Migrations.Model;
using System.Data.Entity.SqlServer;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace TC3EF6.Data.CustomMigrationOperations
{
    public class TCMigrationSqlGenerator : SqlServerMigrationSqlGenerator
    {
        protected override void Generate(AddColumnOperation addColumnOperation)
        {
            SetAnnotatedColumn(addColumnOperation.Column);
            base.Generate(addColumnOperation);
            SetColumnDescription(addColumnOperation.Table, addColumnOperation.Column);
        }
        protected override void Generate(CreateTableOperation createTableOperation)
        {
            foreach (var columnModel in createTableOperation.Columns)
                SetAnnotatedColumn(columnModel);
            base.Generate(createTableOperation);
            SetTableDescription(createTableOperation);
            foreach (var columnModel in createTableOperation.Columns)
                SetColumnDescription(createTableOperation.Name, columnModel);
            foreach (var columnModel in createTableOperation.Columns)
                AddConstraint(createTableOperation.Name, columnModel);
        }
        private void AddConstraint(string tableName, ColumnModel column)
        {
            if (column.Annotations.TryGetValue("MinLength", out AnnotationValues values))
            {
                using (var writer = Writer())
                {
                    string schema = Utilities.GetSchema(tableName);
                    string table = Utilities.GetTableName(tableName);
                    writer.WriteLine("Alter Table [{0}].[{1}] Add Constraint " +
                        "[Chk_{0}_{1}_{2}_MinLength] Check (DataLength([{2}])>={3})",
                        schema, table, column.Name, values.NewValue);
                    Statement(writer);
                }
            }
        }
        private void SetAnnotatedColumn(ColumnModel column)
        {
            if (column.Annotations.TryGetValue("SqlDefaultValue", out AnnotationValues values))
            {
                column.DefaultValueSql = (string)values.NewValue;
            }
        }
        private void SetColumnDescription(string tableName, ColumnModel column)
        {
            if (column.Annotations.TryGetValue("ColumnDescription", out AnnotationValues values))
            {
                using (var writer = Writer())
                {
                    string description = (string)values.NewValue;
                    writer.WriteLine("sp_AddExtendedProperty @name = N'MS_Description'," +
                        "@value=N'{0}'," +
                        "@level0type=N'SCHEMA',@level0name=N'{1}'," +
                        "@level1type=N'TABLE',@level1name=N'{2}'," +
                        "@level2type=N'COLUMN',@level2name=N'{3}'",
                        description.ToString().Replace("'", "''"),
                        Utilities.GetSchema(tableName),
                        Utilities.GetTableName(tableName),
                        column.Name);
                    Statement(writer);
                }
            }
        }
        private void SetTableDescription(CreateTableOperation createTableOperation)
        {
            if (createTableOperation.Annotations.TryGetValue("TableDescription", out var description))
            {
                using (var writer = Writer())
                {
                    string tableName = createTableOperation.Name;
                    writer.WriteLine("sp_AddExtendedProperty @name = N'MS_Description'," +
                        "@value=N'{0}'," +
                        "@level0type=N'SCHEMA',@level0name=N'{1}'," +
                        "@level1type=N'TABLE',@level1name=N'{2}'",
                        ((string)description).Replace("'", "''"),
                        Utilities.GetSchema(tableName),
                        Utilities.GetTableName(tableName));
                    Statement(writer);
                }
            }
        }
        //public void AddColumnsDescriptions(DbContext mydbContext)
        //{
        //    // Fetch all the DbContext class public properties which contains your attributes
        //    var dbContextProperies = typeof(DbContext).GetProperties().Select(pi => pi.Name).ToList();

        //    // Loop each DbSets of type T
        //    foreach (var item in typeof(MyDbContext).GetProperties()
        //        .Where(p => dbContextProperies.IndexOf(p.Name) < 0)
        //        .Select(p => p))
        //    {
        //        if (!item.PropertyType.GetGenericArguments().Any())
        //        {
        //            continue;
        //        }

        //        // Fetch the type of "T"
        //        var entityModelType = item.PropertyType.GetGenericArguments()[0];
        //        var descriptionInfos = from prop in entityModelType.GetProperties()
        //                               where prop.GetCustomAttributes(typeof(DescriptionAttribute), true).Any()
        //                               select new { ColumnName = prop.Name, Attributes = prop.CustomAttributes };

        //        foreach (var descriptionInfo in descriptionInfos)
        //        {
        //            // Sql to create the description column and adding 
        //            var addDiscriptionColumnSql =
        //                @"sp_addextendedproperty  @name = N'MS_Description', @value = '"
        //                + descriptionInfo.Attributes.First().ConstructorArguments.First()
        //                + @"', @level0type = N'Schema', @level0name = dbo,  @level1type = N'Table',  @level1name = "
        //                + entityModelType.Name + "s" + ", @level2type = N'Column', @level2name ="
        //                + descriptionInfo.ColumnName;

        //            var sqlCommandResult = mydbContext.Database.ExecuteSqlCommand(addDiscriptionColumnSql);
        //        }
        //    }
        //}
        #region "EntityFramework 4.3 Implementation attempts..."
        //        protected override void Generate(AddColumnOperation addColumnOperation)
        //        {
        //            SetAnnotatedColumn(addColumnOperation.Column, addColumnOperation.Table);
        //            base.Generate(addColumnOperation);
        //        }
        //        protected override void Generate(AlterColumnOperation alterColumnOperation)
        //        {
        //            SetAnnotatedColumn(alterColumnOperation.Column, alterColumnOperation.Table);
        //            base.Generate(alterColumnOperation);
        //        }
        //        protected override void Generate(CreateTableOperation createTableOperation)
        //        {
        //            SetAnnotatedColumns(createTableOperation.Columns, createTableOperation.Name);
        //            base.Generate(createTableOperation);
        //        }
        //        protected override void Generate(AlterTableOperation alterTableOperation)
        //        {
        //            SetAnnotatedColumns(alterTableOperation.Columns, alterTableOperation.Name);
        //            base.Generate(alterTableOperation);
        //        }
        //        private void SetAnnotatedColumn(ColumnModel column, string tableName)
        //        {
        //            if (column.Annotations.TryGetValue("Description", out AnnotationValues values))
        //            {
        //                if (values.NewValue == null)
        //                {
        //                    using (var writer = Writer())
        //                    {


        //                        var str = $@"DECLARE @var{dropConstraintCount} nvarchar(128)
        //SELECT @var{dropConstraintCount} = name
        //FROM sys.default_constraints
        //WHERE parent_object_id = object_id(N'{tableSchema}.[{tablePureName}]')
        //AND col_name(parent_object_id, parent_column_id) = '{columnName}';
        //IF @var{dropConstraintCount} IS NOT NULL
        //    EXECUTE('ALTER TABLE {tableSchema}.[{tablePureName}] DROP CONSTRAINT [' + @var{dropConstraintCount} + ']')";




        //                        writer.Write("ALTER TABLE {0} ADD CONSTRAINT {1} CHECK (LEN(LTRIM(RTRIM({2}))) > {3})",
        //                            Name(tableName),
        //                            Quote("ML_" + tableName + "_" + column.Name),
        //                            Quote(column.Name),
        //                            minLength);
        //                        Statement(writer.ToString());
        //                    }
        //                }
        //            }
        //            else if (column.Annotations.TryGetValue("SqlDefaultValue", out values))
        //            {
        //                if (values.NewValue == null)
        //                {
        //                    column.DefaultValueSql = null;
        //                    using (var writer = Writer())
        //                    {   // Drop Constraint
        //                        writer.WriteLine(GetSqlDropConstraintQuery(tableName, column.Name));
        //                        Statement(writer);
        //                    }
        //                }
        //                else
        //                {
        //                    column.DefaultValueSql = (string)values.NewValue;
        //                }
        //            }
        //            else if (column.Annotations.TryGetValue("MinLength", out values))
        //            {
        //                var minLength = Convert.ToInt32(values.NewValue);
        //                if (minLength > 0)
        //                {
        //                    if (Convert.ToString(column.DefaultValue).Trim().Length < minLength)
        //                    {
        //                        throw new ArgumentException(String.Format("MinLength {0} specified for {1}.{2}, but the default value, '{3}', does not satisfy this requirement.", minLength, tableName, column.Name, column.DefaultValue));
        //                    }

        //                    using (var writer = Writer())
        //                    {
        //                        //writer.Write("ALTER TABLE ");
        //                        //writer.Write(Name(tableName));
        //                        //writer.Write(" ADD CONSTRAINT ");
        //                        //writer.Write(Quote("ML_" + tableName + "_" + column.Name));
        //                        //writer.Write(" CHECK (LEN(LTRIM(RTRIM({0}))) > {1})", Quote(column.Name), minLength);
        //                        writer.Write("Alter Table {0} Add Constraint {1} Check (Len(LTrim(RTrim({2}))) > {3})",
        //                            Name(tableName),
        //                            Quote("ML_" + tableName + "_" + column.Name),
        //                            Quote(column.Name),
        //                            minLength);
        //                        Statement(writer.ToString());
        //                    }
        //                }
        //            }
        //        }
        //        private void SetAnnotatedColumns(IEnumerable<ColumnModel> columns, string tableName)
        //        {
        //            foreach (var column in columns)
        //            {
        //                SetAnnotatedColumn(column, tableName);
        //            }
        //        }
        //        private int dropConstraintCount = 0;
        //        private string GetSqlDropConstraintQuery(string tableName, string columnName)
        //        {
        //            tableName = GetNormalizedTableName(tableName);

        //            var str = $@"DECLARE @var{dropConstraintCount} nvarchar(128)
        //SELECT @var{dropConstraintCount} = name
        //FROM sys.default_constraints
        //WHERE parent_object_id = object_id(N'{tableSchema}.[{tablePureName}]')
        //AND col_name(parent_object_id, parent_column_id) = '{columnName}';
        //IF @var{dropConstraintCount} IS NOT NULL
        //    EXECUTE('ALTER TABLE {tableSchema}.[{tablePureName}] DROP CONSTRAINT [' + @var{dropConstraintCount} + ']')";

        //            dropConstraintCount = dropConstraintCount + 1;
        //            return str;
        //        }
        //        private string GetSqlDropColumnDescriptionQuery(string tableName, string columnName)
        //        {
        //            string owner = "dbo";
        //            tableName = GetNormalizedTableName(tableName);
        //            string strGetDesc = $@"Select [value] from fn_listextendedproperty('MS_Description','schema','dbo','table',N'{tableName}','column',null) where objname = N'{columnName}';";
        //            writer.WriteLine(
        //                $@"If Exists (Select [value] from fn_listextendedproperty('MS_Description','schema','{owner}','table',N'{tableName}','column',null) where objname = N'{columnName}') Alter Table {Name(migrationOperation.Table)}; Drop Constraint {Quote(migrationOperation.CheckConstraintName)}"
        //            );
        //            Statement(writer);

        //        }
        //        private string GetNormalizedTableName(string fullTableName)
        //        {
        //            Regex regex = new Regex(@"(\[\w+\]\.)?\[(?<table>.*)\]");
        //            Match match = regex.Match(fullTableName);
        //            string tableName;
        //            if (match.Success)
        //                tableName = match.Groups["table"].Value;
        //            else
        //                tableName = fullTableName;
        //            return tableName;
        //        }

        //        protected override void Generate(MigrationOperation migrationOperation)
        //        {
        //            if (migrationOperation is CreateCheckConstraintOperation)
        //            {
        //                Generate(migrationOperation as CreateCheckConstraintOperation);
        //            }
        //            else if (migrationOperation is DropCheckConstraintOperation)
        //            {
        //                Generate(migrationOperation as DropCheckConstraintOperation);
        //            }
        //            else
        //            {
        //                base.Generate(migrationOperation);
        //            }
        //        }
        //        protected virtual void Generate(CreateCheckConstraintOperation migrationOperation)
        //        {
        //            if (migrationOperation.CheckConstraintName == null)
        //            {
        //                migrationOperation.CheckConstraintName = migrationOperation.BuildDefaultName();
        //            }
        //            using (var writer = Writer())
        //            {
        //                writer.WriteLine(
        //                    $@"Alter Table {Name(migrationOperation.Table)} Add Constraint {Quote(migrationOperation.CheckConstraintName)} Check ({migrationOperation.CheckConstraint})"
        //                );
        //                Statement(writer);
        //            }
        //        }
        //        protected virtual void Generate(DropCheckConstraintOperation migrationOperation)
        //        {
        //            using (var writer = Writer())
        //            {
        //                writer.WriteLine(
        //                    $@"If Exists (Select name From sys.check_constraints Where name = N'{migrationOperation.CheckConstraintName.Replace("'", "''")}' And parent_object_id=object_id(N'{Name(migrationOperation.Table).Replace("'", "''")}', N'U')) Alter Table {Name(migrationOperation.Table)}; Drop Constraint {Quote(migrationOperation.CheckConstraintName)}"
        //                );
        //                Statement(writer);
        //            }
        //        }
        #endregion
    }
}
