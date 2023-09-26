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
    public partial class Mediator_Details : Form
    {
        public Mediator_Details()
        {
            InitializeComponent();
        }

        void BindData()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-R72MAA8\\SQLEXPRESS;Initial Catalog=EMS;Integrated Security =True;User ID=sa;Password=*****");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Mediators WHERE Provider_Id=@Provider_Id", con);
            cmd.Parameters.AddWithValue("@Provider_Id", (MedProviderId.Text));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            MediatorDataGrid.DataSource = dt;
        }
        private void MedInsert_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-R72MAA8\\SQLEXPRESS;Initial Catalog=EMS;Integrated Security =True;User ID=sa;Password=*****");
                con.Open();
                String query = "SELECT Provider_Id, Name FROM Providers WHERE Provider_Id= '" + MedProviderId.Text.Trim() + "' and Name= '" + Provider.labelName.Trim() + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                   //SqlConnection con = new SqlConnection("Data Source=DESKTOP-FBTM80V;Initial Catalog=EMS;Integrated Security=True");
                  //  con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Mediators (Mediator_Name, Mediator_Mobile, Mediator_Email, Mediator_Address, Mediator_Id, Provider_id) VALUES(@Mediator_Name, @Mediator_Mobile, @Mediator_Email, @Mediator_Address, @Mediator_Id, @Provider_Id)", con);
                    cmd.Parameters.AddWithValue("@Mediator_Name", (MedNametxt.Text));
                    cmd.Parameters.AddWithValue("@Mediator_Mobile", (MedMbltxt.Text));
                    cmd.Parameters.AddWithValue("@Mediator_Email", (MedEmailtxt.Text));
                    cmd.Parameters.AddWithValue("@Mediator_Address", (MedAddresstxt.Text));
                    cmd.Parameters.AddWithValue("@Mediator_Id", int.Parse(MedIDtxt.Text));
                    cmd.Parameters.AddWithValue("@Provider_Id", (MedProviderId.Text));
                    cmd.ExecuteNonQuery();
                    con.Close();
                   // MedProviderId.Text = "";
                    MedNametxt.Text = "";
                    MedMbltxt.Text = "";
                    MedEmailtxt.Text = "";
                    MedAddresstxt.Text = "";
                    MedIDtxt.Text = "";
                    BindData();
                    MessageBox.Show("Inserted");
                }
                else
                {
                    MessageBox.Show("Inserted ID is not associated with your account");
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show("There was an error, check your inputs");
            }
        }

        private void MedUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-R72MAA8\\SQLEXPRESS;Initial Catalog=EMS;Integrated Security =True;User ID=sa;Password=*****");
                con.Open();
                String query = "SELECT Provider_Id, Name FROM Providers WHERE Provider_Id= '" + MedProviderId.Text.Trim() + "' and Name= '" + Provider.labelName.Trim() + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                   // SqlConnection con = new SqlConnection("Data Source=DESKTOP-R72MAA8\\SQLEXPRESS;Initial Catalog=EMS;Integrated Security =True;User ID=sa;Password=*****");
                   // con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE Mediators SET Mediator_Name=@Mediator_Name, Mediator_Mobile=@Mediator_Mobile, Mediator_Email=@Mediator_Email, Mediator_Address=@Mediator_Address, Provider_id=@Provider_id WHERE Mediator_Id=@Mediator_Id", con);
                    cmd.Parameters.AddWithValue("@Mediator_Name", (MedNametxt.Text));
                    cmd.Parameters.AddWithValue("@Mediator_Mobile", (MedMbltxt.Text));
                    cmd.Parameters.AddWithValue("@Mediator_Email", (MedEmailtxt.Text));
                    cmd.Parameters.AddWithValue("@Mediator_Address", (MedAddresstxt.Text));
                    cmd.Parameters.AddWithValue("@Mediator_Id", int.Parse(MedIDtxt.Text));
                    cmd.Parameters.AddWithValue("@Provider_Id", int.Parse(MedProviderId.Text));
                    cmd.ExecuteNonQuery();
                    con.Close();
                    //MedProviderId.Text = "";
                    MedNametxt.Text = "";
                    MedMbltxt.Text = "";
                    MedEmailtxt.Text = "";
                    MedAddresstxt.Text = "";
                    MedIDtxt.Text = "";
                    BindData();
                    MessageBox.Show("Updated");
                }
                else
                {
                    MessageBox.Show("Inserted ID is not associated with your account");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void MedDelete_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-R72MAA8\\SQLEXPRESS;Initial Catalog=EMS;Integrated Security =True;User ID=sa;Password=*****");
                con.Open();
                String query = "SELECT Provider_Id, Name FROM Providers WHERE Provider_Id= '" + MedProviderId.Text.Trim() + "' and Name= '" + Provider.labelName.Trim() + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    //SqlConnection con = new SqlConnection("Data Source=DESKTOP-FBTM80V;Initial Catalog=EMS;Integrated Security=True");
                   // con.Open();
                    SqlCommand cmd = new SqlCommand("DELETE Mediators WHERE Mediator_Id=@Mediator_Id", con);
                    cmd.Parameters.AddWithValue("@Mediator_Id", int.Parse(MedIDtxt.Text));
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MedNametxt.Text = "";
                    MedMbltxt.Text = "";
                    MedEmailtxt.Text = "";
                    MedAddresstxt.Text = "";
                    MedIDtxt.Text = "";
                    BindData();
                    MessageBox.Show("Deleted");
                }
                else
                {
                    MessageBox.Show("Inserted ID is not associated with your account");
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void Mediator_Details_Load(object sender, EventArgs e)
        {
            /*SqlConnection con = new SqlConnection("Data Source=DESKTOP-FBTM80V;Initial Catalog=EMS;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Mediators WHERE Name=@Name", con);
            cmd.Parameters.AddWithValue("@Name", Provider.labelName);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            MediatorDataGrid.DataSource = dt;*/
        }

        private void MediatorDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void MediatorDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex>=0)
            {
                MedProviderId.Text = MediatorDataGrid.SelectedRows[0].Cells["Provider_Id"].Value.ToString();
                MedNametxt.Text = MediatorDataGrid.SelectedRows[0].Cells["Mediator_Name"].Value.ToString();
                MedMbltxt.Text = MediatorDataGrid.SelectedRows[0].Cells["Mediator_Mobile"].Value.ToString();
                MedEmailtxt.Text = MediatorDataGrid.SelectedRows[0].Cells["Mediator_Email"].Value.ToString();
                MedAddresstxt.Text = MediatorDataGrid.SelectedRows[0].Cells["Mediator_Address"].Value.ToString();
                MedIDtxt.Text = MediatorDataGrid.SelectedRows[0].Cells["Mediator_Id"].Value.ToString();
            }
        }

        private void CheckAllMed_Click(object sender, EventArgs e)
        {
            try
            {
                if (MedProviderId.Text == "")
                {
                    MessageBox.Show("Insert your Id");
                }
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-R72MAA8\\SQLEXPRESS;Initial Catalog=EMS;Integrated Security =True;User ID=sa;Password=*****");
                con.Open();
                String query = "SELECT Provider_Id, Name FROM Providers WHERE Provider_Id= '" + MedProviderId.Text.Trim() + "' and Name= '" + Provider.labelName.Trim() + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count == 1)
                {

                    // SqlConnection con = new SqlConnection("Data Source=DESKTOP-R72MAA8\\SQLEXPRESS;Initial Catalog=EMS;Integrated Security =True;User ID=sa;Password=*****");
                    //con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Mediators WHERE Provider_Id=@Provider_Id", con);
                    cmd.Parameters.AddWithValue("@Provider_Id", (MedProviderId.Text));
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dts = new DataTable();
                    da.Fill(dts);
                    
                    //MedProviderId.Text = "";
                    MediatorDataGrid.DataSource = dts;
                }
                else
                {
                    MessageBox.Show("Inserted ID is not associated with your account");
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
