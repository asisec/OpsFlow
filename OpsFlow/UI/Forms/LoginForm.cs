using Microsoft.EntityFrameworkCore;
using System;
using System.Windows.Forms;

namespace OpsFlow.UI.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void lnkForgotText_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotPasswordForm forgotForm = new ForgotPasswordForm();
            forgotForm.Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var email = txtEmail.Text.Trim();
            var password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Email ve şifre zorunlu.");
                return;
            }

            try
            {
                using var context = Program.Database.CreateContext();

                using var connection = context.Database.GetDbConnection();
                connection.Open();

                using var command = connection.CreateCommand();
                command.CommandText = @"
            SELECT 1
            FROM users
            WHERE email = @email
              AND password = @password
              AND is_active = true
            LIMIT 1;
        ";

                var emailParam = command.CreateParameter();
                emailParam.ParameterName = "@email";
                emailParam.Value = email;

                var passwordParam = command.CreateParameter();
                passwordParam.ParameterName = "@password";
                passwordParam.Value = password;

                command.Parameters.Add(emailParam);
                command.Parameters.Add(passwordParam);

                var result = command.ExecuteScalar();

                if (result == null)
                {
                    MessageBox.Show("Kullanıcı bulunamadı.");
                    return;
                }

                MessageBox.Show("Giriş başarılı.");

                new MainForm().Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.ToString(),
                    "Login Hatası",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
