using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsServices.StringServices
{
    public static class clsDividingWord
    {

        public static string Divide(string Value,string DivideBy,Predicate<char> Predicate)
        {
            if (Predicate == null || string.IsNullOrEmpty(DivideBy)) return Value;

            StringBuilder sb = new StringBuilder();

            if(!string.IsNullOrWhiteSpace(Value) && Value.Length > 0)
            {

                sb.Append(Value[0]);

                Value = Value.Substring(1);

            }

            foreach(char c in  Value)
            {

                if (Predicate(c))
                {
                    sb.Append(DivideBy);
                }

                sb.Append(c);

            }


            return sb.ToString();

        }

    }
}
