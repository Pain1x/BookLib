using System;
using System.Collections.Generic;
using System.Text;

namespace BookLib.BL.Infrastructure
{
    /// <summary>
    /// Exception class to store the exception message and pass through layers
    /// </summary>
    public class ValidationException:Exception
    {
        public string Property { get; protected set; }
        public ValidationException(string message, string prop) : base(message)
        {
            Property = prop;
        }
    }
}
