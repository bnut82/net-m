

namespace MacrixPoc.User.Application.Builder;

public class AgeBuilder : IAgeBuilder
{
    public int Calculate(DateTime? date)
    {
        if (!date.HasValue)
        {
            return 0;
        }
        
        return DateTime.Today.Year - date!.Value.Year;
    }
}