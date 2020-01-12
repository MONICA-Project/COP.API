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
    public class NoiseCaptureMetaOGC
    {

        private int GetNumberOfUsers()
        {
            int retVal = 0;
            string url = "http://monappdwp3.monica-cloud.eu:8845/scral/v1.0/noise-app-manager/active-devices";
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
                string json = reader.ReadToEnd();
                responseStream.Close();
                response.Close();
                if (json != "")
                {
                    dynamic obs = JValue.Parse(json);
                    retVal = obs.registered_devices;
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
                        return 0;
                    }
                }
                System.Console.WriteLine("Invokation error" + url + "" + exception.Message + " " + errorResponse);
            }
            catch (Exception exception)
            {

                System.Console.WriteLine("Result parse error(Maybe)" + url + "" + exception.Message);
                retVal = 0;
            }
            return retVal;
        }

        public Models.NoiseCaptureMeta GetNCMeta()
        {
            Models.NoiseCaptureMeta ncm = null;

            ncm = new Models.NoiseCaptureMeta();
            ncm.NumberOfUsers = GetNumberOfUsers();

            string url = settings.gostServer + "/Datastreams?$filter=substringof('NOISE-APP-GEOSERVER/Smartphone/Leq-mean',name)&$expand=Observations";
            HttpWebRequest client = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                client.Method = "GET";
                client.ContentType = "application/json";
                client.Accept = "application/json";

                client.Timeout = 20000;

                HttpWebResponse response = (HttpWebResponse)client.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                string tmpStr = reader.ReadToEnd();
                responseStream.Close();
                response.Close();
                DateTime latestObs = DateTime.MinValue;
                int totalCount = 0;
                string latestLeq = "0.0";
                string latestPleasantness = "0";
                if (tmpStr != "")
                {
                    dynamic obs = JValue.Parse(tmpStr);
                    foreach(JObject dev in obs.value)
                    {
                        totalCount += ((JArray)dev["Observations"]).Count;
                        DateTime last = (DateTime) dev["Observations"][0]["phenomenonTime"];
                        if (last > latestObs)
                        {
                            latestObs = last;
                            latestLeq = (string) dev["Observations"][0]["result"]["leq_mean"];
                            latestPleasantness = (string)dev["Observations"][0]["result"]["pleasantness"];
                        }
                    }

                }

                ncm.NumberOfTracks = totalCount;
                ncm.LastPleasentness = latestPleasantness;
                ncm.LastLeqMean = latestLeq;
                ncm.Timestamp = latestObs;

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
                        return null;
                    }
                }
                System.Console.WriteLine("Invokation error" + url + "" + exception.Message + " " + errorResponse);
            }
            catch (Exception exception)
            {

                System.Console.WriteLine("Result parse error(Maybe)" + url + "" + exception.Message);
                ncm = null;
            }


            return ncm;
        }

    }
    
}
