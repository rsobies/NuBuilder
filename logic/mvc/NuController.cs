using EnvDTE;
using System.Collections.Generic;

namespace Rsobies.NuBuilder
{
    public class NuController
    {
        private NuspecModel model;
        private INuView view;

        public NuController(Project project, INuView view)
        {
            model = new NuspecModel(project);
            this.view = view;
        }

        public void BuildPackage(NuSpec spec)
        {
            if (model.BuildPackage(spec))
            {
                view.ShowMsgBox("Success");
            }
            else
            {
                view.ShowMsgBox("Failed");
            }
        }

        public void OnDirClick(string dir, bool isChecked)
        {
            var headers=model.GetHeaders();
           
            var headersElement = new List<CheckedElement>();
            foreach (var item in headers)
            {
                if(isChecked)
                {
                    item.DirsToRemove.Remove(dir);
                }
                else
                {
                    item.DirsToRemove.Add(dir);
                }
                headersElement.Add(new CheckedElement(item, model.Spec.Files.Contains(item)));
            }

            view.FillHeaders(headersElement);
        }

        public void OnTargetsChanged(bool debug32, bool debug64, bool release32, bool release64)
        {
            try
            {
                model.Validate(debug32, debug64, release32, release64);
                view.ClearError();
            }
            catch(ValidationException ex)
            {
                view.SetError(ex.Message, ex.MissingTarget);
            }
        }

        public void Start()
        {
            view.SetController(this);
           
            view.Fill(model.Spec);

            var allHeaders = model.GetHeaders();

            var headerChecked = new List<CheckedElement>();
            string[] dirs = new string[0];
            foreach(var item in allHeaders)
            {
                item.DirsToRemove = model.Spec.DirsToRemove;
                if (dirs.Length < item.GetDirs().Length)
                {
                    dirs = item.GetDirs();
                }
                headerChecked.Add(new CheckedElement(item, model.Spec.Files.Contains(item)));
            }

            var file = allHeaders[0];
            var dirsChecked = new List<CheckedElement>();
            foreach(var dir in dirs)
            {
                dirsChecked.Add(new CheckedElement(dir, !file.DirsToRemove.Contains(dir)));
            }
            view.FillHeaders(headerChecked);
            view.FillDirs(dirsChecked);

            try
            {
                model.Validate(model.Spec.Debug32, model.Spec.Debug64, model.Spec.Releas32, model.Spec.Release64);
                view.ClearError();
            }
            catch(ValidationException ex)
            {
                view.SetError(ex.Message, ex.MissingTarget);
            }
            
            view.Start();
        }
    }
}
