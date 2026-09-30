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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            Logger.Instance.Log("Відкрито форму перегляду та збереження відомостей (Form2).");

            LoadStudentsToListBox();
        }

        private void LoadStudentsToListBox()
        {
            listBox1.Items.Clear();
            foreach (var student in DbManager.Instance.Students)
            {
                listBox1.Items.Add(student);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string content = "ВІДОМІСТЬ СТУДЕНТІВ (згенерувала Form2):\n";
            content += "=========================================\n";

            foreach (var student in DbManager.Instance.Students)
            {
                content += "- " + student + "\n";
            }

            DocumentSaver.Instance.SaveDocument("Vidomist.txt", content);

            Logger.Instance.Log("Упішно збережено файл Vidomist.txt з Form2.");

            MessageBox.Show("Відомість успішно збережено у файл Vidomist.txt!",
                            "Успіх",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }
    }
}
