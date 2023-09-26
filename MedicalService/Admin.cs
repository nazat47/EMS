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

namespace MedicalService
{
    public partial class Admin : Form
    {
        private Form activeForm4;
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
        public Admin()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm4 != null)
                activeForm4.Close();
            // ActivateButton(btnSender);
            activeForm4 = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.adminpanel.Controls.Add(childForm);
            this.adminpanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            //TitleLabel.Text = childForm.Text;
        }

        private void btnAdminPvd_Click(object sender, EventArgs e)
        {
            panelp.Height = btnAdminPvd.Height;
            panelp.Top = btnAdminPvd.Top;
            panelp.Left = btnAdminPvd.Left;
            btnAdminPvd.BackColor = Color.FromArgb(128, 0, 0);
            OpenChildForm(new Adminforms.AdminProviders(), sender);
        }

        private void btnAdminUsers_Click(object sender, EventArgs e)
        {
            panelp.Height = btnAdminUsers.Height;
            panelp.Top = btnAdminUsers.Top;
            panelp.Left = btnAdminUsers.Left;
            btnAdminUsers.BackColor = Color.FromArgb(128, 0, 0);
            OpenChildForm(new Adminforms.AdminUsers(), sender);
        }

        private void btnAdminMed_Click(object sender, EventArgs e)
        {
            panelp.Height = btnAdminMed.Height;
            panelp.Top = btnAdminMed.Top;
            panelp.Left = btnAdminMed.Left;
            btnAdminMed.BackColor = Color.FromArgb(128, 0, 0);
            OpenChildForm(new Adminforms.AdminMediators(), sender);
        }

        private void btnAdminReq_Click(object sender, EventArgs e)
        {
            panelp.Height = btnAdminReq.Height;
            panelp.Top = btnAdminReq.Top;
            panelp.Left = btnAdminReq.Left;
            btnAdminReq.BackColor = Color.FromArgb(128, 0, 0);
            OpenChildForm(new Adminforms.AdminService(), sender);
        }

        private void btnAdminLogout_Click(object sender, EventArgs e)
        {
            panelp.Height = btnAdminLogout.Height;
            panelp.Top = btnAdminLogout.Top;
            panelp.Left = btnAdminLogout.Left;
            btnAdminLogout.BackColor = Color.FromArgb(128, 0, 0);
            LoginAndRegister log = new LoginAndRegister();
            this.Hide();
            log.Show();
        }

        private void AdminClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AdminMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void AdminMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }
    }
}
