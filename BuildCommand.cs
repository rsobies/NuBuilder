using System;
using System.ComponentModel.Design;
using System.Threading.Tasks;
using System.Xml;
using EnvDTE;
using Microsoft.VisualStudio.Shell;

namespace Rsobies.NuBuilder
{
    /// <summary>
    /// Command handler
    /// </summary>
    internal sealed class BuildCommand
    {
        /// <summary>
        /// Command ID.
        /// </summary>
        public const int CommandId = 0x0100;

        /// <summary>
        /// Command menu group (command set GUID).
        /// </summary>
        public static readonly Guid CommandSet = new Guid("215364b9-f439-4184-9e52-b9498af96b81");

        /// <summary>
        /// VS Package that provides this command, not null.
        /// </summary>
        private readonly AsyncPackage package;

        /// <summary>
        /// Initializes a new instance of the <see cref="BuildCommand"/> class.
        /// Adds our command handlers for menu (commands must exist in the command table file)
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        /// <param name="commandService">Command service to add command to, not null.</param>
        private BuildCommand(AsyncPackage package, OleMenuCommandService commandService)
        {
            this.package = package ?? throw new ArgumentNullException(nameof(package));
            commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));

            var menuCommandID = new CommandID(CommandSet, CommandId);
            var menuItem = new OleMenuCommand(this.Execute, menuCommandID);
            menuItem.BeforeQueryStatus += OnBeforeStatus;
            commandService.AddCommand(menuItem);
        }

        private Project getActivProject()
        {
            DTE dte = (DTE)Package.GetGlobalService(typeof(DTE));
            Array activeSolutionProjects = dte.ActiveSolutionProjects as Array;
            
            return activeSolutionProjects.GetValue(0) as Project;
            
        }

        public static string GetConiguration(Project project)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(project.FullName);
            var elements = doc.DocumentElement.GetElementsByTagName("PropertyGroup");
            var elelement = (XmlElement)elements[1];
            var items = elelement.GetElementsByTagName("ConfigurationType");
            var projectType = items[0].InnerText;

            return projectType;
        }

        private void OnBeforeStatus(object sender, EventArgs e)
        {
            
            var project = getActivProject();
            //project.ConfigurationManager.ActiveConfiguration.Type
            var cmd = (OleMenuCommand)sender;

           
            var projectType = BuildCommand.GetConiguration(project);
            if (project.FileName.IndexOf(".vcxproj") != -1 &&
                (projectType == "DynamicLibrary" ||
                projectType == "StaticLibrary"))
            {
                cmd.Visible = true;
            }
            else
            {
                cmd.Visible = false;
            }
        }

        /// <summary>
        /// Gets the instance of the command.
        /// </summary>
        public static BuildCommand Instance
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the service provider from the owner package.
        /// </summary>
        private Microsoft.VisualStudio.Shell.IAsyncServiceProvider ServiceProvider
        {
            get
            {
                return this.package;
            }
        }

        /// <summary>
        /// Initializes the singleton instance of the command.
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        public static async System.Threading.Tasks.Task InitializeAsync(AsyncPackage package)
        {
            // Switch to the main thread - the call to AddCommand in Command1's constructor requires
            // the UI thread.
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync(package.DisposalToken);

            OleMenuCommandService commandService = await package.GetServiceAsync(typeof(IMenuCommandService)) as OleMenuCommandService;
            Instance = new BuildCommand(package, commandService);
        }


        /// <summary>
        /// This function is the callback used to execute the command when the menu item is clicked.
        /// See the constructor to see how the menu item is associated with this function using
        /// OleMenuCommandService service and MenuCommand class.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event args.</param>
        private void Execute(object sender, EventArgs e)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            Project activeProject = getActivProject();

            NuController controller = new NuController(activeProject, new Form1(package));
            controller.Start();
            /*
            string message = string.Format(CultureInfo.CurrentCulture, "Inside {0}.MenuItemCallback()", this.GetType().FullName);
            string title = "Command1";
            
            // Show a message box to prove we were here
            VsShellUtilities.ShowMessageBox(
                this.package,
                message,
                title,
                OLEMSGICON.OLEMSGICON_INFO,
                OLEMSGBUTTON.OLEMSGBUTTON_OK,
                OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);*/
        }

    }
}
