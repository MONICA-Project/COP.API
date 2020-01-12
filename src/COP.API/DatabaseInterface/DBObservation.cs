using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;
using COP.API.COPDBContext;

namespace COP.API.DatabaseInterface
{
    public class DBObservation
    {
        public bool AddUpdateObservation(int? thingid, string streamid, DateTime? phenomentime, string Observationresult, int? personid, int? zoneid, ref string errorMessage, ref long newid)
        {
            bool retVal = true;

            using (COPDBContext.monica_cnetContext context = new COPDBContext.monica_cnetContext())
            {

                //Find type
                try
                {
                    var obs = context.LatestObservation
                           .Single(b => b.Thingid == thingid && b.Datastreamid == streamid);


                    obs.Thingid = (long)thingid;
                    obs.Datastreamid = streamid;
                    obs.Phenomentime = phenomentime;
                    obs.Personid = personid;
                    obs.Locationid = zoneid;
                    obs.Observationresult = Observationresult;

                    context.SaveChanges();

                }
                catch (Exception f)
                {
                    LatestObservation lo = new LatestObservation();
                    lo.Thingid = (long)thingid;
                    lo.Datastreamid = streamid;
                    lo.Phenomentime = phenomentime;
                    lo.Observationresult = Observationresult;
                    lo.Personid = personid;
                    lo.Locationid = zoneid;
                    context.LatestObservation.Add(lo);
                    context.SaveChanges();
                }
            }
            return retVal;
        }

        public bool ListObs(int thingId, int noOfObservations, ref string errorMessage, ref List<COP.API.Models.Observation> results)
        {
            bool retVal = true;
            try
            {
                using (COPDBContext.monica_cnetContext context = new COPDBContext.monica_cnetContext())
                {

                    //Make query 
                    var obs = (from d in context.LatestObservation  where d.Thingid == (long) thingId select d
                                     ).ToList();

                    if (obs == null || obs.Count() == 0)
                    {
                        errorMessage = "No things";
                        retVal = false;
                    }
                    else
                        foreach (var th in obs)
                        {
                            COP.API.Models.Observation z = new Models.Observation();
                            z.ThingId = (int) th.Thingid;
                            z.DatastreamId = th.Datastreamid;
                            z.Personid = th.Personid;
                            z.Zoneid = th.Locationid;
                            z.Type = th.Type;

                            if(th.Phenomentime.HasValue)
                            {
                                DateTime tmp = (DateTime) th.Phenomentime;
                                if (tmp.Kind == DateTimeKind.Unspecified)
                                    tmp = tmp.ToUniversalTime();
                                if (tmp.Kind == DateTimeKind.Local)
                                    tmp = tmp.ToUniversalTime();
                                z.PhenomenTime = tmp;
                            }
                            else
                                 z.PhenomenTime = th.Phenomentime;
                          
                            if (settings.useGostObs && th.Type != "SOUNDHEATMAP" && th.Type != "PEOPLEHEATMAP" && th.Type != "AGGREGATE")
                            {
                                string phenTime = "";
                                z.ObservationResult = OGCSensorThings.GetLatestObservation.LastObservation(th.Datastreamid, noOfObservations, ref phenTime);
                                if (phenTime != "")
                                {
                                    //if (!phenTime.Contains('Z'))
                                    //    phenTime = phenTime + ".000Z";
                                    z.PhenomenTime = DateTime.Parse(phenTime);
                                }
                            }
                            else
                                z.ObservationResult = th.Observationresult;
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

        public bool FindDataStreamId(int thingId, string streamType, ref string errorMessage, ref string datastreaminfo)
        {
            bool retVal = true;
            try
            {
                using (COPDBContext.monica_cnetContext context = new COPDBContext.monica_cnetContext())
                {

                    //Make query 
                    var obs = (from d in context.LatestObservation where d.Thingid == (long)thingId && d.Type.Contains(streamType) select d
                                     ).ToList();

                    if (obs == null || obs.Count() == 0)
                    {
                        errorMessage = "No things";
                        retVal = false;
                    }
                    else
                        foreach (var th in obs)
                        {

                            datastreaminfo = th.Datastreamid;

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

