using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace VideoLibrary
{
    public partial class ModifyTablesForm : Form
    {
        public DataSet videoLib;

        public ModifyTablesForm()
        {
            InitializeComponent();
            this.videoLib = new DataSet();
            this.CenterToParent();
        }

        private void ModifyTablesForm_Load(object sender, EventArgs e)
        {
            TableExplorer.GetWholeDB(videoLib);
            List<string> tabArr = TableExplorer.GetVideoLibTableNames();

            foreach (string table in tabArr)
            {
                TabPage tab = new TabPage()
                {
                    Name = table,
                    Text = table,
                };

                tableTabControl.TabPages.Add(tab);
            }

            foreach (TabPage tab in tableTabControl.TabPages)
            {
                DataGridView dataGr = new DataGridView()
                {
                    Name = tab.Name + "DataGridView",
                    Location = new Point(3, 3),
                    Size = new Size(730, 250),
                    DataSource = videoLib.Tables[tab.Name],
                };

                Button btn = new Button()
                {
                    Name = tab.Name + "UpdateBtn",
                    Text = "Update Table",
                    Location = new Point(20, 270),
                    Size = new Size(110, 23),
                };
                btn.Click += updateButton_Click;

                Button btn2 = new Button()
                {
                    Name = tab.Name + "UpdateAllhBtn",
                    Text = "Update All Tables",
                    Location = new Point(140, 270),
                    Size = new Size(110, 23),
                };

                btn2.Click += updateAllButton_Click;

                Button btn3 = new Button()
                {
                    Name = tab.Name + "RefreshBtn",
                    Text = "Refresh Tables",
                    Location = new Point(260, 270),
                    Size = new Size(110, 23),
                };

                btn3.Click += refreshButton_Click;

                tab.Controls.AddRange(new Control[] { dataGr, btn, btn2, btn3 });
            }
        }

        void updateButton_Click(object sender, EventArgs e)
        {
            TableExplorer.UpdateTableDataSource(videoLib.Tables[tableTabControl.SelectedTab.Name]);
        }

        void updateAllButton_Click(object sender, EventArgs e)
        {
            TableExplorer.UpdateDataSource(videoLib);
        }

        void refreshButton_Click(object sender, EventArgs e)
        {
            videoLib.Reset();
            TableExplorer.GetWholeDB(videoLib);
            foreach (TabPage tab in tableTabControl.TabPages)
            {
                var grid = tab.Controls.Find(tab.Name + "DataGridView", false)[0] as DataGridView;
                grid.DataSource = null;
                grid.DataSource = videoLib.Tables[tab.Name];
                grid.Refresh();
            }
        }
        
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
