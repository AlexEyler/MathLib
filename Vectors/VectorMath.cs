using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLib {

    /* Math functions for Vector class */
    public partial class Vector {
        /* Add two vectors */
        public Vector AddVector(object right) {
            if (!checkValidType(right)) {
                throw new InvalidOperationException("Can only add vectors with other vectors");
            }

            Vector rightCast = (Vector)right;

            if (this.Size != rightCast.Size) {
                throw new DimensionMismatchException("Vectors must be same size");
            }

            Vector result = new Vector(this.Size);
            for (int i = 0; i < this.Size; i++) {
                result.SetValue(i, this.GetValue(i) + rightCast.GetValue(i));
            }
            return result;
        }

        /* Subtract two vectors */
        public Vector SubVector(object right) {
            if (!checkValidType(right)) {
                throw new InvalidOperationException("Can only subtract vectors with other vectors");
            }
            Vector rightCast = ((Vector)right).MultiplyScalar(-1);
            return this.AddVector(rightCast);
        }

        /* Vector * Scalar -> Vector */
        public Vector MultiplyScalar(object right) {
            double rightCast = 0.0;
            if (right.GetType() == typeof(int) ||
                right.GetType() == typeof(float)) {
                rightCast = Convert.ToDouble(right);
            } else if (right.GetType() == typeof(double)) {
                rightCast = (double)right;
            } else {
                throw new InvalidOperationException("Scalar must be a double or convertable to a double");
            }
            Vector result = new Vector(this.Size);

            for (int i = 0; i < result.Size; i++) {
                result.SetValue(i, this.GetValue(i) * rightCast);
            }
            return result;
        }

        /* Vector * Vector -> Scalar */
        public double MultiplyVector(object right) {
            if (!checkValidType(right)) {
                throw new InvalidOperationException("Can't call MultiplyVector with anything but a Vector");
            }
            Vector rightCast = (Vector)right;
            if (this.Size != rightCast.Size) {
                throw new DimensionMismatchException("The dimensions of the vectors must be equal");
            }

            double result = 0;
            for (int i = 0; i < this.Size; i++) {
                result += this.GetValue(i) * rightCast.GetValue(i);
            }
            return result;
        }

        /* Vector * Matrix -> Vector */
        public Vector MultiplyMatrix(object right) {
            if (right.GetType() != typeof(Matrix)) {
                throw new InvalidOperationException("Can't call MultiplyMatrix with anything but a Matrix");
            }
            Matrix rightCast = (Matrix)right;
            if (this.Size != rightCast.M) {
                throw new DimensionMismatchException("The dimension of the vector must"
                                     + " equal the M dimension of the matrix");
            }

            Vector result = new Vector(rightCast.N);
            for (int c = 0; c < rightCast.N; c++) {
                for (int i = 0; i < this.Size; i++) {
                    result.SetValue(c, result.GetValue(c) +
                        this.GetValue(i) * rightCast.GetValue(i, c));
                }
            }
            return result;
        }
    }
}
