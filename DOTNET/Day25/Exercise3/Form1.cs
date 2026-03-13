using Microsoft.VisualBasic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Exercise3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            checkedListBox1.Items.Add(textCountry.Text);
            textCountry.Clear();
            comboBoxState.Items.Add(textState.Text);
            textState.Clear();
        }

        private void RemoveCountryBtn_Click(object sender, EventArgs e)
        {
            foreach (var item in checkedListBox1.CheckedItems.Cast<Object>().ToList())
            {
                checkedListBox1.Items.Remove(item);
            }

        }

        private void RemoveStateBtn_Click(object sender, EventArgs e)
        {
            comboBoxState.Items.Remove(comboBoxState.SelectedItem);
        }

        private void ShowBtn_Click(object sender, EventArgs e)
        {
            if ((checkBoxEmail.Checked == true || checkBoxPostal.Checked) == true &&
                RadioMale.Checked == true)
            {
                MessageBox.Show("Hello Mr","Info",MessageBoxButtons.OKCancel,
                MessageBoxIcon.Information);
            }
            else
                if ((checkBoxEmail.Checked == true || checkBoxPostal.Checked) == true
                && RadioFemale.Checked == true)
            {
                MessageBox.Show("Hello Mrs","Info", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Information);
            }
        }
    }
}

