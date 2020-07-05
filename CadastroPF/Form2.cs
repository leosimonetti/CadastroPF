using CadastroPF.AcessoMDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadastroPF
{
    public partial class Form2 : Form
    {

        int IdSelecionado;

        public Form2()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 formPF = new Form3();
            formPF.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pesquisar();
        }

        private void Pesquisar()
        {
            Classe_BD_PessoaFisica BDpessoaFisica = new Classe_BD_PessoaFisica();
            DataTable dtRetornada = new DataTable();

            dtRetornada = BDpessoaFisica.ObtemRegistros(textBox1.Text);

            dataGridView1.Rows.Clear();
            foreach (DataRow linha in dtRetornada.Rows)
            {
                dataGridView1.Rows.Add(linha[0], linha[1]);
            }
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("colID", "ID");
            dataGridView1.Columns[0].Width = 30;
            dataGridView1.Columns.Add("colNome", "Nome");
            dataGridView1.Columns[1].Width = 200;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[0].Value != null) 
            {
                IdSelecionado = Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }

            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Editar();
        }

        private void Editar()
        {
            if (IdSelecionado >= 0)
            {
                Form3 formPessoaFisica = new Form3();
                formPessoaFisica.RecebeID(IdSelecionado);
                formPessoaFisica.ShowDialog();
                Pesquisar();
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            IdSelecionado = Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            Editar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 formPessoaFisica = new Form3();
            formPessoaFisica.RecebeID(IdSelecionado);
            formPessoaFisica.ModoDeAcesso(1);
            formPessoaFisica.ShowDialog();
            Pesquisar();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 formPessoaFisica = new Form3();
            formPessoaFisica.RecebeID(IdSelecionado);
            formPessoaFisica.ModoDeAcesso(3);
            formPessoaFisica.ShowDialog();
            Pesquisar();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form3 formPessoaFisica = new Form3();
            formPessoaFisica.RecebeID(IdSelecionado);
            formPessoaFisica.ModoDeAcesso(5);
            formPessoaFisica.ShowDialog();
            Pesquisar();
        }
    }
}
