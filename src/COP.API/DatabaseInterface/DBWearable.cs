using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;
using COP.API.COPDBContext;

namespace COP.API.DatabaseInterface
{
    public class DBWearable
    {
        public bool AddWearable(int? personid, int? thingid, ref string errorMessage, ref long newid)
        {
            bool retVal = true;
            try
            {
                using (COPDBContext.monica_cnetContext context = new COPDBContext.monica_cnetContext())
                {

                    //Find type 

                    PersonThings a = new PersonThings();
                    a.Personid = (int)personid;
                    a.Thingid = (int)thingid;



                    context.PersonThings.Add(a);
                    context.SaveChanges();

                    newid = 0;

                }
                return retVal;
            }
            catch (Exception e)
            {
                errorMessage = "Database Excaption:" + e.Message + " " + e.StackTrace;
                return false;
            }
        }

        public bool DeleteWearable(string personid, string thingid, ref string errorMessage)
        {
            bool retVal = true;
            try
            {
                using (COPDBContext.monica_cnetContext context = new COPDBContext.monica_cnetContext())
                {

                    //Find type 
                    var loc = context.PersonThings
                            .SingleOrDefault(b => b.Personid == long.Parse(personid) && b.Thingid == long.Parse(thingid)
                            );

                    if (loc == null)
                    {
                        errorMessage = "Non-Existing WEARABLE";
                        retVal = false;
                    }
                    else
                    {
                        context.PersonThings.Remove(loc);
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

        public bool ListWearables(ref string errorMessage, ref List<COP.API.Models.Wearable> results)
        {
            bool retVal = true;
            try
            {
                using (COPDBContext.monica_cnetContext context = new COPDBContext.monica_cnetContext())
                {



                    foreach (var loc in context.PersonThings)
                    {
                        COP.API.Models.Wearable z = new Models.Wearable();
                        z.PersonId = loc.Personid;
                        z.ThingId = (int?)loc.Thingid;
                        z.Timestamp = loc.Timepoint;
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

        public bool WearablesPersonIdGet(string wbid, ref string errorMessage, ref List<COP.API.Models.Wearable> results)
        {
            bool retVal = true;
            try
            {
                using (COPDBContext.monica_cnetContext context = new COPDBContext.monica_cnetContext())
                {

                    //Make query 
                    var pp = (from d in context.Thing
                              where d.Ogcid == wbid
                              select d);

                    if (pp == null || pp.Count() == 0)
                    {
                        errorMessage = "Non existing wearable:" + wbid;
                        retVal = false;
                    }
                    else
                    {
                        results = new List<Models.Wearable>();
                        foreach (var p in pp)
                        {
                            var wearable = (from a in context.Thing
                                            join h in context.PersonThings
                                            on a.Thingid equals h.Thingid
                                            where a.Thingid == p.Thingid
                                            select h);
                            foreach (var obs in wearable)
                            {
                                COP.API.Models.Wearable wb = new Models.Wearable();
                                wb.PersonId = obs.Personid;
                                wb.ThingId = (int)obs.Thingid;
                                wb.Timestamp = obs.Timepoint;

                                results.Add(wb);


                            }

                        }
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
