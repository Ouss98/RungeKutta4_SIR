using System;
using System.Collections.Generic;
using System.Text;

namespace _0Assignment3
{
    // Delegate of ODE functions with args double x, Vector y and 
    // initialization tuple (Vector y0, double gamma, double beta)
    public delegate Vector odeFunc(double x, Vector y, (Vector, double, double) initTuple);

    // Class containing 4th order Runge-Kutta method
    class RungeKutta4
    {
        private readonly double h = 0.038; // Every 2 weeks ( 14 / 365.25 )
        private int nbSteps = 500;
        public double x0 = 0;

        public double[] xvals = new double[501];
        public Vector[] yvals = new Vector[501];

        // Definition of 4th order Runge-Kutta method
        // Arguments: ODE function f and initialization tuple
        public Vector Solve_RK4(odeFunc f, (Vector y0, double gamma, double beta) initTuple)
        {
            double x;
            Vector y0 = initTuple.y0; // Initializes y0 with either the default values, either the user's 
            int vectSize = y0.VectorSize; // Gets the size of the initialization vector
            
            Vector k1, k2, k3, k4 = new Vector(vectSize);
            Vector yj, yjp1 = new Vector(vectSize);

            xvals[0] = x = x0;
            yvals[0] = yj = y0;

            for (int i = 1; i <= nbSteps; i++)
            {
                // Compute k1, k2, k3, k4 vectors
                k1 = h * f(x, yj, initTuple);

                k2 = h * f(x + 0.5 * h, yj + 0.5 * k1, initTuple);

                k3 = h * f(x + 0.5 * h, yj + 0.5 * k2, initTuple);

                k4 = h * f(x + h, yj + k3, initTuple);

                // Update yj and x
                yjp1 = yj + 1.0 / 6.0 * (k1 + 2 * k2 + 2 * k3 + k4);
                x += h;
                xvals[i] = x;
                yvals[i] = yjp1;
                yj = yjp1;

            }
            return yj;
        }
    }
}
