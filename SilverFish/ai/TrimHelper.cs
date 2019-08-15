namespace HREngine.Bots
{
    public class TrimHelper
    {
        public static string TrimEnglishName(string temp)
        {
            if (temp == null)
            {
                return null;
            }
            temp = temp.Replace("&lt;", "");
            temp = temp.Replace("b&gt;", "");
            temp = temp.Replace("/b&gt;", "");
            temp = temp.ToLower(new System.Globalization.CultureInfo("en-US", false));
            temp = temp.Replace("'", "");
            temp = temp.Replace(" ", "");
            temp = temp.Replace(":", "");
            temp = temp.Replace(".", "");
            temp = temp.Replace("!", "");
            temp = temp.Replace("?", "");
            temp = temp.Replace("-", "");
            temp = temp.Replace("_", "");
            temp = temp.Replace(",", "");
            temp = temp.Replace("(", "");
            temp = temp.Replace(")", "");
            temp = temp.Replace("/", "");
            temp = temp.Replace("\"", "");
            temp = temp.Replace("+", "");
            temp = temp.Replace("’", "");
            temp = temp.Replace("=", "");
            return temp;
        }
    }
}
