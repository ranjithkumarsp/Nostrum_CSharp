using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace NostrumWPFUI.Helpers
{
    public static class NostrumHelper
    {
        public static string UppercaseFirst(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }        
    }
    
}
