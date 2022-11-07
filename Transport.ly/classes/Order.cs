using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Configuration;

namespace Transport.ly.classes
{
    internal class Order
    {
        public string OrderID { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
        public int FlightID { get; set; }
        public int DayOfFlight { get; set; }
        public string ArivalCity { get; set; } = string.Empty;

        public void ShowInventory()
        {
            try
            {
                List<Flight> Flights = new Flight().LoadFlightData();
                List<Order> Orders = PopulateOrders();

                Orders = CalculateConsignments(Airports.YYZ, Flights, Orders);
                Orders = CalculateConsignments(Airports.YYC, Flights, Orders);
                Orders = CalculateConsignments(Airports.YVR, Flights, Orders);

                DisplayResults(Orders);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void DisplayResults(List<Order> OrderCollection)
        {
            try
            {
                Console.WriteLine("\nDisplaying : Flight Inventory (Story #2) ******************************");

                foreach (Order order in OrderCollection)
                {
                    if (order.FlightID == 0)
                    {
                        Console.WriteLine($"order: {order.OrderID}, flightNumber: not scheduled");
                    }
                    else
                    {
                        Console.WriteLine($"order: {order.OrderID}, flightNumber: {order.FlightID}, departure: {order.Destination}, arrival: {order.ArivalCity}, day: {order.DayOfFlight}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private List<Order> CalculateConsignments(Airports Airport, List<Flight> Flights, List<Order> Orders)
        {
            try
            {
                List<Flight> DestinationFlights = (from Fl in Flights where Fl.ArivalCity == Airport.ToString() select Fl).ToList();
                int OrderCapacity = Orders.Where(x => x.Destination.Equals(Airport.ToString(), StringComparison.CurrentCultureIgnoreCase)).Count();
                int FlightCapacity = 0;
                int FlightID = 0;
                int DayOfFlight = 0;
                int FlightCounter = 0;
                int FlightDays = DestinationFlights.Count();
                int FlightDay = 0;
                int UpdateCounter = 0;

                for (int Counter = 0; Counter < Orders.Count; Counter++)
                {
                    if (Orders[Counter].Destination.Equals(Airport.ToString(), StringComparison.CurrentCultureIgnoreCase))
                    {
                        if (FlightCounter == 0)
                        {
                            FlightCapacity = DestinationFlights[FlightDay].BoxCapacity;
                            FlightID = DestinationFlights[FlightDay].FlightID;
                            DayOfFlight = DestinationFlights[FlightDay].DayOfFlight;
                        }

                        Orders[Counter].FlightID = FlightID;
                        Orders[Counter].DayOfFlight = DayOfFlight;
                        Orders[Counter].ArivalCity = Airport.ToString();

                        FlightCounter += 1;
                        UpdateCounter += 1;

                        if (UpdateCounter >= OrderCapacity) break;

                        if (FlightCounter == FlightCapacity)
                        {
                            if (FlightDay < DestinationFlights.Count)
                            {
                                FlightCounter = 0;
                                FlightDay += 1;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            return Orders;
        }

        private List<Order> PopulateOrders()
        {
            List<Order> orders = new List<Order>();

            try
            {
                string DataFileJson = AppDomain.CurrentDomain.BaseDirectory + "data\\" + ConfigurationManager.AppSettings["JsonDataFileName"];
                

                if (File.Exists(DataFileJson))
                {
                    using (StreamReader reader = new StreamReader(DataFileJson))
                    {
                        string JsonData = reader.ReadToEnd();
                        string PropertyName; string? Destination = String.Empty;
                        var OrderItems = JsonConvert.DeserializeObject<dynamic>(JsonData);

                        if (OrderItems != null)
                        {
                            JObject ObjectJson = JObject.Parse(JsonData);
                            foreach (var ObjectItem in ObjectJson)
                            {
                                PropertyName = (string)ObjectItem.Key;
                                Destination = JObject.Parse(ObjectItem.Value.ToString())[propertyName: "destination"].ToString();
                                orders.Add(new Order { OrderID = PropertyName, Destination = Destination });
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return orders;
        }

    }
}
