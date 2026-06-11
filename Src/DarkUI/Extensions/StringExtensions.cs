using System.Globalization;
using System.Linq;
using System.Text;

namespace DarkUI.Extensions
{
    public static class StringExtensions
    {
        public static string RemoveDiacritics(this string str)
        {
            return string.Concat(str
                    .Normalize(NormalizationForm.FormD)
                    .Where(ch => CharUnicodeInfo.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark))
                .Normalize(NormalizationForm.FormC);
        }
    }
}
