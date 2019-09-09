using System.Globalization;

namespace SilverFish.Helpers
{
    public static class TrimHelper
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

        public static string TrimCardName(this string s, CultureInfo cultureInfo)
        {
            if (s == null)
            {
                return null;
            }

            var temp = s;
            temp = temp.Replace("&lt;", "");
            temp = temp.Replace("b&gt;", "");
            temp = temp.Replace("/b&gt;", "");
            temp = temp.ToLower(cultureInfo);
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
            return temp;
        }
    }
}
