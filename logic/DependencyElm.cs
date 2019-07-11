using System;

namespace Rsobies.NuBuilder
{
    [Serializable]
    public class DependencyElm
    {
        public DependencyElm(string id, string version)
        {
            this.id = id;
            this.version = version;
        }
        public string id
        {
            get; set;
        }

        public string version
        {
            get;set;
        }
    }
}
