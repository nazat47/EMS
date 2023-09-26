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

namespace MedicalService.Forms
{
    public partial class ProviderPassReset : Form
    {
        public ProviderPassReset()
        {
            InitializeComponent();
        }

        private void ProviderConfirmPass_Click(object sender, EventArgs e)
        {
            try
            {
                // ServiceUser su = new ServiceUser();
                //this.Hide();
                //su.Show();
                if (PvdAccNewPass.Text == "" || PvdAccConfirmPass.Text == "")
                {
                    MessageBox.Show("Please insert all the fields");
                }
                else if ((PvdAccNewPass.Text) == (PvdAccConfirmPass.Text))
                {
                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-R72MAA8\\SQLEXPRESS;Initial Catalog=EMS;Integrated Security =True;User ID=sa;Password=*****");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE Providers SET Password=@Password WHERE Name=@Name", con);
                    cmd.Parameters.AddWithValue("@Name", (Provider.labelName));
                    cmd.Parameters.AddWithValue("@Password", (PvdAccNewPass.Text));
                    cmd.ExecuteNonQuery();
                    con.Close();
                    PvdAccNewPass.Text = "";
                    PvdAccConfirmPass.Text = "";
                    this.Hide();
                    MessageBox.Show("Password Updated");
                }
                else
                {
                    MessageBox.Show("Password didn't Match");
                    PvdAccNewPass.Text = "";
                    PvdAccConfirmPass.Text = "";
                   // this.Show();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
