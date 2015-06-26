using System;
using System.Data;
using System.Windows.Forms;

namespace VideoLibrary
{
    public partial class DeleteTableForm : Form
    {
        public DeleteTableForm()
        {
            InitializeComponent();
            CenterToParent();
            RefreshTables();
        }

        private void RefreshTables()
        {
            showTableBox.Items.Clear();
            var arr = TableExplorer.GetVideoLibTableNames();
            foreach (string tab in arr)
            {
                showTableBox.Items.Add(tab);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure you want to delete this table?", "DeleteDialog", MessageBoxButtons.OKCancel);
            if (res == DialogResult.OK)
            {
                String msg = TableExplorer.DeleteTable(showTableBox.Text);
                MessageBox.Show(msg);
                RefreshTables();
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
