using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using TextFileDataAccessDemo;

namespace Form1
{
    public partial class Form1 : Form
    {
        private List<Person> people = new List<Person>();
        private List<string> outputLines = new List<string>(); // Initialize outputLines list

        public Form1()
        {
            InitializeComponent();
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            string firstName = textBox_FirstName.Text;
            string lastName = textBox_LastName.Text;
            string url = textBox_URL.Text;

            if (!string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(lastName) && !string.IsNullOrWhiteSpace(url))
            {
                Person p = new Person
                {
                    firstName = firstName,
                    lastName = lastName,
                    Url = url
                };

                people.Add(p);

                // Add the person's information to the ListBox
                listBox_People.Items.Add($"First Name: {p.firstName} Last Name: {p.lastName} URL: {p.Url}");

                // Clear the TextBoxes
                textBox_FirstName.Clear();
                textBox_LastName.Clear();
                textBox_URL.Clear();
            }
            else
            {
                MessageBox.Show("Please enter valid values for all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string outPath = Path.Combine(currentDirectory, "File.txt");

            if (people.Count > 0)
            {
                outputLines.Clear(); // Clear the outputLines list before adding new data

                foreach (Person p in people)
                {
                    // Add the person's information to the outputLines list
                    outputLines.Add($"First Name: {p.firstName} Last Name: {p.lastName} URL: {p.Url}");
                }

                // Write the outputLines list to the file, overwriting the existing content
                File.WriteAllText(outPath, string.Join(Environment.NewLine, outputLines));

                MessageBox.Show("Data saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("There is no data to save.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button_Load_Click(object sender, EventArgs e)
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(currentDirectory, "File.txt");

            // Clear the existing data
            people.Clear();
            listBox_People.Items.Clear();

            List<string> lines = File.ReadAllLines(filePath).ToList();

            foreach (string line in lines)
            {
                string[] entries = line.Split(new[] { "First Name: ", " Last Name: ", " URL: " }, StringSplitOptions.RemoveEmptyEntries);

                if (entries.Length != 3)
                {
                    MessageBox.Show($"Invalid line: {line}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }

                Person p = new Person
                {
                    firstName = entries[0],
                    lastName = entries[1],
                    Url = entries[2]
                };

                people.Add(p);

                // Add the person's information to the ListBox
                listBox_People.Items.Add($"First Name: {p.firstName} Last Name: {p.lastName} URL: {p.Url}");
            }

            MessageBox.Show("Data loaded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
