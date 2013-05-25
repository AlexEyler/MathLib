using System;

namespace MathLib {
    /* InvalidIndexException class */
    public class InvalidIndexException : System.ApplicationException {
        /* Each constructor just calls the ApplicationException constructor */
        public InvalidIndexException() : base() { }

        /* Each constructor just calls the ApplicationException constructor */
        public InvalidIndexException(string message) : base(message) { }

        /* Each constructor just calls the ApplicationException constructor */
        public InvalidIndexException(string message, System.Exception inner) : base(message, inner) { }
    }
}
