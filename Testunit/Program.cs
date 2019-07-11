using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using VSIXProject1;

namespace Testunit
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"C:\Users\rsobies\source\repos\StaticLib1\StaticLib1.vcxproj");
            var element = doc.DocumentElement.GetElementsByTagName("PropertyGroup");      
            var el=(XmlElement)element[0];
            var items=el.GetElementsByTagName("RootNamespace");
            var projectType=items[0].InnerText;
            NuSpec spec = new NuSpec();
            spec.Id = "mojalib";
            spec.Author = "rsobies";
            FileElement file = new FileElement();
            file.VirtualPath = "headers\\dir\\dir2\\dir3";
            file.DirsToRemove.Add("dir");
            file.DirsToRemove.Add("dir2");
            
            var dir=file.ToString();
        }
    }
}
