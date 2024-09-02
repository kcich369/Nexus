using Nexus.Shared.Domain.Guards.Base;

namespace Nexus.Shared.Domain.Guards;

public sealed class DateTimeGuard : Guard
{
    private readonly DateTime _value;

    private DateTimeGuard(DateTime value, string prefix) : base(prefix)
    {
        _value = value;
    }

    public static DateTimeGuard Create(DateTime value, string errorPrefix = null) => new(value, errorPrefix);


    public DateTimeGuard HasCurrentDate()
    {
        var currentDate = DateOnly.FromDateTime(DateTime.UtcNow);
        var valueDate = DateOnly.FromDateTime(_value);
        if (currentDate.CompareTo(valueDate) == 0)
            AddError("IT_IS_NOT_CURRENT_DATE");
        return this;
    }

    public DateTimeGuard Before(DateTime value)
    {
        if (_value < value)
            AddError("DATE_SHOULD_BEFORE");
        return this;
    }
    
    public DateTimeGuard MaxDiffInHours(DateTime value, int hours)
    {
        if ((_value - value).Hours > hours)
            AddError($"DIFFERENCE_BETWEEN_DATES_SHOULD_{hours}_HOURS");
        return this;
    }
}