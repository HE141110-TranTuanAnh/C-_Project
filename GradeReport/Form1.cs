using GradeReport.Controller;
using GradeReport.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GradeReport
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Account account = LoginController.GetAccount("TE0605","123");
            if(account == null)
            {
                MessageBox.Show("Incorrect your roll or password!!!", "Confirm...");
            }
            else
            {
                MessageBox.Show("Hello " + account.Name + " " + account.Roll + " " + account.Password, "Confirm...");
            }
        }
        }
    }

