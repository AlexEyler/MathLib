using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLib {

    /* Math functions for Matrix */
    public partial class Matrix {

        /* Add two matrices together */
        public Matrix AddMatrix(object right) {
            // Check to see if object is a Matrix or if it is a subclass of Matrix
            if (!checkValidType(right)) {
                throw new InvalidOperationException("Can only add matrices with other matrices");
            }
            Matrix rightCast = (Matrix)right;

            if (this.m != rightCast.M || this.n != rightCast.N) {
                throw new DimensionMismatchException("The dimensions of the matrices do not match.");
            }
            Matrix result = new Matrix(this.m, this.n);
            for (int r = 0; r < this.m; r++) {
                for (int c = 0; c < this.n; c++) {
                    result.SetValue(r, c, this.GetValue(r, c) + rightCast.GetValue(r, c));
                }
            }
            return result;
        }

        /* Subtract a matrix from current matrix */
        public Matrix SubMatrix(object right) {
            if (!checkValidType(right)) {
                throw new InvalidOperationException("Can only subtract matrices with other matrices");
            }
            Matrix rightCast = ((Matrix)right).MultiplyScalar(-1.0);
            return this.AddMatrix(rightCast);
        }

        /* Matrix * Scalar -> Matrix */
        public Matrix MultiplyScalar(object right) {
            double rightCast = 0.0;
            if (right.GetType() == typeof(int) ||
                right.GetType() == typeof(float)) {
                rightCast = Convert.ToDouble(right);
            } else if (right.GetType() == typeof(double)) {
                rightCast = (double)right;
            } else {
                throw new InvalidOperationException("Scalar must be a double");
            }


            Matrix result = new Matrix(this.m, this.n);

            for (int r = 0; r < this.m; r++) {
                for (int c = 0; c < this.n; c++) {
                    result.SetValue(r, c, rightCast * this.GetValue(r, c));
                }
            }

            return result;
        }

        /* Matrix * Vector -> Vector */
        public Vector MultiplyVector(object right) {
            if (right.GetType() != typeof(Vector)) {
                throw new InvalidOperationException("Can't call MultiplyVector with anything but a Vector");
            }
            Vector rightCast = (Vector)right;

            if (this.N != rightCast.Size) {
                throw new DimensionMismatchException("The N dimension of the matrix must equal the size of the vector");
            }

            Vector result = new Vector(this.m);
            for (int r = 0; r < this.m; r++) {
                for (int i = 0; i < this.n; i++) {
                    result.SetValue(r, result.GetValue(r) +
                        rightCast.GetValue(i) * this.GetValue(r, i));
                }
            }
            return result;
        }

        /* Matrix * Matrix -> Matrix */
        public Matrix MultiplyMatrix(object right) {

            if (!checkValidType(right)) {
                throw new InvalidOperationException("Can't call MultiplyMatrix with anything but a Matrix");
            }

            Matrix rightCast = (Matrix)right;

            if (this.n != rightCast.M) {
                throw new DimensionMismatchException("The dimensions of the matrices do not match. " +
                    "Matrix 1 must be mxn while Matrix 2 must be nxm");
            }

            Matrix result = new Matrix(this.m, rightCast.N);

            int resultR = 0, resultC = 0;
            for (int r = 0; r < this.m; r++) {
                int rightRow = 0;
                for (int rightCol = 0; rightCol < rightCast.N; rightCol++) {
                    for (int c = 0; c < this.n; c++) {
                        double prod = this.GetValue(r, c) * rightCast.GetValue(rightRow, rightCol);
                        result.SetValue(resultR, resultC, result.GetValue(resultR, resultC) + prod);
                        rightRow++;
                    }
                    rightRow = 0;
                    resultC++;
                }
                resultC = 0;
                resultR++;
            }

            return result;
        }
    }
}
