using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore;

namespace COP.API
{
    /// <summary>
    /// Program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {

            //Read settings:
            string connstr = Environment.GetEnvironmentVariable("CONNECTION_STR");
            if (connstr == null || connstr == "")
            {
                System.Console.WriteLine("ERROR:Missing CONNECTION_STR env variable. Process Exit.");
            }
            else settings.ConnectionString = connstr;
            string urlPrefix = "/"+Environment.GetEnvironmentVariable("URL_PREFIX");
            
            settings.urlPrefix = urlPrefix;

            string mediaPath = Environment.GetEnvironmentVariable("MEDIA_PATH");
            if (mediaPath == null || mediaPath  == "")
            {
                System.Console.WriteLine("ERROR:Missing MEDIA_PATH env variable. Process Exit.");
            }
            else settings.mediaPath = mediaPath;

            string testToken = Environment.GetEnvironmentVariable("TEST_TOKEN");
            if (testToken == null || testToken == "")
            {
                System.Console.WriteLine("ERROR:Missing TEST_TOKEN env variable. Process Exit.");
            }
            else settings.testToken = testToken;

            string GOST_SERVER = Environment.GetEnvironmentVariable("GOST_SERVER");
            if (GOST_SERVER == null || GOST_SERVER == "")
            {
                System.Console.WriteLine("ERROR:Missing GOST_SERVER env variable. Process Exit.");
            }
            else settings.gostServer = GOST_SERVER;
            string gostPrefix = Environment.GetEnvironmentVariable("GOST_PREFIX");
            if (gostPrefix == null || gostPrefix == "")
            {
                System.Console.WriteLine("ERROR:Missing GOST_PREFIX env variable. Process Exit.");
            }
            else settings.gostPrefix = gostPrefix;

            string useGostObs = Environment.GetEnvironmentVariable("USE_GOSTOBS");
            if (useGostObs == null || useGostObs == "")
            {
                System.Console.WriteLine("ERROR:Missing USE_GOSTOBS env variable. Process Exit.");
            }
            else settings.useGostObs = bool.Parse(useGostObs);
            BuildWebHost(args).Run();
        }

        /// <summary>
        /// Build Web Host
        /// </summary>
        /// <param name="args"></param>
        /// <returns>Webhost</returns>
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
