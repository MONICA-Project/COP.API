using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace COP.API.OGCSensorThings
{
    public static class GetLatestObservation
    {
        /// <summary>
        /// Gets the latest value
        /// </summary>
        /// <param name="datastream"></param>
        /// <returns></returns>
        public static string LastObservation(string datastream, int noOfObservations, ref string phenomenTime)
        {
            string retVal = "";
            string url = settings.gostServer + datastream.Substring(0, datastream.IndexOf(':')).Replace(settings.gostPrefix,"") + "?$top=" + noOfObservations.ToString();
            HttpWebRequest client = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                client.Method = "GET";
                client.ContentType = "application/json";
                client.Accept = "application/json";

                client.Timeout = 2000;

                HttpWebResponse response = (HttpWebResponse)client.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                retVal = reader.ReadToEnd();
                responseStream.Close();
                response.Close();
                if (retVal != "")
                {
                    dynamic obs = JValue.Parse(retVal);
                    if(noOfObservations == 1 && retVal != "[]")
                        retVal = obs.value[0].ToString();
                    if(retVal != "[]")
                    {
                        DateTime tmp;
                        tmp = obs.value[0].phenomenonTime;
                        phenomenTime = tmp.ToString("O");
                    }

                }
                

            }
            catch (WebException exception)
            {
                string errorResponse = "";
                //read the response.

                if (exception.Response != null)
                {
                    Stream errRes = exception.Response.GetResponseStream();
                    if (errRes != null)
                    {

                        StreamReader sr = new StreamReader(errRes, true);

                        errorResponse = sr.ReadToEnd();
                        errRes.Close();
                        return "";
                    }
                }
                System.Console.WriteLine("Invokation error" + url + "" + exception.Message + " " + errorResponse);
            }
            catch (Exception exception)
            {
                
                System.Console.WriteLine("Result parse error(Maybe)" + url + "" + exception.Message );
                retVal = "";
            }
            return retVal;
        }
    }
}
