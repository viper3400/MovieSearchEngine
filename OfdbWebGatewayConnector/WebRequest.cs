using System;
using System.IO;
using System.Net;



namespace OfdbWebGatewayConnector
{
    /// <summary>
    /// Class for handeling generic WebRequests
    /// </summary>
    public class GenericWebRequest
    {
        public string GetResponse(string url)
        {
            // Create a request for the URL. 		
            WebRequest request = WebRequest.Create(url);
            // If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials;
            // Get the response.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            // Throw an exception if the response is not ok.
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception(String.Format(
                "Server error (HTTP {0}: {1}).",
                response.StatusCode,
                response.StatusDescription));
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream,System.Text.Encoding.UTF8, true);
            // Read from reader and fill up result
            string result = reader.ReadToEnd();
            // Cleanup the streams and the response.
            reader.Close();
            dataStream.Close();
            response.Close();
            // Return the xmlDocument.
            return result;
        }

    }
}
