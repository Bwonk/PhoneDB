using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form

    {

        string connectionString = "Server=localhost\\SQLEXPRESS;Database=PhoneDB;Trusted_Connection=True;Encrypt=False;";

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textArama_TextChanged(object sender, EventArgs e)
        {

        }

        private void SqlDosyasiniCalistir(string dosyaAdi)
        {
            try
            {
                string scriptYolu = Path.Combine(Application.StartupPath, dosyaAdi);
                string script = File.ReadAllText(scriptYolu);

                // "GO" komutlarýna göre böl
                string[] komutlar = Regex.Split(script, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);

                using (SqlConnection baglanti = new SqlConnection("Server=.;Database=master;Trusted_Connection=True;"))
                {
                    baglanti.Open();

                    foreach (string komut in komutlar)
                    {
                        if (string.IsNullOrWhiteSpace(komut))
                            continue;

                        using (SqlCommand cmd = new SqlCommand(komut, baglanti))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("SQL çalýþtýrma hatasý: " + ex.Message);
            }
        }


        private void btnAra_Click(object sender, EventArgs e)
        {
            dataGridViewSonuc.DataSource = null;

            string input = txtArama.Text.Trim();
            if (string.IsNullOrWhiteSpace(input) ||
                input == "Arama kriteri giriniz..." ||
                input == "Ýsim giriniz..." ||
                input == "Telefon numarasý giriniz...")
            {
                MessageBox.Show("Lütfen geçerli bir arama metni girin.");
                return;
            }

            string? secim = cmbAramaTuru.SelectedItem?.ToString();
            string query = "";

            if (secim == "Ýsme Göre")
            {
                query = "SELECT FirstName AS [Ad], LastName AS [Soyad], PhoneNumber AS [Telefon], Address AS [Adres] FROM Contacts WHERE FirstName LIKE @param OR LastName LIKE @param";
            }
            else if (secim == "Telefona Göre")
            {
                query = "SELECT FirstName AS [Ad], LastName AS [Soyad], PhoneNumber AS [Telefon], Address AS [Adres] FROM Contacts WHERE PhoneNumber LIKE @param";
            }
            else
            {
                MessageBox.Show("Arama türü seçilmedi.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@param", "%" + input + "%");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Kayýt bulunamadý.", "Arama Sonucu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dataGridViewSonuc.DataSource = dt;
                }

              }
            }

        private void Form1_Load(object? sender, EventArgs e)
        {
            // ComboBox Ayarlarý
            cmbAramaTuru.Items.Add("Ýsme Göre");
            cmbAramaTuru.Items.Add("Telefona Göre");
            cmbAramaTuru.SelectedIndex = 0;

            // Placeholder ayarý
            txtArama.Text = "Arama kriteri giriniz...";
            txtArama.ForeColor = Color.Gray;

            txtArama.GotFocus += TxtArama_GotFocus;
            txtArama.LostFocus += TxtArama_LostFocus;

            cmbAramaTuru.SelectedIndexChanged += cmbAramaTuru_SelectedIndexChanged;

            // SQL dosyasý varsa çalýþtýrmak istersen burayý açabilirsin
            // SqlDosyasiniCalistir("PhoneDB.sql");
        }

        private void TxtArama_GotFocus(object? sender, EventArgs e)
        {
            if (txtArama.Text == "Arama kriteri giriniz...")
            {
                txtArama.Text = "";
                txtArama.ForeColor = Color.Black;
            }
        }

        private void TxtArama_LostFocus(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtArama.Text))
            {
                txtArama.Text = "Arama kriteri giriniz...";
                txtArama.ForeColor = Color.Gray;
            }
        }

        private void cmbAramaTuru_SelectedIndexChanged(object? sender, EventArgs e)
        {
            txtArama.Text = cmbAramaTuru.SelectedItem?.ToString() == "Ýsme Göre"
                ? "Ýsim giriniz..."
                : "Telefon numarasý giriniz...";
            txtArama.ForeColor = Color.Gray;
        }
    }
}
