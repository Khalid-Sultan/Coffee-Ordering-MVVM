using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Markup;

namespace Coffee_Ordering_with_MVVM.Enumeration
{
    public class EnumerationExtension : MarkupExtension
    {
        private Type _enumType;


        public EnumerationExtension(Type enumType)
        {
            if (enumType == null)
                throw new ArgumentNullException("enumType");

            EnumType = enumType;
        }

        public Type EnumType
        {
            get { return _enumType; }
            private set
            {
                if (_enumType == value)
                    return;

                var enumType = Nullable.GetUnderlyingType(value) ?? value;

                if (enumType.IsEnum == false)
                    throw new ArgumentException("Type must be an Enum.");

                _enumType = value;
            }
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var enumValues = Enum.GetValues(EnumType);

            return (
              from object enumValue in enumValues
              select new EnumerationMember
              {
                  Value = enumValue,
                  Description = GetDescription(enumValue)
              }).ToArray();
        }

        private string GetDescription(object enumValue)
        {
            var descriptionAttribute = EnumType
              .GetField(enumValue.ToString())
              .GetCustomAttributes(typeof(DescriptionAttribute), false)
              .FirstOrDefault() as DescriptionAttribute;


            return descriptionAttribute != null
              ? descriptionAttribute.Description
              : enumValue.ToString();
        }

        public class EnumerationMember
        {
            public string Description { get; set; }
            public object Value { get; set; }
        }
    }
    public enum CommonOrder
    {
        Latte = 0, Espresso = 1, Machiatto = 2, Custom = 3
    }
    public enum CondimentType
    {
        NONE = 0, SALT = 1, SUGAR = 2
    }
    public enum IceSelection
    {
        HOT = 0, ICED = 1
    }
    public enum BeanSelection
    {
        HARRAR = 5, YIRGACHEFE = 4, SIDAMO = 6, ARABICA = 8
    }
    public enum CreamSelection
    {
        NONE = 0, MILK = 2, WHIPPED = 4, DOUBLE = 3, HALFANDHALF = 5, HEAVY = 6
    }
    public enum SizeSelection
    {
        SMALL = 10, MEDIUM = 15, LARGE = 20
    }
}
