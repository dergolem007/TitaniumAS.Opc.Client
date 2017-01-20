using System;
using System.Runtime.InteropServices.ComTypes;

namespace TitaniumAS.Opc.Client.Interop.Helpers
{
    internal static class FileTimeConverter
    {
        public static DateTimeOffset FromFileTime(FILETIME fileTime)
        {
            try
            {
                var lft = (((long)fileTime.dwHighDateTime) << 32) + fileTime.dwLowDateTime;
                return DateTimeOffset.FromFileTime(lft);
            }
            catch (Exception ex)
            {
                return DateTimeOffset.Now;
            }
        }

        public static FILETIME ToFileTime(DateTimeOffset fileTime)
        {
            var lft = fileTime.ToFileTime();
            FILETIME ft;
            ft.dwLowDateTime = (int) (lft & 0xFFFFFFFF);
            ft.dwHighDateTime = (int) (lft >> 32);
            return ft;
        }
    }
}
