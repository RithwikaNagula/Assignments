namespace Exercise3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            checkBoxPostal = new CheckBox();
            checkBoxEmail = new CheckBox();
            RadioMale = new RadioButton();
            RadioFemale = new RadioButton();
            AddBtn = new Button();
            RemoveCountryBtn = new Button();
            RemoveStateBtn = new Button();
            ShowBtn = new Button();
            comboBoxState = new ComboBox();
            textCountry = new TextBox();
            textState = new TextBox();
            checkedListBox1 = new CheckedListBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(109, 63);
            label1.Name = "label1";
            label1.Size = new Size(75, 25);
            label1.TabIndex = 0;
            label1.Text = "Country";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(109, 124);
            label2.Name = "label2";
            label2.Size = new Size(51, 25);
            label2.TabIndex = 1;
            label2.Text = "State";
            label2.Click += label2_Click;
            // 
            // checkBoxPostal
            // 
            checkBoxPostal.AutoSize = true;
            checkBoxPostal.Location = new Point(109, 198);
            checkBoxPostal.Name = "checkBoxPostal";
            checkBoxPostal.Size = new Size(123, 29);
            checkBoxPostal.TabIndex = 2;
            checkBoxPostal.Text = "Postal Mail";
            checkBoxPostal.UseVisualStyleBackColor = true;
            
            // 
            // checkBoxEmail
            // 
            checkBoxEmail.AutoSize = true;
            checkBoxEmail.Location = new Point(109, 249);
            checkBoxEmail.Name = "checkBoxEmail";
            checkBoxEmail.Size = new Size(87, 29);
            checkBoxEmail.TabIndex = 3;
            checkBoxEmail.Text = "E-Mail";
            checkBoxEmail.UseVisualStyleBackColor = true;

            // 
            // RadioMale
            // 
            RadioMale.AutoSize = true;
            RadioMale.Location = new Point(291, 198);
            RadioMale.Name = "RadioMale";
            RadioMale.Size = new Size(75, 29);
            RadioMale.TabIndex = 4;
            RadioMale.TabStop = true;
            RadioMale.Text = "Male";
            RadioMale.UseVisualStyleBackColor = true;
            
            // 
            // RadioFemale
            // 
            RadioFemale.AutoSize = true;
            RadioFemale.Location = new Point(291, 249);
            RadioFemale.Name = "RadioFemale";
            RadioFemale.Size = new Size(93, 29);
            RadioFemale.TabIndex = 5;
            RadioFemale.TabStop = true;
            RadioFemale.Text = "Female";
            RadioFemale.UseVisualStyleBackColor = true;
           
            // 
            // AddBtn
            // 
            AddBtn.Location = new Point(76, 340);
            AddBtn.Name = "AddBtn";
            AddBtn.Size = new Size(112, 34);
            AddBtn.TabIndex = 6;
            AddBtn.Text = "Add";
            AddBtn.UseVisualStyleBackColor = true;
            AddBtn.Click += AddBtn_Click;
            // 
            // RemoveCountryBtn
            // 
            RemoveCountryBtn.Location = new Point(206, 340);
            RemoveCountryBtn.Name = "RemoveCountryBtn";
            RemoveCountryBtn.Size = new Size(164, 34);
            RemoveCountryBtn.TabIndex = 7;
            RemoveCountryBtn.Text = "Remove Country";
            RemoveCountryBtn.UseVisualStyleBackColor = true;
            RemoveCountryBtn.Click += RemoveCountryBtn_Click;
            // 
            // RemoveStateBtn
            // 
            RemoveStateBtn.Location = new Point(394, 340);
            RemoveStateBtn.Name = "RemoveStateBtn";
            RemoveStateBtn.Size = new Size(140, 34);
            RemoveStateBtn.TabIndex = 8;
            RemoveStateBtn.Text = "Remove State";
            RemoveStateBtn.UseVisualStyleBackColor = true;
            RemoveStateBtn.Click += RemoveStateBtn_Click;
            // 
            // ShowBtn
            // 
            ShowBtn.Location = new Point(563, 340);
            ShowBtn.Name = "ShowBtn";
            ShowBtn.Size = new Size(150, 34);
            ShowBtn.TabIndex = 9;
            ShowBtn.Text = "Show Details";
            ShowBtn.UseVisualStyleBackColor = true;
            ShowBtn.Click += ShowBtn_Click;
            // 
            // comboBoxState
            // 
            comboBoxState.FormattingEnabled = true;
            comboBoxState.Location = new Point(517, 231);
            comboBoxState.Name = "comboBoxState";
            comboBoxState.Size = new Size(182, 33);
            comboBoxState.TabIndex = 11;
            // 
            // textCountry
            // 
            textCountry.Location = new Point(220, 66);
            textCountry.Name = "textCountry";
            textCountry.Size = new Size(150, 31);
            textCountry.TabIndex = 12;
            // 
            // textState
            // 
            textState.Location = new Point(220, 118);
            textState.Name = "textState";
            textState.Size = new Size(150, 31);
            textState.TabIndex = 13;
            // 
            // checkedListBox1
            // 
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(517, 51);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(180, 144);
            checkedListBox1.TabIndex = 14;
            
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(checkedListBox1);
            Controls.Add(textState);
            Controls.Add(textCountry);
            Controls.Add(comboBoxState);
            Controls.Add(ShowBtn);
            Controls.Add(RemoveStateBtn);
            Controls.Add(RemoveCountryBtn);
            Controls.Add(AddBtn);
            Controls.Add(RadioFemale);
            Controls.Add(RadioMale);
            Controls.Add(checkBoxEmail);
            Controls.Add(checkBoxPostal);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private CheckBox checkBoxPostal;
        private CheckBox checkBoxEmail;
        private RadioButton RadioMale;
        private RadioButton RadioFemale;
        private Button AddBtn;
        private Button RemoveCountryBtn;
        private Button RemoveStateBtn;
        private Button ShowBtn;
        private ComboBox comboBoxState;
        private TextBox textCountry;
        private TextBox textState;
        private CheckedListBox checkedListBox1;
    }
}
