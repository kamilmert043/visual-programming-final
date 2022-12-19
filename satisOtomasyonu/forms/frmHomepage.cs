﻿using satisOtomasyonu.forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace satisOtomasyonu
{
    public partial class frmHomepage : Form
    {
        public frmHomepage()
        {
            InitializeComponent();
        }

        private void getForm(Form frm)
        {
            panelPages.Controls.Clear();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Left;
            panelPages.Controls.Add(frm);
            frm.Show();

        }
        private void frmHomepage_Load(object sender, EventArgs e)
        {

        }
        
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            frmAddProduct addProduct = new frmAddProduct();
            getForm(addProduct);
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmRegister userRegister = new frmRegister();
            getForm(userRegister);
        }

        private void frmHomepage_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnListProduct_Click(object sender, EventArgs e)
        {
            frmListProduct listProduct = new frmListProduct();
            getForm(listProduct);
        }

        private void btnAddProductGroup_Click(object sender, EventArgs e)
        {
            frmAddProductGroup addProductGroup = new frmAddProductGroup();
            getForm(addProductGroup);
        }

        private void btnListUser_Click(object sender, EventArgs e)
        {
            frmListUsers listUsers = new frmListUsers();
            getForm(listUsers);
        }
    }
}
