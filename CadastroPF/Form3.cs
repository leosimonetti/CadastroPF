using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CadastroPF.Classes;
using Microsoft.VisualBasic;

namespace CadastroPF
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Classes.Classe_PessoaFisica pessoaFisica = new Classes.Classe_PessoaFisica();

            pessoaFisica.ID = Int32.Parse(textBox1.Text);
            pessoaFisica.Nome = textBox2.Text;

            if (IsDate(textBox3.Text))
            {
                pessoaFisica.DataNasc = DateTime.Parse(textBox3.Text);
            } else
            {
                MessageBox.Show("Erro. Digite uma data correta no formato dd/mm/aaaa.");
                return;
            }

            pessoaFisica.RG = textBox4.Text;
            pessoaFisica.Telefone = textBox5.Text;
            pessoaFisica.Endereco = textBox6.Text;

            // salvar no banco de dados


        }

        public static bool IsDate(Object obj)
        {
            string strDate = obj.ToString();
            try
            {
                DateTime dt = DateTime.Parse(strDate);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
