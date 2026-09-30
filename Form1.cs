using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lib.Class;

namespace lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Logger.Instance.Log("Запущено головну форму деканату (Form1).");
            RefreshList();
        }

        private void RefreshList()
        {
            listBox1.Items.Clear();
            foreach (var student in DbManager.Instance.Students)
            {
                listBox1.Items.Add(student);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                DbManager.Instance.AddStudent(textBox1.Text);
                Logger.Instance.Log($"Додано студента: {textBox1.Text}");
                textBox1.Clear();
                RefreshList();
            }
        }

        private void btnOpenSecondForm_Click(object sender, EventArgs e)
        {
            Form2 secondForm = new Form2();
            secondForm.ShowDialog();
            RefreshList();
        }
    }
}
