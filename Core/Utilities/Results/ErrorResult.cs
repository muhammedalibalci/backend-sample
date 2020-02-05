using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorResult:Result
    {
        public ErrorResult(string Message) : base(Message, false)
        {
        }
        public ErrorResult() : base(false)
        {
        }
    }
}
