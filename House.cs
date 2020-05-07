using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stoiko2
{
    class House
    {
        private string address;
        private string shortDescription;
        private int number;
        private int age;
        private double square;

        public string Address
        {
            set
            {
                Validation.ValidationString(value);
                Validation.ValidationAddress(value);

                address = value;
            }
            get => address;
        }

        public string ShortDescription
        {
            set
            {
                Validation.ValidationString(value);

                shortDescription = value;
            }
            get => shortDescription;
        }

        public int Number
        {
            set
            {
                Validation.ValidationNumber(value);

                number = value;
            }
            get => number;
        }

        public int Age
        {
            set
            {
                Validation.ValidationAge(value);

                age = value;
            }
            get => age;
        }

        public double Square
        {
            set
            {
                Validation.ValidationSquare(value);

                square = value;
            }
            get => square;
        }

        public House()
        { 
        
        }

        public House(string str)
        {
            House a = House.Parse(str);
            Address = a.Address;
            Number = a.Number;
            Age = a.Age;
            Square = a.Square;
            ShortDescription = a.ShortDescription;
        }

        public House(string addres = "Unknown", int n = 1, int a = 0, double sqr = 10.0, string sdn = "short description1")
        {
            Address = address;
            Number = n;
            Age = a;
            ShortDescription = sdn;
            Square = sqr;
        }

        public House(House another)
        {
            Address = another.Address;
            Number = another.Number;
            Square = another.Square;
            Age = another.Age;
            ShortDescription = another.ShortDescription;
        }

        public override string ToString()
        {
            string result = "";
            result += Address + "\t";
            result += Number + "\t";
            result += Age + "\t";
            result += Square + "\t";
            result += ShortDescription + "\t";

            return result;
        }


        public static House Parse(string repr)
        {
            repr = Validation.ValidationToParse(repr.Replace('\t', ' '));
            string[] repr_div = repr.Split();

            House h = new House();

            h.Address = repr_div[0];
            h.Number = Int32.Parse(repr_div[1]);
            h.Age = Int32.Parse(repr_div[2]);
            h.Square = Double.Parse(repr_div[3]);
            h.ShortDescription = repr_div[4];

            return h;

        }
    }
}
