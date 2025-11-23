using System.Text;

namespace FrontendDASALUD.Helpers
{
    public static class QueryHelper
    {
        public static string ToQueryString(IDictionary<string, object?> parameters)
        {
            if (parameters == null || parameters.Count == 0) return string.Empty;
            var sb = new StringBuilder();
            var first = true;
            foreach (var kv in parameters)
            {
                if (kv.Value is null) continue;
                var key = Uri.EscapeDataString(kv.Key);
                var value = Uri.EscapeDataString(kv.Value.ToString()!);
                if (first) { sb.Append('?'); first = false; }
                else sb.Append('&');
                sb.Append(key).Append('=').Append(value);
            }
            return sb.ToString();
        }
    }
}
