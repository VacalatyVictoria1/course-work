using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace course_work
{
    public partial class Input_study : Form
    {
        public int count = 0, check_enabled = 0;
        internal Study[] study;
        public Input_study()
        {
            study = new Study[5];
            for (int i = 0; i < 5; i++)
            {
                study[i] = new Study();
            }
            InitializeComponent();
            check_enabled = 0;
           
        }
        private void button_add_progress_Click(object sender, EventArgs e) 
        {
            if (count >= 5)
                count = 0;
            study[count].Subject = comboBox_subject.Text;
            study[count].Name_teacher = comboBox_teacher.Text;
            study[count].Mark = Convert.ToDouble(numeric_mark1.Value);
            count++;
            Close();
        }
        private void button_Cancel_Click(object sender, EventArgs e) 
        {
            check_enabled = 1;
            Close();
        }
        void Check_input_text(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\b')) return;
            if (e.KeyChar.Equals(' ')) return;
            var tb = (ComboBox)sender;
            if (e.KeyChar.Equals('-'))
            {
                e.Handled = tb.SelectionStart == 0 || tb.Text[tb.SelectionStart - 1].Equals('-');
                if (!e.Handled)
                {
                    return;
                }
            }
            e.Handled = !char.IsLetter(e.KeyChar);
        } 
     
        private void numeric_mark1_ValueChanged(object sender, EventArgs e) 
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) 
        {

        }

        private void comboBox_teacher_SelectedIndexChanged_1(object sender, EventArgs e)  
        {

        }
        private void ComboBox_subject_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\b')) return;
            if (e.KeyChar.Equals(' ')) return;
            var tb = (ComboBox)sender;
            if (e.KeyChar.Equals('-'))
            {
                e.Handled = tb.SelectionStart == 0 || tb.Text[tb.SelectionStart - 1].Equals('-');
                if (!e.Handled)
                {
                    return;
                }
            }
            e.Handled = !char.IsLetter(e.KeyChar);
        }

        private void Input_study_Load(object sender, EventArgs e)
        {

        }


    }
}
