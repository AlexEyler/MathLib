using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLib {
    public class DimensionMismatchException : System.ApplicationException {
       
        /* Each constructor just calls the ApplicationException constructor */
        public DimensionMismatchException() : base() { }

        /* Each constructor just calls the ApplicationException constructor */
        public DimensionMismatchException(string message) : base(message) { }

        /* Each constructor just calls the ApplicationException constructor */
        public DimensionMismatchException(string message, System.Exception inner) : base(message, inner) { }
    }
}
