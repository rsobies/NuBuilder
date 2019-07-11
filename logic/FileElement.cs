using System;
using System.Collections.Generic;

namespace Rsobies.NuBuilder
{

    [Serializable]
    public class FileElement
    {      
        public FileElement()
        {
            DirsToRemove = new List<string>();
        }

        public string VirtualPath
        {
            get;set;
        }

        public string ModVirtualPath
        {
            get;set;
        }

        public string FullPath
        {
            get;set;
        }

        public string Name
        {
            set;get;
        }

        public string[] GetDirs()
        {
            char[] charSeparators = new char[] { '\\' };
            return VirtualPath.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
        }

        public override bool Equals(object obj)
        {
            if(!(obj is FileElement))
            {
                return false;
            }
            FileElement element =(FileElement) obj;
            return element.Name == Name &&
                element.VirtualPath == VirtualPath && 
                element.FullPath== FullPath;
        }

        public List<string> DirsToRemove
        {
            get;set;
        }

        public override int GetHashCode()
        {
           
            var hashCode = -1210281820;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(VirtualPath);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FullPath);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            return hashCode;
        }

        public override string ToString()
        {
            var dirs = GetDirs();
            string retPath = "";
            foreach(var dir in dirs)
            {
                if (!DirsToRemove.Contains(dir))
                {
                    retPath += dir + "\\";
                }
            }

            return retPath + Name;
        }
    }
}
