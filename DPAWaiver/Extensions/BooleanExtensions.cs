public static class BooleanExtensions
{
    public static string ToYesNoString(this bool? value)
    {
        return value == null ? "No" : (value == true ? "Yes": "No");
    }
}