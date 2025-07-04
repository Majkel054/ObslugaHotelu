namespace Hotel_Management_App.UI
{
    public partial class ClientsControl : UserControl
    {
        private ListBox listBoxClients = null!;
        private Button buttonAdd = null!;
        private Button buttonEdit = null!;
        private Button buttonDelete = null!;

        private void InitializeComponent()
        {
            listBoxClients = new ListBox { Location = new Point(10, 10), Size = new Size(300, 200) };
            buttonAdd = new Button { Text = "Dodaj", Location = new Point(320, 10), Width = 80 };
            buttonEdit = new Button { Text = "Edytuj", Location = new Point(320, 45), Width = 80 };
            buttonDelete = new Button { Text = "Usuń", Location = new Point(320, 80), Width = 80 };

            buttonAdd.Click += this.buttonAdd_Click;
            buttonEdit.Click += this.buttonEdit_Click;
            buttonDelete.Click += this.buttonDelete_Click;

            this.Controls.Add(listBoxClients);
            this.Controls.Add(buttonAdd);
            this.Controls.Add(buttonEdit);
            this.Controls.Add(buttonDelete);
            this.Size = new Size(420, 230);
        }
    }
}
