using System;
using System.Text.Json;

namespace FrontendDASALUD.Helpers
{
    public static class JwtHelper
    {
        public static DateTime? GetExpiration(string token)
        {
            if (string.IsNullOrWhiteSpace(token)) return null;
            var parts = token.Split('.');
            if (parts.Length < 2) return null;
            var payload = parts[1];
            try
            {
                var jsonBytes = Base64UrlDecode(payload);
                var doc = JsonDocument.Parse(jsonBytes);
                if (doc.RootElement.TryGetProperty("exp", out var expProp))
                {
                    if (expProp.ValueKind == JsonValueKind.Number && expProp.TryGetInt64(out var seconds))
                    {
                        return DateTimeOffset.FromUnixTimeSeconds(seconds).UtcDateTime;
                    }
                    var s = expProp.GetString();
                    if (long.TryParse(s, out var seconds2))
                    {
                        return DateTimeOffset.FromUnixTimeSeconds(seconds2).UtcDateTime;
                    }
                }
            }
            catch
            {
            }
            return null;
        }

        private static byte[] Base64UrlDecode(string input)
        {
            string s = input.Replace('-', '+').Replace('_', '/');
            switch (s.Length % 4)
            {
                case 2: s += "=="; break;
                case 3: s += "="; break;
            }
            return Convert.FromBase64String(s);
        }
    }
}
