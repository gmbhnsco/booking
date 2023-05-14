using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framework.Application
{
    public class ApplicationMessages
    {
        public const string DouplicatedRecord = "It is not possible to register a duplicate record, please try again";
        public const string RecordNotFound = "The record with the requested information was not found, please try again";
        public const string PasswordNotMatch = "The password and its repetition do not match";
        public const string WrongUserPasss = "The username or password is incorrect";
    }
}
