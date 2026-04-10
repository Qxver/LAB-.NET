using System.Text.RegularExpressions;

namespace Zadanie_04
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string email = txtEmail.Text;

            if (string.IsNullOrWhiteSpace(firstName) ||
                string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Wypełnij wszystkie pola!");
                return;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Niepoprawny email!");
                return;
            }

            Person person = new Person
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email
            };

            PersonRepository.Add(person);

            listBoxPeople.Items.Add(person);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
