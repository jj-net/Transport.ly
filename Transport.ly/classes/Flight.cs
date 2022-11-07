namespace Transport.ly.classes
{
    internal class Flight
    {
        public int FlightID { get; set; }
        public string OrderID { get; set; } = string.Empty;
        public string DepartureCity { get; set; } = string.Empty;
        public string ArivalCity { get; set; } = string.Empty;
        public int DayOfFlight { get; set; }
        public int BoxCapacity { get; set; }

        public void ShowFlightSchedule()
        {
            try
            {
                List<Flight> flights = LoadFlightData();

                foreach (Flight flight in flights)
                {
                    Console.WriteLine($"Flight: {flight.FlightID}, departure: {flight.DepartureCity}, arrival: {flight.ArivalCity}, day: {flight.DayOfFlight}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<Flight> LoadFlightData()
        {
            List<Flight> flights = new List<Flight>();

            try
            {
                flights.Add(new Flight { FlightID = 1, DepartureCity = Airports.YUL.ToString(), ArivalCity = Airports.YYZ.ToString(), DayOfFlight = 1, BoxCapacity = 20 });
                flights.Add(new Flight { FlightID = 2, DepartureCity = Airports.YUL.ToString(), ArivalCity = Airports.YYC.ToString(), DayOfFlight = 1, BoxCapacity = 20 });
                flights.Add(new Flight { FlightID = 3, DepartureCity = Airports.YUL.ToString(), ArivalCity = Airports.YVR.ToString(), DayOfFlight = 1, BoxCapacity = 20 });
                flights.Add(new Flight { FlightID = 4, DepartureCity = Airports.YUL.ToString(), ArivalCity = Airports.YYZ.ToString(), DayOfFlight = 2, BoxCapacity = 20 });
                flights.Add(new Flight { FlightID = 5, DepartureCity = Airports.YUL.ToString(), ArivalCity = Airports.YYC.ToString(), DayOfFlight = 2, BoxCapacity = 20 });
                flights.Add(new Flight { FlightID = 6, DepartureCity = Airports.YUL.ToString(), ArivalCity = Airports.YVR.ToString(), DayOfFlight = 2, BoxCapacity = 20 });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return flights;
        }
    }

}
