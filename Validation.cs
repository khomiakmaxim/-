using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;

namespace Stoiko2
{
    class Validation
    {
        public static Regex stringToParse { get; private set; } = new Regex(".+[ ].+[ ].+[ ].+[ ].+");


        public static void ValidationString(string str)
        {
            if (str.Length < 3 || str.Length > 20)
            {
                throw new ArgumentException(@"{str} string should have lenght in range [3;20]");
            }
        }

        public static void ValidationAddress(string addr)
        { 
            for (int i = 1; i < addr.Length; ++i)
            {
                if (addr[i - 1] == ' ' && char.IsLower(addr[i]))
                {
                    throw new ArgumentException(@"{addr} first letters should be in upper case");
                }
            }

            for (int i = 1; i < addr.Length; ++i)
            {
                if (addr[i - 1] != ' ' && char.IsUpper(addr[i]))
                {
                    throw new ArgumentException(@"{addr} not first letters should be in lower case");
                }
            }
        }

        public static void ValidationNumber(int numb)
        {
            if (numb < 1 || numb > 1000)
            {
                throw new ArgumentException(@"{numb} should be in range [1;1000]");
            }
        }

        public static void ValidationAge(int age)
        {
            if (age < 0 || age > 1000)
            {
                throw new ArgumentException(@"{age} should be in range [0;1000]");
            }
        }

        public static void ValidationSquare(double square)
        {
            if (square < 10.0 || square > 1000.0)
            {
                throw new ArgumentException(@"{square} should be in range [10.0;1000.0]");
            }
        }

        public static string ValidationFile(string fileName)
        {
            if (!File.Exists(@"C:\Users\Максим\source\repos\Stoiko2\" + fileName))
            {
                throw new Exception();
            }

            return fileName;
        }

        public static string ValidationToParse(string strToParse)
        {
            if (!stringToParse.IsMatch(strToParse))
            {
                Console.Beep();
                Console.WriteLine("Inappropriate form!(name age gender height email)");
                throw new Exception();
            }

            return strToParse;
        }
    }
}
