//MP3 Main (console app version)
//This file contains the SimulatorMain with the Main method for the program.

//Complete the Main method. Do not add any new using directive, methods, or fields.

using System;

namespace SolarSystemSimulation
{
    class SimulatorMain
    {
        public static void Main()
        {
            PlanetarySystem planets = new PlanetarySystem(0);
            SimulationTimer timer = new SimulationTimer();
            bool running = false; //set to true when a simulation is running
            bool paused = false; //set to true when a simulation is paused

            Console.WriteLine("Welcome to the solar planet simulator! Select from the menu.");
            while (true)
            {
                Console.WriteLine();
                Console.Write("(s)tart, (p)ause, (r)esume, (g)et status, (q)uit? ");

                string choice;
                try
                {
                    choice = Console.ReadLine().Trim().ToLower();
                }
                catch (System.IO.IOException e)
                {
                    Console.WriteLine($"IO Exception: {e.Message}");
                    continue;
                }

                string result = "Please choose from the menu";

                if (choice.StartsWith("s"))
                {
                    /*
                     * Ask for:
                     * 1. n: number of planets
                     * 2. dt: simulation timer interval
                     * 3. duration: duration of simulation (in terms of how many intervals)
                     */
                    bool check;
                    string error = "";
                    int n, dt, duration, iterations;

                    do
                    {
                        error = "";
                        Console.Write("How many planets (In addition to the sun) [1 - 9]:  ");
                        check = GetInt(out n, 1, 9, ref error);
                        if (!error.Equals(""))
                        {
                            Console.WriteLine(error);
                        }
                    } while (!check);

                    do
                    {
                        error = "";
                        Console.Write("Simulation dt (ms) [1 - 1000]:  ");
                        check = GetInt(out dt, 1, 1000, ref error);
                        if (!error.Equals(""))
                        {
                            Console.WriteLine(error);
                        }
                    } while (!check);

                    do
                    {
                        error = "";
                        Console.Write("Simulation duration (how many dt's) [1 - 1000]  ");
                        check = GetInt(out iterations, 1, 1000, ref error);
                        if (!error.Equals(""))
                        {
                            Console.WriteLine(error);
                        }
                    } while (!check);

                    running = true;
                    duration = dt * iterations;
                    timer = new SimulationTimer();
                    planets = new PlanetarySystem(n);

                    timer.SetTimer(planets, duration, dt);
                    Console.WriteLine("A new simulation of " + n + " planets is initiated");
                }
                else if (choice.StartsWith("p"))
                {
                    if (running)
                    {
                        timer.Pause();
                        paused = true;
                        running = false;
                        Console.WriteLine("Simulation has pasued.");
                    }
                    else
                    {
                        Console.WriteLine("No simulation is running to be paused.");
                    }
                }
                else if (choice.StartsWith("r"))
                {
                    if (paused)
                    {
                        timer.Resume();
                        paused = false;
                        running = true;
                        Console.WriteLine("Simulation has resumed.");
                    }
                    else
                    {
                        Console.WriteLine("No simulation is paused to be resumed.");
                    }
                }
                else if (choice.StartsWith("g"))
                {
                    if (running)
                    {
                        string time = "Current Time: " + timer.GetSimulationTime() + "\n";
                        Console.WriteLine(time);

                        string status;
                        planets.GetCurrentState(out status);
                        Console.Write(status);
                    }
                    else
                    {
                        Console.WriteLine("No simulation is running.");
                    }
                }
                else if (choice.StartsWith("q"))
                {
                    break;
                }
                Console.WriteLine();
                Console.WriteLine(result);
            }
        }

        /// <summary>
        /// Gets an int from the command line within the range [min, max].
        /// If the provided num is not acceptable, str will contain an error message.
        /// </summary>
        /// <param name="num">Nummber received from the user and returned through the out argument.</param>
        /// <param name="min">Min acceptable range for num.</param>
        /// <param name="max">Max acceptable range for num.</param>
        /// <param name="str">Contains an error message if not successful.</param>
        /// <returns>true if successful, false otherwise.</returns>
        private static bool GetInt(out int num, int min, int max, ref string str)
        {
            if (int.TryParse(Console.ReadLine().Trim(), out num))
            {
                if (num >= min && num <= max)
                {
                    return true;
                }
                str = "Number outside range";
            }
            else
            {
                str = "Not an acceptable number";
            }
            return false;
        }
    }
}
