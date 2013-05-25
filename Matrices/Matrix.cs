using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLib {

    /* An mxn matrix class */
    public partial class Matrix {
        
        /* Matrix is an mxn matrix */
        private int m, n;

        /* A two-dimensional array for the matrix */
        private double[][] matrix;

        /* Getter for M */
        public int M {
            get { return this.m; }
        }

        /* Getter for N */
        public int N {
            get { return this.n; }
        }

        /* Matrix class constructor (create blank Matrix) */
        public Matrix(int m, int n) {
            this.m = m;
            this.n = n;
            initialize_matrix(m, n);
        }

        /* Matrix class constructor for string input */
        public Matrix(string input) {
            Matrix temp = Matrix.NewMatrix(input);
            this.m = temp.M; this.n = temp.N;
            this.matrix = temp.matrix;
        }

        /* Matrix class constructor for double[][] input */
        public Matrix(double[][] input) {
            Matrix temp = Matrix.NewMatrix(input);
            this.m = temp.M; this.n = temp.N;
            this.matrix = temp.matrix;
        }

        /* Matrix class constructor for double[,] input */
        public Matrix(double[,] input) {
            Matrix temp = Matrix.NewMatrix(input);
            this.m = temp.M; this.n = temp.N;
            this.matrix = temp.matrix;
        }

        /* Matrix class constructor for List<List<double>> input */
        public Matrix(List<List<double>> input) {
            Matrix temp = Matrix.NewMatrix(input);
            this.m = temp.M; this.n = temp.N;
            this.matrix = temp.matrix;
        }

        /* Initialize the matrix given an m (row size) and n (col size) */
        private void initialize_matrix(int m, int n) {
            this.matrix = new double[m][];
            for (int i = 0; i < m; i++) {
                this.matrix[i] = new double[n];
            }
        }

        /* Copy a Matrix */
        public void Copy(out Matrix result) {
            Matrix temp = new Matrix(m, n);
            temp.matrix = this.matrix;
            result = temp;
        }

        /* Set the value at row and col */
        public void SetValue(int row, int col, double value) {
            if (row < 0 || row > this.m) {
                throw new InvalidIndexException("Invalid row: " + row);
            } else if (col < 0 || col > this.n) {
                throw new InvalidIndexException("Invalid col: " + col);
            }
            matrix[row][col] = value;
        }

        /* Get the value at row and col */
        public double GetValue(int row, int col) {
            if (row < 0 || row > this.m) {
                throw new InvalidIndexException("Invalid row: " + row);
            } else if (col < 0 || col > this.n) {
                throw new InvalidIndexException("Invalid col: " + col);
            }
            return matrix[row][col];
        }

        /* Override Object.Equals function */
        public override bool Equals(object other) {
            if (!checkValidType(other)) {
                return false;
            }

            Matrix otherCast = (Matrix)other;
            if (otherCast.M != this.m || otherCast.N != this.n) {
                return false;
            }
            for (int r = 0; r < this.m; r++) {
                for (int c = 0; c < this.n; c++) {
                    if (!(this.GetValue(r, c) + .00001 >= otherCast.GetValue(r, c) &&
                        this.GetValue(r, c) - .00001 <= otherCast.GetValue(r, c))) {
                        return false;
                    }
                }
            }
            return true;
        }

        /* Needed to be overrode when == and != operators were overloaded */
        public override int GetHashCode() {
            return base.GetHashCode();
        }

        /* ToString method */
        public override string ToString() {
            string returnString = "{";
            for (int r = 0; r < this.m; r++) {
                returnString += "{";
                for (int c = 0; c < this.n; c++) {
                    returnString += " " + this.GetValue(r, c);
                    if (c != this.n - 1) {
                        returnString += ", ";
                    } else {
                        returnString += " ";
                    }
                }
                returnString += "},";
            }
            return returnString + "}";
        }

        /* Check to see if an Object is a Matrix */
        private bool checkValidType(Object o) {
            return o.GetType() == typeof(Matrix);
        }

    }
}
