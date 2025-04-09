namespace WinFormsApp2
{
    partial class zarezerwuj
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
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            terminOd = new Label();
            terminDo = new Label();
            klient = new Label();
            listBox1 = new ListBox();
            listBox2 = new ListBox();
            pokoj = new Label();
            zapisz = new Button();
            zamknij = new Button();
            SuspendLayout();
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(160, 81);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 0;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(160, 127);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(200, 23);
            dateTimePicker2.TabIndex = 1;
            // 
            // terminOd
            // 
            terminOd.AutoSize = true;
            terminOd.Location = new Point(44, 81);
            terminOd.Name = "terminOd";
            terminOd.Size = new Size(104, 15);
            terminOd.TabIndex = 2;
            terminOd.Text = "Wybierz termin od";
            // 
            // terminDo
            // 
            terminDo.AutoSize = true;
            terminDo.Location = new Point(44, 127);
            terminDo.Name = "terminDo";
            terminDo.Size = new Size(104, 15);
            terminDo.TabIndex = 3;
            terminDo.Text = "Wybierz termin do";
            // 
            // klient
            // 
            klient.AutoSize = true;
            klient.Location = new Point(44, 30);
            klient.Name = "klient";
            klient.Size = new Size(85, 15);
            klient.TabIndex = 4;
            klient.Text = "wybierz klienta";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(135, 30);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(76, 19);
            listBox1.TabIndex = 6;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 15;
            listBox2.Location = new Point(160, 167);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(76, 19);
            listBox2.TabIndex = 7;
            // 
            // pokoj
            // 
            pokoj.AutoSize = true;
            pokoj.Location = new Point(65, 167);
            pokoj.Name = "pokoj";
            pokoj.Size = new Size(82, 15);
            pokoj.TabIndex = 8;
            pokoj.Text = "Wybierz pokój";
            // 
            // zapisz
            // 
            zapisz.Location = new Point(151, 226);
            zapisz.Name = "zapisz";
            zapisz.Size = new Size(75, 23);
            zapisz.TabIndex = 9;
            zapisz.Text = "Zapisz";
            zapisz.UseVisualStyleBackColor = true;
            // 
            // zamknij
            // 
            zamknij.Location = new Point(151, 266);
            zamknij.Name = "zamknij";
            zamknij.Size = new Size(75, 23);
            zamknij.TabIndex = 10;
            zamknij.Text = "Zamknij";
            zamknij.UseVisualStyleBackColor = true;
            // 
            // zarezerwuj
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(392, 301);
            Controls.Add(zamknij);
            Controls.Add(zapisz);
            Controls.Add(pokoj);
            Controls.Add(listBox2);
            Controls.Add(listBox1);
            Controls.Add(klient);
            Controls.Add(terminDo);
            Controls.Add(terminOd);
            Controls.Add(dateTimePicker2);
            Controls.Add(dateTimePicker1);
            Name = "zarezerwuj";
            Text = "zarezerwuj";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private Label terminOd;
        private Label terminDo;
        private Label klient;
        private ListBox listBox1;
        private ListBox listBox2;
        private Label pokoj;
        private Button zapisz;
        private Button zamknij;
    }
}