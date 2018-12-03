using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECX.CD.BL.IF
{
    public class ResponseAuthorizationException : Exception
    {

        public ResponseAuthorizationException(string message)
            : base(message)
        {
            //this = new Exception(message);
            //this.Message = message + '\n' + this.Message;
        }
    }
}
