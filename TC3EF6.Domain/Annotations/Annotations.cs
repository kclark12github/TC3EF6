using System;

namespace TC3EF6.Domain.Annotations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ColumnDescriptionAttribute : Attribute
    {
        public ColumnDescriptionAttribute(string description)
        {
            this.Value = description;
        }
        public string Value { get; }
    }
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class SqlDefaultValueAttribute : Attribute
    {
        public string DefaultValue { get; set; }
    }
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class TableDescriptionAttribute : Attribute
    {
        public TableDescriptionAttribute(string description)
        {
            this.Value = description;
        }
        public string Value { get; }
    }
}
