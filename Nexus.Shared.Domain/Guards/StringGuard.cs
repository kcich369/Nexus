using Nexus.Shared.Domain.Guards.Base;

namespace Nexus.Shared.Domain.Guards;

public sealed class StringGuard : Guard
{
    private readonly string _value;

    private StringGuard(string value, string errorPrefix = null) : base(errorPrefix)
    {
        _value = value;
    }

    public static StringGuard Create(string value, string errorPrefix = null) => new(value, errorPrefix);

    public StringGuard HasMaxValue(int length)
    {
        if (_value.Length > length)
            AddError($"MAX_LENGTH_IS: {length}");
        return this;
    }

    public StringGuard NotNullAndEmpty()
    {
        if (string.IsNullOrEmpty(_value))
            AddError($"VALUE_IS_NULL_OR_EMPTY");
        return this;
    }

    public StringGuard IsEmail()
    {
        return this;
    }

    public StringGuard IsPhoneNumber()
    {
        if (_value.Length != 9)
            AddError($"IT_IS_NOT_PHONE_NUMBER_VALUE");
        if (_value.Select(char.IsNumber).Any(x => !x))
            AddError($"IT_IS_NOT_PHONE_NUMBER_VALUE");
        return this;
    }

    public StringGuard IsPhonePrefix(string prefix)
    {
        if (prefix.Length != 3)
            AddError($"IT_IS_NOT_PHONE_PREFIX_VALUE");
        if (_value.Skip(1).Select(char.IsNumber).Any(x => !x))
            AddError($"IT_IS_NOT_PHONE_PREFIX_VALUE");
        if (_value[0] != '+')
            AddError($"IT_IS_NOT_PHONE_PREFIX_VALUE");
        return this;
    }
}