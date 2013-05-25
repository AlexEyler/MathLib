using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLib {

    /* An 1xn vector class */
    public partial class Vector {

        /* A vector just has a size */
        private int size;

        /* An array for the vector */
        private double[] vector;

        /* Size of the vector */
        public int Size {
            get { return this.size; }
        }

        /* Vector class constructor */
        public Vector(int size) {
            this.size = size;
            initialize_vector(size);
        }

        /* Initialize a vector given the size */
        private void initialize_vector(int size) {
            this.vector = new double[size];
        }
        /* SetValue of an index in the vector */
        public void SetValue(int index, double value) {
            if (index < size && index >= 0) {
                vector[index] = value;
            } else {
                throw new InvalidIndexException("Invalid index: " + index);
            }
        }

        /* GetValue of an index of a vector */
        public double GetValue(int index) {
            if (index < size && index >= 0) {
                return vector[index];
            }
            throw new InvalidIndexException("Invalid index: " + index);
        }

        /* Override Object.Equals function */
        public override bool Equals(object other) {
            if (!checkValidType(other)) {
                return false;
            }

            Vector otherCast = (Vector)other;
            if (otherCast.Size != this.Size) {
                return false;
            }
            for (int i = 0; i < this.Size; i++) {
                if (!(this.GetValue(i) + .00001 >= otherCast.GetValue(i) &&
                    this.GetValue(i) - .00001 <= otherCast.GetValue(i))) {
                    return false;
                }
            }
            return true;
        }
        
        /* Needed to be overrode when == and != operators were overloaded */
        public override int GetHashCode() {
            return base.GetHashCode();
        }

        /* String representation */
        public override string ToString() {
            string returnString = "{";

            for (int i = 0; i < this.size; i++) {
                returnString += " " + this.GetValue(i);
                if (i != this.size - 1) {
                    returnString += ", ";
                } else {
                    returnString += " ";
                }
            }

            return returnString + "}";
        }

        /* Check to see if an Object is a Vector */
        private bool checkValidType(Object o) {
            return o.GetType() == typeof(Vector);
        }

    }
}
