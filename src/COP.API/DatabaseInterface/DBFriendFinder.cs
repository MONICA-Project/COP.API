using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using COP.API.COPDBContext;
namespace COP.API.DatabaseInterface
{
    public class DBFriendFinder
    {

        public bool Register(string wbid, string nickname)
        {
            bool retVal = true;
            try
            {
                using (COPDBContext.monica_cnetContext context = new COPDBContext.monica_cnetContext())
                {


                    FriendfinderReg a = new FriendfinderReg();
                    a.Id = wbid;
                    a.NickName = nickname;
                    context.FriendfinderReg.Add(a);
                    context.SaveChanges();
                }
                return retVal;
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Database Exception:" + e.Message + " " + e.StackTrace);
                return false;
            }
        }


        public bool AddFriend(string wbid1, string wbid2)
        {
            bool retVal = true;
            try
            {
                using (COPDBContext.monica_cnetContext context = new COPDBContext.monica_cnetContext())
                {


                    Fffriends a = new Fffriends();
                    a.Friend1 = wbid1;
                    a.Friend2 = wbid2;
                    context.Fffriends.Add(a);
                    context.SaveChanges();


                    a = new Fffriends();
                    a.Friend2 = wbid1;
                    a.Friend1 = wbid2;
                    context.Fffriends.Add(a);
                    context.SaveChanges();
                }
                return retVal;
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Database Exception:" + e.Message + " " + e.StackTrace);
                return false;
            }
        }

        public bool FindFriend(string wbid1, ref Models.FriendFinderList friends)
        {
            bool retVal = true;
            try
            {
                using (COPDBContext.monica_cnetContext context = new COPDBContext.monica_cnetContext())
                {


                    var friendList = (from d in context.Fffriends
                                      join e in context.FriendfinderReg
                                      on d.Friend2 equals e.Id
                                      where d.Friend1 == wbid1
                                      select new
                                      { friendid = d.Friend2, nick = e.NickName }
                                        ).ToList();

                    OGCSensorThings.GetFriendPositions fpos = new OGCSensorThings.GetFriendPositions();
                    foreach (var f in friendList)
                    {
                        //673458
                        COP.API.Models.FriendFinder z = new Models.FriendFinder();
                        z.NickName = f.nick;
                        string strLat = "";
                        string strLon = "";
                        string LastSeen = "";

                        if (fpos.GetFriendPostion(f.friendid, ref strLat, ref strLon, ref LastSeen))
                        {
                            z.Lat = (decimal?) double.Parse(strLat, System.Globalization.CultureInfo.InvariantCulture);
                            z.Lon = (decimal?)double.Parse(strLon, System.Globalization.CultureInfo.InvariantCulture);
                            z.LastSeen = LastSeen;
                            friends.Add(z);
                        }
                    }
                }
                return true;

            }
            catch (Exception e)
            {
                System.Console.WriteLine("Database Exception:" + e.Message + " " + e.StackTrace);
                return false;
            }
        }

        public bool TranslateNick(string wbid1, ref string nick)
        {
            bool retVal = true;
            try
            {
                using (COPDBContext.monica_cnetContext context = new COPDBContext.monica_cnetContext())
                {


                    var friend = (from d in context.FriendfinderReg
                                 
                                      where d.Id == wbid1
                                      select new
                                      { friendid = d.Id, nick = d.NickName }
                                        ).ToList();


                    foreach (var f in friend)
                    {
                        nick = f.nick;
                     
                    }
                }
                return true;

            }
            catch (Exception e)
            {
                System.Console.WriteLine("Database Exception:" + e.Message + " " + e.StackTrace);
                return false;
            }
        }
        private int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
    }
}
