using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using COP.API.COPDBContext;
using Newtonsoft.Json.Linq;
namespace COP.API.DatabaseInterface
{
    public class DBImages
    {
        public bool AddImage(string imgUrl, string university, ref string errorMessage, ref long newid)
        {
            bool retVal = true;
            try
            {
                using (COPDBContext.monica_cnetContext context = new COPDBContext.monica_cnetContext())
                {


                    Image a = new Image();
                    a.Imgurl= imgUrl;
                    a.University = university;
                   

                    context.Image.Add(a);
                    context.SaveChanges();

                    newid = a.Id;
                }
                return retVal;
            }
            catch (Exception e)
            {
                errorMessage = "Database Excaption:" + e.Message + " " + e.StackTrace;
                return false;
            }
        }


        public bool DeleteImage(string imageId, ref string errorMessage)
        {
            bool retVal = true;
            try
            {
                using (COPDBContext.monica_cnetContext context = new COPDBContext.monica_cnetContext())
                {

                   
                    var loc = context.Image
                            .SingleOrDefault(b => b.Id == long.Parse(imageId));

                    if (loc == null)
                    {
                        errorMessage = "Non-Existing Location";
                        retVal = false;
                    }
                    else
                    {
                        context.Image.Remove(loc);
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

        public bool ListImages(string university, int take, ref string errorMessage, ref List<COP.API.Models.Image> results)
        {
            bool retVal = true;
            try
            {
                using (COPDBContext.monica_cnetContext context = new COPDBContext.monica_cnetContext())
                {

                    //Make query 
                    var imgs = (from d in context.Image
                                  where d.University == university
                                  orderby d.Id descending
                                  select new
                                  { id = d.Id, imgUrl = d.Imgurl, uni = d.University }
                                     ).Take(take).ToList();

                    if (imgs == null)
                    {
                        errorMessage = "No things";
                        retVal = false;
                    }
                    else
                        foreach (var th in imgs)
                        {
                            COP.API.Models.Image z = new Models.Image();
                   
                            z.Id = (int)th.id;
                            z.ImgUrl = th.imgUrl;
                            if(th.uni == "LBU")
                                z.University = Models.Image.UniversityEnum.LBU;
                            else if(th.uni == "LUU")
                                z.University = Models.Image.UniversityEnum.LUU;
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
    }
}
