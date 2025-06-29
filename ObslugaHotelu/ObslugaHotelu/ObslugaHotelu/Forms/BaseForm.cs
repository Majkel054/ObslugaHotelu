using System.Drawing;
using System.Windows.Forms;

namespace ObslugaHotelu
{
    public class BaseForm : Form
    {
        public BaseForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.WhiteSmoke;
            this.Font = new Font("Segoe UI", 10);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
        }
    }
}
