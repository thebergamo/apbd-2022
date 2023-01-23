using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace ClientsTripAPI.Validations;

[AttributeUsage((AttributeTargets.Property | AttributeTargets.Field))]
sealed public class CustomDateAttribute : ValidationAttribute
{
    private readonly string _format;

    public string Format
    {
        get { return _format; }
    }

    public CustomDateAttribute(string format)
    {
        _format = format;
    }

    public override bool IsValid(object value)
    {
        var date = (String)value;

        DateTime newDate;
        
        return DateTime.TryParseExact(date, Format, null, DateTimeStyles.None, out newDate);
    }

    public override string FormatErrorMessage(string name)
    {
        return String.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, Format);
    }
}