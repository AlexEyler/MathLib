using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLib {
    public partial class Matrix {

        /* Determine if a matrix is diagonal */
        public bool IsDiagonal() {
            for (int r = 0; r < this.M; r++) {
                for (int c = 0; c < this.N; c++) {
                    if (r != c) {
                        if (!(this[r][c] - .0000001 < 0.0 &&
                            this[r][c] + .0000001 > 0.0)) {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        /* Determine if a matrix is an identity matrix */
        public bool IsIdentity() {
            for (int r = 0; r < this.M; r++) {
                for (int c = 0; c < this.N; c++) {
                    if (r != c) {
                        if (!(this[r][c] - .0000001 < 0.0 &&
                            this[r][c] + .0000001 > 0.0)) {
                            return false;
                        }
                    } else {
                        if (!(this[r][c] - .0000001 < 1.0 &&
                            this[r][c] + .0000001 > 1.0)) {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        /* Determine if a matrix is square */
        public bool IsSquare() {
            return this.M == this.N;
        }

        /* Determine if matrix is upper triangular */
        public bool IsUpperTriangular() {
            if (!this.IsSquare())
                throw new DimensionMismatchException("Matrix must be square");

            for (int r = 0; r < this.M; r++) {
                for (int c = 0; c < this.N; c++) {
                    if (c < r) {
                        if (!(this[r][c] - .0000001 < 0.0 &&
                            this[r][c] + .0000001 > 0.0)) {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        /* Determine if matrix is lower triangular */
        public bool IsLowerTriangular() {
            if (!this.IsSquare())
                throw new DimensionMismatchException("Matrix must be square");

            for (int r = 0; r < this.M; r++) {
                for (int c = 0; c < this.N; c++) {
                    if (c > r) {
                        if (!(this[r][c] - .0000001 < 0.0 &&
                            this[r][c] + .0000001 > 0.0)) {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        /* Determine if matrix is triangular */
        public bool IsTriangular() {
            return IsLowerTriangular() || IsUpperTriangular();
        }
        
        /* Find the trace of a matrix */
        public double Trace() {
            if (!this.IsSquare())
                throw new DimensionMismatchException("Matrix must be square");

            double trace = 0.0;
            for (int r = 0; r < this.M; r++) {
                for (int c = 0; c < this.N; c++) {
                    trace += this[r][c];
                }
            }
            return trace;
        }

        /* Short-hand for determinant function */
        public double Det() {
            return this.Determinant();
        }

        /* Determinant function */
        public double Determinant() {
            if (!this.IsSquare())
                throw new DimensionMismatchException("Matrix must be square");

            return determinantHelper(this);
        }

        /* Helper method for determinant function */
        private double determinantHelper(Matrix m) {
            if (m.M == 1)
                return m[0][0];
            else if (m.M == 2)
                return (m[0][0] * m[1][1]) - (m[1][0] * m[0][1]);

            // use first col to recursively call determinant helper
            double det = 0.0;
            for (int r = 0; r < m.M; r++) {
                Matrix temp = new Matrix(m.M - 1, m.N - 1);
                int tR = 0, tC = 0;
                for (int r2 = 0; r2 < m.M; r2++) {
                    if (r != r2) {
                        for (int c = 1; c < m.N; c++, tC++) {
                            temp[tR][tC] = m[r2][c];
                        }
                        tR++;
                        tC = 0;
                    }
                }
                if (r % 2 == 0) {
                    det += m[r][0] * determinantHelper(temp);
                } else {
                    det += -m[r][0] * determinantHelper(temp);
                }
            }

            return det;
        }

        /* Transpose a matrix */
        public void Transpose() {
            Matrix m = new Matrix(this.m, this.n);
            m.matrix = this.matrix;

            // swap m and n
            int temp = this.m;
            this.m = this.n;
            this.n = temp;
            initialize_matrix(this.m, this.n);

            // get values from temp matrix
            for (int r = 0; r < this.m; r++) {
                for (int c = 0; c < this.n; c++) {
                    this[r][c] = m[c][r];
                }
            }
        }

        /* Get Tranposition of Matrix */
        public Matrix GetTranspose() {
            Matrix tm;
            this.Copy(out tm);
            tm.Transpose();
            return tm;
        }

        /* Perform Gaussian Elimination on a matrix */
        public void GaussElim() {
            for (int k = 0; k < this.M; k++) {
                int i_max = -1;
                double max = 0.0;
                for (int i = k; i < this.M; i++) {
                    if (Math.Abs(this[i][k]) >= max) {
                        i_max = i;
                        max = Math.Abs(this[i][k]);
                    }
                }
                RowSwap(k, i_max);
                for (int i = k + 1; i < this.M; i++) {
                    for (int j = k + 1; j < this.N; j++) {
                        this[i][j] -= this[k][j] * (this[i][k] / this[k][k]);
                    }
                    this[i][k] = 0;
                }
            }

            for (int i = 0; i < this.M; i++) {
                double scale = 0.0;
                int j_start = 0;
                for (int j = 0; j < this.N; j++) {
                    if (this[i][j] != 0.0) {
                        scale = this[i][j];
                        j_start = j;
                        break;
                    }
                }
                if (scale != 0.0) {
                    for (int j = j_start; j < this.N; j++) {
                        this[i][j] /= scale;
                    }
                }

            }
        }

        /* Get the REF of the matrix */
        public Matrix GetREF() {
            Matrix newMatrix;
            this.Copy(out newMatrix);
            newMatrix.GaussElim();
            return newMatrix;
        }

        /* Perform GaussJordan Elimination */
        public void GaussJordan() {
            this.GaussElim();
            for (int r = 1; r < this.M; r++) {
                for (int c = r; c < this.N; c++) {
                    if (this[r][c] == 1.0) {
                        double scale = this[r - 1][c];
                        if (this[r - 1][c] != 0.0) {
                            for (int k = c; k < this.N; k++) {
                                this[r - 1][k] -= this[r][k] * scale;
                            }
                        }
                        break;
                    }
                }
            }
        }

        /* Get the RREF of the matrix */
        public Matrix GetRREF() {
            Matrix newMatrix;
            this.Copy(out newMatrix);
            newMatrix.GaussJordan();
            return newMatrix;
        }

        /* Swap two rows */
        public void RowSwap(int firstRow, int secondRow) {
            for (int j = 0; j < this.N; j++) {
                double temp = this[firstRow][j];
                this[firstRow][j] = this[secondRow][j];
                this[secondRow][j] = temp;
            }
        }

        /* Invert the matrix */
        public void Invert() {
            Matrix im = GetInverse();
            this.m = im.M; this.n = im.N;
            this.matrix = im.matrix;
        }

        /* Get Inverse of the matrix */
        public Matrix GetInverse() {
            if (!this.IsSquare())
                throw new DimensionMismatchException("Matrix must be square");
            Matrix am = GetAugmentedMatrix(Matrix.I(this.N));
            am.GaussJordan();
            return am.GetColumnsFromMatrix(this.N, am.N);
        }

        /* Augment the matrix */
        public void AugmentMatrix(Matrix a) {
            Matrix am = GetAugmentedMatrix(a);
            this.m = am.M; this.n = am.N;
            this.matrix = am.matrix;
        }
    
        /* Return augmented matrix */
        public Matrix GetAugmentedMatrix(Matrix a) {
            if (a.M != this.M)
                throw new DimensionMismatchException("Matrices must have same row size");
            Matrix newMatrix = new Matrix(this.M, this.N + a.N);
            for (int i = 0; i < this.M; i++) {
                for (int j1 = 0; j1 < this.N; j1++) {
                    newMatrix[i][j1] = this[i][j1];
                }
                for (int j2 = 0; j2 < a.N; j2++) {
                    newMatrix[i][this.N + j2] = a[i][j2];
                }
            }
            return newMatrix;
        }

        /* Get columns from c1 and up to but not including c2 from matrix */
        public Matrix GetColumnsFromMatrix(int c1, int c2) {
            if (c1 < 0 || c1 > this.N || c2 < 0 || c2 > this.N || c1 >= c2)
                throw new DimensionMismatchException("Column indices are too large or too small");
            Matrix newMatrix = new Matrix(this.M, c2 - c1);
            for (int r = 0; r < this.M; r++) {
                for (int c = c1; c < c2; c++) {
                    newMatrix[r][c - c1] = this[r][c];
                }
            }
            return newMatrix;
        }
    }
}
