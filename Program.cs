using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace TestWebsiteUrls
{
    class TestUrl
    {
        public static string checkPageStatus (string url)
        {
            if (url == null)
                throw new ArgumentNullException("url");

            if (url.IndexOf(':') < 0)
                url = "http://" + url.TrimStart('/');

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = WebRequestMethods.Http.Head;

            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string statusDescription = response.StatusDescription;

                response.Close();

                return statusDescription;

            }
            catch (WebException)
            {
                return "Error:  Web Exception";
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string url = null;
            string pageStatus = null;

            StreamReader inputFile = new StreamReader("InputFile.txt");
            StreamWriter outputFile = new StreamWriter("OutputFile.txt");

            while (!inputFile.EndOfStream)
            {
                url = inputFile.ReadLine();

                pageStatus = TestUrl.checkPageStatus(url);

                outputFile.WriteLine(url + "\t" + pageStatus);

                //Console.WriteLine("Status of " + url + ": " + pageStatus);
                //Console.Read();
            }

            inputFile.Close();
            outputFile.Close();

        }
    }
}


/*string sURL = null;
string domain = null;
string protocol = null;

bool pageExists = false;

protocol = "http://www.";

            domain = "taraplacetreefarm.com";

            sURL = protocol + domain;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sURL);
request.Method = WebRequestMethods.Http.Head;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
pageExists = response.StatusCode == HttpStatusCode.OK;

                if (response != null)
                {
                    HttpStatusCode status = response.StatusCode;
string statusDescription = response.StatusDescription;

Console.WriteLine("Status Code:  " + status + Environment.NewLine);
                    Console.WriteLine("Status Description:  " + statusDescription + Environment.NewLine);
                    Console.WriteLine("Page Exists:  " + pageExists + Environment.NewLine);
                }

                Console.Read();
                response.Close();
            }
           /* catch (Exception e)
            {
                Console.WriteLine("Page Exists:  " + pageExists + Environment.NewLine);
                Console.WriteLine("An error occurred: '{0}'", e);          
                Console.Read();
            }*/
          /*  catch(System.Net.WebException e)
            {
                Console.WriteLine("Website does not exist.");
                Console.Read();
            }
    */