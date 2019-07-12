using Rsobies.NuBuilder;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Testunit
{
    class Program
    {
        static void Main(string[] args)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(@"C:\Users\rsobies\source\repos\RSCrypto\nuspec.bin", FileMode.Open);
            var spec = (NuSpec)formatter.Deserialize(stream);
            stream.Close();
        }
    }
}
