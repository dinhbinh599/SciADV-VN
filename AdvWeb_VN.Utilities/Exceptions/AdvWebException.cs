using System;

namespace AdvWeb_VN.Utilities.Exceptions
{

	public class AdvWebException : Exception
	{
        public AdvWebException()
        {
        }

        public AdvWebException(string message)
            : base(message)
        {
        }

        public AdvWebException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

}