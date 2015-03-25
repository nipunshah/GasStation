// --------------------------------------------------------------------------------------------------------------------
// <copyright company="SomeCompany" file="ApiCalls.cs">
//   Copyright 2015
// </copyright>
// <summary>
//   API calls to endpoints
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GasStation
{
    using System.Net;

    /// <summary>
    /// The api calls.
    /// </summary>
    public class ApiCalls
    {
        /// <summary>
        /// Get end point response.
        /// </summary>
        /// <param name="url">
        /// Url for request
        /// </param>
        /// <returns>
        /// Webresponse from URL
        /// </returns>
        public static HttpWebResponse GetEndPointResponse(string url)
        {
            var webRequest = (HttpWebRequest)WebRequest.Create(url);
            var webResponse = (HttpWebResponse)webRequest.GetResponse();
            return webResponse;
        }
    }
}
