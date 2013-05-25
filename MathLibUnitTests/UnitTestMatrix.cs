using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathLib;
using System.Collections.Generic;

namespace MathLibUnitTests
{
    [TestClass]
    public class UnitTestMatrix
    {
        [TestMethod]
        public void TestMatrixAddition() {
            Matrix m1, m2;
            m1 = new Matrix(2, 2);
            m2 = new Matrix(2, 2);
            
            // init m1
            m1.SetValue(0, 0, 1);
            m1.SetValue(0, 1, 1);
            m1.SetValue(1, 0, 1);
            m1.SetValue(1, 1, 1);

            // init m2
            m2.SetValue(0, 0, 2);
            m2.SetValue(0, 1, 2);
            m2.SetValue(1, 0, 2);
            m2.SetValue(1, 1, 2);

            Matrix sum = m1.AddMatrix(m2);
            Matrix result;

            result = new Matrix(2, 2);
            result.SetValue(0, 0, 3);
            result.SetValue(0, 1, 3);
            result.SetValue(1, 0, 3);
            result.SetValue(1, 1, 3);

            Assert.AreEqual(result, sum);

            // test plus operator
            sum = m1 + m2;
            Assert.AreEqual(result, sum);
        }

        [TestMethod]
        public void TestMatrixEquals() {
            Matrix m1, m2;
            m1 = new Matrix(2, 2);
            m2 = new Matrix(2, 2);

            m1.SetValue(0, 0, 1);
            m1.SetValue(0, 1, 1);
            m1.SetValue(1, 0, 1);
            m1.SetValue(1, 1, 1);

            m2.SetValue(0, 0, 1);
            m2.SetValue(0, 1, 1);
            m2.SetValue(1, 0, 1);
            m2.SetValue(1, 1, 1);

            Assert.AreEqual(true, m1 == m2);
        }

        [TestMethod]
        public void TestMatrixScalarMultiply() {
            Matrix m1, m2;
            m1 = new Matrix(2, 2);

            m1.SetValue(0, 0, 1);
            m1.SetValue(0, 1, 1);
            m1.SetValue(1, 0, 1);
            m1.SetValue(1, 1, 1);

            m2 = m1.MultiplyScalar(3);

            Matrix m3;
            m3 = new Matrix(2, 2);

            m3.SetValue(0, 0, 3);
            m3.SetValue(0, 1, 3);
            m3.SetValue(1, 0, 3);
            m3.SetValue(1, 1, 3);

            Assert.AreEqual(true, m2 == m3);
            m2 = m1 * 3;
            Assert.AreEqual(true, m2 == m3);
            m2 = 3 * m1;
            Assert.AreEqual(true, m2 == m3);
        }


        [TestMethod]
        public void TestMatrixSubtraction() {
            Matrix m1, m2;
            m1 = new Matrix(2, 2);
            m2 = new Matrix(2, 2);

            // init m1
            m1.SetValue(0, 0, 1);
            m1.SetValue(0, 1, 1);
            m1.SetValue(1, 0, 1);
            m1.SetValue(1, 1, 1);

            // init m2
            m2.SetValue(0, 0, 2);
            m2.SetValue(0, 1, 2);
            m2.SetValue(1, 0, 2);
            m2.SetValue(1, 1, 2);

            Matrix diff = m1.SubMatrix(m2);
            Matrix result;

            result = new Matrix(2, 2);
            result.SetValue(0, 0, -1);
            result.SetValue(0, 1, -1);
            result.SetValue(1, 0, -1);
            result.SetValue(1, 1, -1);

            Assert.AreEqual(result, diff);

            // test minus operator
            diff = m1 - m2;
            Assert.AreEqual(result, diff);
        }

        [TestMethod]
        public void TestMatrixMultiplication() {
            Matrix m1, m2;
            m1 = new Matrix(3, 2);
            m2 = new Matrix(2, 3);

            // init m1
            m1.SetValue(0, 0, 3);
            m1.SetValue(0, 1, 1);
            m1.SetValue(1, 0, 0);
            m1.SetValue(1, 1, 2);
            m1.SetValue(2, 0, 0);
            m1.SetValue(2, 1, 1);

            // init m2
            m2.SetValue(0, 0, 4);
            m2.SetValue(0, 1, 1);
            m2.SetValue(0, 2, 2);
            m2.SetValue(1, 0, 0);
            m2.SetValue(1, 1, 3);
            m2.SetValue(1, 2, 1);

            Matrix prod = m1.MultiplyMatrix(m2);
            Matrix result;

            result = new Matrix(3, 3);
            result.SetValue(0, 0, 12);
            result.SetValue(0, 1, 6);
            result.SetValue(0, 2, 7);
            result.SetValue(1, 0, 0);
            result.SetValue(1, 1, 6);
            result.SetValue(1, 2, 2);
            result.SetValue(2, 0, 0);
            result.SetValue(2, 1, 3);
            result.SetValue(2, 2, 1);

            Assert.AreEqual(true, result == prod);
            prod = m1 * m2;
            Assert.AreEqual(true, result == prod);
        }

        [TestMethod]
        public void TestMatrixIndexer() {
            Matrix m = new Matrix(2, 2);
            m.SetValue(0, 0, 1.0);
            m.SetValue(0, 1, 0.0);
            m.SetValue(1, 0, 0.0);
            m.SetValue(1, 1, 1.0);

            Assert.AreEqual(m[0][0], 1.0);
            Assert.AreEqual(m[0][1], 0.0);
            Assert.AreEqual(m[1][0], 0.0);
            Assert.AreEqual(m[1][1], 1.0);

            m[0][0] = 2.0;
            m[0][1] = 1.0;
            m[1][0] = 1.0;
            m[1][1] = 2.0;

            Assert.AreEqual(m[0][0], 2.0);
            Assert.AreEqual(m[0][1], 1.0);
            Assert.AreEqual(m[1][0], 1.0);
            Assert.AreEqual(m[1][1], 2.0);

        }

        [TestMethod]
        public void TestMatrixFactoryIdentity() {
            Matrix i = Matrix.I(3);
            Matrix i2 = Matrix.Identity(3);

            Assert.AreEqual(true, i == i2);

            Matrix i3 = new Matrix(3, 3);
            i3[0][0] = 1.0;
            i3[1][1] = 1.0;
            i3[2][2] = 1.0;

            Assert.AreEqual(true, i == i3);
        }

        [TestMethod]
        public void TestMatrixFactoryNewMatrix() {
            List<List<double>> input = new List<List<double>>();
            double[,] arrayInput = new double[2,2];
            double[][] twoDArrayInput = new double[2][];

            for (int r = 0; r < 2; r++) {
                input.Add(new List<double>());
                twoDArrayInput[r] = new double[2];
                for (int c = 0; c < 2; c++) {
                    input[r].Add((r + 1) * (c + 1));
                    arrayInput[r,c] = (r + 1) * (c + 1);
                    twoDArrayInput[r][c] = (r + 1) * (c + 1);
                }
            }

            Matrix expected = new Matrix(2, 2);
            for (int r = 0; r < 2; r++) {
                for (int c = 0; c < 2; c++) {
                    expected[r][c] = (r + 1) * (c + 1);
                }
            }

            Assert.AreEqual(expected, new Matrix(input));
            Assert.AreEqual(expected, Matrix.NewMatrix(arrayInput));
            Assert.AreEqual(expected, Matrix.NewMatrix(twoDArrayInput));

            input[1].Remove(4.0);

            try {
                Matrix.NewMatrix(input);
                Assert.Fail();
            } catch (FormatException) { }

            string testInput = "{{1,2}{2,4}}";
            Assert.AreEqual(expected, Matrix.NewMatrix(testInput));

            testInput = "{{1.0,2.0}{2.0,4.0}}";
            Assert.AreEqual(expected, Matrix.NewMatrix(testInput));

            testInput = "{{ 1.0 , 2.0 }{ 2.0 , 4.0 }}";
            Assert.AreEqual(expected, Matrix.NewMatrix(testInput));

            testInput = "{ { 1.0 , 2.0 } { 2.0 , 4.0 } }";
            Assert.AreEqual(expected, Matrix.NewMatrix(testInput));

            testInput = "{ { 1.0 , 2.0 } , { 2.0, 4.0 } }";
            Assert.AreEqual(expected, Matrix.NewMatrix(testInput));

            testInput = "{ { 1.0 , 2.0 } { 2.0 } }";
            try {
                Matrix.NewMatrix(testInput);
                Assert.Fail();
            } catch (FormatException) { }

            testInput = "{ { 1.0 , 2.0.0 } { 2.0 , 4.0 } }";
            try {
                Matrix.NewMatrix(testInput);
                Assert.Fail();
            } catch (FormatException) { }

            testInput = "{ { 1.0 , 2.0, 3.0 } { 2.0 , 4.0 } }";
            try {
                Matrix.NewMatrix(testInput);
                Assert.Fail();
            } catch (FormatException) { }

            testInput = "{ { 1.0 , 2.0,, 3.0 } { 2.0 , 4.0 } }";
            try {
                Matrix.NewMatrix(testInput);
                Assert.Fail();
            } catch (FormatException) { }

            testInput = "{ {} {} }";
            try {
                Matrix.NewMatrix(testInput);
                Assert.Fail();
            } catch (FormatException) { }

            testInput = "{ {} { }";
            try {
                Matrix.NewMatrix(testInput);
                Assert.Fail();
            } catch (FormatException) { }

            testInput = "{ {} { ";
            try {
                Matrix.NewMatrix(testInput);
                Assert.Fail();
            } catch (FormatException) { }

            testInput = "{ { { ";
            try {
                Matrix.NewMatrix(testInput);
                Assert.Fail();
            } catch (FormatException) { }

            testInput = "{}";
            try {
                Matrix.NewMatrix(testInput);
                Assert.Fail();
            } catch (FormatException) { }

            testInput = "}";
            try {
                Matrix.NewMatrix(testInput);
                Assert.Fail();
            } catch (FormatException) { }

            testInput = "{";
            try {
                Matrix.NewMatrix(testInput);
                Assert.Fail();
            } catch (FormatException) { }
        }

        [TestMethod]
        public void TestMatrixFunctionsIsDiagonal() {
            Matrix m = Matrix.I(2);
            Assert.AreEqual(true, m.IsDiagonal());

            m = Matrix.NewMatrix("{{1.0,1.0},{1.0,1.0}}");
            Assert.AreEqual(false, m.IsDiagonal());
        }

        [TestMethod]
        public void TestMatrixFunctionsIsIdentity() {
            Matrix m = Matrix.I(2);
            Assert.AreEqual(true, m.IsIdentity());

            m = Matrix.NewMatrix("{{1.0,1.0},{1.0,1.0}}");
            Assert.AreEqual(false, m.IsIdentity());
        }

        [TestMethod]
        public void TestMatrixFunctionsIsSquare() {
            Matrix m = Matrix.I(2);
            Assert.AreEqual(true, m.IsSquare());

            m = Matrix.NewMatrix("{{1.0},{1.0}}");
            Assert.AreEqual(false, m.IsSquare());
        }

        [TestMethod]
        public void TestMatrixFunctionsTrace() {
            Matrix m = Matrix.I(2) * 2.0;
            Assert.AreEqual(4.0, m.Trace());

            m = Matrix.NewMatrix("{{1.0},{1.0}}"); 
            try {
                m.Trace();
                Assert.Fail();
            } catch (DimensionMismatchException) { }
        }

        [TestMethod]
        public void TestMatrixFunctionsDet() {
            Matrix m = Matrix.NewMatrix("{{2.0,1.0}{1.0,2.0}}");
            Assert.AreEqual(3.0, m.Determinant());
            Assert.AreEqual(3.0, m.Det());

            m = Matrix.NewMatrix("{{1}}");
            Assert.AreEqual(1.0, m.Det());

            m = Matrix.NewMatrix("{{3.0,2.0,1.0}{1.0,2.0,3.0}{2.0,1.0,3.0}}");
            Assert.AreEqual(12.0, m.Det());

            m = Matrix.NewMatrix("{{3.0,2.0,1.0,4.0},{1.0,2.0,4.0,3.0},{2.0,4.0,1.0,3.0},{4.0,1.0,2.0,3.0}}");
            Assert.AreEqual(70.0, m.Det());
        }

        [TestMethod]
        public void TestMatrixFunctionsUpperTriangular() {
            Matrix m = Matrix.NewMatrix("{{2.0,1.0}{0.0,2.0}}");
            Assert.AreEqual(true, m.IsUpperTriangular());
            m[1][0] = 1.0;
            Assert.AreEqual(false, m.IsUpperTriangular());
        }

        [TestMethod]
        public void TestMatrixFunctionsLowerTriangular() {
            Matrix m = Matrix.NewMatrix("{{2.0,0.0}{1.0,2.0}}");
            Assert.AreEqual(true, m.IsLowerTriangular());
            m[0][1] = 1.0;
            Assert.AreEqual(false, m.IsLowerTriangular());
        }

        [TestMethod]
        public void TestMatrixFunctionsTranspose() {
            Matrix m = Matrix.NewMatrix("{{1.0,2.0,3.0}{4.0,5.0,6.0}}");
            Matrix expected = Matrix.NewMatrix("{{1.0,4.0}{2.0,5.0}{3.0,6.0}}");
            m.Transpose();
            Assert.AreEqual(expected, m);
        }

        [TestMethod]
        public void TestMatrixFunctionsGaussElim() {
            Matrix m = Matrix.NewMatrix("{{1.0,2.0}{4.0,5.0}}");
            m.GaussElim();
            Matrix expected = new Matrix("{{1.0,1.25},{0.0,1.0}}");
            Assert.AreEqual(expected, m);


            m = Matrix.NewMatrix("{{1.0,2.0,3.0}{2.0,4.0,6.0}}");
            m.GaussElim();
            expected = new Matrix("{{1.0,2.0,3.0}{0.0,0.0,0.0}}");
            Assert.AreEqual(expected, m);
        }

        [TestMethod]
        public void TestMatrixFunctionsGaussJordan() {
            Matrix m = Matrix.NewMatrix("{{1.0,2.0}{4.0,5.0}}");
            m.GaussJordan();
            Matrix expected = Matrix.I(2);
            Assert.AreEqual(expected, m);


            m = Matrix.NewMatrix("{{1.0,2.0,3.0}{3.0,9.0,27.0}}");
            m.GaussJordan();
            expected = new Matrix("{{1.0,0.0,-9.0}{0.0,1.0,6.0}}");
            Assert.AreEqual(expected, m);
        }

        [TestMethod]
        public void TestMatrixFunctionsGetAugmentedMatrix() {
            Matrix m = Matrix.NewMatrix("{{1.0,2.0}{4.0,5.0}}");
            Matrix am = m.GetAugmentedMatrix(Matrix.I(2));
            Matrix expected = new Matrix("{{1.0, 2.0, 1.0, 0.0}{4.0, 5.0, 0.0, 1.0}}");
            Assert.AreEqual(expected, am);
        }

        [TestMethod]
        public void TestMatrixFunctionsGetColumnsFromMatrix() {
            Matrix m = Matrix.NewMatrix("{{1.0,2.0,3.0}{4.0,5.0,6.0}}");
            Matrix expected = new Matrix("{{1.0, 2.0}{4.0,5.0}}");
            Assert.AreEqual(expected, m.GetColumnsFromMatrix(0, 2));
        }

        [TestMethod]
        public void TestMatrixFunctionsGetInverse() {
            Matrix m = Matrix.NewMatrix("{{1.0,2.0}{3.0,4.0}}");
            Matrix expected = new Matrix("{{-2.0, 1.0}{1.5, -.5}}");
            Assert.AreEqual(expected, m.GetInverse());
        }

        [TestMethod]
        public void TestMatrixFunctionsGetREFAndGetRREF() {
            Matrix m = Matrix.NewMatrix("{{1.0,2.0}{3.0,4.0}}");
            Matrix REF = new Matrix("{{1.0, 1.33333333}{0.0, 1.0}}");
            Assert.AreEqual(REF, m.GetREF());
            Matrix RREF = Matrix.I(2);
            Assert.AreEqual(RREF, m.GetRREF());
        }
    }
}
