﻿using System;
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
    public partial class ServiceUser : Form
    {
        private Form activeForm2;
        public static String Uname;

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
        public ServiceUser()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            pnl2.Height = btnUserHome.Height;
            pnl2.Top = btnUserHome.Top;
            pnl2.Left = btnUserHome.Left;
            btnUserHome.BackColor = Color.FromArgb(128, 0, 0);
        }

        private void UserHome_click(object sender, EventArgs e)
        {
            pnl2.Height = btnUserHome.Height;
            pnl2.Top = btnUserHome.Top;
            pnl2.Left = btnUserHome.Left;
            btnUserHome.BackColor = Color.FromArgb(128, 0, 0);
            OpenChildForm(new UserForms.UserHome(), sender);
        }
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm2 != null)
                activeForm2.Close();
            // ActivateButton(btnSender);
            activeForm2 = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.UserHomePanel.Controls.Add(childForm);
            this.UserHomePanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            UserTitleLabel.Text = childForm.Text;
        }

        private void UserBilling_click(object sender, EventArgs e)
        {
            pnl2.Height = btnUserBilling.Height;
            pnl2.Top = btnUserBilling.Top;
            pnl2.Left = btnUserBilling.Left;
            btnUserBilling.BackColor = Color.FromArgb(128, 0, 0);
            OpenChildForm(new UserForms.UserBilling(), sender);
        }

        private void UserRequests_click(object sender, EventArgs e)
        {
            pnl2.Height = btnUserRequests.Height;
            pnl2.Top = btnUserRequests.Top;
            pnl2.Left = btnUserRequests.Left;
            btnUserRequests.BackColor = Color.FromArgb(128, 0, 0);
            OpenChildForm(new UserForms.UserRequests(), sender);
        }

        private void UserAccount_click(object sender, EventArgs e)
        {
            pnl2.Height = btnUserAccount.Height;
            pnl2.Top = btnUserAccount.Top;
            pnl2.Left = btnUserAccount.Left;
            btnUserAccount.BackColor = Color.FromArgb(128, 0, 0);
            OpenChildForm(new UserForms.UserAccount() ,sender);
        }

        private void UserLogout_click(object sender, EventArgs e)
        {
            pnl2.Height = btnUserLogout.Height;
            pnl2.Top = btnUserLogout.Top;
            pnl2.Left = btnUserLogout.Left;
            btnUserLogout.BackColor = Color.FromArgb(128, 0, 0);
            LoginAndRegister lg = new LoginAndRegister();
            this.Hide();
            lg.Show();
        }

        private void UserSearch_click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureTools_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnUserSearch_click(object sender, EventArgs e)
        {

        }

        private void btnUserTextBox_TextChanged(object sender, EventArgs e)
        {
            if (btnUserTextBox.Text == "Search in your services")
            {
                btnUserTextBox.Clear();
            }
        }

        private void UserMaximize_Click(object sender, EventArgs e)
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

        private void UserMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void UserClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ServiceUser_Load(object sender, EventArgs e)
        {

        }

        private void ServiceUser_Load_1(object sender, EventArgs e)
        {
            ServiceUserName.Text = Uname;
        }

        private void UserMedicine_Click(object sender, EventArgs e)
        {
            OpenChildForm(new UserForms.User_Medicine(), sender);
        }

        private void UserAid_Click(object sender, EventArgs e)
        {
            OpenChildForm(new UserForms.User_FirstAid(), sender);
        }

        private void UserTools_Click(object sender, EventArgs e)
        {
            OpenChildForm(new UserForms.User_Tools(), sender);
        }

        private void UserAmbulance_Click(object sender, EventArgs e)
        {
            OpenChildForm(new UserForms.User_Ambulance(), sender);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUser2SearchSvc_Click(object sender, EventArgs e)
        {
            OpenChildForm(new UserForms.UserSearch(), sender);
        }
    }
}
