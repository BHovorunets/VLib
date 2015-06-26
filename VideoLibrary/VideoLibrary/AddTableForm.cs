using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VideoLibrary
{
    public partial class AddTableForm : Form
    {
        public AddTableForm()
        {
            InitializeComponent();
            CenterToScreen();

        }
        private void CreateTable(string name, string s)
        {

            string command2 = string.Format("CREATE TABLE {0} ({1})", name, s);

            try
            {
                using (SqlConnection connection = new SqlConnection(TableExplorer.Connection))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(command2, connection);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(string.Format("DataTable {0} succesfuly created in VideoLibraryDB", name));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Close();
            }

        }

        private void CreateTableBtn_Click(object sender, EventArgs e)
        {
            Control.ControlCollection contrArr = this.Controls;
            string Tname = "";
            StringBuilder colStr = new StringBuilder("");
            foreach (Control c in contrArr)
            {
                if (c.Name == "TableNBox")
                {
                    if (c.Text == "")
                    {
                        MessageBox.Show("Give a name to new table!"); break;
                    }
                    else
                        Tname = c.Text;
                }
                else
                {
                    if (c.Text == "")
                    { MessageBox.Show("Some fields are empty!"); colStr.Clear(); break; }
                    else
                    {
                        if (c.GetType() == typeof(TextBox))
                            colStr.AppendFormat("{0} ", c.Text);
                        else if (c.GetType() == typeof(ComboBox))
                            colStr.AppendFormat("{0},", c.Text);
                        else
                            continue;
                    }
                }
            }
            if (Tname != "" && colStr.ToString() != "")
            {
                try
                {
                    string s = colStr.ToString().Remove(colStr.Length - 1);
                    CreateTable(Tname, s);
                }
                catch
                {
                    MessageBox.Show("Some fields are empty or wrong!"); colStr.Clear();
                }
            }

        }

        public object[] coll = {"int","tinyint","bigint","char(10)","varchar(10)","nchar(10)","nvarchar(10)",
                                   "numeric","bit","smallint","smallmoney","money","float",
                                 "real","date","datetimeoffset","datetime2","smalldatetime","datetime","time",
                                 "varbinary", "image" };

        private int lastValue = 0;
        private int y = 85;
        public int val = 0;


        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            val = (int)numericUpDown1.Value;
            if (val > lastValue)
            {
                TextBox textB = new TextBox()
                {
                    Name = "ColumnTextBox" + val.ToString(),
                    Location = new Point(155, y),
                    Size = new Size(150, 20)
                };

                this.Controls.Add(textB);

                ComboBox combo = new ComboBox()
                {
                    Name = "ColumnTypeColl" + val.ToString(),
                    Location = new Point(328, y),
                    Size = new Size(90, 20),
                    AutoCompleteMode = AutoCompleteMode.Suggest,
                    AutoCompleteSource = AutoCompleteSource.ListItems
                };
                combo.Items.AddRange(coll);

                this.Controls.Add(combo);

                string t = "";
                switch (val)
                {
                    case 1: { t = val.ToString() + "-st  Column"; break; }
                    case 2: { t = val.ToString() + "-nd  Column"; break; }
                    case 3: { t = val.ToString() + "-rd  Column"; break; }
                    default: { t = val.ToString() + "-th  Columm"; break; }
                }

                this.Controls.Add(new Label()
                {
                    Name = "ColumnLabel" + val.ToString(),
                    Location = new Point(70, y),
                    Text = t
                });

                y += 35;
            }
            else
            {
                this.Controls.RemoveByKey("ColumnTextBox" + lastValue.ToString());
                this.Controls.RemoveByKey("ColumnTypeColl" + lastValue.ToString());
                this.Controls.RemoveByKey("ColumnLabel" + lastValue.ToString());
                y -= 35;
            }
            lastValue = val;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }



    }
}
