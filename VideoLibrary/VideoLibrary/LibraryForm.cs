using System;
using System.Data;
using System.Windows.Forms;

namespace VideoLibrary
{
    public partial class LibraryForm : Form
    {

        public LibraryForm()
        {
            InitializeComponent();
            ShDBTablesButton.Select();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                AddTableForm addForm = new AddTableForm();
                addForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ShDBTablesButton_Click(object sender, EventArgs e)
        {
            try
            {
                DBexplorerForm selectForm = new DBexplorerForm();
                selectForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteTableForm deleteForm = new DeleteTableForm();
                deleteForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EditTablesButton_Click(object sender, EventArgs e)
        {
            try
            {
                ModifyTablesForm modifyForm = new ModifyTablesForm();
                modifyForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CompositeQbutton_Click(object sender, EventArgs e)
        {
            try
            {
                ComplexQueryForm complexForm = new ComplexQueryForm();
                complexForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
