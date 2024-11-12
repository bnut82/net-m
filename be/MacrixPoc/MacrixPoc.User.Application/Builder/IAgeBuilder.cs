namespace MacrixPoc.User.Application.Builder;

public interface IAgeBuilder
{
    public int Calculate(DateTime? date);
    public DateTime? TransformToDate(int? age);
}