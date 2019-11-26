using System;

namespace Softplan.Financial.Commom.Types
{
    public class SoftException : Exception
    {
        public string Code { get; }
        public string MessageError { get; }

        public SoftException(string code, string message)
        {
            Code = code;
            MessageError = message;
        }
    }
}
