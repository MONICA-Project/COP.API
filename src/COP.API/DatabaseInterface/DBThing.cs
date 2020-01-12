using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using COP.API.COPDBContext;

namespace COP.API.DatabaseInterface
{
    public class DBThing
    {
        //name.Name, name.ThingTemplate,name.Description, name.Status, name.Lat,name.Lon, ref errorMessage, ref newThingID
        public bool AddThing(string thingName, string type, string description, int? status, decimal? lat,decimal? lon, ref string errorMessage, ref long newid)
        {
            bool retVal = true;
            try
            {
                using (COPDBContext.monica_cnetContext context = new COPDBContext.monica_cnetContext())
                {

                    //Find type 
                    var ThingType = context.ThingTemplates
                            .SingleOrDefault(b => b.Name == type);

                    if (ThingType == null)
                    {
                        errorMessage = "Non-Existing Role";
                        retVal = false;
                    }
                    else
                    {
                        Thing a = new Thing();
                        a.Name = thingName;
                        a.Templateid = ThingType.Thingtemplateid;
                        a.Description = description;
                        a.Status = (short)status;
                        a.Lat = (double)lat;
                        a.Lon = (double)lon;
                        a.Ogcid = "";
                       


                        context.Thing.Add(a);
                        context.SaveChanges();

                        newid = a.Thingid;
                    }
                }
                return retVal;
            }
            catch (Exception e)
            {
                errorMessage = "Database Excaption:" + e.Message + " " + e.StackTrace;
                return false;
            }
        }

        public bool DeleteThing(string thingId, ref string errorMessage)
        {
            bool retVal = true;
            try
            {
                using (COPDBContext.monica_cnetContext context = new COPDBContext.monica_cnetContext())
                {

                    //Find type 
                    var loc = context.Thing
                            .SingleOrDefault(b => b.Thingid == long.Parse(thingId));

                    if (loc == null)
                    {
                        errorMessage = "Non-Existing Location";
                        retVal = false;
                    }
                    else
                    {
                        context.Thing.Remove(loc);
                        context.SaveChanges();
                    }


                    //Insert role connection;
                }
                return retVal;
            }
            catch (Exception e)
            {
                errorMessage = "Database Excaption:" + e.Message + " " + e.StackTrace;
                return false;
            }

        }

        public bool ListThings(string thingType, ref string errorMessage, ref List<COP.API.Models.Thing> results)
        {
            bool retVal = true;
            try
            {
                using (COPDBContext.monica_cnetContext context = new COPDBContext.monica_cnetContext())
                {

                    //Make query 
                    var things = (from d in context.Thing
                                     join f in context.ThingTemplates
                                     on d.Templateid equals f.Thingtemplateid
                                     where f.Name == thingType
                                     select new
                                     { ogcid=d.Ogcid, id = d.Thingid, name = d.Name, descripton = d.Description, status = d.Status, lat = d.Lat, lon = d.Lon, ThingTemplate = f.Name }
                                     ).ToList();

                    if (things == null)
                    {
                        errorMessage = "No things";
                        retVal = false;
                    }
                    else
                        foreach (var th in things)
                        {
                            COP.API.Models.Thing z = new Models.Thing();
                            z.Name = th.name;
                            z.Id = (int)th.id;
                            z.Description = th.descripton;
                            z.Status = th.status;
                            z.Lat = (decimal?) th.lat;
                            z.Lon = (decimal?) th.lon;
                            z.ThingTemplate = th.ThingTemplate;
                            z.Ogcid = th.ogcid;
                            results.Add(z);

                        }



                    //Insert role connection;
                }
                return retVal;
            }
            catch (Exception e)
            {
                errorMessage = "Database Excaption:" + e.Message + " " + e.StackTrace;
                return false;
            }

        }

        public bool ListThingsWithObs(string thingType, int? noOfObservations, ref string errorMessage, ref List<COP.API.Models.ThingsWithObservation> results)
        {
            bool retVal = true;
            if (noOfObservations == null)
                noOfObservations = 1;
            try
            {
                using (COPDBContext.monica_cnetContext context = new COPDBContext.monica_cnetContext())
                {

                    //Make query 
                    var things = (from d in context.Thing
                                  join f in context.ThingTemplates
                                  on d.Templateid equals f.Thingtemplateid
                                  where f.Name == thingType
                                  orderby d.Name
                                  select new
                                  { ogcid = d.Ogcid, id = d.Thingid, name = d.Name, descripton = d.Description, status = d.Status, lat = d.Lat, lon = d.Lon, ThingTemplate = f.Name }
                                     ).ToList();

                    if (things == null)
                    {
                        errorMessage = "No things";
                        retVal = false;
                    }
                    else
                        foreach (var th in things)
                        {
                            COP.API.Models.ThingsWithObservation z = new Models.ThingsWithObservation();
                            z.Name = th.name;
                            z.Id = (int)th.id;
                            z.Description = th.descripton;
                            z.Status = th.status;
                            z.Lat = (decimal?)th.lat;
                            z.Lon = (decimal?)th.lon;
                            z.ThingTemplate = th.ThingTemplate;
                            z.Ogcid = th.ogcid;
                            DBObservation dbo = new DBObservation();
                            List<COP.API.Models.Observation> lo = new List<COP.API.Models.Observation>();
                            if (dbo.ListObs((int)th.id, (int)noOfObservations, ref errorMessage, ref lo))
                                z.Observations = lo;
                            results.Add(z);

                        }



                    //Insert role connection;
                }
                return retVal;
            }
            catch (Exception e)
            {
                errorMessage = "Database Excaption:" + e.Message + " " + e.StackTrace;
                return false;
            }

        }

        public bool FindThingFromId(string thingId, ref string errorMessage, ref COP.API.Models.Thing results)
        {
            bool retVal = true;
            try
            {
                using (COPDBContext.monica_cnetContext context = new COPDBContext.monica_cnetContext())
                {

                    //Make query 
                    var things = (from d in context.Thing
                                  join f in context.ThingTemplates
                                  on d.Templateid equals f.Thingtemplateid
                                  where d.Thingid == long.Parse(thingId)
                                  select new
                                  {
                                      ogcid=d.Ogcid,
                                      id = d.Thingid,
                                      name = d.Name,
                                      descripton = d.Description,
                                      status = d.Status,
                                      lat = d.Lat,
                                      lon = d.Lon,
                                      ThingTemplate = f.Name
                                  }
                                     ).ToList();

                    if (things == null)
                    {
                        errorMessage = "No things";
                        retVal = false;
                    }
                    else
                        {
                            results = new Models.Thing();
                            var th = things[0];
                        results.Name = th.name;
                        results.Id = (int)th.id;
                        results.Description = th.descripton;
                        results.Status = th.status;
                        results.Lat = (decimal?)th.lat;
                        results.Lon = (decimal?)th.lon;
                        results.Ogcid = th.ogcid;
                        results.ThingTemplate = th.ThingTemplate;
                       
                    }



                    //Insert role connection;
                }
                return retVal;
            }
            catch (Exception e)
            {
                errorMessage = "Database Excaption:" + e.Message + " " + e.StackTrace;
                return false;
            }

        }

        public bool FindThingFromIdWithObs(string thingId, int? noOfObservations,ref string errorMessage, ref COP.API.Models.ThingsWithObservation results)
        {
            bool retVal = true;
            if (noOfObservations == null)
                noOfObservations = 1;
            try
            {
                using (COPDBContext.monica_cnetContext context = new COPDBContext.monica_cnetContext())
                {

                    //Make query 
                    var things = (from d in context.Thing
                                  join f in context.ThingTemplates
                                  on d.Templateid equals f.Thingtemplateid
                                  where d.Thingid == long.Parse(thingId)
                                  select new
                                  {
                                      ogcid = d.Ogcid,
                                      id = d.Thingid,
                                      name = d.Name,
                                      descripton = d.Description,
                                      status = d.Status,
                                      lat = d.Lat,
                                      lon = d.Lon,
                                      ThingTemplate = f.Name
                                  }
                                     ).ToList();

                    if (things == null)
                    {
                        errorMessage = "No things";
                        retVal = false;
                    }
                    else
                    {
                        results = new Models.ThingsWithObservation();
                        var th = things[0];
                        results.Name = th.name;
                        results.Id = (int)th.id;
                        results.Description = th.descripton;
                        results.Status = th.status;
                        results.Lat = (decimal?)th.lat;
                        results.Lon = (decimal?)th.lon;
                        results.ThingTemplate = th.ThingTemplate;
                        results.Ogcid = th.ogcid;
                        DBObservation dbo = new DBObservation();
                        List<COP.API.Models.Observation> lo = new List<COP.API.Models.Observation>();
                        if (dbo.ListObs((int)th.id, (int)noOfObservations, ref errorMessage, ref lo))
                            results.Observations = lo;
                    }



                    //Insert role connection;
                }
                return retVal;
            }
            catch (Exception e)
            {
                errorMessage = "Database Excaption:" + e.Message + " " + e.StackTrace;
                return false;
            }

        }
    }
}
