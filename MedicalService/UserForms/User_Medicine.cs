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
    public partial class User_Medicine : Form
    {
        public User_Medicine()
        {
            InitializeComponent();
        }
        void BindData()
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-R72MAA8\\SQLEXPRESS;Initial Catalog=EMS;Integrated Security =True;User ID=sa;Password=*****");
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Medicines", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                UsrMdcDataGrid.DataSource = dt;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        private void UsrMedicineReq_Click(object sender, EventArgs e)
        {
          
            try
            {
                if (UserMedicinePvrIDTxt.Text == "" || UserReqMedicineLabel.Text == "" || UserMedicineNameTxt.Text == "" || UserMedicineQuantityTxt.Text == "" || UserMedicinePriceTag.Text == "" || UserMedicineUserIdTxt.Text == "" || UserMedicineAddressTxt.Text == "" || UserMedicineMobileTxt.Text == "")
                {
                    MessageBox.Show("Please insert all the fields");
                }
                else
                {
                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-R72MAA8\\SQLEXPRESS;Initial Catalog=EMS;Integrated Security =True;User ID=sa;Password=*****");
                    con.Open();
                    String query = "SELECT User_Id, User_Name FROM Users WHERE User_Id= '" + UserMedicineUserIdTxt.Text.Trim() + "' and User_Name= '" + ServiceUser.Uname.Trim() + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count == 1)
                    {
                      //  SqlConnection con = new SqlConnection("Data Source=DESKTOP-R72MAA8\\SQLEXPRESS;Initial Catalog=EMS;Integrated Security =True;User ID=sa;Password=*****");
                       // con.Open();
                        SqlCommand cmd = new SqlCommand("INSERT INTO Requests (Provider_Id, Service_Type, Service_Name, Quantity_Request, Cost, User_Id, User_Address, User_Mobile) VALUES(@Provider_Id, @Service_Type, @Service_Name, @Quantity_Request, @Cost, @User_Id, @User_Address, @User_Mobile)", con);
                        cmd.Parameters.AddWithValue("@Provider_Id", int.Parse((UserMedicinePvrIDTxt.Text)));
                        cmd.Parameters.AddWithValue("@Service_Type", (UserReqMedicineLabel.Text));
                        cmd.Parameters.AddWithValue("@Service_Name", (UserMedicineNameTxt.Text));
                        cmd.Parameters.AddWithValue("@Quantity_Request", int.Parse(UserMedicineQuantityTxt.Text));
                        cmd.Parameters.AddWithValue("@Cost", (int.Parse(UserMedicinePriceTag.Text) * int.Parse(UserMedicineQuantityTxt.Text)));
                        cmd.Parameters.AddWithValue("@User_Id", int.Parse(UserMedicineUserIdTxt.Text));
                        cmd.Parameters.AddWithValue("@User_Address", (UserMedicineAddressTxt.Text));
                        cmd.Parameters.AddWithValue("@User_Mobile", (UserMedicineMobileTxt.Text));
                        cmd.ExecuteNonQuery();
                       
                        con.Close();
                        UserMedicinePvrIDTxt.Text = "";
                        UserReqMedicineLabel.Text = "";
                        UserMedicineNameTxt.Text = "";
                        UserMedicineQuantityTxt.Text = "";
                        UserMedicinePriceTag.Text = "";
                        UserMedicineUserIdTxt.Text = "";
                        UserMedicineAddressTxt.Text = "";
                        UserMedicineMobileTxt.Text = "";
                        BindData();
                        MessageBox.Show("Requested");
                    }
                    else
                    {
                        MessageBox.Show("Inserted ID is not associated with your account");
                    }
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            
        }

        private void User_Medicine_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-R72MAA8\\SQLEXPRESS;Initial Catalog=EMS;Integrated Security =True;User ID=sa;Password=*****");
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Medicines", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                UsrMdcDataGrid.DataSource = dt;
            }           
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void UserDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    UserMedicineNameTxt.Text = UsrMdcDataGrid.SelectedRows[0].Cells["Medicine_Name"].Value.ToString();
                    UserMedicinePriceTag.Text = UsrMdcDataGrid.SelectedRows[0].Cells["Medicine_Price"].Value.ToString();
                    UserMedicinePvrIDTxt.Text = UsrMdcDataGrid.SelectedRows[0].Cells["Provider_Id"].Value.ToString();
                }
            }           
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
