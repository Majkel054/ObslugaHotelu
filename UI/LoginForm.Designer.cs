namespace Hotel_Management_App.UI
{
    partial class LoginForm
    {
        private TextBox usernameBox;
        private TextBox passwordBox;
        private Button loginButton;

        private void InitializeComponent()
        {
            usernameBox = new TextBox { PlaceholderText = "Login", Location = new Point(10, 10), Width = 200 };
            passwordBox = new TextBox { PlaceholderText = "Hasło", Location = new Point(10, 40), Width = 200, UseSystemPasswordChar = true };
            loginButton = new Button { Text = "Zaloguj", Location = new Point(10, 70), Width = 200 };
            loginButton.Click += loginButton_Click;

            Controls.Add(usernameBox);
            Controls.Add(passwordBox);
            Controls.Add(loginButton);
            ClientSize = new Size(230, 110);
            Text = "Panel logowania";
            StartPosition = FormStartPosition.CenterScreen;
        }
    }
}