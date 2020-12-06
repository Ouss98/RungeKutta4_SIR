using System;
using System.Collections.Generic;
using System.Text;

namespace _0Assignment3
{
    public class Vector
    {
        /* Variable */
        private readonly double[] _vector;

        /* Parameter for getting Vector[index] value 
         * or assigning a value to Vector[index] */
        public double this[int index]
        {
            get { return _vector[index]; }
            set { _vector[index] = value; }
        }

        /* Parameter for getting siz of a vector via Vector.VectorSize */
        public int VectorSize
        {
            get { return _vector.Length; }
        }

        /* Constructors */
        // Takes an array of doubles as an argument
        public Vector(double[] vector)
        {
            _vector = vector;
        }
        // Takes a size of type int as an argument
        public Vector(int size)
        {
            _vector = new double[size];
        }

        /* Methods */
        // Overloading + operator to handle 'Vector + Vector'
        public static Vector operator +(Vector x, Vector y)
        {
            double[] v0 = x._vector;
            double[] v1 = y._vector;
            double[] newVector = new double[v0.Length];
            for (int i = 0; i < v0.Length; i++)
            {
                newVector[i] = v0[i] + v1[i];
            }
            return new Vector(newVector);
        }

        // Overloading - operator to handle 'Vector - Vector'
        public static Vector operator -(Vector x, Vector y)
        {
            double[] v0 = x._vector;
            double[] v1 = y._vector;
            double[] newVector = new double[v0.Length];
            for (int i = 0; i < v0.Length; i++)
            {
                newVector[i] = v0[i] - v1[i];
            }
            return new Vector(newVector);
        }

        // Overloading * operator to handle 'Vector * Vector'
        public static double operator *(Vector x, Vector y)
        {
            double[] v0 = x._vector;
            double[] v1 = y._vector;
            double scalar = 0;
            for (int i = 0; i < v0.Length; i++)
            {
                scalar += v0[i] * v1[i];
            }
            return scalar;
        }
        // Overloading * operator to handle 'double * Vector'
        public static Vector operator *(double x, Vector y)
        {
            double[] v1 = y._vector;
            double[] newVector = new double[v1.Length];
            for (int i = 0; i < v1.Length; i++)
            {
                newVector[i] = x * v1[i];
            }
            return new Vector(newVector);
        }
    }
}
