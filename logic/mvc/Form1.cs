using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Rsobies.NuBuilder
{
    public partial class Form1 : Form, INuView
    {
        
        private NuController controller;
        readonly IServiceProvider service;

        public Form1(IServiceProvider service)
        {
            this.service = service;
            InitializeComponent();
            stepWizardControl1.SetStepText(metaDataPage, "Meta data");
            stepWizardControl1.SetStepText(filesPage, "Files");
            stepWizardControl1.SetStepText(targetsPage, "Targets");
        }

        private void BtnBuild_Click(object sender, EventArgs e)
        {
            var spec = new NuSpec();
            spec.Id = txtId.Text;
            spec.Author = txtId.Text;
            spec.Description = txtDescription.Text;
            spec.Tags = txtTags.Text;
            spec.Relnotes = txtRelNotes.Text;
            spec.Version = txtVersion.Text;
            spec.Title = txtTitle.Text;
            spec.Description = txtDescription.Text;
            spec.Debug64 = chkDebug64.Checked;
            spec.Debug32 = chkDebug32.Checked;
            spec.Release64 = chkRelease64.Checked;
            spec.Releas32 = chkRelease32.Checked;

            for (int i = 0; i < headerFiles.Items.Count; i++)
            {
                if (headerFiles.GetItemChecked(i))
                {
                    spec.Files.Add((FileElement)headerFiles.Items[i]);
                }
            }

            for (int i = 0; i < chkDirs.Items.Count; i++)
            {
                if (!chkDirs.GetItemChecked(i))
                {
                    spec.DirsToRemove.Add(chkDirs.Items[i].ToString());
                }
            }

            controller.BuildPackage(spec);
        }

        private void ChkDirs_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var item=chkDirs.Items[e.Index].ToString();

            controller.OnDirClick(item, e.NewValue == CheckState.Checked);
        }

        public void SetController(NuController controller)
        {
            this.controller = controller;
        }

        public void Start()
        {
            ShowDialog();
        }

        public void FillDirs(List<CheckedElement> elements)
        {
            chkDirs.ItemCheck -= ChkDirs_ItemCheck;
            foreach (var item in elements)
            {
                chkDirs.Items.Add(item.Element, item.Checked);
            }

            chkDirs.ItemCheck += ChkDirs_ItemCheck;
        }

        public void FillHeaders(List<CheckedElement> elements)
        {
            headerFiles.Items.Clear();
            foreach (var item in elements)
            {
                headerFiles.Items.Add(item.Element, item.Checked);
            }
        }

        public void Fill(NuSpec spec)
        {        
            txtId.Text = spec.Id;
            txtTitle.Text = spec.Title;
            txtTags.Text = spec.Tags;
            txtVersion.Text = spec.Version;
            txtRelNotes.Text = spec.Relnotes;
            txtAuthor.Text = spec.Author;
            txtDescription.Text = spec.Description;

            chkDebug32.CheckedChanged -= CheckedChanged;
            chkDebug64.CheckedChanged -= CheckedChanged;
            chkRelease32.CheckedChanged -= CheckedChanged;
            chkRelease64.CheckedChanged -= CheckedChanged;

            chkDebug32.Checked = spec.Debug32;
            chkDebug64.Checked = spec.Debug64;
            chkRelease32.Checked = spec.Releas32;
            chkRelease64.Checked = spec.Release64;

            chkDebug32.CheckedChanged += CheckedChanged;
            chkDebug64.CheckedChanged += CheckedChanged;
            chkRelease32.CheckedChanged += CheckedChanged;
            chkRelease64.CheckedChanged += CheckedChanged;

        }

        public void SetError(string msgErr, LibTarget misTarget)
        {
            ClearError();
            switch (misTarget)
            {
                case LibTarget.Release32:
                    errorProvider.SetError(chkRelease32, msgErr);
                    break;
                case LibTarget.Debug32:
                    errorProvider.SetError(chkDebug32, msgErr);
                    break;
                case LibTarget.Debug64:
                    errorProvider.SetError(chkDebug64, msgErr);
                    break;
                case LibTarget.Release64:
                    errorProvider.SetError(chkRelease64, msgErr);
                    break;
            }
            
            targetsPage.AllowNext = false;
           
        }

        public void ClearError()
        {
            //btnBuild.Enabled = true;
            targetsPage.AllowNext = true;
            errorProvider.SetError(chkRelease32, null);         
            errorProvider.SetError(chkDebug32, null);          
            errorProvider.SetError(chkDebug64, null);          
            errorProvider.SetError(chkRelease64, null);
        }

        public void ShowMsgBox(string msg)
        {
            VsShellUtilities.ShowMessageBox(
                service,
                msg,
                null,
                OLEMSGICON.OLEMSGICON_INFO,
                OLEMSGBUTTON.OLEMSGBUTTON_OK,
                OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);
            //MessageBox.Show(msg, "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            controller.OnTargetsChanged(chkDebug32.Checked, chkDebug64.Checked, chkRelease32.Checked, chkRelease64.Checked);
        }

        private void StepWizardControl1_Finished(object sender, EventArgs e)
        {
            var spec = new NuSpec();
            spec.Id = txtId.Text;
            spec.Author = txtId.Text;
            spec.Description = txtDescription.Text;
            spec.Tags = txtTags.Text;
            spec.Relnotes = txtRelNotes.Text;
            spec.Version = txtVersion.Text;
            spec.Title = txtTitle.Text;
            spec.Description = txtDescription.Text;
            spec.Debug64 = chkDebug64.Checked;
            spec.Debug32 = chkDebug32.Checked;
            spec.Release64 = chkRelease64.Checked;
            spec.Releas32 = chkRelease32.Checked;

            for (int i = 0; i < headerFiles.Items.Count; i++)
            {
                if (headerFiles.GetItemChecked(i))
                {
                    spec.Files.Add((FileElement)headerFiles.Items[i]);
                }
            }

            for (int i = 0; i < chkDirs.Items.Count; i++)
            {
                if (!chkDirs.GetItemChecked(i))
                {
                    spec.DirsToRemove.Add(chkDirs.Items[i].ToString());
                }
            }

            controller.BuildPackage(spec);
        }
    }
}
