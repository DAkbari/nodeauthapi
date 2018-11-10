using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testApiClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new RestClient("http://localhost:5000/api/");
            //client.Authenticator = new HttpBasicAuthenticator("username","pass");

            var request = new RestRequest("posts", Method.POST);

            //request.AddParameter("name", "value"); // adds to POST or URL querystring based on Method
            //request.AddUrlSegment("id", "123"); // replaces matching token in request.Resource

            // easily add HTTP Headers
            request.AddHeader("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyIjp7ImlkIjoxLCJ1c2VybmFtZSI6ImJyYWQiLCJlbWFpbCI6ImJyYWRAZ21haWwuY29tIn0sImlhdCI6MTU0MTg1ODk4N30.tGYuNpb75AJSDFHytAvOIHjJDzRdOSP3_dRFJGqzo-8");

            // add files to upload (works with compatible verbs)
            //request.AddFile(path);

            // execute the request
            IRestResponse response = client.Execute(request);
            var content = response.Content; // raw content as string
            Console.WriteLine(content);

        }
    }
}
