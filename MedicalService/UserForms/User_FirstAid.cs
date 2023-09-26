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

namespace MedicalService.UserForms
{
    public partial class User_FirstAid : Form
    {
        public User_FirstAid()
        {
            InitializeComponent();
        }
        void BindData()
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-R72MAA8\\SQLEXPRESS;Initial Catalog=EMS;Integrated Security =True;User ID=sa;Password=*****");
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM FirstAids", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                UsrFirstAidDataGrid.DataSource = dt;
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            
        }
        private void UsrAidReq_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (UserAidPvrIDTxt.Text == "" || UserReqAidLabel.Text == "" || UserAidNameTxt.Text == "" || UserAidQuantityTxt.Text == "" || UserAidQuantityTxt.Text == "" || UserAidIDTxt.Text == "" || UserAidAddressTxt.Text == "" || UserAidMobileTxt.Text == "")
                {
                    MessageBox.Show("Please insert all the fields");
                }
                else
                {
                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-R72MAA8\\SQLEXPRESS;Initial Catalog=EMS;Integrated Security =True;User ID=sa;Password=*****");
                    con.Open();
                    String query = "SELECT User_Id, User_Name FROM Users WHERE User_Id= '" + UserAidIDTxt.Text.Trim() + "' and User_Name= '" + ServiceUser.Uname.Trim() + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count == 1)
                    {

                        // SqlConnection con = new SqlConnection("Data Source=DESKTOP-R72MAA8\\SQLEXPRESS;Initial Catalog=EMS;Integrated Security =True;User ID=sa;Password=*****");
                        //  con.Open();
                        SqlCommand cmd = new SqlCommand("INSERT INTO Requests (Provider_Id, Service_Type, Service_Name, Quantity_Request, Cost, User_Id, User_Address, User_Mobile) VALUES(@Provider_Id, @Service_Type, @Service_Name, @Quantity_Request, @Cost, @User_Id, @User_Address, @User_Mobile)", con);
                        cmd.Parameters.AddWithValue("@Provider_Id", int.Parse((UserAidPvrIDTxt.Text)));
                        cmd.Parameters.AddWithValue("@Service_Type", (UserReqAidLabel.Text));
                        cmd.Parameters.AddWithValue("@Service_Name", (UserAidNameTxt.Text));
                        cmd.Parameters.AddWithValue("@Quantity_Request", int.Parse(UserAidQuantityTxt.Text));
                        cmd.Parameters.AddWithValue("@Cost", (int.Parse(UserAidPriceTag.Text) * int.Parse(UserAidQuantityTxt.Text)));
                        cmd.Parameters.AddWithValue("@User_Id", int.Parse(UserAidIDTxt.Text));
                        cmd.Parameters.AddWithValue("@User_Address", (UserAidAddressTxt.Text));
                        cmd.Parameters.AddWithValue("@User_Mobile", (UserAidMobileTxt.Text));
                        cmd.ExecuteNonQuery();
                     
                        con.Close();
                        UserAidPvrIDTxt.Text = "";
                        UserReqAidLabel.Text = "";
                        UserAidNameTxt.Text = "";
                        UserAidQuantityTxt.Text = "";
                        UserAidQuantityTxt.Text = "";
                        UserAidIDTxt.Text = "";
                        UserAidAddressTxt.Text = "";
                        UserAidMobileTxt.Text = "";
                        BindData();
                        MessageBox.Show("Requested");
                    }
                    else
                    {
                        MessageBox.Show("Inserted ID is not associated with your account");
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void User_FirstAid_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-R72MAA8\\SQLEXPRESS;Initial Catalog=EMS;Integrated Security =True;User ID=sa;Password=*****");
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM FirstAids", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                UsrFirstAidDataGrid.DataSource = dt;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void UserAidGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    UserAidNameTxt.Text = UsrFirstAidDataGrid.SelectedRows[0].Cells["Aid_Type"].Value.ToString();
                    UserAidPriceTag.Text = UsrFirstAidDataGrid.SelectedRows[0].Cells["Aid_Price"].Value.ToString();
                    UserAidPvrIDTxt.Text = UsrFirstAidDataGrid.SelectedRows[0].Cells["Provider_Id"].Value.ToString();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
