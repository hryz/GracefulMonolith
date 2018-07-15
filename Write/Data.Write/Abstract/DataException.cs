using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Write.Abstract
{
    public class DataException : Exception
    {
        public DataException()
        {
        }

        public DataException(string message) : base(message)
        {
        }
    }
}
