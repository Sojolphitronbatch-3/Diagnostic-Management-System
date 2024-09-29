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
using System.Xml.Linq;

namespace Diagnostic_Management_System
{
    public partial class Paymentfrm : Form
    {
        private const string connectionString = "Data Source=DESKTOP-ODCLL6A\\SQLEXPRESS;Initial Catalog=sojol;Integrated Security=True";
        public string AmountText
        {
            get { return lblAmount.Text; }
            set { lblAmount.Text = value; }
        }

        public string ServiceChargeText
        {
            get { return lblServiceCharge.Text; }
            set { lblServiceCharge.Text = value; }
        }

        public string TotalAmountText
        {
            get { return lblTotalAmount.Text; }
            set { lblTotalAmount.Text = value; }
        }

        private List<string> selectedServices;
        private Servicefrm serviceForm;
        public string SelectedD_ID { get; private set; }
        public string SelectedP_ID { get; private set; }
        private List<PictureBox> emptyStars;
        private List<PictureBox> filledStars;
        public Paymentfrm(List<string> selectedServices, Servicefrm serviceForm, string selectedD_ID, string selectedP_ID)
        {
            InitializeComponent();
            this.selectedServices = selectedServices;
            this.serviceForm = serviceForm;
            this.SelectedD_ID = selectedD_ID;
            this.SelectedP_ID = selectedP_ID;
            InitializeStarRating();
        }

        private void Paymentfrm_Load(object sender, EventArgs e)
        {
            lblAmount.Text = AmountText;
            lblServiceCharge.Text = ServiceChargeText;
            lblTotalAmount.Text = TotalAmountText;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            serviceForm.Show();
            this.Hide();
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnConfirmPayment_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (string.IsNullOrEmpty(GetSelectedPaymentMethod()))
                {
                    MessageBox.Show("Please select a payment method.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (comboBoxNumber.SelectedItem == null)
                {
                    MessageBox.Show("Please select a payment number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string orderDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string numericPart = lblTotalAmount.Text.Replace("Total Amount: Tk", "");
                if (double.TryParse(numericPart, out double totalAmount))
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string orderQuery = "INSERT INTO Orders (D_ID, P_ID, O_DATE, O_PRICE) OUTPUT INSERTED.O_ID " +"VALUES (@D_ID, @P_ID, @O_DATE, @O_PRICE)";


                        using (SqlCommand command = new SqlCommand(orderQuery, connection))
                        {
                            command.Parameters.AddWithValue("@D_ID", SelectedD_ID);
                            command.Parameters.AddWithValue("@P_ID", SelectedP_ID);
                            command.Parameters.AddWithValue("@O_DATE", orderDate);
                            command.Parameters.AddWithValue("@O_PRICE", totalAmount);

                         
                            string generatedOrderID = command.ExecuteScalar()?.ToString();


                            string paymentMethod = GetSelectedPaymentMethod();
                            string paymentNumber = comboBoxNumber.SelectedItem?.ToString();

                            string paymentQuery = "INSERT INTO Payment (P_ID, PAY_METHOD, O_ID, PAYMENT_NUMBER) VALUES (@P_ID, @PAY_METHOD, @O_ID, @PAYMENT_NUMBER)";

                            using (SqlCommand paymentCommand = new SqlCommand(paymentQuery, connection))
                            {
                                paymentCommand.Parameters.AddWithValue("@P_ID", SelectedP_ID);
                                paymentCommand.Parameters.AddWithValue("@PAY_METHOD", paymentMethod);
                                paymentCommand.Parameters.AddWithValue("@O_ID", generatedOrderID);
                                paymentCommand.Parameters.AddWithValue("@PAYMENT_NUMBER", paymentNumber);

                                paymentCommand.ExecuteNonQuery();
                            }
                        }
                    }

                    panelPayment.Visible = false;
                    groupBoxReview.Visible = true;
                    MessageBox.Show("Payment confirmed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Invalid total amount format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetSelectedPaymentMethod()
        {
            if (radioBkash.Checked) return "Bkash";
            if (radioNagod.Checked) return "Nagod";
            if (radioRocket.Checked) return "Rocket";
            if (radioUpay.Checked) return "Upay";

            return string.Empty;
        }

        private void InitializeStarRating()
        {
            emptyStars = new List<PictureBox> { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5 };
            filledStars = new List<PictureBox> { pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox10 };

            // Hide all filled stars initially
            foreach (var star in filledStars)
            {
                star.Visible = false;
            }

            // Wire up the Click event for each empty star
            foreach (var emptyStar in emptyStars)
            {
                emptyStar.Click += pictureBox_Click;
            }
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            PictureBox clickedPictureBox = sender as PictureBox;

            if (clickedPictureBox != null)
            {
                // Get the index of the clicked PictureBox
                int clickedIndex = emptyStars.IndexOf(clickedPictureBox);

                // Show the corresponding filled stars
                for (int i = 0; i <= clickedIndex; i++)
                {
                    filledStars[i].Visible = true;
                }
            }
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the selected star rating
                int starRating = filledStars.Count(pictureBox => pictureBox.Visible);

                // Get the comment from the TextBox
                string comment = txtComment.Text.Trim();

                // Validate that a star rating is selected
                if (starRating == 0)
                {
                    MessageBox.Show("Please select a star rating before submitting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    
                    string ratingQuery = "INSERT INTO Rating (P_ID, D_ID, O_ID, COMMENT, STAR) " +
                                         "VALUES (@P_ID, @D_ID, @O_ID, @COMMENT, @STAR)";

                    using (SqlCommand ratingCommand = new SqlCommand(ratingQuery, connection))
                    {
                        ratingCommand.Parameters.AddWithValue("@P_ID", SelectedP_ID);
                        ratingCommand.Parameters.AddWithValue("@D_ID", SelectedD_ID);
                        ratingCommand.Parameters.AddWithValue("@O_ID", GetLatestOrderID()); // Call a method to get the latest order ID
                        ratingCommand.Parameters.AddWithValue("@COMMENT", comment);
                        ratingCommand.Parameters.AddWithValue("@STAR", starRating);

                        ratingCommand.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Rating submitted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string GetLatestOrderID()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Query to get the latest order ID for the current patient and diagnostic center
                string query = "SELECT TOP 1 O_ID FROM Orders WHERE P_ID = @P_ID AND D_ID = @D_ID ORDER BY O_DATE DESC";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@P_ID", SelectedP_ID);
                    command.Parameters.AddWithValue("@D_ID", SelectedD_ID);

                    object result = command.ExecuteScalar();
                    return result?.ToString();
                }
            }
        }


    }
}
