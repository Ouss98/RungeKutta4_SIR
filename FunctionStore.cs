using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace _0Assignment3
{
    // Class containing ODE function methods
    class FunctionStore
    {
        // Denition of SIR method that return a vector of size 3
        // Arguments: x, y, initialization tuple (y0, gamma, beta)
        public static Vector SIR(double x, Vector y, (Vector y0, double gamma, double beta) initTuple)
        {
            // Initializing gamma and beta from iniyTuple
            double gamma = initTuple.gamma;
            double beta = initTuple.beta;

            // (S, I, R) = (y[0], y[1], y[2])
            double S = y[0];
            double I = y[1];
            double R = y[2];

            // Compute the ODE values
            double S_dot = -beta * I * S;
            double I_dot = beta * I * S - gamma * I;
            double R_dot = gamma * I;

            Vector SIR_vect = new Vector(new double[3] { S_dot, I_dot, R_dot });
            return SIR_vect; // Return ODE values as vector
        }
    }
}
