#region Sharp3D.Math, Copyright(C) 2003-2004 Eran Kampf, Licensed under LGPL.
//	Sharp3D.Math math library
//	Copyright (C) 2003-2004  
//	Eran Kampf
//	tentacle@zahav.net.il
//	http://www.ekampf.com/Sharp3D.Math/
//
//	This library is free software; you can redistribute it and/or
//	modify it under the terms of the GNU Lesser General Public
//	License as published by the Free Software Foundation; either
//	version 2.1 of the License, or (at your option) any later version.
//
//	This library is distributed in the hope that it will be useful,
//	but WITHOUT ANY WARRANTY; without even the implied warranty of
//	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//	Lesser General Public License for more details.
//
//	You should have received a copy of the GNU Lesser General Public
//	License along with this library; if not, write to the Free Software
//	Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
#endregion
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace Sharp3D.Math.Core {
    /// <summary>
    /// Represents 4-Dimentional vector of double-precision floating point numbers.
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    [TypeConverter(typeof(Vector4DConverter))]
    public struct Vector4D : ISerializable, ICloneable {
        #region Private fields
        private double _x;
        private double _y;
        private double _z;
        private double _w;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4D"/> class with the specified coordinates.
        /// </summary>
        /// <param name="x">The vector's X coordinate.</param>
        /// <param name="y">The vector's Y coordinate.</param>
        /// <param name="z">The vector's Z coordinate.</param>
        /// <param name="w">The vector's W coordinate.</param>
        public Vector4D(double x, double y, double z, double w) {
            _x = x;
            _y = y;
            _z = z;
            _w = w;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4D"/> class with the specified coordinates.
        /// </summary>
        /// <param name="x">The vector's X coordinate.</param>
        /// <param name="y">The vector's Y coordinate.</param>
        /// <param name="z">The vector's Z coordinate.</param>
        /// <param name="w">The vector's W coordinate.</param>
        public Vector4D(double x,double y,double z):this(x,y,z,0d) {

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4D"/> class with the specified coordinates.
        /// </summary>
        /// <param name="coordinates">An array containing the coordinate parameters.</param>
        public Vector4D(double[] coordinates) {
            Debug.Assert(coordinates != null);
            Debug.Assert(coordinates.Length >= 4);

            _x = coordinates[0];
            _y = coordinates[1];
            _z = coordinates[2];
            _w = coordinates[3];
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4D"/> class with the specified coordinates.
        /// </summary>
        /// <param name="coordinates">An array containing the coordinate parameters.</param>
        public Vector4D(DoubleArrayList coordinates) {
            Debug.Assert(coordinates != null);
            Debug.Assert(coordinates.Count >= 4);

            _x = coordinates[0];
            _y = coordinates[1];
            _z = coordinates[2];
            _w = coordinates[3];
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4D"/> class using coordinates from a given <see cref="Vector4D"/> instance.
        /// </summary>
        /// <param name="vector">A <see cref="Vector4D"/> to get the coordinates from.</param>
        public Vector4D(Vector4D vector) {
            _x = vector.X;
            _y = vector.Y;
            _z = vector.Z;
            _w = vector.W;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4D"/> class using coordinates from a given <see cref="Vector4D"/> instance.
        /// </summary>
        /// <param name="vector">A <see cref="Vector4D"/> to get the coordinates from.</param>
        public Vector4D(Vector3D vector, double w = 1d) {
            _x = vector.X;
            _y = vector.Y;
            _z = vector.Z;
            _w = w;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4D"/> class with serialized data.
        /// </summary>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        private Vector4D(SerializationInfo info, StreamingContext context) {
            _x = info.GetSingle("X");
            _y = info.GetSingle("Y");
            _z = info.GetSingle("Z");
            _w = info.GetSingle("W");
        }
        #endregion

        #region Constants
        /// <summary>
        /// 4-Dimentional double-precision floating point zero vector.
        /// </summary>
        public static readonly Vector4D Zero = new Vector4D(0.0f, 0.0f, 0.0f, 0.0f);
        /// <summary>
        /// 4-Dimentional double-precision floating point X-Axis vector.
        /// </summary>
        public static readonly Vector4D XAxis = new Vector4D(1.0f, 0.0f, 0.0f, 0.0f);
        /// <summary>
        /// 4-Dimentional double-precision floating point Y-Axis vector.
        /// </summary>
        public static readonly Vector4D YAxis = new Vector4D(0.0f, 1.0f, 0.0f, 0.0f);
        /// <summary>
        /// 4-Dimentional double-precision floating point Y-Axis vector.
        /// </summary>
        public static readonly Vector4D ZAxis = new Vector4D(0.0f, 0.0f, 1.0f, 0.0f);
        /// <summary>
        /// 4-Dimentional double-precision floating point Y-Axis vector.
        /// </summary>
        public static readonly Vector4D WAxis = new Vector4D(0.0f, 0.0f, 0.0f, 1.0f);
        #endregion

        #region Public properties
        /// <summary>
        /// Gets or sets the x-coordinate of this vector.
        /// </summary>
        /// <value>The x-coordinate of this vector.</value>
        public double X {
            get { return _x; }
            set { _x = value; }
        }

        public double GetX(double t) {
            return _x;
        }

        public void SetX(double x) {
            _x = x;
        }

        /// <summary>
        /// Gets or sets the y-coordinate of this vector.
        /// </summary>
        /// <value>The y-coordinate of this vector.</value>
        public double Y {
            get { return _y; }
            set { _y = value; }
        }

        public double GetY(double t) {
            return _y;
        }

        public void SetY(double y) {
            _y = y;
        }
        /// <summary>
        /// Gets or sets the z-coordinate of this vector.
        /// </summary>
        /// <value>The z-coordinate of this vector.</value>
        public double Z {
            get { return _z; }
            set { _z = value; }
        }

        public double GetZ(double t) {
            return _z;
        }

        public void SetZ(double z) {
            _z = z;
        }
        /// <summary>
        /// Gets or sets the w-coordinate of this vector.
        /// </summary>
        /// <value>The w-coordinate of this vector.</value>
        public double W {
            get { return _w; }
            set { _w = value; }
        }
        /// <summary>
        /// To/From Vector 3D
        /// </summary>
        public Vector3D Vec3D {
            get {
                return new Vector3D(_x, _y, _z);
            }
            set {
                _x = value.X;
                _y = value.Y;
                _z = value.Z;
            }
        }
        #endregion

        #region ICloneable Members
        /// <summary>
        /// Creates an exact copy of this <see cref="Vector4D"/> object.
        /// </summary>
        /// <returns>The <see cref="Vector4D"/> object this method creates, cast as an object.</returns>
        object ICloneable.Clone() {
            return new Vector4D(this);
        }
        /// <summary>
        /// Creates an exact copy of this <see cref="Vector4D"/> object.
        /// </summary>
        /// <returns>The <see cref="Vector4D"/> object this method creates.</returns>
        public Vector4D Clone() {
            return new Vector4D(this);
        }
        #endregion

        #region ISerializable Members
        /// <summary>
        /// Populates a <see cref="SerializationInfo"/> with the data needed to serialize this object.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> to populate with data. </param>
        /// <param name="context">The destination (see <see cref="StreamingContext"/>) for this serialization.</param>
        //[SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter=true)]
        public void GetObjectData(SerializationInfo info, StreamingContext context) {
            info.AddValue("X", _x);
            info.AddValue("Y", _y);
            info.AddValue("Z", _z);
            info.AddValue("W", _w);
        }
        #endregion

        #region Public Static Parse Methods
        /// <summary>
        /// Converts the specified string to its <see cref="Vector4D"/> equivalent.
        /// </summary>
        /// <param name="s">A string representation of a <see cref="Vector4D"/></param>
        /// <returns>A <see cref="Vector4D"/> that represents the vector specified by the <paramref name="s"/> parameter.</returns>
        public static Vector4D Parse(string s) {
            Regex r = new Regex(@"\((?<x>.*),(?<y>.*),(?<z>.*),(?<w>.*)\)", RegexOptions.None);
            Match m = r.Match(s);
            if (m.Success) {
                return new Vector4D(
                    double.Parse(m.Result("${x}")),
                    double.Parse(m.Result("${y}")),
                    double.Parse(m.Result("${z}")),
                    double.Parse(m.Result("${w}"))
                    );
            }
            else {
                throw new ParseException("Unsuccessful Match.");
            }
        }
        #endregion

        #region Public Static Vector Arithmetics
        /// <summary>
        /// Adds two vectors.
        /// </summary>
        /// <param name="v">A <see cref="Vector4D"/> instance.</param>
        /// <param name="w">A <see cref="Vector4D"/> instance.</param>
        /// <returns>A new <see cref="Vector4D"/> instance containing the sum.</returns>
        public static Vector4D Add(Vector4D v, Vector4D w) {
            return new Vector4D(v.X + w.X, v.Y + w.Y, v.Z + w.Z, v.W + w.W);
        }
        /// <summary>
        /// Adds a vector and a scalar.
        /// </summary>
        /// <param name="v">A <see cref="Vector4D"/> instance.</param>
        /// <param name="s">A scalar.</param>
        /// <returns>A new <see cref="Vector4D"/> instance containing the sum.</returns>
        public static Vector4D Add(Vector4D v, double s) {
            return new Vector4D(v.X + s, v.Y + s, v.Z + s, v.W + s);
        }
        /// <summary>
        /// Adds two vectors and put the result in the third vector.
        /// </summary>
        /// <param name="u">A <see cref="Vector4D"/> instance.</param>
        /// <param name="v">A <see cref="Vector4D"/> instance</param>
        /// <param name="w">A <see cref="Vector4D"/> instance to hold the result.</param>
        public static void Add(Vector4D u, Vector4D v, ref Vector4D w) {
            w.X = u.X + v.X;
            w.Y = u.Y + v.Y;
            w.Z = u.Z + v.Z;
            w.W = u.W + v.W;
        }
        /// <summary>
        /// Adds a vector and a scalar and put the result into another vector.
        /// </summary>
        /// <param name="u">A <see cref="Vector4D"/> instance.</param>
        /// <param name="s">A scalar.</param>
        /// <param name="v">A <see cref="Vector4D"/> instance to hold the result.</param>
        public static void Add(Vector4D u, double s, ref Vector4D v) {
            v.X = u.X + s;
            v.Y = u.Y + s;
            v.Z = u.Z + s;
            v.W = u.W + s;
        }
        /// <summary>
        /// Subtracts a vector from a vector.
        /// </summary>
        /// <param name="v">A <see cref="Vector4D"/> instance.</param>
        /// <param name="w">A <see cref="Vector4D"/> instance.</param>
        /// <returns>A new <see cref="Vector4D"/> instance containing the difference.</returns>
        /// <remarks>
        ///	result[i] = v[i] - w[i].
        /// </remarks>
        public static Vector4D Subtract(Vector4D v, Vector4D w) {
            return new Vector4D(v.X - w.X, v.Y - w.Y, v.Z - w.Z, v.W - w.W);
        }
        /// <summary>
        /// Subtracts a scalar from a vector.
        /// </summary>
        /// <param name="v">A <see cref="Vector4D"/> instance.</param>
        /// <param name="s">A scalar.</param>
        /// <returns>A new <see cref="Vector4D"/> instance containing the difference.</returns>
        /// <remarks>
        /// result[i] = v[i] - s
        /// </remarks>
        public static Vector4D Subtract(Vector4D v, double s) {
            return new Vector4D(v.X - s, v.Y - s, v.Z - s, v.W - s);
        }
        /// <summary>
        /// Subtracts a vector from a scalar.
        /// </summary>
        /// <param name="v">A <see cref="Vector4D"/> instance.</param>
        /// <param name="s">A scalar.</param>
        /// <returns>A new <see cref="Vector4D"/> instance containing the difference.</returns>
        /// <remarks>
        /// result[i] = s - v[i]
        /// </remarks>
        public static Vector4D Subtract(double s, Vector4D v) {
            return new Vector4D(s - v.X, s - v.Y, s - v.Z, s - v.W);
        }
        /// <summary>
        /// Subtracts a vector from a second vector and puts the result into a third vector.
        /// </summary>
        /// <param name="u">A <see cref="Vector4D"/> instance.</param>
        /// <param name="v">A <see cref="Vector4D"/> instance</param>
        /// <param name="w">A <see cref="Vector4D"/> instance to hold the result.</param>
        /// <remarks>
        ///	w[i] = v[i] - w[i].
        /// </remarks>
        public static void Subtract(Vector4D u, Vector4D v, ref Vector4D w) {
            w.X = u.X - v.X;
            w.Y = u.Y - v.Y;
            w.Z = u.Z - v.Z;
            w.W = u.W - v.W;
        }
        /// <summary>
        /// Subtracts a vector from a scalar and put the result into another vector.
        /// </summary>
        /// <param name="u">A <see cref="Vector4D"/> instance.</param>
        /// <param name="s">A scalar.</param>
        /// <param name="v">A <see cref="Vector4D"/> instance to hold the result.</param>
        /// <remarks>
        /// v[i] = u[i] - s
        /// </remarks>
        public static void Subtract(Vector4D u, double s, ref Vector4D v) {
            v.X = u.X - s;
            v.Y = u.Y - s;
            v.Z = u.Z - s;
            v.W = u.W - s;
        }
        /// <summary>
        /// Subtracts a scalar from a vector and put the result into another vector.
        /// </summary>
        /// <param name="u">A <see cref="Vector4D"/> instance.</param>
        /// <param name="s">A scalar.</param>
        /// <param name="v">A <see cref="Vector4D"/> instance to hold the result.</param>
        /// <remarks>
        /// v[i] = s - u[i]
        /// </remarks>
        public static void Subtract(double s, Vector4D u, ref Vector4D v) {
            v.X = s - u.X;
            v.Y = s - u.Y;
            v.Z = s - u.Z;
            v.W = s - u.W;
        }
        /// <summary>
        /// Divides a vector by another vector.
        /// </summary>
        /// <param name="u">A <see cref="Vector4D"/> instance.</param>
        /// <param name="v">A <see cref="Vector4D"/> instance.</param>
        /// <returns>A new <see cref="Vector4D"/> containing the quotient.</returns>
        /// <remarks>
        ///	result[i] = u[i] / v[i].
        /// </remarks>
        public static Vector4D Divide(Vector4D u, Vector4D v) {
            return new Vector4D(u.X / v.X, u.Y / v.Y, u.Z / v.Z, u.W / v.W);
        }
        /// <summary>
        /// Divides a vector by a scalar.
        /// </summary>
        /// <param name="v">A <see cref="Vector4D"/> instance.</param>
        /// <param name="s">A scalar</param>
        /// <returns>A new <see cref="Vector4D"/> containing the quotient.</returns>
        /// <remarks>
        /// result[i] = v[i] / s;
        /// </remarks>
        public static Vector4D Divide(Vector4D v, double s) {
            return new Vector4D(v.X / s, v.Y / s, v.Z / s, v.W / s);
        }
        /// <summary>
        /// Divides a scalar by a vector.
        /// </summary>
        /// <param name="v">A <see cref="Vector4D"/> instance.</param>
        /// <param name="s">A scalar</param>
        /// <returns>A new <see cref="Vector4D"/> containing the quotient.</returns>
        /// <remarks>
        /// result[i] = s / v[i]
        /// </remarks>
        public static Vector4D Divide(double s, Vector4D v) {
            return new Vector4D(s / v.X, s / v.Y, s / v.Z, s / v.W);
        }
        /// <summary>
        /// Divides a vector by another vector.
        /// </summary>
        /// <param name="u">A <see cref="Vector4D"/> instance.</param>
        /// <param name="v">A <see cref="Vector4D"/> instance.</param>
        /// <param name="w">A <see cref="Vector4D"/> instance to hold the result.</param>
        /// <remarks>
        /// w[i] = u[i] / v[i]
        /// </remarks>
        public static void Divide(Vector4D u, Vector4D v, ref Vector4D w) {
            w.X = u.X / v.X;
            w.Y = u.Y / v.Y;
            w.Z = u.Z / v.Z;
            w.W = u.W / v.W;
        }
        /// <summary>
        /// Divides a vector by a scalar.
        /// </summary>
        /// <param name="u">A <see cref="Vector4D"/> instance.</param>
        /// <param name="s">A scalar</param>
        /// <param name="v">A <see cref="Vector4D"/> instance to hold the result.</param>
        /// <remarks>
        /// v[i] = u[i] / s
        /// </remarks>
        public static void Divide(Vector4D u, double s, ref Vector4D v) {
            v.X = u.X / s;
            v.Y = u.Y / s;
            v.Z = u.Z / s;
            v.W = u.W / s;
        }
        /// <summary>
        /// Divides a scalar by a vector.
        /// </summary>
        /// <param name="u">A <see cref="Vector4D"/> instance.</param>
        /// <param name="s">A scalar</param>
        /// <param name="v">A <see cref="Vector4D"/> instance to hold the result.</param>
        /// <remarks>
        /// v[i] = s / u[i]
        /// </remarks>
        public static void Divide(double s, Vector4D u, ref Vector4D v) {
            v.X = s / u.X;
            v.Y = s / u.Y;
            v.Z = s / u.Z;
            v.W = s / u.W;
        }
        /// <summary>
        /// Multiplies a vector by a scalar.
        /// </summary>
        /// <param name="u">A <see cref="Vector4D"/> instance.</param>
        /// <param name="s">A scalar.</param>
        /// <returns>A new <see cref="Vector4D"/> containing the result.</returns>
        public static Vector4D Multiply(Vector4D u, double s) {
            return new Vector4D(u.X * s, u.Y * s, u.Z * s, u.W * s);
        }
        /// <summary>
        /// Multiplies a vector by a scalar and put the result in another vector.
        /// </summary>
        /// <param name="u">A <see cref="Vector4D"/> instance.</param>
        /// <param name="s">A scalar.</param>
        /// <param name="v">A <see cref="Vector4D"/> instance to hold the result.</param>
        public static void Multiply(Vector4D u, double s, ref Vector4D v) {
            v.X = u.X * s;
            v.Y = u.Y * s;
            v.Z = u.Z * s;
            v.W = u.W * s;
        }
        /// <summary>
        /// Calculates the dot product of two vectors.
        /// </summary>
        /// <param name="u">A <see cref="Vector4D"/> instance.</param>
        /// <param name="v">A <see cref="Vector4D"/> instance.</param>
        /// <returns>The dot product value.</returns>
        public static double DotProduct(Vector4D u, Vector4D v) {
            return (u.X * v.X) + (u.Y * v.Y) + (u.Z * v.Z) + (u.W * v.W);
        }
        /// <summary>
        /// Negates a vector.
        /// </summary>
        /// <param name="v">A <see cref="Vector4D"/> instance.</param>
        /// <returns>A new <see cref="Vector4D"/> instance containing the negated values.</returns>
        public static Vector4D Negate(Vector4D v) {
            return new Vector4D(-v.X, -v.Y, -v.Z, -v.W);
        }
        /// <summary>
        /// Tests whether two vectors are approximately equal using default tolerance value.
        /// </summary>
        /// <param name="v">A <see cref="Vector4D"/> instance.</param>
        /// <param name="u">A <see cref="Vector4D"/> instance.</param>
        /// <returns><see langword="true"/> if the two vectors are approximately equal; otherwise, <see langword="false"/>.</returns>
        public static bool ApproxEqual(Vector4D v, Vector4D u) {
            return ApproxEqual(v, u, MathFunctions.EpsilonD);
        }
        /// <summary>
        /// Tests whether two vectors are approximately equal given a tolerance value.
        /// </summary>
        /// <param name="v">A <see cref="Vector4D"/> instance.</param>
        /// <param name="u">A <see cref="Vector4D"/> instance.</param>
        /// <param name="tolerance">The tolerance value used to test approximate equality.</param>
        /// <returns><see langword="true"/> if the two vectors are approximately equal; otherwise, <see langword="false"/>.</returns>
        public static bool ApproxEqual(Vector4D v, Vector4D u, double tolerance) {
            return
                (
                (System.Math.Abs(v.X - u.X) <= tolerance) &&
                (System.Math.Abs(v.Y - u.Y) <= tolerance) &&
                (System.Math.Abs(v.Z - u.Z) <= tolerance) &&
                (System.Math.Abs(v.W - u.W) <= tolerance)
                );
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Scale the vector so that its length is 1.
        /// </summary>
        public void Normalize() {
            double length = GetLength();
            if (length == 0) {
                throw new DivideByZeroException("Trying to normalize a vector with length of zero.");
            }

            _x /= length;
            _y /= length;
            _z /= length;
            _w /= length;
        }
        /// <summary>
        /// Returns the length of the vector.
        /// </summary>
        /// <returns>The length of the vector. (Sqrt(X*X + Y*Y))</returns>
        public double GetLength() {
            return System.Math.Sqrt(_x * _x + _y * _y + _z * _z + _w * _w);
        }
        /// <summary>
        /// Returns the squared length of the vector.
        /// </summary>
        /// <returns>The squared length of the vector. (X*X + Y*Y)</returns>
        public double GetLengthSquared() {
            return (_x * _x + _y * _y + _z * _z + _w * _w);
        }
        /// <summary>
        /// Clamps vector values to zero using a given tolerance value.
        /// </summary>
        /// <param name="tolerance">The tolerance to use.</param>
        /// <remarks>
        /// The vector values that are close to zero within the given tolerance are set to zero.
        /// </remarks>
        public void ClampZero(double tolerance) {
            _x = MathFunctions.Clamp(_x, 0, tolerance);
            _y = MathFunctions.Clamp(_y, 0, tolerance);
            _z = MathFunctions.Clamp(_z, 0, tolerance);
            _w = MathFunctions.Clamp(_w, 0, tolerance);
        }
        /// <summary>
        /// Clamps vector values to zero using the default tolerance value.
        /// </summary>
        /// <remarks>
        /// The vector values that are close to zero within the given tolerance are set to zero.
        /// The tolerance value used is <see cref="MathFunctions.EpsilonD"/>
        /// </remarks>
        public void ClampZero() {
            _x = MathFunctions.Clamp(_x, 0);
            _y = MathFunctions.Clamp(_y, 0);
            _z = MathFunctions.Clamp(_z, 0);
            _w = MathFunctions.Clamp(_w, 0);
        }
        #endregion

        #region Overrides
        /// <summary>
        /// Returns the hashcode for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode() {
            return _x.GetHashCode() ^ _y.GetHashCode() ^ _z.GetHashCode() ^ _w.GetHashCode();
        }
        /// <summary>
        /// Returns a value indicating whether this instance is equal to
        /// the specified object.
        /// </summary>
        /// <param name="obj">An object to compare to this instance.</param>
        /// <returns><see langword="true"/> if <paramref name="obj"/> is a <see cref="Vector4D"/> and has the same values as this instance; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj) {
            if (obj is Vector4D) {
                Vector4D v = (Vector4D)obj;
                return (_x == v.X) && (_y == v.Y) && (_z == v.Z) && (_w == v.W);
            }
            return false;
        }

        /// <summary>
        /// Returns a string representation of this object.
        /// </summary>
        /// <returns>A string representation of this object.</returns>
        public override string ToString() {
            return string.Format("({0}, {1}, {2}, {3})", _x, _y, _z, _w);
        }
        #endregion

        #region Comparison Operators
        /// <summary>
        /// Tests whether two specified vectors are equal.
        /// </summary>
        /// <param name="u">The left-hand vector.</param>
        /// <param name="v">The right-hand vector.</param>
        /// <returns><see langword="true"/> if the two vectors are equal; otherwise, <see langword="false"/>.</returns>
        public static bool operator ==(Vector4D u, Vector4D v) {
            return ValueType.Equals(u, v);
        }
        /// <summary>
        /// Tests whether two specified vectors are not equal.
        /// </summary>
        /// <param name="u">The left-hand vector.</param>
        /// <param name="v">The right-hand vector.</param>
        /// <returns><see langword="true"/> if the two vectors are not equal; otherwise, <see langword="false"/>.</returns>
        public static bool operator !=(Vector4D u, Vector4D v) {
            return !ValueType.Equals(u, v);
        }

        /// <summary>
        /// Tests if a vector's components are greater than another vector's components.
        /// </summary>
        /// <param name="u">The left-hand vector.</param>
        /// <param name="v">The right-hand vector.</param>
        /// <returns><see langword="true"/> if the left-hand vector's components are greater than the right-hand vector's component; otherwise, <see langword="false"/>.</returns>
        public static bool operator >(Vector4D u, Vector4D v) {
            return (
                (u._x > v._x) &&
                (u._y > v._y) &&
                (u._z > v._z) &&
                (u._w > v._w));
        }
        /// <summary>
        /// Tests if a vector's components are smaller than another vector's components.
        /// </summary>
        /// <param name="u">The left-hand vector.</param>
        /// <param name="v">The right-hand vector.</param>
        /// <returns><see langword="true"/> if the left-hand vector's components are smaller than the right-hand vector's component; otherwise, <see langword="false"/>.</returns>
        public static bool operator <(Vector4D u, Vector4D v) {
            return (
                (u._x < v._x) &&
                (u._y < v._y) &&
                (u._z < v._z) &&
                (u._w < v._w));
        }
        /// <summary>
        /// Tests if a vector's components are greater or equal than another vector's components.
        /// </summary>
        /// <param name="u">The left-hand vector.</param>
        /// <param name="v">The right-hand vector.</param>
        /// <returns><see langword="true"/> if the left-hand vector's components are greater or equal than the right-hand vector's component; otherwise, <see langword="false"/>.</returns>
        public static bool operator >=(Vector4D u, Vector4D v) {
            return (
                (u._x >= v._x) &&
                (u._y >= v._y) &&
                (u._z >= v._z) &&
                (u._w >= v._w));
        }
        /// <summary>
        /// Tests if a vector's components are smaller or equal than another vector's components.
        /// </summary>
        /// <param name="u">The left-hand vector.</param>
        /// <param name="v">The right-hand vector.</param>
        /// <returns><see langword="true"/> if the left-hand vector's components are smaller or equal than the right-hand vector's component; otherwise, <see langword="false"/>.</returns>
        public static bool operator <=(Vector4D u, Vector4D v) {
            return (
                (u._x <= v._x) &&
                (u._y <= v._y) &&
                (u._z <= v._z) &&
                (u._w <= v._w));
        }
        #endregion

        #region Unary Operators
        /// <summary>
        /// Negates the values of the vector.
        /// </summary>
        /// <param name="v">A <see cref="Vector4D"/> instance.</param>
        /// <returns>A new <see cref="Vector4D"/> instance containing the negated values.</returns>
        public static Vector4D operator -(Vector4D v) {
            return Vector4D.Negate(v);
        }
        #endregion

        #region Binary Operators
        /// <summary>
        /// Adds two vectors.
        /// </summary>
        /// <param name="u">A <see cref="Vector4D"/> instance.</param>
        /// <param name="v">A <see cref="Vector4D"/> instance.</param>
        /// <returns>A new <see cref="Vector4D"/> instance containing the sum.</returns>
        public static Vector4D operator +(Vector4D u, Vector4D v) {
            return Vector4D.Add(u, v);
        }
        /// <summary>
        /// Adds a vector and a scalar.
        /// </summary>
        /// <param name="v">A <see cref="Vector4D"/> instance.</param>
        /// <param name="s">A scalar.</param>
        /// <returns>A new <see cref="Vector4D"/> instance containing the sum.</returns>
        public static Vector4D operator +(Vector4D v, double s) {
            return Vector4D.Add(v, s);
        }
        /// <summary>
        /// Adds a vector and a scalar.
        /// </summary>
        /// <param name="v">A <see cref="Vector4D"/> instance.</param>
        /// <param name="s">A scalar.</param>
        /// <returns>A new <see cref="Vector4D"/> instance containing the sum.</returns>
        public static Vector4D operator +(double s, Vector4D v) {
            return Vector4D.Add(v, s);
        }
        /// <summary>
        /// Subtracts a vector from a vector.
        /// </summary>
        /// <param name="u">A <see cref="Vector4D"/> instance.</param>
        /// <param name="v">A <see cref="Vector4D"/> instance.</param>
        /// <returns>A new <see cref="Vector4D"/> instance containing the difference.</returns>
        /// <remarks>
        ///	result[i] = v[i] - w[i].
        /// </remarks>
        public static Vector4D operator -(Vector4D u, Vector4D v) {
            return Vector4D.Subtract(u, v);
        }
        /// <summary>
        /// Subtracts a scalar from a vector.
        /// </summary>
        /// <param name="v">A <see cref="Vector4D"/> instance.</param>
        /// <param name="s">A scalar.</param>
        /// <returns>A new <see cref="Vector4D"/> instance containing the difference.</returns>
        /// <remarks>
        /// result[i] = v[i] - s
        /// </remarks>
        public static Vector4D operator -(Vector4D v, double s) {
            return Vector4D.Subtract(v, s);
        }
        /// <summary>
        /// Subtracts a vector from a scalar.
        /// </summary>
        /// <param name="v">A <see cref="Vector4D"/> instance.</param>
        /// <param name="s">A scalar.</param>
        /// <returns>A new <see cref="Vector4D"/> instance containing the difference.</returns>
        /// <remarks>
        /// result[i] = s - v[i]
        /// </remarks>
        public static Vector4D operator -(double s, Vector4D v) {
            return Vector4D.Subtract(s, v);
        }

        /// <summary>
        /// Multiplies a vector by a scalar.
        /// </summary>
        /// <param name="v">A <see cref="Vector4D"/> instance.</param>
        /// <param name="s">A scalar.</param>
        /// <returns>A new <see cref="Vector4D"/> containing the result.</returns>
        public static Vector4D operator *(Vector4D v, double s) {
            return Vector4D.Multiply(v, s);
        }
        /// <summary>
        /// Multiplies a vector by a scalar.
        /// </summary>
        /// <param name="v">A <see cref="Vector4D"/> instance.</param>
        /// <param name="s">A scalar.</param>
        /// <returns>A new <see cref="Vector4D"/> containing the result.</returns>
        public static Vector4D operator *(double s, Vector4D v) {
            return Vector4D.Multiply(v, s);
        }
        /// <summary>
        /// Divides a vector by a scalar.
        /// </summary>
        /// <param name="v">A <see cref="Vector4D"/> instance.</param>
        /// <param name="s">A scalar</param>
        /// <returns>A new <see cref="Vector4D"/> containing the quotient.</returns>
        /// <remarks>
        /// result[i] = v[i] / s;
        /// </remarks>
        public static Vector4D operator /(Vector4D v, double s) {
            return Vector4D.Divide(v, s);
        }
        /// <summary>
        /// Divides a scalar by a vector.
        /// </summary>
        /// <param name="v">A <see cref="Vector4D"/> instance.</param>
        /// <param name="s">A scalar</param>
        /// <returns>A new <see cref="Vector4D"/> containing the quotient.</returns>
        /// <remarks>
        /// result[i] = s / v[i]
        /// </remarks>
        public static Vector4D operator /(double s, Vector4D v) {
            return Vector4D.Divide(s, v);
        }
        #endregion

        #region Array Indexing Operator
        /// <summary>
        /// Indexer ( [x, y] ).
        /// </summary>
        public double this[int index] {
            get {
                switch (index) {
                    case 0:
                        return _x;
                    case 1:
                        return _y;
                    case 2:
                        return _z;
                    case 3:
                        return _w;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
            set {
                switch (index) {
                    case 0:
                        _x = value;
                        break;
                    case 1:
                        _y = value;
                        break;
                    case 2:
                        _z = value;
                        break;
                    case 3:
                        _w = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }

        }

        #endregion

        #region Conversion Operators
        /// <summary>
        /// Converts the vector to an array of double-precision floating point values.
        /// </summary>
        /// <param name="v">A <see cref="Vector4D"/> instance.</param>
        /// <returns>An array of double-precision floating point values.</returns>
        public static explicit operator double[] (Vector4D v) {
            double[] array = new double[4];
            array[0] = v.X;
            array[1] = v.Y;
            array[2] = v.Z;
            array[3] = v.W;
            return array;
        }
        /// <summary>
        /// Converts the vector to an array of double-precision floating point values.
        /// </summary>
        /// <param name="v">A <see cref="Vector4D"/> instance.</param>
        /// <returns>An array of double-precision floating point values.</returns>
        public static explicit operator DoubleArrayList(Vector4D v) {
            DoubleArrayList array = new DoubleArrayList(4);
            array.Add(v.X);
            array.Add(v.Y);
            array.Add(v.Z);
            array.Add(v.W);
            return array;
        }
        #endregion
    }

    #region Vector4DConverter class
    /// <summary>
    /// Converts a <see cref="Vector4D"/> to and from string representation.
    /// </summary>
    public class Vector4DConverter : ExpandableObjectConverter {
        /// <summary>
        /// Returns whether this converter can convert an object of the given type to the type of this converter, using the specified context.
        /// </summary>
        /// <param name="context">An <see cref="ITypeDescriptorContext"/> that provides a format context.</param>
        /// <param name="sourceType">A <see cref="Type"/> that represents the type you want to convert from.</param>
        /// <returns><b>true</b> if this converter can perform the conversion; otherwise, <b>false</b>.</returns>
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) {
            if (sourceType == typeof(string))
                return true;

            return base.CanConvertFrom(context, sourceType);
        }
        /// <summary>
        /// Returns whether this converter can convert the object to the specified type, using the specified context.
        /// </summary>
        /// <param name="context">An <see cref="ITypeDescriptorContext"/> that provides a format context.</param>
        /// <param name="destinationType">A <see cref="Type"/> that represents the type you want to convert to.</param>
        /// <returns><b>true</b> if this converter can perform the conversion; otherwise, <b>false</b>.</returns>
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) {
            if (destinationType == typeof(string))
                return true;

            return base.CanConvertTo(context, destinationType);
        }
        /// <summary>
        /// Converts the given value object to the specified type, using the specified context and culture information.
        /// </summary>
        /// <param name="context">An <see cref="ITypeDescriptorContext"/> that provides a format context.</param>
        /// <param name="culture">A <see cref="System.Globalization.CultureInfo"/> object. If a null reference (Nothing in Visual Basic) is passed, the current culture is assumed.</param>
        /// <param name="value">The <see cref="Object"/> to convert.</param>
        /// <param name="destinationType">The Type to convert the <paramref name="value"/> parameter to.</param>
        /// <returns>An <see cref="Object"/> that represents the converted value.</returns>
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType) {
            if ((destinationType == typeof(string)) && (value is Vector4D)) {
                Vector4D v = (Vector4D)value;
                return v.ToString();
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }
        /// <summary>
        /// Converts the given object to the type of this converter, using the specified context and culture information.
        /// </summary>
        /// <param name="context">An <see cref="ITypeDescriptorContext"/> that provides a format context.</param>
        /// <param name="culture">The <see cref="System.Globalization.CultureInfo"/> to use as the current culture. </param>
        /// <param name="value">The <see cref="Object"/> to convert.</param>
        /// <returns>An <see cref="Object"/> that represents the converted value.</returns>
        /// <exception cref="ParseException">Failed parsing from string.</exception>
        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value) {
            if (value.GetType() == typeof(string)) {
                return Vector4D.Parse((string)value);
            }

            return base.ConvertFrom(context, culture, value);
        }

        /// <summary>
        /// Returns whether this object supports a standard set of values that can be picked from a list.
        /// </summary>
        /// <param name="context">An <see cref="ITypeDescriptorContext"/> that provides a format context.</param>
        /// <returns><b>true</b> if <see cref="GetStandardValues"/> should be called to find a common set of values the object supports; otherwise, <b>false</b>.</returns>
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) {
            return true;
        }

        /// <summary>
        /// Returns a collection of standard values for the data type this type converter is designed for when provided with a format context.
        /// </summary>
        /// <param name="context">An <see cref="ITypeDescriptorContext"/> that provides a format context that can be used to extract additional information about the environment from which this converter is invoked. This parameter or properties of this parameter can be a null reference.</param>
        /// <returns>A <see cref="TypeConverter.StandardValuesCollection"/> that holds a standard set of valid values, or a null reference (Nothing in Visual Basic) if the data type does not support a standard set of values.</returns>
        public override System.ComponentModel.TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context) {
            StandardValuesCollection svc =
                new StandardValuesCollection(new object[5] { Vector4D.Zero, Vector4D.XAxis, Vector4D.YAxis, Vector4D.ZAxis, Vector4D.WAxis });

            return svc;
        }
    }
    #endregion


}
