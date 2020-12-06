using System;
using System.IO;

/* AM6007 Assignment 3 - Oussama CHAHBOUNE - 120225721 */
namespace _0Assignment3
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isSIR = true; // SIR is chosen by default

            IOHandler ioh = new IOHandler(); // Instanciates IOHandler class

            Console.WriteLine("----------------------- Runge-Kutta Method -----------------------");
            Console.WriteLine("__________________________________________________________________");

            Console.WriteLine("\n----------------------- Model selection -----------------------\n");
            Console.WriteLine("For SIR, press 'A' ....... For another model, press 'B'");
            isSIR = ioh.ModelChoice(); // Chooses the model

            // Handle model choice
            // SIR chosen
            if (isSIR == true)
            {
                (Vector y0, double gamma, double beta) initTuple = ioh.ModelInit(); // Initializes SIR

                RungeKutta4 rk = new RungeKutta4();
                Vector solved = rk.Solve_RK4(FunctionStore.SIR, initTuple); // Solves system

                Console.WriteLine("S = " + solved[0]);
                Console.WriteLine("I = " + solved[1]);
                Console.WriteLine("R = " + solved[2]);

                string path = "../../../SIR_results.csv"; // Writes .csv file at /[project_folder]/test.csv

                ioh.OutputCSV(solved, path, isSIR);
            }
            // Other model chosen
            else
            {
                Console.WriteLine("/!\\ Other models not available /!\\"); // Not the point of the assignment
            }
        }
    }
}
