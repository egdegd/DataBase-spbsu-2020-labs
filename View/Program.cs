using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStorage.DataProviders;

namespace HW_13
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleClient client = new ConsoleClient();
            client.Run();
        }
    }
}
