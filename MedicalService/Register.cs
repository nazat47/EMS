using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace MedicalService
{
    public partial class LoginAndRegister : Form
    {
        
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
       (
           int nLeftRect,
           int nTopRect,
           int nRightRect,
           int nBottomRect,
           int nWidthEllipse,
           int nHeightEllipse
       );
        public LoginAndRegister()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Register_Panel.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            if (RegisterOptions.Text == "Provider")
            {
                if (RegName.Text != "" && RegMobile.Text != "" && RegAddress.Text != "" && RegDoB.Text != "" && RegPass.Text != "" && RegConfirmPass.Text != "" && RegEmail.Text != "" && RegID.Text!="")
                {
                    if (RegID.Text.Length == 5)
                    {
                        SqlConnection con = new SqlConnection("Data Source=DESKTOP-R72MAA8\\SQLEXPRESS;Initial Catalog=EMS;Integrated Security =True;User ID=sa;Password=*****");
                        con.Open();
                        String query = "SELECT Provider_Id FROM Providers WHERE Provider_Id= '" + RegID.Text.Trim() + "'";
                        SqlDataAdapter sda = new SqlDataAdapter(query, con);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        if (dt.Rows.Count == 1)
                        {
                            MessageBox.Show("This ID is unavailable");
                        }
                        else
                        {
                            try
                            {
                                if (RegConfirmPass.Text == RegPass.Text)
                                {
                                    SqlCommand cmd = new SqlCommand("INSERT INTO Providers (Name, Provider_Id, Date_of_Birth, Address, Mobile, Email, Password) VALUES(@Name, @Provider_Id, @Date_of_Birth, @Address, @Mobile, @Email, @Password)", con);

                                    cmd.Parameters.AddWithValue("@Name", (RegName.Text));
                                    cmd.Parameters.AddWithValue("@Provider_Id", int.Parse(RegID.Text));
                                    cmd.Parameters.AddWithValue("@Date_of_Birth", DateTime.Parse(RegDoB.Text));
                                    cmd.Parameters.AddWithValue("@Address", (RegAddress.Text));
                                    cmd.Parameters.AddWithValue("@Mobile", (RegMobile.Text));
                                    cmd.Parameters.AddWithValue("@Email", (RegEmail.Text));
                                    cmd.Parameters.AddWithValue("@Password", (RegPass.Text));
                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                    MessageBox.Show("Registered");
                                    RegName.Text = "";
                                    RegID.Text = "";
                                    RegDoB.Text = "";
                                    RegAddress.Text = "";
                                    RegEmail.Text = "";
                                    RegMobile.Text = "";
                                    RegPass.Text = "";
                                    RegConfirmPass.Text = "";
                                    Register_Panel.Visible = false;
                                    Login_Palen.Visible = true;
                                }
                                else
                                {
                                    MessageBox.Show("Password did not match");
                                }
                            }
                            catch (Exception exc)
                            {
                                MessageBox.Show(exc.Message);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Your ID must be of 5 digits");
                    }
                    
                }
            }
            if (RegisterOptions.Text == "Patient")
            {
                if (RegName.Text != "" && RegMobile.Text != "" && RegAddress.Text != "" && RegDoB.Text != "" && RegPass.Text != "" && RegConfirmPass.Text != "" && RegEmail.Text != "" && RegID.Text != "")
                {
                    if (RegID.Text.Length == 5)
                    {
                        SqlConnection con = new SqlConnection("Data Source=DESKTOP-R72MAA8\\SQLEXPRESS;Initial Catalog=EMS;Integrated Security =True;User ID=sa;Password=*****");
                        con.Open();
                        String query = "SELECT User_Id FROM Users WHERE User_Id= '" + RegID.Text.Trim() + "'";
                        SqlDataAdapter sda = new SqlDataAdapter(query, con);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        if (dt.Rows.Count == 1)
                        {
                            MessageBox.Show("This ID is unavailable");
                        }
                        else
                        {
                            if (RegConfirmPass.Text == RegPass.Text)
                            {
                                // SqlConnection con = new SqlConnection("Data Source=DESKTOP-R72MAA8\\SQLEXPRESS;Initial Catalog=EMS;Integrated Security =True;User ID=sa;Password=*****");
                                //  con.Open();

                                SqlCommand cmd = new SqlCommand("INSERT INTO Users (User_Name, User_Id, User_Date_of_Birth, User_Address, User_Email, User_Mobile, User_Password) VALUES(@User_Name, @User_Id, @User_Date_of_Birth, @User_Address, @User_Email, @User_Mobile, @User_Password)", con);
                                try
                                {

                                    cmd.Parameters.AddWithValue("@User_Name", (RegName.Text));
                                    cmd.Parameters.AddWithValue("@User_Id", int.Parse(RegID.Text));
                                    cmd.Parameters.AddWithValue("@User_Date_of_Birth", DateTime.Parse(RegDoB.Text));
                                    cmd.Parameters.AddWithValue("@User_Address", (RegAddress.Text));
                                    cmd.Parameters.AddWithValue("@User_Email", (RegEmail.Text));
                                    cmd.Parameters.AddWithValue("@User_Mobile", (RegMobile.Text));
                                    cmd.Parameters.AddWithValue("@User_Password", (RegPass.Text));
                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                    MessageBox.Show("Registered");
                                    RegName.Text = "";
                                    RegID.Text = "";
                                    RegDoB.Text = "";
                                    RegAddress.Text = "";
                                    RegEmail.Text = "";
                                    RegMobile.Text = "";
                                    RegPass.Text = "";
                                    Register_Panel.Visible = false;
                                    Login_Palen.Visible = true;
                                }
                                catch (Exception exc)
                                {
                                    MessageBox.Show(exc.Message);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Password did not match");
                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show("Your ID must be of 5 digits");
                    }
                }
                
            
                
            }
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (LoginOption.Text == "")
            {
                MessageBox.Show("Please insert an option");
            }
                if (LoginOption.Text=="Patient")
            {
                ServiceUser sv = new ServiceUser();
                this.Hide();
                sv.Show();
            }
            if (LoginOption.Text == "Owner")
            {
                Provider pv = new Provider();
                this.Hide();
                pv.Show();
            }
           // else
            //{
              //  MessageBox.Show("Please insert an option");
            //}

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void ForgetButton_Click(object sender, EventArgs e)
        {

        }

        private void SignupButton_Click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login_Palen.Visible = false;
            Register_Panel.Visible = true;
        }

        private void RegisterClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void RegisterMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void RegisterMaximize_Click(object sender, EventArgs e)
        {
            if(WindowState==FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (LoginOption.Text == "")
            {
                MessageBox.Show("Please insert an option");
            }
            if (LoginOption.Text == "Admin")
            {
                try
                {
                    if (LoginNametxt.Text=="Admin" && LoginPasstxt.Text=="Admin")
                    {

                        Admin ad = new Admin();
                        this.Hide();
                        ad.Show();
                    }
                    else
                    {
                        MessageBox.Show("Name or Password is incorrect");
                    }
                }
                catch (Exception exc1)
                {
                    MessageBox.Show(exc1.Message);
                }
            }
            if (LoginOption.Text == "Patient")
            {
                try
                {
                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-R72MAA8\\SQLEXPRESS;Initial Catalog=EMS;Integrated Security =True;User ID=sa;Password=*****");
                    con.Open();
                    String query = "SELECT User_Name, User_Password FROM Users WHERE User_Name= '" + LoginNametxt.Text.Trim() + "' and User_Password= '"+ LoginPasstxt.Text.Trim() + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count == 1)
                    {
                        ServiceUser.Uname = LoginNametxt.Text;
                        ServiceUser sv = new ServiceUser();
                        this.Hide();
                        sv.Show();
                    }
                    else
                    {
                        MessageBox.Show("Name or Password is incorrect");
                    }
                }
                catch (Exception exc1)
                {
                    MessageBox.Show(exc1.Message);
                }
            }
            if (LoginOption.Text == "Provider")
            {
                try
                {
                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-R72MAA8\\SQLEXPRESS;Initial Catalog=EMS;Integrated Security =True;User ID=sa;Password=*****");
                    con.Open();
                    String query = "SELECT Name, Password FROM Providers WHERE Name= '" + LoginNametxt.Text.Trim() + "' and Password= '" + LoginPasstxt.Text.Trim() + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count == 1)
                    {
                        Provider.labelName = LoginNametxt.Text;
                        Provider pv = new Provider();
                        this.Hide();
                        pv.Show();
                    }
                    else
                    {
                        MessageBox.Show("Name or Password is incorrect");
                    }
                }
                catch(Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
        }

        private void RegLogInButt_Click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login_Palen.Visible = true;
            Register_Panel.Visible = false;

        }

       
        private void PassShowCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if(PassShowCheckbox.Checked)
            {
                LoginPasstxt.UseSystemPasswordChar = true;
            }
            else
            {
                LoginPasstxt.UseSystemPasswordChar = false;
               
                
            }
        }

        private void Register_Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RegName_Validating(object sender, CancelEventArgs e)
        {
            if(RegName.Text=="")
            {
                errorProvider1.SetError(RegName, "Please insert");
            }
            else
            {
                // e.Cancel = false;
                errorProvider1.SetError(RegName, null);

            }
        }

        private void RegID_Validating(object sender, CancelEventArgs e)
        {
            if (RegID.Text == "")
            {
                errorProvider1.SetError(RegID, "Please insert");
            }
            else
            {
                // e.Cancel = false;
                errorProvider1.SetError(RegID, null);

            }
        }

        private void RegDoB_Validating(object sender, CancelEventArgs e)
        {
            if (RegDoB.Text == "")
            {
                errorProvider1.SetError(RegDoB, "Please insert");
            }
            else
            {
                // e.Cancel = false;
                errorProvider1.SetError(RegDoB, null);

            }
        }

        private void RegEmail_Validating(object sender, CancelEventArgs e)
        {
            if (RegEmail.Text == "")
            {
                errorProvider1.SetError(RegEmail, "Please insert");
            }
            else
            {
                // e.Cancel = false;
                errorProvider1.SetError(RegEmail, null);

            }
        }

        private void RegAddress_Validating(object sender, CancelEventArgs e)
        {
            if (RegAddress.Text == "")
            {
                errorProvider1.SetError(RegAddress, "Please insert");
            }
            else
            {
                // e.Cancel = false;
                errorProvider1.SetError(RegAddress, null);

            }
        }

        private void RegPass_Validating(object sender, CancelEventArgs e)
        {
            if (RegPass.Text == "")
            {
                errorProvider1.SetError(RegPass, "Please insert");
            }
            else
            {
                // e.Cancel = false;
                errorProvider1.SetError(RegPass, null);

            }
        }

        private void RegConfirmPass_Validating(object sender, CancelEventArgs e)
        {
            if (RegConfirmPass.Text == "")
            {
                errorProvider1.SetError(RegConfirmPass, "Please insert");
            }
            else
            {
                // e.Cancel = false;
                errorProvider1.SetError(RegConfirmPass, null);

            }
        }

        private void RegMobile_Validating(object sender, CancelEventArgs e)
        {
            if (RegMobile.Text == "")
            {
                errorProvider1.SetError(RegMobile, "Please insert");
            }
            else
            {
                // e.Cancel = false;
                errorProvider1.SetError(RegMobile, null);

            }
        }

        private void LoginNametxt_Validating(object sender, CancelEventArgs e)
        {
            if(LoginNametxt.Text=="")
            {
                //e.Cancel = true;
               // LoginNametxt.Focus();
                errorProvider1.SetError(LoginNametxt, "please insert");
            }
            else
            {
               // e.Cancel = false;
                errorProvider1.SetError(LoginNametxt, null);

            }
        }

        private void LoginPasstxt_Validating(object sender, CancelEventArgs e)
        {
            if (LoginPasstxt.Text == "")
            {
                errorProvider1.SetError(LoginPasstxt, "please insert");
            }
            else
            {
                // e.Cancel = false;
                errorProvider1.SetError(LoginPasstxt, null);

            }
        }

        private void LoginNametxt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
