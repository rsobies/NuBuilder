using System;
using System.Collections.Generic;

namespace Rsobies.NuBuilder
{
    public enum LibTarget { Debug32, Debug64, Release32, Release64};
    [Serializable]
    public class NuSpec
    {
        public NuSpec()
        {
            //dependencies = new List<DependencyElm>();
            Files = new List<FileElement>();
            DirsToRemove = new List<string>();
            Debug64 = true;
            Debug32 = true;
            Release64 = true;
            Releas32 = true;
        }

        public bool Debug32
        {
            get;set;
        }

        public bool Debug64
        {
            get;set;
        }

        public bool Releas32
        {
            get;set;
        }

        public bool Release64
        {
            get;set;
        }

       
        public List<string> DirsToRemove
        {
            get; set;
        }

        public string Owners
        {
            get;set;
        }


        public string NugetPath
        {
            get;set;
        }
      
        public string Id
        {
            get; set;
        }

        public string Author
        {
            get; set;
        }

        public string Tags
        {
            get; set;
        }

        public string Relnotes
        {
            get; set;
        }

        public string Description
        {
            get; set;
        }

        public string Version
        {
            get; set;
        }

        public string Title
        {
            get; set;
        }

        public List<FileElement> Files
        {
            get; set;
        }
    }
}
