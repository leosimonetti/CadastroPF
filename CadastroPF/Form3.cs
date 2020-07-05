using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CadastroPF.AcessoMDB;
using CadastroPF.Classes;
using Microsoft.VisualBasic;

namespace CadastroPF
{
    public partial class Form3 : Form
    {
        Classes.Classe_PessoaFisica pessoaFisica = new Classes.Classe_PessoaFisica();
        int tipoAcesso;
        /* 1 = acessando
         * 2 = novo
         * 3 = copiando
         * 4 = editando
         * 5 = deletando
         */
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        public void ModoDeAcesso(int modoAcesso)
        {
            tipoAcesso = modoAcesso;

            if (tipoAcesso == 1)
            {
                button1.Text = "Fechar";
            }
            if (tipoAcesso == 3)
            {
                button1.Text = "Salvar Copiado";
            }
            if (tipoAcesso == 5)
            {
                button1.Text = "Deletar Registro";
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tipoAcesso == 1)
            {
                this.Close();
            }

            if (tipoAcesso == 2)
            {
                SalvaNovo();
            }

            if (tipoAcesso == 3)
            {
                SalvaNovo();
            }

            if (tipoAcesso == 4)
            {
                SalvaEdicao();
            }

            if (tipoAcesso == 5)
            {
                Deletar();
            }

        }

        private void SalvaEdicao()
        {
            pessoaFisica.Nome = textBox2.Text;

            if (IsDate(textBox3.Text))
            {
                pessoaFisica.DataNasc = DateTime.Parse(textBox3.Text);
            }
            else
            {
                MessageBox.Show("Erro. Digite uma data correta no formato dd/mm/aaaa.");
                return;
            }

            pessoaFisica.RG = textBox4.Text;
            pessoaFisica.Telefone = textBox5.Text;
            pessoaFisica.Endereco = textBox6.Text;

            // salvar no banco de dados
            int intRetornado;
            Classe_BD_PessoaFisica BDpessoaFisica = new Classe_BD_PessoaFisica();

            pessoaFisica.ID = Int32.Parse(textBox1.Text);

            intRetornado = BDpessoaFisica.SalvaPessoaFisicaEditada(pessoaFisica);
            if (intRetornado == -1)
            {
                MessageBox.Show("Erro! Não foi salvo.");
            }
            else
            {
                MessageBox.Show("Salvo!");
                this.Close();
            }
        }

        private void Deletar()
        {
            // deletar do banco de dados

            Classe_BD_PessoaFisica BDpessoaFisica = new Classe_BD_PessoaFisica();
            int idDeletar;
            idDeletar = Int32.Parse(textBox1.Text);

            BDpessoaFisica.DeletarRegistro(idDeletar);
            MessageBox.Show("Registro deletado!");
            this.Close();
        }


        private void SalvaNovo()
        {
            pessoaFisica.Nome = textBox2.Text;

            if (IsDate(textBox3.Text))
            {
                pessoaFisica.DataNasc = DateTime.Parse(textBox3.Text);
            }
            else
            {
                MessageBox.Show("Erro. Digite uma data correta no formato dd/mm/aaaa.");
                return;
            }

            pessoaFisica.RG = textBox4.Text;
            pessoaFisica.Telefone = textBox5.Text;
            pessoaFisica.Endereco = textBox6.Text;

            // salvar no banco de dados
            int intRetornado;
            Classe_BD_PessoaFisica BDpessoaFisica = new Classe_BD_PessoaFisica();

            intRetornado = BDpessoaFisica.ObtemMaiorIDSalvo();
            intRetornado = intRetornado + 1;
            pessoaFisica.ID = intRetornado;

            intRetornado = BDpessoaFisica.SalvaNovaPessoaFisica(pessoaFisica);
            if (intRetornado == -1)
            {
                MessageBox.Show("Erro! Não foi salvo.");
            }
            else
            {
                MessageBox.Show("Salvo!");
                this.Close();
            }
        }



        public void RecebeID(int IDdaPessoaFisica)
        {
            Classe_BD_PessoaFisica BDpessoaFisica = new Classe_BD_PessoaFisica();
            pessoaFisica = BDpessoaFisica.ObtemRegistroPeloID(IDdaPessoaFisica);
            PreencheCampos();
            tipoAcesso = 4; // Editando
            button1.Text = "Salvar Edição";
        }


        private void PreencheCampos()
        {
            textBox1.Text = pessoaFisica.ID.ToString();
            textBox2.Text = pessoaFisica.Nome.ToString();
            textBox3.Text = pessoaFisica.DataNasc.ToString().Substring(0, 10);
            textBox4.Text = pessoaFisica.RG.ToString();
            textBox5.Text = pessoaFisica.Telefone.ToString();
            textBox6.Text = pessoaFisica.Endereco.ToString();
        }


        private bool IsDate(Object obj)
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
