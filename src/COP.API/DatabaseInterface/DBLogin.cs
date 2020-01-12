using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COP.API.DatabaseInterface
{
    public class DBLogin
    {
        public bool ValidateUserCredentials(ref string errorMessage, COP.API.Models.Login log)
        {
            bool retVal = false;
            try
            {
                using (COPDBContext.monica_cnetContext context = new COPDBContext.monica_cnetContext())
                {

                    //Find type 
                    var loc = context.UserAuth
                            .SingleOrDefault(b => b.Username == log.Uid && b.Userpassword == log.Pwd);

                    if (loc == null)
                    {
                        errorMessage = "Failed Authorization";
                        retVal = false;
                    }
                    else
                    {
                        retVal = true;
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
