using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLib {
    public partial class Matrix {

        /* Short-hand for Identity Function */
        public static Matrix I(int size) {
            return Matrix.Identity(size);
        }

        /* Identity Matrix Builder */
        public static Matrix Identity(int size) {
            Matrix i = new Matrix(size, size);
            for (int r = 0; r < size; r++) {
                for (int c = 0; c < size; c++) {
                    if (r == c) {
                        i[r][c] = 1.0;
                    } else {
                        i[r][c] = 0.0;
                    }
                }
            }
            return i;
        }

        /* Create New Matrix from a string input */
        public static Matrix NewMatrix(string input) {
            List<List<double>> newMatrix = new List<List<double>>();

            bool inMatrix = false;
            bool inRow = false;
            int m = 0, n = 0;
            int i = 0;

            while (input[i] != '{') {
                if (input[i] != ' ')
                    throw new FormatException("Matrix is an invalid format");
                i++;
            }
            inMatrix = true;
            i++;
            while (inMatrix) {
                if (i >= input.Length) {
                    throw new FormatException("Vector is an invalid format");
                }
                while (!(input[i] == '{' || input[i] == '}')) {
                    if (!(input[i] == ' ' || input[i] == ',')) {
                        throw new FormatException("Matrix is an invalid format");
                    }
                    i++;
                }

                if (input[i] == '{') {
                    newMatrix.Add(new List<double>());
                    inRow = true;
                    i++;
                }

                if (input[i] == '}') {
                    if (newMatrix.Count == 0) {
                        throw new FormatException("Matrix is an invalid format");
                    }
                    inMatrix = false;
                    i++;
                    break;
                }

                if (inRow) {
                    int size = 0;
                    while (input[i] != '}') {
                        if (i >= input.Length) {
                            throw new FormatException("Vector is an invalid format");
                        }
                        // go to number
                        while (input[i] == ' ') {
                            i++;
                        }

                        string num = "";
                        // build number
                        while (Char.IsNumber(input[i]) || input[i] == '.' || input[i] == '-' || input[i] == '+') {
                            num += input[i];
                            i++;
                        }
                        double value = -1;
                        try {
                            value = Double.Parse(num);
                        } catch (Exception) {
                            throw new FormatException("Matrix is an invalid format");
                        }
                        newMatrix[m].Add(value);
                        size++;

                        // go to next index in matrix
                        while (input[i] != ',') {
                            if (input[i] == '}') {
                                i--; // we're adding to it later, but we want to stay here for now
                                break;
                            }
                            if (input[i] != ' ')
                                throw new FormatException("Matrix is an invalid format");
                            i++;
                        }
                        i++;
                    }
                    if (n == 0) {
                        n = size;
                    } else if (n != size) {
                        throw new FormatException("Matrix is an invalid format");
                    }
                    inRow = false;
                    m++;
                    i++;
                }
            }
            return NewMatrix(newMatrix);
        }

        /* Create a new matrix from ArrayList input */
        public static Matrix NewMatrix(List<List<double>> input) {
            int m = input.Count;
            int n = 0;

            // ensure lengths are correct
            foreach (List<double> row in input) {
                if (n == 0) {
                    if (row.Count == 0)
                        throw new FormatException("Matrix is an invalid format");
                    n = row.Count;
                } else if (n != row.Count) {
                    throw new FormatException("Matrix is an invalid format");
                }
            }

            // create Matrix
            Matrix newMatrix = new Matrix(m, n);
            for (int r = 0; r < m; r++) {
                for (int c = 0; c < n; c++) {
                    newMatrix[r][c] = input[r][c];
                }
            }

            return newMatrix;
        }

        /* Create a new matrix from a comma separated array */
        public static Matrix NewMatrix(double[,] input) {
            int m = input.GetLength(0);
            if (m == 0)
                throw new FormatException("Matrix is an invalid format");
            int n = input.GetLength(1);

            Matrix newMatrix = new Matrix(m, n);

            for (int r = 0; r < m; r++) {
                for (int c = 0; c < n; c++) {
                    newMatrix[r][c] = input[r,c];
                }
            }

            return newMatrix;
        }

        /* Create a new matrix from a two dimensional array */
        public static Matrix NewMatrix(double[][] input) {
            int m = input.Length;
            if (m == 0)
                throw new FormatException("Matrix is an invalid format");
            int n = input[0].Length;

            Matrix newMatrix = new Matrix(m, n);

            for (int r = 0; r < m; r++) {
                for (int c = 0; c < n; c++) {
                    newMatrix[r][c] = input[r][c];
                }
            }

            return newMatrix;
        }
    }
}
