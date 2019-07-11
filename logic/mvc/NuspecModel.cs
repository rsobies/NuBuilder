using EnvDTE;
using Microsoft.VisualStudio.Shell;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Linq;

namespace Rsobies.NuBuilder
{
    enum LibType { Unknown, Static, Dynamic };
    public class NuspecModel
    {
        private readonly Project project;

        private NuSpec _nuspec = null;

        private string _projectDir = null;

        private string ProjectDir
        {
            get
            {
                if (_projectDir != null)
                {
                    return _projectDir;
                }

                foreach (Property prop in project.Properties)
                {

                    if (prop.Name == "ProjectDirectory")
                    {
                        _projectDir = prop.Value.ToString();
                        return _projectDir;
                    }
                }

                return null;
            }
        }

        public NuSpec Spec
        {
            get
            {
                if (_nuspec != null)
                {
                    return _nuspec;
                }
                NuSpec spec;

                try
                {
                    IFormatter formatter = new BinaryFormatter();
                    Stream stream = new FileStream(String.Format("{0}nuspec.bin", ProjectDir), FileMode.Open, FileAccess.Read, FileShare.Read);
                    spec = (NuSpec)formatter.Deserialize(stream);
                    stream.Close();

                    if (spec.DirsToRemove != null)
                    {
                        foreach (var file in spec.Files)
                        {
                            file.DirsToRemove = spec.DirsToRemove;
                        }
                    }

                }
                catch (FileNotFoundException)
                {
                    spec = new NuSpec
                    {
                        Id = project.Name,
                        Title = project.Name,
                        Files = GetHeaders(),
                        Version = "1.0.0",
                        Tags = "native",
                        Description = "opis",
                        Relnotes = "relnotes"
                    };
                }

                _nuspec = spec;
                return _nuspec;
            }
        }

        private LibType _libType = LibType.Unknown;
        private LibType ProjectType
        {
            get
            {
                if (_libType != LibType.Unknown)
                {
                    return _libType;
                }

                var projectType = BuildCommand.GetConiguration(project);
                if (projectType == "DynamicLibrary")
                {
                    _libType = LibType.Dynamic;
                }
                else if (projectType == "StaticLibrary")
                {
                    _libType = LibType.Static;
                }

                return _libType;
            }
        }

        public void Validate(bool debug32, bool debug64, bool release32, bool release64)
        {
            if (debug32 && !File.Exists(Debug32Lib))
            {
                throw new ValidationException(String.Format("Cannot find {0}", Debug32Lib), LibTarget.Debug32);
            }

            if (debug64 && !File.Exists(Debug64Lib))
            {
                throw new ValidationException(String.Format("Cannot find {0}", Debug64Lib), LibTarget.Debug64);
            }

            if (release64 && !File.Exists(Release64Lib))
            {
                throw new ValidationException(String.Format("Cannot find {0}", Release64Lib), LibTarget.Release64);
            }

            if (release32 && !File.Exists(Release32Lib))
            {
                throw new ValidationException(String.Format("Cannot find {0}", Release32Lib), LibTarget.Release32);
            }

        }

        private string Release64Lib
        {
            get
            {
                return String.Format("{1}x64\\Release\\{0}", LibFile, ProjectDir);

            }
        }

        private string Debug64Lib
        {
            get
            {
                return String.Format("{1}x64\\Debug\\{0}", LibFile, ProjectDir);

            }
        }

        private string Release32Lib
        {
            get
            {
                return String.Format("{1}Release\\{0}", LibFile, ProjectDir);

            }
        }

        private string Debug32Lib
        {
            get
            {
                return String.Format("{1}Debug\\{0}", LibFile, ProjectDir);
            }
        }

        private string Release64Dll
        {
            get
            {
                return String.Format("{1}x64\\Release\\{0}", DllFile, ProjectDir);

            }
        }

        private string Debug64Dll
        {
            get
            {
                return String.Format("{1}x64\\Debug\\{0}", DllFile, ProjectDir);

            }
        }

        private string Release32Dll
        {
            get
            {
                return String.Format("{1}Release\\{0}", DllFile, ProjectDir);

            }
        }

        private string Debug32Dll
        {
            get
            {
                return String.Format("{1}Debug\\{0}", DllFile, ProjectDir);
            }
        }

        private string LibFile
        {
            get
            {
                return String.Format("{0}.lib", project.Name);
            }

        }

        private string DllFile
        {
            get
            {
                return String.Format("{0}.dll", project.Name);
            }
        }

        public NuspecModel(Project project) => this.project = project;

        List<DependencyElm> GetDependencies()
        {
            var depend = new List<DependencyElm>();
            //var dir = GetProjectDir();
            try
            {
                XDocument packDoc = XDocument.Load(ProjectDir + "packages.config");
                var packages = packDoc.Element("packages");

                foreach (var element in packages.Elements())
                {
                    depend.Add(new DependencyElm(element.Attribute("id").Value, element.Attribute("version").Value));

                }


            }
            catch (FileNotFoundException)
            {

            }

            return depend;
        }

        public List<FileElement> GetHeaders()
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            string empty = "";
            var headers = GetHeaders(project.ProjectItems, empty);


            return headers;
        }

        private List<FileElement> GetHeaders(ProjectItems items, string virtPath)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            var retList = new List<FileElement>();
            if (items.Count == 0)
            {
                return retList;
            }

            foreach (ProjectItem item in items)
            {
                Debug.WriteLine(item.Name);

                //to jest liść
                if (item.ProjectItems.Count == 0)
                {
                    bool bHeader = false;
                    var fileHeader = new FileElement();
                    bool bFull = false, bName = false;
                    foreach (Property prop in item.Properties)
                    {
                        if (!bHeader)
                        {
                            if (prop.Name == "Extension")
                            {
                                if (prop.Value.ToString() == ".h")
                                {
                                    bHeader = true;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }

                        if (prop.Name == "FullPath")
                        {
                            fileHeader.FullPath = prop.Value.ToString();
                            bFull = true;
                            if (bName)
                            {
                                break;
                            }
                        }

                        if (prop.Name == "Name")
                        {
                            fileHeader.Name = prop.Value.ToString();
                            bName = true;
                            if (bFull)
                            {
                                break;
                            }
                        }

                    }
                    if (bHeader)
                    {
                        fileHeader.VirtualPath = virtPath;
                        retList.Add(fileHeader);
                    }

                }
                else
                {
                    string newVirtual;
                    if (virtPath == "")
                    {
                        newVirtual = item.Name;
                    }
                    else
                    {
                        newVirtual = virtPath + "\\" + item.Name;
                    }
                    retList.AddRange(GetHeaders(item.ProjectItems, newVirtual));
                }
            }

            return retList;
        }

        public XDocument CreateTargets(string lib)
        {
            XNamespace aw = "http://schemas.microsoft.com/developer/msbuild/2003";
            XDocument doc = new XDocument(
                new XElement(aw + "Project",
                new XAttribute("ToolsVersion", "4.0"),
                    new XElement(aw + "ItemDefinitionGroup",
                        new XElement(aw + "ClCompile",
                            new XElement(aw + "AdditionalIncludeDirectories", @"$(MSBuildThisFileDirectory)..\..\build\native\include\;%(AdditionalIncludeDirectories)")
                ),
                        new XElement(aw + "Link",
                            new XElement(aw + "AdditionalLibraryDirectories", @"$(MSBuildThisFileDirectory)..\..\build\native\bin\$(PlatformTarget)\$(Configuration);%(AdditionalLibraryDirectories)"),
                            new XElement(aw + "AdditionalDependencies", String.Format("{0}%(AdditionalDependencies)", lib))
                        ))));
            //Debug.WriteLine(doc);
            return doc;
        }

        private void CreateFilesToBuild(NuSpec spec)
        {
            XNamespace aw = "http://schemas.microsoft.com/packaging/2013/01/nuspec.xsd";

            var files = new List<XElement>();

            if (spec.Debug32)
            {
                files.Add(new XElement(aw + "file",
                    new XAttribute("src", Debug32Lib),
                    new XAttribute("target", @"build\native\bin\x86\Debug")));

                if (ProjectType == LibType.Dynamic)
                {
                    files.Add(new XElement(aw + "file",
                        new XAttribute("src", Debug32Dll),
                        new XAttribute("target", @"build\native\bin\x86\Debug")));

                }

            }
            if (spec.Releas32)
            {
                files.Add(new XElement(aw + "file",
                new XAttribute("src", Release32Lib),
                new XAttribute("target", @"build\native\bin\x86\Release")));

                if (ProjectType == LibType.Dynamic)
                {
                    files.Add(new XElement(aw + "file",
                        new XAttribute("src", Release32Dll),
                        new XAttribute("target", @"build\native\bin\x86\Release")));
                }
            }
            if (spec.Debug64)
            {
                files.Add(new XElement(aw + "file",
                    new XAttribute("src", Debug64Lib),
                    new XAttribute("target", @"build\native\bin\x64\Debug")));

                if (ProjectType == LibType.Dynamic)
                {
                    files.Add(new XElement(aw + "file",
                        new XAttribute("src", Debug64Dll),
                        new XAttribute("target", @"build\native\bin\x64\Debug")));
                }
            }
            if (spec.Release64)
            {
                files.Add(new XElement(aw + "file",
                    new XAttribute("src", Release64Lib),
                    new XAttribute("target", @"build\native\bin\x64\Release")));

                if (ProjectType == LibType.Dynamic)
                {
                    files.Add(new XElement(aw + "file",
                    new XAttribute("src", Release64Dll),
                    new XAttribute("target", @"build\native\bin\x64\Release")));
                }
            }

            foreach (var file in spec.Files)
            {
                files.Add(new XElement(aw + "file",
                  new XAttribute("src", file.FullPath),
                  new XAttribute("target", @"build\native\include\" + file.ToString())));
            }

            var dependeciesList = GetDependencies();
            XDocument doc = new XDocument(
                new XElement(aw + "package",
                new XElement(aw + "metadata",
                new XElement(aw + "id", spec.Id),
                new XElement(aw + "title", spec.Title),
                 new XElement(aw + "version", spec.Version),
                 new XElement(aw + "authors", spec.Author),
                 new XElement(aw + "owners", spec.Owners),
                 new XElement(aw + "tags", spec.Tags),
                 new XElement(aw + "description", spec.Description),
                 new XElement(aw + "releaseNotes", spec.Relnotes),
                 new XElement(aw + "dependencies",
                 from el in dependeciesList
                 select new XElement(aw + "dependency",
                        new XAttribute("id", el.id),
                        new XAttribute("version", el.version)))),
                new XElement(aw + "files",
                    new XElement(aw + "file", new XAttribute("src", String.Format("{1}{0}.targets", spec.Id, ProjectDir)),
                    new XAttribute("target", String.Format("build\\native\\{0}.targets", spec.Id))),
                    files)

                ));

            doc.Save(GetNupecPath(spec.Id));

            var targets = CreateTargets(project.Name);
            targets.Save(String.Format("{1}{0}.targets", spec.Id, ProjectDir));

        }

        private string GetNupecPath(string id)
        {
            return String.Format("{0}{1}.nuspec", ProjectDir, id);

        }
        public bool BuildPackage(NuSpec spec)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            CreateFilesToBuild(spec);

            var nugetPath = String.Format("{0}nuget.exe", ProjectDir);
            if (!File.Exists(nugetPath))
            {
                var zipPath = String.Format("{0}nuget.zip", ProjectDir);

                File.WriteAllBytes(zipPath, Rsobies.NuBuilder.Properties.Resources.nuget);

                ZipFile.ExtractToDirectory(zipPath, ProjectDir);
            }

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(String.Format("{0}nuspec.bin", ProjectDir),
                        FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, spec);
            stream.Close();

            var firstProc = new System.Diagnostics.Process();
            firstProc.StartInfo.FileName = nugetPath;
            firstProc.StartInfo.RedirectStandardOutput = true;
            firstProc.StartInfo.Arguments = String.Format("pack {0} -OutputDirectory {1}", GetNupecPath(spec.Id), ProjectDir);
            firstProc.StartInfo.UseShellExecute = false;
            firstProc.EnableRaisingEvents = true;

            firstProc.Start();

            firstProc.WaitForExit();

            var output = firstProc.StandardOutput.ReadToEnd();

            Debug.WriteLine(output);
            if (output.IndexOf("Successfully created package") != -1)
            {
                return true;
            }


            return false;

        }
    }
}
