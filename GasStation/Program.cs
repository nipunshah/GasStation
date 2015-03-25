// --------------------------------------------------------------------------------------------------------------------
// <copyright company="SomeCompany" file="Program.cs">
//   Copyright 2015
// </copyright>
// <summary>
//   Get gas station information using API calls
// </summary>
//
// Disclaimers:
// - In the interest of time, I have not expanded all the fuel station classes
//      > These should ideally be checked into source control or as an interface for consistency
// - In the interest of time, I have not written detailed comments for each of the fuel station classes
// - The program below can fail and throw exception, no retry logic is implemented yet, this functionality can be built in here
// - However, the framework running tests should be responsible for the retry logic
// - Newtonsoft.json is used to parse the JSON since Visual Studio extension is available for the same.
// - In the interest of time, output is on console
// - In ideal case, output should be put into a well structured log that can be read and analyzed (for pass fail rate) later
//
// Findings:
// - There is no need to call second end point as the first end point will have the address too
// - However, since the interview question asked for 2 API calls, it has been implemented (search "ADDRESS: " to find how I can get address using 1 API call)
//
// How to run the test:
// - Open in Visual Studio (2012 used for development)
// - Get NuGet packages (Tools -> Nuget Package Manager -> Manage NuGet packages -> Search for 'Json' -> Install Json.Net
// - Compile
// - Run
//
// --------------------------------------------------------------------------------------------------------------------

namespace GasStation
{
    using System;
    using System.Configuration;
    using System.IO;
    using System.Net;
    
    /// <summary>
    /// Program to find fuel station information
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The partner id
        /// </summary>
        private static string pId;

        /// <summary>
        /// The base url.
        /// </summary>
        private static string baseUrl;

        /// <summary>
        /// The nearest station end point.
        /// </summary>
        private static string nearestStationEndPoint;

        /// <summary>
        /// The nearest station end point given Id
        /// </summary>
        private static string fuelStationFromIdEndpoint;

        /// <summary>
        /// Init variables
        /// </summary>
        /// <exception cref="Exception">
        /// Throws exception is settings cannot be read
        /// </exception>
        public static void Init()
        {
            // Read the appid, url, and endpoint from configuration
            pId = ReadSetting("AppId");
            if (pId == null)
            {
                throw new Exception("AppId could not be read from configuration file");
            }

            baseUrl = ReadSetting("BaseUrl");
            if (baseUrl == null)
            {
                throw new Exception("Base Url could not be read from configuration file");
            }

            nearestStationEndPoint = ReadSetting("FuelStationEndPointJson");
            if (nearestStationEndPoint == null)
            {
                throw new Exception("Fuel station end point could not be read from configuration file");
            }

            fuelStationFromIdEndpoint = ReadSetting("FuelStationFromIdEndpoint");
            if (fuelStationFromIdEndpoint == null)
            {
                throw new Exception("Fuel station ID end point could not be read from configuration file");
            }
        }

        /// <summary>
        /// The is valid response.
        /// </summary>
        /// <param name="response">
        /// The response.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool IsValidResponse(HttpWebResponse response)
        {
            return (response.StatusCode == HttpStatusCode.OK) && (response.ContentLength > 0);
        }

        /// <summary>
        /// Function to get address given an id
        /// </summary>
        /// <param name="id">
        /// Gas station id
        /// </param>
        /// <returns>
        /// Address of gas station
        /// </returns>
        public static string GetAddressFromId(int id)
        {
            var address = String.Empty;

            var getIdUrl = baseUrl + fuelStationFromIdEndpoint + id + @".json?api_key=" + pId; 
            Console.WriteLine("pUrl: " + getIdUrl);

            // Call the API
            var webResponse = ApiCalls.GetEndPointResponse(getIdUrl);
            if (IsValidResponse(webResponse))
            {
                var reader = new StreamReader(webResponse.GetResponseStream());
                string s = reader.ReadToEnd();
                address = JsonParser.ParseJsonResponseForAddress(s);
            }

            return address;
        }

        /// <summary>
        /// Read settings from App.Config
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <returns>
        /// value of the key
        /// </returns>
        public static string ReadSetting(string key)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                string result = appSettings[key] ?? "Not Found";
                return result;
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app settings");
                return null;
            }
        }

        /// <summary>
        /// Main program
        /// </summary>
        /// <param name="args">
        /// Arguments supplied by user (in this case, none)
        /// </param>
        public static void Main(string[] args)
        {
            // Define test case parameters
            const string CityName = "Austin";
            const string StateName = "TX";
            const string NetworkType = "ChargePoint+Network";
            try
            {
                // Initialize by getting common settings
                Init();

                // Set parameters for API call
                var apiKey = "api_key=" + pId;
                const string Location = "location=" + CityName;
                const string State = "state=" + StateName;
                const string Network = "ev_network=" + NetworkType;
                var parameters = apiKey + "&" + Location + "&" + State + "&" + Network;

                // Create the base url
                var url = baseUrl + nearestStationEndPoint + parameters;
                Console.WriteLine("pUrl: " + url);

                // Call the API
                var webResponse = ApiCalls.GetEndPointResponse(url);
                if (IsValidResponse(webResponse))
                {
                    // Status can be fine, check content length
                    if (webResponse.ContentLength > 0)
                    {
                        var reader = new StreamReader(webResponse.GetResponseStream());
                        var response = reader.ReadToEnd();
                        var gasStationId = JsonParser.ParseJsonResponse(response);
                        var address = GetAddressFromId(gasStationId);
                        var fullAddress = address + ", " + CityName + ", " + StateName;
                        Console.WriteLine("\n*** Found Address : " + fullAddress + " ***");
                    }
                    else
                    {
                        Console.WriteLine("Status ok, but content was empty");
                    }
                }
                else
                {
                    Console.WriteLine("Got error getting web response: " + webResponse.StatusCode);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception found: " + e.Message);
                Console.WriteLine("Press any key to exit...");
                Console.ReadLine();
            }
        }
    }
}
