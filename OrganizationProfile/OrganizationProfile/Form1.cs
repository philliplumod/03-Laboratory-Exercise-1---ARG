using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrganizationProfile
{
    public partial class frmRegistration : Form
    {
        private string _FullName, _ContactNo;
        private int _Age;
        private long _StudentNo;

        public frmRegistration()
        {
            InitializeComponent();
        }




        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ListOfProgram = new string[]
            {
                "BS Information Technology",
                "BS Computer Science",
                "BS Information System",
                "BS in Accountacy",
                "BS in Hospitality Management",
                "BS in Tourism Management"
            };

            for(int i = 0; i < 6; i++)
            {
                cbPrograms.Items.Add(ListOfProgram[i].ToString());
            }
        }

        public long StudentNumber(string studNum)
        {
            try
            {
                _StudentNo = long.Parse(studNum);

            }
            catch(FormatException fe)
            {
                MessageBox.Show("Invalid Student Number Format");
            }
            

            return _StudentNo;
        }

        public string ContactNo(string Contact)
        {
            if (Regex.IsMatch(Contact, @"^[0-9]{10,11}$"))
            {
                _ContactNo = Contact;
            }
            else
            {
                MessageBox.Show("Invalid Contact Number Format!");
            }
           
            return _ContactNo;
        }

        public string FullName(string LastName, string FirstName, string MiddleInitial)
        {
            if (Regex.IsMatch(LastName, @"^[a-zA-Z]+$") || Regex.IsMatch(FirstName, @"^[a-zA-Z]+$") || Regex.IsMatch(MiddleInitial, @"^[a-zA-Z]+$"))
            {
                _FullName = LastName + ", " + FirstName + ", " + MiddleInitial;
            }
            else
            {
                MessageBox.Show("Invalid Name Format!");
            }
            return _FullName;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            
            try
            {
                StudentInformationClass.SetFullName = FullName(txtLastName.Text,
                   txtFirstName.Text, txtMiddleInitial.Text);
                StudentInformationClass.SetStudentNo = (int)StudentNumber(txtStudentNo.Text);
                StudentInformationClass.SetProgram = cbPrograms.Text;
                StudentInformationClass.SetGender = cbGender.Text;
                StudentInformationClass.SetContactNo = "+63" + ContactNo(txtContactNo.Text.Substring(1));
                StudentInformationClass.SetAge = Age(txtAge.Text);
                StudentInformationClass.SetBirthday = datePickerBirthday.Value.ToString("yyyy-MM-dd");
                
            }
            catch (FormatException fe)
            {
                MessageBox.Show("Format Exception");
            }
            catch (ArgumentNullException ane)
            {
                MessageBox.Show("Argument Null Exception");
            }
            catch (OverflowException oe)
            {
                MessageBox.Show("Overflow Exception");
            }
            catch (IndexOutOfRangeException iore)
            {
                MessageBox.Show("Index Out Of Range Exception");
            }
            finally
            {
                frmConfirmation frm = new frmConfirmation();
                frm.ShowDialog();
            }
            
           
        }

        public int Age(string age)
        {
            if (Regex.IsMatch(age, @"^[0-9]{1,3}$"))
            {
                _Age = Int32.Parse(age);
            }
            else
            {
                MessageBox.Show("Invalid Age Format!");
            }

            return _Age;
        }
    }
}
