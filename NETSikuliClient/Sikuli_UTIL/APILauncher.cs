﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace NETSikuliClient.Sikuli_UTIL
{
    [Obsolete("Not used anymore", true)]
    public class APILauncher
    {
        private Process APIProcess;
        private ProcessStartInfo APIProcessStartInfo;
        public String API_Output;

        private String APIJar;
        private String WorkingDir;
        private String APIPath;
		private String JarReleaseAddress;

        public APILauncher(bool Windowless = false)
        {
            APIJar = "sikulirestapi-1.0.jar";
			JarReleaseAddress = "http://sourceforge.net/projects/sikulirestapi/files/sikulirestapi-1.0.jar/download";
            WorkingDir = Directory.GetCurrentDirectory();
            APIPath = Path.Combine(WorkingDir, APIJar);
            if (Windowless == false)
            {
                APIProcessStartInfo = new ProcessStartInfo("java", "-jar \"" + APIPath + "\"");
            }
            else
            {
                APIProcessStartInfo = new ProcessStartInfo("javaw", "-jar \"" + APIPath + "\"");
            }
            APIProcess = new Process();
            APIProcess.StartInfo = APIProcessStartInfo;

            //Console.WriteLine("API PATH: " + APIPath);
            //Console.WriteLine("java -jar \"" + APIPath + "\"");
        }

        public void Start()
        {
			VerifyJarExists();
			Util.Log.WriteLine("Starting jetty server...");
            APIProcess.Start();
        }

        public void Stop()
        {
			Util.Log.WriteLine("Stopping jetty server...");
            APIProcess.Kill();
			Util.Log.WriteLine("Jetty server stopped!");
			Util.Log.WriteLine("Client log for this test run can be located at: "+Util.Log.LogPath);
			Util.Log.WriteLine("Exiting...");
        }
		
		public void VerifyJarExists()
		{
			if(File.Exists(APIPath))
			{
				Util.Log.WriteLine("Jar already downloaded, launching jetty server...");
			}
			else
			{
				Util.Log.WriteLine("Jar not downloaded, downloading jetty server jar from SourceForge...");
				WebClient client = new WebClient();
				client.DownloadFile(JarReleaseAddress,APIPath);
				Util.Log.WriteLine("File downloaded!");
			}
		}
    }
}
