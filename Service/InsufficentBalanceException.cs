using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcoountAppClassLibrary.Service
{
    internal class InsufficentBalanceException : Exception
    {
        public InsufficentBalanceException(string message) : base(message) { }
    }
}
