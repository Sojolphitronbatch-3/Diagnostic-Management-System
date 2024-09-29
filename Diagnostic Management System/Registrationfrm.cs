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
    public partial class Registrationfrm : Form
    {
        private const string connectionString = "Data Source=DESKTOP-ODCLL6A\\SQLEXPRESS;Initial Catalog=sojol;Integrated Security=True";
        public Registrationfrm()
        {
            InitializeComponent();
        }

        private void btnloginb_Click(object sender, EventArgs e)
        {
            Loginfrm frm = new Loginfrm();
            frm.Show();
            this.Close();
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnsignup_Click(object sender, EventArgs e)
        {
            try
            {
                string type = cmbtype.Text;
                string name = txtname.Text;
                string age = txtage.Text;
                string address = txtaddress.Text;
                string phoneNo = txtphoneno.Text;
                string username = txtusername.Text;
                string password = txtpassword.Text;
                string cpassword = txtcpassword.Text;

                if (string.IsNullOrEmpty(type) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(age) ||
                    string.IsNullOrEmpty(address) || string.IsNullOrEmpty(phoneNo) || string.IsNullOrEmpty(username) ||
                    string.IsNullOrEmpty(password) || string.IsNullOrEmpty(cpassword))
                {
                    MessageBox.Show("Please fill in all the fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtphoneno.Text.Length != 11)
                {
                    MessageBox.Show("Phone number should be 11 characters long.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (password != cpassword)
                {
                    MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string loginInsertQuery = "INSERT INTO Login (Type, Name, Username, Password) VALUES (@Type, @Name, @Username, @Password)";
                    using (SqlCommand loginCommand = new SqlCommand(loginInsertQuery, connection))
                    {
                        loginCommand.Parameters.AddWithValue("@Type", type);
                        loginCommand.Parameters.AddWithValue("@Name", name);
                        loginCommand.Parameters.AddWithValue("@Username", username);
                        loginCommand.Parameters.AddWithValue("@Password", password);

                        loginCommand.ExecuteNonQuery();
                    }

                    string patientInsertQuery = "INSERT INTO Patient (P_NAME, P_AGE, P_ADDRESS, P_NUMBER, Username) VALUES (@Name, @Age, @Address, @PhoneNo, @Username)";
                    using (SqlCommand patientCommand = new SqlCommand(patientInsertQuery, connection))
                    {
                        patientCommand.Parameters.AddWithValue("@Name", name);
                        patientCommand.Parameters.AddWithValue("@Age", age);
                        patientCommand.Parameters.AddWithValue("@Address", address);
                        patientCommand.Parameters.AddWithValue("@PhoneNo", phoneNo);
                        patientCommand.Parameters.AddWithValue("@Username", username);

                        patientCommand.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Registration successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Loginfrm lg = new Loginfrm();
                lg.Show();
                this.Close();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) 
                {
                    MessageBox.Show("Username already exists. Please choose a different username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"A SQL error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
