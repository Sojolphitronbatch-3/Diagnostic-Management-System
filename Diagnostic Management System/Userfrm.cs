using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diagnostic_Management_System
{
    public partial class Userfrm : Form
    {
        private const string connectionString = "Data Source=DESKTOP-ODCLL6A\\SQLEXPRESS;Initial Catalog=sojol;Integrated Security=True";
        private string selectedP_ID;
        public Userfrm(string loggedInPatientID)
        {
            InitializeComponent();
            BindDiagnosticCenters();
            panelInformation.Visible = true;
            selectedP_ID = loggedInPatientID;
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BindDiagnosticCenters()
        {
            DataTable diagnosticCenters = GetDiagnosticCenters();
            listBoxDiagnosticCenters.DataSource = diagnosticCenters;
            listBoxDiagnosticCenters.DisplayMember = "D_NAME";
            listBoxDiagnosticCenters.ValueMember = "D_ID";
        }

        private DataTable GetDiagnosticCenters()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT D_ID, D_NAME, D_ADDRESS FROM Diagnostic_Center", connection))
                {
                    DataTable dt = new DataTable();
                    dt.Load(command.ExecuteReader());
                    return dt;
                }
            }
        }

        private void listBoxDiagnosticCenters_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxDiagnosticCenters.SelectedItem != null)
            {
                string selectedD_ID = listBoxDiagnosticCenters.SelectedValue.ToString();
                DisplayDiagnosticCenterInformation(selectedD_ID);
                panelInformation.Visible = true;
            }
        }

        private void DisplayDiagnosticCenterInformation(string selectedD_ID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"SELECT dc.D_NAME, dc.D_ADDRESS, dc.D_ID, AVG(CAST(r.STAR AS FLOAT)) AS AvgRating
                         FROM Diagnostic_Center dc
                         LEFT JOIN Rating r ON dc.D_ID = r.D_ID
                         WHERE dc.D_ID = @D_ID
                         GROUP BY dc.D_NAME, dc.D_ADDRESS, dc.D_ID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@D_ID", selectedD_ID);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        labelDiagnosticCenterName.Text = $"Name: {reader["D_NAME"].ToString()}";
                        labelDiagnosticCenterAddress.Text = $"Address: {reader["D_ADDRESS"].ToString()}";
                        labelDiagnosticCenterID.Text = $"Center ID: {reader["D_ID"].ToString()}";

                        if (!reader.IsDBNull(reader.GetOrdinal("AvgRating")))
                        {
                            double avgRating = Convert.ToDouble(reader["AvgRating"]);
                            labelAvgRating.Text = $"Rating: {avgRating:F2}";
                        }
                        else
                        {
                            labelAvgRating.Text = "Rating: Not available";
                        }

                    }
                }
            }
        }
        
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (listBoxDiagnosticCenters.SelectedItem != null)
            {

                string selectedD_ID = listBoxDiagnosticCenters.SelectedValue.ToString();
                DisplayDiagnosticCenterInformation(selectedD_ID);
                Servicefrm sf = new Servicefrm(selectedD_ID, selectedP_ID);
                sf.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please select a diagnostic center before proceeding.");
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Loginfrm lg = new Loginfrm();
            lg.Show();
            this.Hide();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();

            if (!string.IsNullOrEmpty(searchText))
            {
                DataView dv = new DataView(GetDiagnosticCenters());
                dv.RowFilter = $"D_NAME LIKE '%{searchText}%'";

                if (dv.Count > 0)
                {
                    listBoxDiagnosticCenters.DataSource = dv.ToTable();
                    panelInformation.Visible = true;
                }
                else
                {
                    listBoxDiagnosticCenters.DataSource = null;
                    listBoxDiagnosticCenters.Items.Clear();
                    listBoxDiagnosticCenters.Items.Add("No diagnostic centers found");
                    panelInformation.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("Please enter a search term.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
