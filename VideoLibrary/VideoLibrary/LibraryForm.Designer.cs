using System.ComponentModel;
using System.Windows.Forms;

namespace VideoLibrary
{
    partial class LibraryForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.ShDBTablesButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.EditTablesButton = new System.Windows.Forms.Button();
            this.CompositeQbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(90, 149);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 24);
            this.button1.TabIndex = 4;
            this.button1.Text = "Create New Table";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ShDBTablesButton
            // 
            this.ShDBTablesButton.Location = new System.Drawing.Point(90, 38);
            this.ShDBTablesButton.Name = "ShDBTablesButton";
            this.ShDBTablesButton.Size = new System.Drawing.Size(154, 24);
            this.ShDBTablesButton.TabIndex = 5;
            this.ShDBTablesButton.Text = "Select From Tables";
            this.ShDBTablesButton.UseVisualStyleBackColor = true;
            this.ShDBTablesButton.Click += new System.EventHandler(this.ShDBTablesButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(90, 202);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(154, 24);
            this.button2.TabIndex = 6;
            this.button2.Text = "Delete Table";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // EditTablesButton
            // 
            this.EditTablesButton.Location = new System.Drawing.Point(90, 94);
            this.EditTablesButton.Name = "EditTablesButton";
            this.EditTablesButton.Size = new System.Drawing.Size(154, 24);
            this.EditTablesButton.TabIndex = 7;
            this.EditTablesButton.Text = "Edit Tables";
            this.EditTablesButton.UseVisualStyleBackColor = true;
            this.EditTablesButton.Click += new System.EventHandler(this.EditTablesButton_Click);
            // 
            // CompositeQbutton
            // 
            this.CompositeQbutton.Location = new System.Drawing.Point(90, 255);
            this.CompositeQbutton.Name = "CompositeQbutton";
            this.CompositeQbutton.Size = new System.Drawing.Size(154, 24);
            this.CompositeQbutton.TabIndex = 8;
            this.CompositeQbutton.Text = "Composite Query";
            this.CompositeQbutton.UseVisualStyleBackColor = true;
            this.CompositeQbutton.Click += new System.EventHandler(this.CompositeQbutton_Click);
            // 
            // LibraryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 327);
            this.Controls.Add(this.CompositeQbutton);
            this.Controls.Add(this.EditTablesButton);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.ShDBTablesButton);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "LibraryForm";
            this.Text = "Video Library";
            this.ResumeLayout(false);

        }

        #endregion

        private Button button1;
        private Button ShDBTablesButton;
        private Button button2;
        private Button EditTablesButton;
        private Button CompositeQbutton;
    }
}