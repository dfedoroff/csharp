namespace ClinicDesktop
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            listViewClients = new ListView();
            columnHeaderId = new ColumnHeader();
            columnHeaderSurName = new ColumnHeader();
            columnHeaderFirstName = new ColumnHeader();
            columnHeaderPatronymic = new ColumnHeader();
            btnUpdate = new Button();
            documentBox = new TextBox();
            surnameBox = new TextBox();
            firstNameBox = new TextBox();
            patronymicBox = new TextBox();
            birthdayBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            btnAdd = new Button();
            btnDelete = new Button();
            SuspendLayout();

            listViewClients.AccessibleRole = AccessibleRole.Text;
            listViewClients.Columns.AddRange(new ColumnHeader[] { columnHeaderId, columnHeaderSurName, columnHeaderFirstName, columnHeaderPatronymic });
            listViewClients.FullRowSelect = true;
            listViewClients.GridLines = true;
            listViewClients.Location = new Point(12, 12);
            listViewClients.MultiSelect = false;
            listViewClients.Name = "listViewClients";
            listViewClients.Size = new Size(776, 331);
            listViewClients.TabIndex = 1;
            listViewClients.UseCompatibleStateImageBehavior = false;
            listViewClients.View = View.Details;

            columnHeaderId.Text = "#";

            columnHeaderSurName.Text = "Фамилия";
            columnHeaderSurName.Width = 200;

            columnHeaderFirstName.Text = "Имя";
            columnHeaderFirstName.Width = 200;

            columnHeaderPatronymic.Text = "Отчество";
            columnHeaderPatronymic.Width = 200;

            btnUpdate.Location = new Point(667, 391);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(121, 52);
            btnUpdate.TabIndex = 2;
            btnUpdate.Text = "Обновить";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;

            documentBox.Location = new Point(12, 391);
            documentBox.Name = "documentBox";
            documentBox.Size = new Size(114, 23);
            documentBox.TabIndex = 3;

            surnameBox.Location = new Point(132, 391);
            surnameBox.Name = "surnameBox";
            surnameBox.Size = new Size(100, 23);
            surnameBox.TabIndex = 4;

            firstNameBox.Location = new Point(238, 391);
            firstNameBox.Name = "firstNameBox";
            firstNameBox.Size = new Size(100, 23);
            firstNameBox.TabIndex = 5;

            patronymicBox.Location = new Point(344, 391);
            patronymicBox.Name = "patronymicBox";
            patronymicBox.Size = new Size(100, 23);
            patronymicBox.TabIndex = 6;

            birthdayBox.Location = new Point(450, 391);
            birthdayBox.Name = "birthdayBox";
            birthdayBox.Size = new Size(100, 23);
            birthdayBox.TabIndex = 7;
            birthdayBox.Text = "1955-01-01";

            label1.AutoSize = true;
            label1.Location = new Point(12, 363);
            label1.Name = "label1";
            label1.Size = new Size(106, 15);
            label1.TabIndex = 8;
            label1.Text = "Номер документа";

            label2.AutoSize = true;
            label2.Location = new Point(132, 363);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 9;
            label2.Text = "Фамилия";

            label3.AutoSize = true;
            label3.Location = new Point(238, 363);
            label3.Name = "label3";
            label3.Size = new Size(31, 15);
            label3.TabIndex = 10;
            label3.Text = "Имя";

            label4.AutoSize = true;
            label4.Location = new Point(344, 363);
            label4.Name = "label4";
            label4.Size = new Size(58, 15);
            label4.TabIndex = 11;
            label4.Text = "Отчество";

            label5.AutoSize = true;
            label5.Location = new Point(452, 364);
            label5.Name = "label5";
            label5.Size = new Size(90, 15);
            label5.TabIndex = 12;
            label5.Text = "Дата рождения";

            btnAdd.Location = new Point(556, 391);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(93, 23);
            btnAdd.TabIndex = 13;
            btnAdd.Text = "Добавить";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;

            btnDelete.Location = new Point(556, 420);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(93, 23);
            btnDelete.TabIndex = 14;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 448);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(birthdayBox);
            Controls.Add(patronymicBox);
            Controls.Add(firstNameBox);
            Controls.Add(surnameBox);
            Controls.Add(documentBox);
            Controls.Add(btnUpdate);
            Controls.Add(listViewClients);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Моя клиника";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ListView listViewClients;
        private Button btnUpdate;
        private ColumnHeader columnHeaderId;
        private ColumnHeader columnHeaderSurName;
        private ColumnHeader columnHeaderFirstName;
        private ColumnHeader columnHeaderPatronymic;
        private TextBox documentBox;
        private TextBox surnameBox;
        private TextBox firstNameBox;
        private TextBox patronymicBox;
        private TextBox birthdayBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btnAdd;
        private Button btnDelete;
    }
}