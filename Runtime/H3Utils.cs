using System;
using System.Globalization;
using UnityEngine.Scripting;

namespace H3Unity
{
    [Preserve]
    public static class H3Utils
    {
        // ---- Angle Conversion ----

        public static double DegsToRads(double degrees) => degrees * (Math.PI / 180.0);

        public static double RadsToDegs(double radians) => radians * (180.0 / Math.PI);

        // ---- Hex Index Conversion ----

        public static string H3ToString(ulong index) => index.ToString("X");

        public static ulong StringToH3(string hex)
        {
            try
            {
                return ulong.Parse(hex, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                throw new H3Exception($"Failed to parse H3 index from string: '{hex}'", ex);
            }
        }

        public static bool TryParseH3(string hex, out ulong result)
        {
            return ulong.TryParse(hex, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out result);
        }

        // ---- Bitmask Decoding ----

        public static int GetResolution(ulong h3) => (int)((h3 >> 52) & 0x0F);

        public static int GetBaseCellNumber(ulong h3) => (int)((h3 >> 45) & 0x7F);
    }
}
