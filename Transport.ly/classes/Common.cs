using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport.ly.classes
{
    internal static class Common
    {

        public static void ProcessRequest(int StoryID)
        {
            try
            {

                switch (StoryID)
                {
                    case 1:
                        new Flight().ShowFlightSchedule();
                        break;
                    case 2:
                        new Order().ShowInventory();
                        break;
                    default:
                        Console.WriteLine("Invalid Input. The input value should be either 1 or 2");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
