using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Abstract
{
    public class DomainException : Exception
    {
        public DomainException() : base()
        {
        }

        public DomainException(string message) : base(message)
        {
        }
    }
}
