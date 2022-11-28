using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitWise.BusinessLogic.CustomExceptions
{
    public class ArgumentIsNotUniqueException : Exception
    {
        public ArgumentIsNotUniqueException() : base()
        {
        }

        public ArgumentIsNotUniqueException(string message)
            : base(message)
        {
        }

        public ArgumentIsNotUniqueException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
