using System.Collections.Generic;

namespace ExtensionMethods
{
    using System;

    /// <inheritdoc cref="IComplex"/>
    public class Complex : IComplex, IEquatable<Complex>
    {
        private readonly double _re;
        private readonly double _im;

        /// <summary>
        /// Initializes a new instance of the <see cref="Complex"/> class.
        /// </summary>
        /// <param name="re">the real part.</param>
        /// <param name="im">the imaginary part.</param>
        public Complex(double re, double im)
        {
            this._re = re;
            this._im = im;
        }




        /// <inheritdoc cref="IComplex.Real"/>
        public double Real => this._re;

        /// <inheritdoc cref="IComplex.Imaginary"/>
        public double Imaginary => this._im;

        /// <inheritdoc cref="IComplex.Modulus"/>
        public double Modulus => Math.Sqrt(Math.Pow(this.Real, 2) + Math.Pow(this.Imaginary, 2));

        /// <inheritdoc cref="IComplex.Phase"/>
        public double Phase => Math.Atan2(this._im, this._re);

        /// <inheritdoc cref="IComplex.ToString"/>
        public override string ToString()
        {
            return $"{nameof(Real)}: {Real}, {nameof(Imaginary)}: {Imaginary}";
        }

        /// <inheritdoc cref="object.GetHashCode"/>
        public override int GetHashCode()
        {
            return HashCode.Combine(_re, _im);
        }

        public bool Equals(Complex other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _re.Equals(other._re) && _im.Equals(other._im);
        }

        public bool Equals(IComplex other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _re.Equals(other.Real) && _im.Equals(other.Imaginary);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Complex) obj);
        }
    }
}
