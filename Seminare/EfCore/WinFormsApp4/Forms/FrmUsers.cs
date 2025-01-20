using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp4.Core.Services;

namespace WinFormsApp4.Forms
{
    public partial class FrmUsers : Form
    {
        public FrmUsers()
        {
            InitializeComponent();
            FillUsers();
        }

        private void FillUsers()
        {
            var users = UsersService.GetUsers();
            this.dataGridView1.DataSource = users.Select(x => new
            {
                x.Id,
                x.Name,
                x.Surname,
                x.Email
            }).ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frm = new FrmAddUser();
            frm.FormClosed += (sender, args) =>
            {
                FillUsers();
            };
            frm.Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FillUsers();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var selectedRows = dataGridView1.SelectedRows;
            if (selectedRows.Count != 1)
            {
                MessageBox.Show("Zgjidhni saktesisht 1 perdorues");
                return;
            }
            var userId = int.Parse(selectedRows[0].Cells[0].Value.ToString());
            var frm = new FrmAddUser(userId);
            frm.FormClosed += (sender, args) =>
            {
                FillUsers();
            };
            frm.Show();
        }
    }
}
