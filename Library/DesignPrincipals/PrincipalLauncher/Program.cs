using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using DesignPrinter;
using DesignPrinter.Missives;

namespace PrincipalLauncher
{
    class Program
    {
        static void Main(string[] args)
        {

            var Machine = new WindowsMachine();
            var Response = Machine.StartMeUp();

            do
            {




            } while (true);



        }
    }
}
