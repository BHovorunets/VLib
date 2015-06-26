using System.ComponentModel;
using System.Windows.Forms;

namespace VideoLibrary
{
    partial class ModifyTablesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.tableTabControl = new System.Windows.Forms.TabControl();
            this.closeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tableTabControl
            // 
            this.tableTabControl.Location = new System.Drawing.Point(0, 0);
            this.tableTabControl.Name = "tableTabControl";
            this.tableTabControl.SelectedIndex = 0;
            this.tableTabControl.Size = new System.Drawing.Size(744, 335);
            this.tableTabControl.TabIndex = 0;
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(624, 341);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(109, 25);
            this.closeButton.TabIndex = 0;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // ModifyTablesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 375);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.tableTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ModifyTablesForm";
            this.Text = "Tables modification ";
            this.Load += new System.EventHandler(this.ModifyTablesForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tableTabControl;
        private Button closeButton;
    }
}