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
    public partial class Servicefrm : Form
    {
        private const string connectionString = "Data Source=DESKTOP-ODCLL6A\\SQLEXPRESS;Initial Catalog=sojol;Integrated Security=True";
        public string AmountText
        {
            set { lblAmount.Text = value; }
        }

        public string ServiceChargeText
        {
            set { lblServiceCharge.Text = value; }
        }

        public string TotalAmountText
        {
            set { lblTotalAmount.Text = value; }
        }

        private string selectedD_ID;
        private string selectedP_ID;
        public Servicefrm(string selectedD_ID, string selectedP_ID)
        {
            InitializeComponent();
            dataGridViewServices.CellValueChanged += dataGridViewServices_CellValueChanged;


            this.selectedD_ID = selectedD_ID;
            this.selectedP_ID = selectedP_ID;

            DisplayAvailableServices();
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            Userfrm uf = new Userfrm(selectedP_ID);
            uf.Show();
            this.Hide();
        }
        private void closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            bool anyServiceSelected = dataGridViewServices.Rows.Cast<DataGridViewRow>().Any(row =>
            {
                DataGridViewCheckBoxCell checkBox = row.Cells["CheckBoxColumn"] as DataGridViewCheckBoxCell;
                return checkBox != null && Convert.ToBoolean(checkBox.Value);
            });

            if (!anyServiceSelected)
            {
                MessageBox.Show("Please select at least one service before proceeding with the payment.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return; 
            }

            List<string> selectedServices = new List<string>();

            foreach (DataGridViewRow row in dataGridViewServices.Rows)
            {
                DataGridViewCheckBoxCell checkBox = row.Cells["CheckBoxColumn"] as DataGridViewCheckBoxCell;

                if (checkBox != null && Convert.ToBoolean(checkBox.Value))
                {
                    string serviceID = row.Cells["S_ID"].Value.ToString();
                    selectedServices.Add(serviceID);
                }
            }
           
            Paymentfrm paymentForm = new Paymentfrm(selectedServices, this, selectedD_ID, selectedP_ID);
            paymentForm.AmountText = lblAmount.Text;
            paymentForm.ServiceChargeText = lblServiceCharge.Text;
            paymentForm.TotalAmountText = lblTotalAmount.Text;
            paymentForm.Show();
            this.Hide();
        }





        private void UpdateInformationPanel()
        {
            try
            {

                lblServiceName.Text = "";
                lblTestID.Text = "";
                lblAmount.Text = "";
                lblServiceCharge.Text = "";
                lblTotalAmount.Text = "";

                List<string> selectedServiceNames = new List<string>();
                List<string> selectedServiceIDs = new List<string>();
                double Amount = 0;

                foreach (DataGridViewRow row in dataGridViewServices.Rows)
                {
                    DataGridViewCheckBoxCell checkBox = row.Cells["CheckBoxColumn"] as DataGridViewCheckBoxCell;

                    if (checkBox != null && Convert.ToBoolean(checkBox.Value))
                    {
                        string serviceID = row.Cells["S_ID"].Value.ToString();
                        string serviceName = row.Cells["S_NAME"].Value.ToString();
                        double servicePrice = Convert.ToDouble(row.Cells["S_PRICE"].Value);

                        selectedServiceNames.Add(serviceName);
                        selectedServiceIDs.Add(serviceID);
                        Amount += servicePrice;
                    }
                }

                lblServiceName.Text = $"Selected Test: {string.Join(", ", selectedServiceNames)}";
                lblTestID.Text = $"Service IDs: {string.Join(", ", selectedServiceIDs)}";
                lblAmount.Text = $"Amount: Tk{Amount:F2}";

                double serviceCharge = Amount * 0.05;
                lblServiceCharge.Text = $"Service Charge(5 %): Tk{serviceCharge:F2}";

                double totalAmount = Amount + serviceCharge;
                lblTotalAmount.Text = $"Total Amount: Tk{totalAmount:F2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dataGridViewServices_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.ColumnIndex == dataGridViewServices.Columns["CheckBoxColumn"].Index)
                {
                    UpdateInformationPanel();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DisplayAvailableServices()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT S.S_ID, S.S_NAME, S.S_PRICE " +
                           "FROM Services S " +
                           "INNER JOIN DiagnosticCenterService DCS ON S.S_ID = DCS.S_ID " +
                           "WHERE DCS.D_ID = @D_ID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@D_ID", selectedD_ID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            dataGridViewServices.DataSource = dt;

                            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
                            checkBoxColumn.HeaderText = "Select";
                            checkBoxColumn.Name = "CheckBoxColumn";
                            dataGridViewServices.Columns.Insert(3, checkBoxColumn);
                        }
                    }
                }
                dataGridViewServices.AllowUserToAddRows = false;


                dataGridViewServices.Columns["S_ID"].HeaderText = "Service ID";
                dataGridViewServices.Columns["S_NAME"].HeaderText = "Name";
                dataGridViewServices.Columns["S_PRICE"].HeaderText = "Price";
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"A SQL error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewServices_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridViewServices.IsCurrentCellDirty)
            {
                dataGridViewServices.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtSearch.Text.Trim();

                if (!string.IsNullOrEmpty(searchText))
                {
                    DataView dv = new DataView((DataTable)dataGridViewServices.DataSource);
                    dv.RowFilter = $"S_NAME LIKE '%{searchText}%'";

                    if (dv.Count > 0)
                    {
                        dataGridViewServices.DataSource = dv.ToTable();
                        UpdateInformationPanel();
                    }
                    else
                    {
                        dataGridViewServices.DataSource = null;
                        MessageBox.Show("No services found with the given search term.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a search term.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"A SQL error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
