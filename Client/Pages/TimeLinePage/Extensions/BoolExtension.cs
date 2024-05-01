namespace Client.Pages.TimeLinePage.Extensions
{
    /// <summary>
    /// Расширения для bool
    /// </summary>
    public static class BoolExtension
    {
        public static string ToDefaultStringFormat(this bool value) => value ? "Да" : "Нет";
    }
}
