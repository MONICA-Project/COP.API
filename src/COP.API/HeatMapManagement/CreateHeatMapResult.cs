using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Xml;
using System.IO;
using Newtonsoft.Json;

namespace COP.API.HeatMapManagement
{
    public class CreateHeatMapResult
    {
        public bool GetHeatMapInfo(string filename, ref COP.API.Models.HeatMapImage res, ref string errorMessage)
        {
            try
            {
                //var client = new HttpClient(new HttpClientHandler { }, true);
                //client.DefaultRequestHeaders.Clear();
                //HttpResponseMessage httpResponse = null;
                //httpResponse = client.GetAsync("http://monappdwp4.monica-cloud.eu:5000/maps/latest").Result;
                //StreamReader reader = new StreamReader(httpResponse.Content.ReadAsStreamAsync().Result, System.Text.Encoding.UTF8);
                //var encoding = reader.CurrentEncoding;
                //string InnerText = reader.ReadToEnd();
                //XmlDocument xDoc = JsonConvert.DeserializeXmlNode(InnerText, "Root");
                string Json = "";
                using (COPDBContext.monica_cnetContext context = new COPDBContext.monica_cnetContext())
                {

                    //Find type
                    try
                    {
                        var obs = context.LatestObservation
                               .Single(b => b.Thingid == 16 && b.Datastreamid == "GOST/Datastreams(46)/Observations:crowd_density_global:1624");

                        Json = obs.Observationresult;


                    }
                    catch (Exception f)
                    {
                        errorMessage = "Heatmap failed";
                        return false;
                    }
                }

                XmlDocument xDoc = JsonConvert.DeserializeXmlNode(Json, "Root");
                HeatMapBuilder hmb = new HeatMapBuilder();
                hmb.CreateMapFile(xDoc, filename);

                res = new Models.HeatMapImage();
                //XmlNode xLatStart = xDoc.SelectSingleNode("//lat_0");
                //res.LatStart = decimal.Parse(xLatStart.InnerText, System.Globalization.CultureInfo.InvariantCulture);
                //XmlNode xLonStart = xDoc.SelectSingleNode("//lon_0");
                //res.LonStart = decimal.Parse(xLonStart.InnerText, System.Globalization.CultureInfo.InvariantCulture);
                //XmlNode xCellsize = xDoc.SelectSingleNode("//cellsize");
                //decimal cellsize = decimal.Parse(xCellsize.InnerText, System.Globalization.CultureInfo.InvariantCulture);
                //XmlNode xRow = xDoc.SelectSingleNode("//nrow");
                //int noOfRows = int.Parse(xRow.InnerText);
                //XmlNode xCol = xDoc.SelectSingleNode("//ncols");
                //int noOfCols = int.Parse(xCol.InnerText); XmlNode xLatStart = xDoc.SelectSingleNode("//lat_0");
                //res.LatStart = decimal.Parse(xLatStart.InnerText, System.Globalization.CultureInfo.InvariantCulture);

                res.LatStart = (decimal)45.091533;
                res.LonStart = (decimal)7.663375;
                res.RoatationDegrees = (decimal) 0.0;
              
                decimal cellsize = (decimal)0.0005;

                int noOfRows = 33;
              
                int noOfCols = 17;
                res.LatEnd = (decimal)45.092530;
                res.LonEnd = (decimal)7.669211;
             
                return true;
            }
            catch (Exception e)
            {
                errorMessage = e.Message + " " + e.Source;
                return false;
            }
        }

    }
}
