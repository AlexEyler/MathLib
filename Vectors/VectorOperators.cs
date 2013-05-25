using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLib {

    /* Operator overloads for vector class */
    public partial class Vector {

        /* Array indexer */
        public double this[int i] {
            get { return this.GetValue(i); }
            set { this.SetValue(i, value); }
        }

        /* Operator for vector addition */
        public static Vector operator +(Vector v1, Vector v2) {
            return v1.AddVector(v2);
        }

        /* Operator for vector subtraction */
        public static Vector operator -(Vector v1, Vector v2) {
            return v1.SubVector(v2);
        }

        /* Operator for scalar multiplication */
        public static Vector operator *(Vector v1, double scalar) {
            return v1.MultiplyScalar(scalar);
        }

        /* Operator for scalar multiplication */
        public static Vector operator *(double scalar, Vector v1) {
            return v1.MultiplyScalar(scalar);
        }

        /* Operator for vector multiplication */
        public static double operator *(Vector v1, Vector v2) {
            return v1.MultiplyVector(v2);
        }

        /* Operator for vector/matrix multliplication */
        public static Vector operator *(Vector v1, Matrix m1) {
            return v1.MultiplyMatrix(m1);
        }

        /* Override == operator */
        public static bool operator ==(Vector v1, Vector v2) {
            return v1.Equals(v2);
        }

        /* Override != operator */
        public static bool operator !=(Vector v1, Vector v2) {
            return !v1.Equals(v2);
        }

    }
}
