using WinFormsApp4.Core.Services;

namespace WinFormsApp4
{
    public partial class FrmAddUser : Form
    {
        int userId = 0;
        public FrmAddUser(int userId = 0)
        {
            InitializeComponent();
            this.userId = userId;
            if(this.userId > 0)
            {
                this.FillUserInfo();
            }
        }

        private void FillUserInfo()
        {
            var user = UsersService.GetById(this.userId);
            if(user == null)
            {
                MessageBox.Show("Nuk ekziston perdoruesi i kerkuar");
                return;
            }
            txtName.Text = user.Name;
            txtSurname.Text = user.Surname;
            txtEmail.Text = user.Email;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (userId == 0)
            {
                UsersService.AddUser(new Core.User
                {
                    Name = txtName.Text,
                    Surname = txtSurname.Text,
                    Email = txtEmail.Text,
                    Password = txtPassword.Text,
                });
                MessageBox.Show("Perdoruesi u regjistrua me sukses");
            }
            else
            {
                UsersService.EditUser(userId, new Core.User
                {
                    Name = txtName.Text,
                    Surname = txtSurname.Text,
                    Email = txtEmail.Text,
                    Password = txtPassword.Text,
                });
                MessageBox.Show("Perdoruesi u modifikua me sukses");
            }
            this.Close();
        }
    }
}