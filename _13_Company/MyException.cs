using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_Company
{
    internal class BirthDayException : Exception
    {
        public BirthDayException(string message) : base(string.Format("Invalid date: " + message)) { }
    }
    internal class PhoneException : Exception
    {
        public PhoneException(string message) : base(string.Format("Invalid phone number: " + message)) { }
    }
    internal class EmailException : Exception
    {
        public EmailException(string message) : base(string.Format("Invalid email: " + message)) { }
    }
    internal class FullNameException : Exception
    {
        public FullNameException(string message) : base(string.Format("Invalid full name: " + message)) { }
    }
}
