using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressManagemement.ExceptionHandle
{
    internal class EmailException : Exception
    {
        public EmailException(String msg):base(msg) { }
    }
}
