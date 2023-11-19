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

namespace AddressBook
{
    public partial class Form1 : Form
    {

        public static List<PersonEntry> People = new List<PersonEntry>();
        //Field to hold a list of entry objects.

        public Form1()
        {
            InitializeComponent();
        }

        public class PersonEntry
        {
            public string name;
            public string email;
            public string phoneNumber;
            //Declaring variables 
            public PersonEntry()
            {
                name = " ";
                email = " ";
                phoneNumber = " ";
                //Initializing objects
            }

            public void setName(string nameSet)
            {
                name = nameSet;
            }
            public void setEmail(string emailSet)
            {
                email = emailSet;
            }
            public void setPhone(string phoneSet)
            {
                phoneNumber = phoneSet;
            }

            public string getName()
            {
                return name;
            }
            public string getEmail()
            {
                return email;
            }
            public string getPhone()
            {
                return phoneNumber;
            }
            //Constructors
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            char[] delim = { ',' };
            //Declaring delimitier array
            StreamReader inputFile;
            openMyFile(out inputFile);
            //Opening file
            try
            {
                while (!inputFile.EndOfStream)
                {

                    string line = inputFile.ReadLine();
                    //Holds line from file
                    string[] parse = line.Split(delim);
                    //Tokenizing line
                    PersonEntry perEntry = new PersonEntry();
                    //Creating new entry
                    perEntry.setName(parse[0]);
                    perEntry.setEmail(parse[1]);
                    perEntry.setPhone(parse[2]);
                    //Storing tokens in the entry object

                    People.Add(perEntry);
                    //Adding entry to list
                    lstNames.Items.Add(perEntry.getName());
                    //Adding names from entry to list
                }
            }
            catch
            {
                MessageBox.Show("Operation cancelled.");
                //Error handling
            }
        }

        public void openMyFile(out StreamReader inputFile)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                inputFile = File.OpenText(openFileDialog1.FileName);
                //Opens file if dialog result is ok
            }
            else
            {

                inputFile = null;
                //Error handling
            }


        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            //Closes program
        }

        private void lstNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form form2 = new Form();
            //Creating new form
            int index = lstNames.SelectedIndex;
            //Creating index for selected name on list
            form2.Text = People[index].getName() + "'s details: ";
            //Declaring form text
            string str = "";

            Label lb = new Label();
            //Creating label for form
            str += "Name: " + People[index].getName() + "\n";
            str += "Email address: " + People[index].getEmail() + "\n";
            str += "Phone number: " + People[index].getPhone() + "\n";
            //Adding elements to string
            lb.Font = new Font("Helvetica", 12);
            lb.Size = new System.Drawing.Size(250, 250);
            lb.Text = str;
            lb.Visible = true;
            lb.Location = new System.Drawing.Point(7, 7);
            //Adjusting label settings
            form2.Controls.Add(lb);
            form2.Size = new System.Drawing.Size(325, 250);
            form2.ShowDialog();
            //Adding label and showing form
        }
    }
}