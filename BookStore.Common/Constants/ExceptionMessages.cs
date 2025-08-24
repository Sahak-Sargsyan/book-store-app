using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Common.Constants
{
    public static class AuthExceptionMessages
    {
        public static string USERNOTFOUND { get; } = "User doesn't exist.";
        public static string INCORRECTCREDENTIALS { get; } = "Incorrect username or password.";
    }
}
