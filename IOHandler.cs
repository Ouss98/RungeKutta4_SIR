using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace _0Assignment3
{
    /* Input and Output handler class  */
    class IOHandler
    {
        // Method allowing user to choose the model
        public bool ModelChoice()
        {
            bool isSIR = true; // SIR is chosen by default

            string model = Console.ReadLine(); // Model is determined by user's input

            while (model != "A" || model != "B") // While wrong input, suggest the same choices
            {
                // SIR chosen
                if (model == "A")
                {
                    isSIR = true;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\nModel selected: 'SIR' (A)\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                }
                // Other model chosen
                else if (model == "B")
                {
                    isSIR = false;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\nModel selected: 'Other' (B)\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                }
                // Handle wrong input, and suggest same choices again
                else
                {
                    Console.WriteLine("\nPlease press either 'A' or 'B' to choose a model ...\n");
                    model = Console.ReadLine();
                }
            }
            return isSIR;
        }

        // SIR initialization
        // Method that return a tuple (Vector y0, double gamma, double beta)
        public (Vector, double, double) ModelInit()
        {
            // Default initial value for SIR, chosen to fit COVID-19 case
            /* Values inspired by https://doi.org/10.1371/journal.pone.0237832 */

            double gamma = 0.393;
            double beta = 0.615;
            Vector y0 = new Vector(new double[3] { (25216237.0 - 1.0) / 25216237.0,
                    1 / 25216237.0, 2.4 / 25216237.0 });

            Console.WriteLine("----------------------- Model initialization --s---------------------");            
            Console.WriteLine("\nFor COVID-19 values, press 'Y' ....... For custom values, press 'N'\n");
            Console.WriteLine("( The COVID-19 model is pre-initialized )");
            string valMod = Console.ReadLine();

            while (valMod != "Y" || valMod != "N") // While wrong input, suggest the same choices
            {
                // COVID-19 initialization chosen
                if (valMod == "Y")
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    // Shows values in console
                    Console.WriteLine("\nModel initialized with COVID-19 values\n");
                    Console.WriteLine("\nS0 = {0} ; I0 = {1} ; R0 = {2}\ngamma = {3} ; beta = {4}\n",
                        y0[0], y0[1], y0[2], gamma, beta);
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                }
                // Custom initialization chosen
                else if (valMod == "N")
                {
                    Console.WriteLine("\nPlease enter one numerical value for each parameter");
                    try
                    {
                        // The user inputs its initialization values
                        Console.WriteLine("\nGamma = ");
                        gamma = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("\nBeta = ");
                        beta = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("\nS0 = ");
                        y0[0] = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("\nI0 = ");
                        y0[1] = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("\nR0 = ");
                        y0[2] = Convert.ToDouble(Console.ReadLine());
                        Console.ForegroundColor = ConsoleColor.Cyan;

                        // Shows values in console
                        Console.WriteLine("\nModel initialized with custom values\n");
                        Console.WriteLine("\nS0 = {0} ; I0 = {1} ; R0 = {2}\ngamma = {3} ; beta = {4}\n",
                            y0[0], y0[1], y0[2], gamma, beta);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error {0}", e.Message);
                    }
                    break;
                }
                // Handle wrong input, and suggest same choices again
                else
                {
                    Console.WriteLine("\nPlease press either 'Y' or 'N' to choose the initialization ...\n");
                    valMod = Console.ReadLine();
                }
            }
            return (y0, gamma, beta); // Returns a tuple containing the initialization values.
        }

        // Output the result into a .csv file
        // General method taking into account other model, with size N vector
        public void OutputCSV(Vector v, string path, bool model)
        {
            Console.WriteLine("\nCreating a .csv file with the output in the following directory:");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(path + "\n");
            Console.ForegroundColor = ConsoleColor.White;
            
            var w = new StreamWriter(path);
            // SIR case
            if (model == true)
            {
                // Writes first line
                string firstLine = "S,I,R";
                w.WriteLine(firstLine);
            }
            // General use case
            else
            {
                // Writes first line
                StringBuilder sbf = new StringBuilder();
                List<string> firstList = new List<string>();
                string variable = "";
                for (int i = 0; i < v.VectorSize; i++)
                {
                    variable = string.Format("Variable[{0}]", i);
                    firstList.Add(variable); // Adds each variable to firstList
                }
                // Appends every element of firstList and separate them with ','
                var firstLine = sbf.Append(string.Join(",", firstList));
                w.WriteLine(firstLine);
            }

            // Writing results
            StringBuilder sbr = new StringBuilder();
            List<string> resList = new List<string>();
            string res = "";
            for (int i = 0; i < v.VectorSize; i++)
            {
                res = v[i].ToString();
                resList.Add(res); // Adds each res to resList
            }
            // Appends every element of firstList and separate them with ','
            var resLine = sbr.Append(string.Join(",", resList));
            w.WriteLine(resLine);
            w.Flush(); // Clears buffers
        }
    }
}
