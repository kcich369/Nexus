using Nexus.Shared.Domain.Guards.Base;

namespace Nexus.Shared.Domain.Guards;

public sealed class DateTimeGuard : Guard<DateTime>
{
    private DateTimeGuard(DateTime value, string prefix) : base(value, prefix)
    {
    }

    public static DateTimeGuard Create(DateTime value, string errorPrefix = null) => new(value, errorPrefix);


    public DateTimeGuard HasCurrentDate()
    {
        var currentDate = DateOnly.FromDateTime(DateTime.UtcNow);
        var valueDate = DateOnly.FromDateTime(Value);
        if (currentDate.CompareTo(valueDate) == 0)
            AddError("IT_IS_NOT_CURRENT_DATE");
        return this;
    }

    public DateTimeGuard Before(DateTime value)
    {
        if (Value < value)
            AddError("DATE_SHOULD_BEFORE");
        return this;
    }
    
    public DateTimeGuard MaxDiffInHours(DateTime value, int hours)
    {
        if ((Value - value).Hours > hours)
            AddError($"DIFFERENCE_BETWEEN_DATES_SHOULD_{hours}_HOURS");
        return this;
    }
}