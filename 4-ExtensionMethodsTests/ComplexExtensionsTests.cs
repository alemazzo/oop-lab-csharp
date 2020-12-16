namespace ExtensionMethods
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ComplexExtensionsTests
    {
        private readonly IComplex _c1 = new Complex(1, 1);
        private readonly IComplex _c2 = new Complex(1, 1);

        [TestMethod]
        public void AddTest()
        {
            Assert.AreEqual(new Complex(2, 2), this._c1.Add(this._c2));
        }

        [TestMethod]
        public void SubtractTest()
        {
            Assert.AreEqual(new Complex(0, 0), this._c1.Subtract(this._c2));
        }

        [TestMethod]
        public void MultiplyTest()
        {
            Assert.AreEqual(new Complex(0, 2), this._c1.Multiply(this._c2));
        }

        [TestMethod]
        public void DivideTest()
        {
            Assert.AreEqual(new Complex(1, 0), this._c1.Divide(this._c2));
        }

        [TestMethod]
        public void ConjugateTest()
        {
            Assert.AreEqual(new Complex(1, -1), this._c1.Conjugate());
        }

        [TestMethod]
        public void ReciprocalTest()
        {
            Assert.AreEqual(new Complex(0.5, -0.5), this._c1.Reciprocal());
        }
    }
}
