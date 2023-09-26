using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MedicalService.UserForms
{
    public partial class UserPassReset : Form
    {
        public UserPassReset()
        {
            InitializeComponent();
        }
        
        private void UserConfirmPassbtn_Click(object sender, EventArgs e)
        {
            try
            {
                // ServiceUser su = new ServiceUser();
                //this.Hide();
                //su.Show();
                if (UserNewPassTextBox.Text == "" || UserConfirmPassTextBox.Text == "")
                {
                    MessageBox.Show("Please insert all the fields");
                }
                else if ((UserNewPassTextBox.Text) == (UserConfirmPassTextBox.Text))
                {
                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-R72MAA8\\SQLEXPRESS;Initial Catalog=EMS;Integrated Security =True;User ID=sa;Password=*****");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE Users SET User_Password=@User_Password WHERE User_Name=@User_Name", con);
                    cmd.Parameters.AddWithValue("@User_Name", (ServiceUser.Uname));
                    cmd.Parameters.AddWithValue("@User_Password", (UserNewPassTextBox.Text));
                    cmd.ExecuteNonQuery();
                    con.Close();
                    UserNewPassTextBox.Text = "";
                    UserConfirmPassTextBox.Text = "";
                    this.Hide();
                    MessageBox.Show("Password Updated");
                }
                else
                {
                    MessageBox.Show("Password did't Match");
                    UserNewPassTextBox.Text = "";
                    UserConfirmPassTextBox.Text = "";
                    //this.Show();
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
           
        }
    }
}
