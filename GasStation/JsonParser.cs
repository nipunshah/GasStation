// --------------------------------------------------------------------------------------------------------------------
// <copyright company="SomeCompany" file="JsonParser.cs">
//   Copyright 2015
// </copyright>
// <summary>
//   Json Parser for response
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GasStation
{
    using System.Linq;
    using Newtonsoft.Json;

    class JsonParser
    {
        /// <summary>
        /// Parse json response.
        /// </summary>
        /// <param name="jsonResponse">
        /// string containing json
        /// </param>
        /// <returns>
        /// Gas station Id
        /// </returns>
        public static int ParseJsonResponse(string jsonResponse)
        {
            var response = JsonConvert.DeserializeObject<RootObject>(jsonResponse);
            var stations = response.fuel_stations;
            var oneStation = stations.Where(n => n.station_name == "HYATT AUSTIN");

            // ADDRESS: The below will also get the ID, no need to make a second call
            // var address = stations.Where(n => n.station_name == "HYATT AUSTIN").Select(m => m.street_address).FirstOrDefault();

            // Get the id
            var id = oneStation.Select(n => n.id).SingleOrDefault();
            return id;
        }

        /// <summary>
        /// Parse Json response to get the address
        /// </summary>
        /// <param name="jsonResponse">
        /// Response in json
        /// </param>
        /// <returns>
        /// Address as a string
        /// </returns>
        public static string ParseJsonResponseForAddress(string jsonResponse)
        {
            var response = JsonConvert.DeserializeObject<FuelStationAddress>(jsonResponse);
            var address = response.alt_fuel_station.street_address;
            return address;
        }
    }
}
