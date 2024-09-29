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
    public partial class AdminDashboardfrm : Form
    {
        public AdminDashboardfrm()
        {
            InitializeComponent();
            InitializeDataGridView();
            panelAddDiagnosticCenter.Visible = false;
            dataGridViewService.Visible = false;
            dataGridViewViewOrder.Visible = false;
            dataGridViewEarning.Visible = false;
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private const string connectionString = "Data Source=DESKTOP-ODCLL6A\\SQLEXPRESS;Initial Catalog=sojol;Integrated Security=True";

        private void InitializeDataGridView()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT S_ID, S_NAME,S_PRICE FROM Services";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);

                            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
                            checkBoxColumn.HeaderText = "Select";
                            checkBoxColumn.Name = "CheckBoxColumn";
                            dataGridViewService.Columns.Add(checkBoxColumn);

                            dataGridViewService.DataSource = dt;

                            dataGridViewService.Columns["S_ID"].Visible = false; ;
                            dataGridViewService.Columns["S_NAME"].HeaderText = "Service Name";
                            dataGridViewService.Columns["S_PRICE"].HeaderText = "Service Price";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddDiagnosticCenter_Click(object sender, EventArgs e)
        {
            dataGridViewViewOrder.Visible = false;
            dataGridViewEarning.Visible = false;
            panelAddDiagnosticCenter.Visible = true;
            dataGridViewService.Visible = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string diagnosticCenterName = txtName.Text;
                string diagnosticCenterAddress = txtAddress.Text;

                List<string> selectedServices = GetSelectedServices();
                if (selectedServices.Count == 0)
                {
                    MessageBox.Show("Please select at least one service.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return; 
                }
                InsertDiagnosticCenter(diagnosticCenterName, diagnosticCenterAddress);
                InsertDiagnosticCenterServices(diagnosticCenterName, selectedServices);
                

                ClearSelectedServices();

                MessageBox.Show("Diagnostic center and services added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InsertDiagnosticCenter(string name, string address)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Diagnostic_Center (D_NAME, D_ADDRESS) VALUES (@Name, @Address)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Address", address);
                    command.ExecuteNonQuery();
                }
            }
        }

        private List<string> GetSelectedServices()
        {
            List<string> selectedServices = new List<string>();

            foreach (DataGridViewRow row in dataGridViewService.Rows)
            {
                DataGridViewCheckBoxCell checkBox = row.Cells["CheckBoxColumn"] as DataGridViewCheckBoxCell;

                if (checkBox != null && Convert.ToBoolean(checkBox.Value))
                {
                    string serviceID = row.Cells["S_ID"].Value.ToString();
                    selectedServices.Add(serviceID);
                }
            }

            return selectedServices;
        }

        private void InsertDiagnosticCenterServices(string diagnosticCenterName, List<string> selectedServices)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

               
                string getDIDQuery = "SELECT D_ID FROM Diagnostic_Center WHERE D_NAME = @DiagnosticCenterName";

                using (SqlCommand getDIDCommand = new SqlCommand(getDIDQuery, connection))
                {
                    getDIDCommand.Parameters.AddWithValue("@DiagnosticCenterName", diagnosticCenterName);
                    object result = getDIDCommand.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        string diagnosticCenterID = result.ToString();

                        foreach (string serviceID in selectedServices)
                        {
                            string insertQuery = "INSERT INTO DiagnosticCenterService (D_ID, S_ID) VALUES (@DiagnosticCenterID, @ServiceID)";

                            using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                            {
                                insertCommand.Parameters.AddWithValue("@DiagnosticCenterID", diagnosticCenterID);
                                insertCommand.Parameters.AddWithValue("@ServiceID", serviceID);
                                insertCommand.ExecuteNonQuery();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Failed to retrieve D_ID for the diagnostic center.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }


        private void ClearSelectedServices()
        {
            dataGridViewService.ClearSelection();
        }


        private void btnLogout_Click(object sender, EventArgs e)
        {
            Loginfrm loginfrm = new Loginfrm();
            loginfrm.Show();
            this.Hide();
        }

        private void LoadOrders()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT O_ID, D_ID, P_ID, O_DATE, O_PRICE FROM Orders";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            dataGridViewViewOrder.DataSource = dt;
                        }
                    }
                }
                dataGridViewViewOrder.Columns["O_ID"].HeaderText = "Order ID";
                dataGridViewViewOrder.Columns["D_ID"].HeaderText = "Center ID";
                dataGridViewViewOrder.Columns["P_ID"].HeaderText = "Patient ID";
                dataGridViewViewOrder.Columns["O_DATE"].HeaderText = "Order Date";
                dataGridViewViewOrder.Columns["O_PRICE"].HeaderText = "Price";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnViewOrder_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridViewEarning.Visible = false;
                panelAddDiagnosticCenter.Visible = false;
                dataGridViewService.Visible = false;
                dataGridViewViewOrder.Visible = true;

                LoadOrders();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoadOrdersWithProfit()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT O_ID, D_ID, P_ID, O_DATE, O_PRICE, O_PRICE * 0.05 AS Profit FROM Orders";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            dataGridViewEarning.DataSource = dt;
                        }
                    }
                }
                dataGridViewEarning.Columns["O_ID"].HeaderText = "Order ID";
                dataGridViewEarning.Columns["D_ID"].HeaderText = "Center ID";
                dataGridViewEarning.Columns["P_ID"].HeaderText = "Patient ID";
                dataGridViewEarning.Columns["O_DATE"].HeaderText = "Order Date";
                dataGridViewEarning.Columns["O_PRICE"].HeaderText = "Price";
                dataGridViewEarning.Columns["Profit"].HeaderText = "Profit (5%)";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnViewEarning_Click(object sender, EventArgs e)
        {
            try
            {
                
                panelAddDiagnosticCenter.Visible = false;
                dataGridViewService.Visible = false;
                dataGridViewViewOrder.Visible = false;
                dataGridViewEarning.Visible = true;

                LoadOrdersWithProfit();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
