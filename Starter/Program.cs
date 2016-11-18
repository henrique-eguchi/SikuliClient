using NETSikuliClient.Sikuli_REST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starter
{

    //Used for test purposes
    public class Program
    {
        public static void Main(string[] args)
        {
            
            Pattern p = null;
            Screen s = null;

            string remoto = "mymac";


            switch (remoto)
            {
                case "mymac":
                    p = new Pattern(@"..\..\..\NETSikuliClientTests\1478714104.png");
                    s = new Screen("200.160.12.10", 9000);
                    break;

                default:
                    //Local remote
                    p = new Pattern(@"..\..\..\NETSikuliClientTests\startwin10.png");
                    s = new Screen("localhost", 9000);
                    break;
            }
            
            s.Click(p, true);
        }
    }
}

