using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Common.Exceptions
{
    public class AuthException : Exception
    {
        public AuthException()
        {
        }

        public AuthException(string message)
            : base(message)
        {
        }

        public AuthException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
