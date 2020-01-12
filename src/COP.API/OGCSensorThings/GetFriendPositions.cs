using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Net;
using Newtonsoft.Json;
using System.IO;

namespace COP.API.OGCSensorThings
{
    public class GetFriendPositions
    {
        public  bool GetFriendPostion(string id, ref string lat, ref string lon, ref string lastSeen)
        {
            bool retval = true;
            string JsonResult = "";
            XmlDocument xDoc = null;
            string url = settings.gostServer + "Datastreams?$filter=substringof('868/Localization-Wristband/" + id + "',name)";
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
                JsonResult = reader.ReadToEnd();
                responseStream.Close();
                response.Close();

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
                        return false;
                    }
                }
                System.Console.WriteLine("Invokation error" +url + "" + exception.Message + " " + errorResponse);
            }
            

            xDoc = JsonConvert.DeserializeXmlNode(JsonResult, "Root");
            if (xDoc.SelectSingleNode("//Observations_x0040_iot.navigationLink") == null)
            {

                lat = "0.0";
                lon = "0.0";
                lastSeen = DateTime.MinValue.ToString("O");
                return true;
            }
            string observationUrl = xDoc.SelectSingleNode("//Observations_x0040_iot.navigationLink").InnerText + "?$top=1";
            observationUrl = observationUrl.Replace(":5050/gost_tivoli", ":8099");
            client = (HttpWebRequest)WebRequest.Create(observationUrl);
            try
            {
                client.Method = "GET";
                client.ContentType = "application/json";
                client.Accept = "application/json";

                client.Timeout = 2000;

                HttpWebResponse response = (HttpWebResponse)client.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                JsonResult  = reader.ReadToEnd();
                responseStream.Close();
                response.Close();

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
                        return false;
                    }
                }
                System.Console.WriteLine("Invokation error" + url + "" + exception.Message + " " + errorResponse);
            }

            

            xDoc = JsonConvert.DeserializeXmlNode(JsonResult, "Root");
            if (xDoc.SelectSingleNode("//lat") == null)
            {
                lat = "0.0";
                lon = "0.0";
                lastSeen = DateTime.MinValue.ToString("O");
                return true;
            }
             lat = xDoc.SelectSingleNode("//lat").InnerText;
             lon = xDoc.SelectSingleNode("//lon").InnerText;
            lastSeen = xDoc.SelectSingleNode("//resultTime").InnerText;



            return retval;
        }
    }
}
