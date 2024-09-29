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
    public partial class Loginfrm : Form
    {
        public string LoggedInPatientID { get; private set; }
        private const string connectionString = "Data Source=DESKTOP-ODCLL6A\\SQLEXPRESS;Initial Catalog=sojol;Integrated Security=True";
        public Loginfrm()
        {
            InitializeComponent();
        }

        private void btnregistration_Click(object sender, EventArgs e)
        {
            Registrationfrm frm = new Registrationfrm();
            frm.Show();
            this.Close();
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            string username = txtusername.Text;
            string password = txtpassword.Text;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT L.*, P.P_ID FROM Login L JOIN Patient P ON L.Username = P.Username WHERE L.username = @username AND L.password = @password";

                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);

                        using (SqlDataAdapter sda = new SqlDataAdapter(command))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                string userType = dt.Rows[0]["type"].ToString();
                                string userName = dt.Rows[0]["name"].ToString();

                                if (userType == "Admin")
                                {
                                    AdminDashboardfrm af = new AdminDashboardfrm();
                                    af.Show();
                                }
                                else if (userType == "User")
                                {
                                    string patientID = dt.Rows[0]["P_ID"].ToString();
                                    
                                   
                                    Loginfrm loginForm = new Loginfrm();
                                    loginForm.LoggedInPatientID = patientID;
                                    string loggedInPatientID = loginForm.LoggedInPatientID;
                                    Userfrm uf = new Userfrm(loggedInPatientID);
                                    uf.Show();
                                }
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Invalid login details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtusername.Clear();
                                txtpassword.Clear();
                                txtusername.Focus();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void showPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (showPassword.Checked)
            {
                txtpassword.UseSystemPasswordChar=false;

            }
            else
            {
                txtpassword.UseSystemPasswordChar = true;
            }
        }
    }
    
}
