namespace Rsobies.NuBuilder
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.title = new System.Windows.Forms.Label();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTags = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRelNotes = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnBuild = new System.Windows.Forms.Button();
            this.headerFiles = new System.Windows.Forms.CheckedListBox();
            this.chkDirs = new System.Windows.Forms.CheckedListBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.chkDebug32 = new System.Windows.Forms.CheckBox();
            this.chkDebug64 = new System.Windows.Forms.CheckBox();
            this.chkRelease32 = new System.Windows.Forms.CheckBox();
            this.chkRelease64 = new System.Windows.Forms.CheckBox();
            this.stepWizardControl1 = new AeroWizard.StepWizardControl();
            this.metaDataPage = new AeroWizard.WizardPage();
            this.filesPage = new AeroWizard.WizardPage();
            this.targetsPage = new AeroWizard.WizardPage();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stepWizardControl1)).BeginInit();
            this.metaDataPage.SuspendLayout();
            this.filesPage.SuspendLayout();
            this.targetsPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nuget id";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(114, 13);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(513, 31);
            this.txtId.TabIndex = 1;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(115, 65);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(513, 31);
            this.txtTitle.TabIndex = 3;
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Location = new System.Drawing.Point(10, 65);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(44, 25);
            this.title.TabIndex = 2;
            this.title.Text = "Title";
            // 
            // txtVersion
            // 
            this.txtVersion.Location = new System.Drawing.Point(115, 106);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Size = new System.Drawing.Size(513, 31);
            this.txtVersion.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Version";
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(115, 159);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(513, 31);
            this.txtAuthor.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Author";
            // 
            // txtTags
            // 
            this.txtTags.Location = new System.Drawing.Point(115, 207);
            this.txtTags.Name = "txtTags";
            this.txtTags.Size = new System.Drawing.Size(512, 31);
            this.txtTags.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "tags";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(114, 255);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(513, 31);
            this.txtDescription.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 259);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 25);
            this.label5.TabIndex = 10;
            this.label5.Text = "Description";
            // 
            // txtRelNotes
            // 
            this.txtRelNotes.Location = new System.Drawing.Point(115, 306);
            this.txtRelNotes.Name = "txtRelNotes";
            this.txtRelNotes.Size = new System.Drawing.Size(513, 31);
            this.txtRelNotes.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 306);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 25);
            this.label6.TabIndex = 12;
            this.label6.Text = "Rel notes";
            // 
            // btnBuild
            // 
            this.btnBuild.Location = new System.Drawing.Point(686, 300);
            this.btnBuild.Name = "btnBuild";
            this.btnBuild.Size = new System.Drawing.Size(97, 40);
            this.btnBuild.TabIndex = 14;
            this.btnBuild.Text = "Build nuget";
            this.btnBuild.UseVisualStyleBackColor = true;
            this.btnBuild.Click += new System.EventHandler(this.BtnBuild_Click);
            // 
            // headerFiles
            // 
            this.headerFiles.FormattingEnabled = true;
            this.headerFiles.Location = new System.Drawing.Point(30, 20);
            this.headerFiles.Name = "headerFiles";
            this.headerFiles.Size = new System.Drawing.Size(258, 312);
            this.headerFiles.TabIndex = 16;
            // 
            // chkDirs
            // 
            this.chkDirs.FormattingEnabled = true;
            this.chkDirs.Location = new System.Drawing.Point(313, 20);
            this.chkDirs.Name = "chkDirs";
            this.chkDirs.Size = new System.Drawing.Size(208, 312);
            this.chkDirs.TabIndex = 17;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // chkDebug32
            // 
            this.chkDebug32.AutoSize = true;
            this.chkDebug32.Location = new System.Drawing.Point(188, 99);
            this.chkDebug32.Name = "chkDebug32";
            this.chkDebug32.Size = new System.Drawing.Size(117, 29);
            this.chkDebug32.TabIndex = 18;
            this.chkDebug32.Text = "Debug 32";
            this.chkDebug32.UseVisualStyleBackColor = true;
            // 
            // chkDebug64
            // 
            this.chkDebug64.AutoSize = true;
            this.chkDebug64.Location = new System.Drawing.Point(188, 187);
            this.chkDebug64.Name = "chkDebug64";
            this.chkDebug64.Size = new System.Drawing.Size(117, 29);
            this.chkDebug64.TabIndex = 19;
            this.chkDebug64.Text = "Debug 64";
            this.chkDebug64.UseVisualStyleBackColor = true;
            // 
            // chkRelease32
            // 
            this.chkRelease32.AutoSize = true;
            this.chkRelease32.Location = new System.Drawing.Point(375, 99);
            this.chkRelease32.Name = "chkRelease32";
            this.chkRelease32.Size = new System.Drawing.Size(121, 29);
            this.chkRelease32.TabIndex = 20;
            this.chkRelease32.Text = "Release 32";
            this.chkRelease32.UseVisualStyleBackColor = true;
            // 
            // chkRelease64
            // 
            this.chkRelease64.AutoSize = true;
            this.chkRelease64.Location = new System.Drawing.Point(375, 187);
            this.chkRelease64.Name = "chkRelease64";
            this.chkRelease64.Size = new System.Drawing.Size(121, 29);
            this.chkRelease64.TabIndex = 21;
            this.chkRelease64.Text = "Release 64";
            this.chkRelease64.UseVisualStyleBackColor = true;
            // 
            // stepWizardControl1
            // 
            this.stepWizardControl1.BackColor = System.Drawing.Color.White;
            this.stepWizardControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stepWizardControl1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stepWizardControl1.Location = new System.Drawing.Point(0, 0);
            this.stepWizardControl1.Name = "stepWizardControl1";
            this.stepWizardControl1.Pages.Add(this.metaDataPage);
            this.stepWizardControl1.Pages.Add(this.filesPage);
            this.stepWizardControl1.Pages.Add(this.targetsPage);
            this.stepWizardControl1.Size = new System.Drawing.Size(859, 552);
            this.stepWizardControl1.StepListFont = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.stepWizardControl1.StepListWidth = 140;
            this.stepWizardControl1.TabIndex = 22;
            this.stepWizardControl1.Text = "text";
            this.stepWizardControl1.Title = "Nuget builder";
            this.stepWizardControl1.Finished += new System.EventHandler(this.StepWizardControl1_Finished);
            // 
            // metaDataPage
            // 
            this.metaDataPage.Controls.Add(this.txtId);
            this.metaDataPage.Controls.Add(this.label1);
            this.metaDataPage.Controls.Add(this.title);
            this.metaDataPage.Controls.Add(this.txtTitle);
            this.metaDataPage.Controls.Add(this.txtVersion);
            this.metaDataPage.Controls.Add(this.label2);
            this.metaDataPage.Controls.Add(this.txtAuthor);
            this.metaDataPage.Controls.Add(this.label3);
            this.metaDataPage.Controls.Add(this.txtRelNotes);
            this.metaDataPage.Controls.Add(this.label6);
            this.metaDataPage.Controls.Add(this.txtTags);
            this.metaDataPage.Controls.Add(this.label4);
            this.metaDataPage.Controls.Add(this.txtDescription);
            this.metaDataPage.Controls.Add(this.label5);
            this.metaDataPage.HelpText = "";
            this.metaDataPage.Name = "metaDataPage";
            this.metaDataPage.Size = new System.Drawing.Size(671, 362);
            this.metaDataPage.TabIndex = 2;
            this.metaDataPage.Text = "Fill meta data";
            // 
            // filesPage
            // 
            this.filesPage.Controls.Add(this.headerFiles);
            this.filesPage.Controls.Add(this.chkDirs);
            this.filesPage.Name = "filesPage";
            this.filesPage.Size = new System.Drawing.Size(671, 362);
            this.filesPage.TabIndex = 3;
            this.filesPage.Text = "Select files";
            // 
            // targetsPage
            // 
            this.targetsPage.Controls.Add(this.chkDebug64);
            this.targetsPage.Controls.Add(this.btnBuild);
            this.targetsPage.Controls.Add(this.chkRelease64);
            this.targetsPage.Controls.Add(this.chkDebug32);
            this.targetsPage.Controls.Add(this.chkRelease32);
            this.targetsPage.Name = "targetsPage";
            this.targetsPage.Size = new System.Drawing.Size(671, 362);
            this.targetsPage.TabIndex = 4;
            this.targetsPage.Text = "Select targets";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 552);
            this.Controls.Add(this.stepWizardControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stepWizardControl1)).EndInit();
            this.metaDataPage.ResumeLayout(false);
            this.metaDataPage.PerformLayout();
            this.filesPage.ResumeLayout(false);
            this.targetsPage.ResumeLayout(false);
            this.targetsPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.TextBox txtVersion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTags;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRelNotes;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnBuild;
        private System.Windows.Forms.CheckedListBox headerFiles;
        private System.Windows.Forms.CheckedListBox chkDirs;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.CheckBox chkRelease64;
        private System.Windows.Forms.CheckBox chkRelease32;
        private System.Windows.Forms.CheckBox chkDebug64;
        private System.Windows.Forms.CheckBox chkDebug32;
        private AeroWizard.StepWizardControl stepWizardControl1;
        private AeroWizard.WizardPage metaDataPage;
        private AeroWizard.WizardPage filesPage;
        private AeroWizard.WizardPage targetsPage;
    }
}