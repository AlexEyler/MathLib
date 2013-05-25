using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLib {

    /* Operator overloads for Matrix class */
    public partial class Matrix {
        
        /* Array indexer */
        public double[] this[int i] {
            get { return this.matrix[i]; }
            set {
                for (int x = 0; x < value.Length; x++) {
                    this.SetValue(i, x, value[x]);
                }
            }
        }

        /* Operator for addition */
        public static Matrix operator +(Matrix m1, Matrix m2) {
            return m1.AddMatrix(m2);
        }

        /* Operator for subtraction */
        public static Matrix operator -(Matrix m1, Matrix m2) {
            return m1.SubMatrix(m2);
        }

        /* Operator for matrix multiplication */
        public static Matrix operator *(Matrix m1, Matrix m2) {
            return m1.MultiplyMatrix(m2);
        }

        /* Operator for scalar multiplication */
        public static Matrix operator *(Matrix m1, double scalar) {
            return m1.MultiplyScalar(scalar);
        }

        /* Operator for matrix/vector multiplication*/
        public static Vector operator *(Matrix m1, Vector v1) {
            return m1.MultiplyVector(v1);
        }

        /* Operator for scalar multiplication */
        public static Matrix operator *(double scalar, Matrix m1) {
            return m1.MultiplyScalar(scalar);
        }

        /* Override == operator */
        public static bool operator ==(Matrix m1, Matrix m2) {
            return m1.Equals(m2);
        }

        /* Override != operator */
        public static bool operator !=(Matrix m1, Matrix m2) {
            return !m1.Equals(m2);
        }
    }
}
