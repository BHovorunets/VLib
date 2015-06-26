using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoLibrary
{
    public partial class ComplexQueryForm : Form
    {
        public ComplexQueryForm()
        {
            InitializeComponent();
        }

        private void ComplexQueryForm_Load(object sender, EventArgs e)
        {
            DataTable table = TableExplorer.SelectTable("", "SELECT DISTINCT m.MovieID, m.Title FROM Movies m RIGHT JOIN MovieActors ma ON m.MovieID = ma.MovieID");

            MoviesComBox.DataSource = table;
            MoviesComBox.DisplayMember = "Title";
            MoviesComBox.ValueMember = "MovieID";

        }

        private void MoviesComBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MoviesComBox.SelectedValue is int)
            {
                string command = String.Format(
                    "SELECT X.ActorID, FName, LName, DateOfBirth, CountryOfBirth, CityOfBirth  " +
                    "FROM MovieActors X " +
                    "JOIN Actors a ON a.ActorID = X.ActorID WHERE MovieID = \'{0}\'", MoviesComBox.SelectedValue);
                dataGridView1.DataSource = TableExplorer.SelectTable("", command);
            }
        }

    }
}
