namespace WinFormsApp2
{
    partial class wolne_pokoje
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            WybranyTermin = new Label();
            dateTimePicker1 = new DateTimePicker();
            DostepnePokoje = new Label();
            SuspendLayout();
            // 
            // WybranyTermin
            // 
            WybranyTermin.BorderStyle = BorderStyle.FixedSingle;
            WybranyTermin.Location = new Point(38, 42);
            WybranyTermin.Name = "WybranyTermin";
            WybranyTermin.Size = new Size(122, 41);
            WybranyTermin.TabIndex = 0;
            WybranyTermin.Text = "Wybrany Termin: ";
            WybranyTermin.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(187, 47);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(272, 27);
            dateTimePicker1.TabIndex = 1;
            // 
            // DostepnePokoje
            // 
            DostepnePokoje.BorderStyle = BorderStyle.FixedSingle;
            DostepnePokoje.Location = new Point(38, 125);
            DostepnePokoje.Name = "DostepnePokoje";
            DostepnePokoje.Size = new Size(122, 57);
            DostepnePokoje.TabIndex = 2;
            DostepnePokoje.Text = "Dostępne Pokoje:";
            DostepnePokoje.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // wolne_pokoje
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(471, 600);
            Controls.Add(DostepnePokoje);
            Controls.Add(dateTimePicker1);
            Controls.Add(WybranyTermin);
            Margin = new Padding(3, 4, 3, 4);
            Name = "wolne_pokoje";
            Text = "wolne_pokoje";
            ResumeLayout(false);
        }

        #endregion

        private Label WybranyTermin;
        private DateTimePicker dateTimePicker1;
        private Label DostepnePokoje;
    }
}