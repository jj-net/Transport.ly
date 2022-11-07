using System;
using Transport.ly.classes;

namespace Transport.ly
{
    class Program
    {
        static void Main(string[] args)
        {
            string? InputValue;
            int StoryID;
            
            try
            {

                Console.WriteLine("Enter the story # (1 = Flight Schedule, 2 = Inventory)");
                InputValue = Console.ReadLine();

                if (InputValue != null)
                {
                    if (int.TryParse(InputValue, out StoryID))
                    {
                        Common.ProcessRequest(StoryID);
                    }
                    else
                    {
                        Console.WriteLine("Input value is not numeric. ");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }

                Console.WriteLine("\n****Press any key to exit***");
                Console.ReadLine();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        

    }
}