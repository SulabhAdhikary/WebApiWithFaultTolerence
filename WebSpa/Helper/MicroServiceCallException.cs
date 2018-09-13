using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSpa.Helper
{
    public class MicroServiceCallException: Exception
    {
        public MicroServiceCallException()
        {

        }

        public MicroServiceCallException(string message)
            : base(message)
        {
        }

        public MicroServiceCallException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
