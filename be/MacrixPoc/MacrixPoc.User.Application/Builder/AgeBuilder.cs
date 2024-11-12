

namespace MacrixPoc.User.Application.Builder;

public class AgeBuilder : IAgeBuilder
{
    public int Calculate(DateTime? date)
    {
        if (!date.HasValue)
        {
            return 0;
        }
        
        return date!.Value.Year - DateTime.Today.Year;
    }

    public DateTime? TransformToDate(int? age)
    {
        if (age == null)
        {
            return null;
        }
        return DateTime.Today.AddYears(age.Value);
    }
}