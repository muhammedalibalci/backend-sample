using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {

        public Result(string Message,bool Success):this(Success)
        {
            this.Message = Message;            
        }

        public Result(bool Success)
        {
            this.Success = Success;
        }

        public string Message { get ; set ; }
        public bool Success { get; set ; }
    }
}
