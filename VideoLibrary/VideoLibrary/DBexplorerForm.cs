using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VideoLibrary
{
    public partial class DBexplorerForm : Form
    {
        private DataTable table;
        private DataSet videoLib;

        public DBexplorerForm()
        {
            InitializeComponent();
            this.CenterToScreen();
            this.videoLib = new DataSet();
            this.table = new DataTable();
        }


        //----------------------------------------------------------------------------------------

        #region Fill Tables and controls

        private void DBexplorerForm_Load(object sender, EventArgs e)
        {
            TableExplorer.GetWholeDB(this.videoLib);

            var Arr = TableExplorer.GetVideoLibTableNames();
            foreach (string tab in Arr)
            {
                showTableBox.Items.Add(tab);
            }
        }

        private void showTableBox_SelectedValueChanged(object sender, EventArgs e)
        {
            string tableName = showTableBox.SelectedItem.ToString();
            table = videoLib.Tables[tableName];
            
            filterBox.Items.Clear();

            foreach (DataColumn col in table.Columns)
            {
                filterBox.Items.Add(col.ColumnName);
                col.ReadOnly = true;
            }

            dataGridView1.DataSource = table;
        }

        #endregion

        //----------------------------------------------------------------------------------------

        #region Select Function

        private void SelectButton_Click(object sender, EventArgs e)
        {
            if (table != null)
            {
                try
                {
                    StringBuilder command = new StringBuilder(String.Format("WHERE {0} {1} ",
                                                                               filterBox.SelectedItem,
                                                                               compererBox.SelectedItem));

                    if (compererBox.Text == "LIKE" || compererBox.Text == "NOT LIKE")
                        command.AppendFormat("'%{0}%' ", filterTextBox.Text);
                    else
                        command.AppendFormat("'{0}' ", filterTextBox.Text);


                    for (int i = 0; i < 3; i++)
                    {
                        ComboBox andOrBox = null;
                        if (this.groupBox2.Controls.Find("AddFilterBox" + i, false).Length != 0)
                        {
                            andOrBox = this.groupBox2.Controls.Find("AddFilterBox" + i, false)[0] as ComboBox;

                            command.AppendFormat(" {0} ", andOrBox.Text);

                            if (andOrBox != null && andOrBox.SelectedIndex != -1)
                            {
                                command.AppendFormat("{0} {1} ", this.groupBox2.Controls.Find("FilterBox" + i, false)[0].Text,
                                                                     this.groupBox2.Controls.Find("CompererBox" + i, false)[0].Text);

                                if (this.groupBox2.Controls.Find("CompererBox" + i, false)[0].Text == "LIKE" ||
                                    this.groupBox2.Controls.Find("CompererBox" + i, false)[0].Text == "NOT LIKE")
                                {
                                    command.AppendFormat("'%{0}%' ", this.groupBox2.Controls.Find("FilterTextBox" + i, false)[0].Text);
                                }
                                else
                                    command.AppendFormat("'{0}' ", this.groupBox2.Controls.Find("FilterTextBox" + i, false)[0].Text);
                            }
                        }
                    }

                    dataGridView1.DataSource = TableExplorer.SelectTable(command.ToString(), "SELECT * FROM " + table.TableName);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Some SELECT fields are empty or irregular! \n" + ex.Message);
                }
            }
            else
                MessageBox.Show("There is no table selected!");
        }
        #endregion

        //---------------------------------------------------------------------------------------

        #region Dinamic controls for Filtration

        private void filterTextBox_TextChanged(object sender, EventArgs e)
        {
            if (filtersCreated < 3)
            {
                if (filterBox.SelectedIndex != -1 && compererBox.SelectedIndex != -1)
                {
                    TextBox t = sender as TextBox;
                    int x = t.Location.X + t.Size.Width + 2;
                    CreateFilterationBox(x, filtersCreated);
                }
            }
        }

        private void CreateFilterationBox(int x, int val)
        {
            ComboBox combo = new ComboBox()
            {
                Name = "AddFilterBox" + val.ToString(),
                Location = new Point(7 + x, 50),
                Size = new Size(47, 20),
                DropDownStyle = ComboBoxStyle.DropDownList,
            };

            combo.Items.AddRange(new string[] { "AND", "OR" });
            combo.SelectedIndexChanged += combo_SelectedIndexChanged;

            if (this.groupBox2.Controls.ContainsKey(combo.Name))
                return;
            this.groupBox2.Controls.Add(combo);
        }

        int filtersCreated = 0;
        String previousName = "";

        void combo_SelectedIndexChanged(object sender, EventArgs e)
        {

            ComboBox source = sender as ComboBox;
            int x = source.Location.X + source.Size.Width + 2;
            if (previousName == source.Name)
                return;
            ComboBox combo = new ComboBox()
            {
                Name = "FilterBox" + filtersCreated,
                Location = new Point(x, 19),
                Size = new Size(133, 21),
                DropDownStyle = ComboBoxStyle.DropDownList,
            };
            foreach (DataColumn col in table.Columns)
            {
                combo.Items.Add(col.ColumnName);
            }

            ComboBox comper = new ComboBox()
            {
                Name = "CompererBox" + filtersCreated,
                Location = new Point(x, 50),
                Size = new Size(44, 21),
                DropDownStyle = ComboBoxStyle.DropDownList,
            };
            comper.Items.AddRange(new object[] { "=", "!=", ">", "<", ">=", "<=", "LIKE", "NOT LIKE" });

            int tx = comper.Location.X + comper.Size.Width + 2;
            TextBox textB = new TextBox()
            {
                Name = "FilterTextBox" + filtersCreated,
                Location = new Point(tx, 51),
                Size = new Size(82, 21),
            };
            textB.TextChanged += filterTextBox_TextChanged;

            this.groupBox2.Controls.AddRange(new Control[] { combo, comper, textB });

            filtersCreated++;
            previousName = source.Name;

        }

        #endregion

        //---------------------------------------------------------------------------------------

        #region Clear fields
        private void Clear()
        {
            for (int i = 0; i < 3; i++)
            {
                var filter = this.groupBox2.Controls.Find("AddFilterBox" + i, false);
                if (filter.Length != 0)
                {
                    this.groupBox2.Controls.Remove(filter[0]);
                    var filter2 = this.groupBox2.Controls.Find("FilterBox" + i, false);
                    if (filter2.Length != 0)
                    {
                        this.groupBox2.Controls.Remove(filter2[0]);
                        this.groupBox2.Controls.Remove(this.groupBox2.Controls.Find("CompererBox" + i, false)[0]);
                        this.groupBox2.Controls.Remove(this.groupBox2.Controls.Find("FilterTextBox" + i, false)[0]);
                    }
                }
            }
        }
        private void clearButton_Click(object sender, EventArgs e)
        {
            filterTextBox.Text = "";
            filterBox.SelectedIndex = -1;
            compererBox.SelectedIndex = -1;
            Clear();
        }

        private void AdditonClearButton_Click(object sender, EventArgs e)
        {
            Clear();
        }
        #endregion

        //---------------------------------------------------------------------------------------

        #region Other
        private void filterBox_MouseClick(object sender, MouseEventArgs e)
        {
            dataGridView1.DataSource = table;
        }

        private void compererBox_MouseClick(object sender, MouseEventArgs e)
        {
            dataGridView1.DataSource = table;
        }

        private void filterTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            dataGridView1.DataSource = table;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        //---------------------------------------------------------------------------------------
    }
}
