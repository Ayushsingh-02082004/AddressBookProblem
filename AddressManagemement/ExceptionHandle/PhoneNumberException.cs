using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressManagemement.ExceptionHandle
{
    public class PhoneNumberException: Exception
    {
        public PhoneNumberException(string msg):base(msg) { }
    }
}
