using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nostrum
{
    public class Utils
    {
        public static int countDigits(long num)
        {
            int c = 1;
            while ((num /= 10) != 0)
                c++;
            return c;
        }
        public static string numToNdigitString(int num, int digit)
        {
            string numStr = "";
            while (digit - countDigits(num) > 0)
            {
                numStr += "0";
                digit--;
            }
            numStr += num;
            return numStr;
        }
        public static string numInWords(long num, int rec)
        {
            string words = "";
            string[] ones = new string[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
            string[] spl_tens = new string[] { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
            string[] tens = new string[] { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

            num = (num > 0) ? num : (-num);

            switch (countDigits(num))
            {
                case 1:
                    if ((num > 0) || (num == 0 && rec == 0))
                    {
                        words += ones[num];
                    }
                    break;
                case 2:
                    if (num < 20)
                        words += spl_tens[num % 10];
                    else
                    {
                        words += tens[num / 10] + " " + numInWords(num % 10, 1);
                    }
                    break;
                case 3:
                    words += numInWords(num / 100, 1) + " Hundred";
                    if ((num %= 100) != 0)
                    {
                        words += " and " + numInWords(num, 1);
                    }
                    break;
                case 4:
                case 5:
                    words += numInWords(num / 1000, 1) + " Thousand " + numInWords(num % 1000, 1);
                    break;
                case 6:
                case 7:
                    words += numInWords(num / 100000, 1) + " Lakh " + numInWords(num % 100000, 1);
                    break;
                case 8:
                case 9:
                    words += numInWords(num / 10000000, 1) + " Crore " + numInWords(num % 10000000, 1);
                    break;
                default:
                    break;
            }
            return words;
        }
    }
}
