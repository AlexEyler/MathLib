using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathLib;

namespace MathLibUnitTests {

    [TestClass]
    public class UnitTestVector {

        [TestMethod]
        public void TestVectorSize() {
            Vector v = new Vector(5);

            v.SetValue(0, 1.0);
            v.SetValue(1, 1.0);
            v.SetValue(2, 1.0);
            v.SetValue(3, 1.0);
            v.SetValue(4, 1.0);

            Assert.AreEqual(v.Size, 5);
        }

        [TestMethod]
        public void TestVectorMath() {
            Vector v1 = new Vector(5);
            Vector v2 = new Vector(5);

            v1.SetValue(0, 1.0);
            v1.SetValue(1, 2.0);
            v1.SetValue(2, 3.0);
            v1.SetValue(3, 4.0);
            v1.SetValue(4, 5.0);

            v2.SetValue(0, 5.0);
            v2.SetValue(1, 4.0);
            v2.SetValue(2, 3.0);
            v2.SetValue(3, 2.0);
            v2.SetValue(4, 1.0);

            Vector sum = new Vector(5);
            sum.SetValue(0, 6.0);
            sum.SetValue(1, 6.0);
            sum.SetValue(2, 6.0);
            sum.SetValue(3, 6.0);
            sum.SetValue(4, 6.0);

            Assert.AreEqual(sum, v1 + v2);

            Vector diff = new Vector(5);
            diff.SetValue(0, -4.0);
            diff.SetValue(1, -2.0);
            diff.SetValue(2, 0.0);
            diff.SetValue(3, 2.0);
            diff.SetValue(4, 4.0);

            Assert.AreEqual(diff, v1 - v2);

            double dotprod = 35.0;

            Assert.AreEqual(dotprod, v1 * v2);

            Matrix m = new Matrix(2, 2);
            m.SetValue(0, 0, 1);
            m.SetValue(0, 1, 2);
            m.SetValue(1, 0, 3);
            m.SetValue(1, 1, 4);

            Vector v = new Vector(2);
            v.SetValue(0, 1);
            v.SetValue(1, 2);

            Vector result1 = new Vector(2);
            result1.SetValue(0, 5);
            result1.SetValue(1, 11);

            Vector result2 = new Vector(2);
            result2.SetValue(0, 7);
            result2.SetValue(1, 10);

            Assert.AreEqual(result1, m * v);
            Assert.AreEqual(result2, v * m);

        }

        [TestMethod]
        public void TestVectorIndexer() {
            Vector v = new Vector(3);
            v.SetValue(0, 1.0);
            v.SetValue(1, 2.0);
            v.SetValue(2, 3.0);

            Assert.AreEqual(v[0], 1.0);
            Assert.AreEqual(v[1], 2.0);
            Assert.AreEqual(v[2], 3.0);

            v[0] = 1.0;
            v[1] = 2.0;
            v[2] = 3.0;

            Assert.AreEqual(v[0], 1.0);
            Assert.AreEqual(v[1], 2.0);
            Assert.AreEqual(v[2], 3.0);
        }

        [TestMethod]
        public void TestVectorFactoryNewVector() {
            Vector v = Vector.NewVector(new double[]{1.0,2.0,3.0});
            Vector expected = new Vector(3);
            expected[0] = 1.0;
            expected[1] = 2.0;
            expected[2] = 3.0;
            Assert.AreEqual(expected, v);
            v = Vector.NewVector("{1.0,2.0,3.0}");
            Assert.AreEqual(expected, v);

            try {
                v = Vector.NewVector("{{");
                Assert.Fail();
            } catch (FormatException) { }

            try {
                v = Vector.NewVector("{}");
                Assert.Fail();
            } catch (FormatException) { }

            try {
                v = Vector.NewVector("{1.0,,2.0}");
                Assert.Fail();
            } catch (FormatException) { }

            try {
                v = Vector.NewVector("{13.0.0}");
                Assert.Fail();
            } catch (FormatException) { }

            try {
                v = Vector.NewVector("{");
                Assert.Fail();
            } catch (FormatException) { }

        }
    }
}
