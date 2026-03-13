namespace Exercise1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = "";
            s += $"Person Name: {textBox1.Text}\n";
            s += $"Father's Name: {textBox2.Text}\n";
            s += $"DOB: {dateTimePicker1.Text}\n";
            s += $"Preference: {comboBox1.Text}";
            MessageBox.Show(s);
        }
    }
}
