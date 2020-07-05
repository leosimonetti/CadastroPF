using CadastroPF.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;

namespace CadastroPF.AcessoMDB
{
    class Classe_BD_PessoaFisica
    {
        //Classe_PessoaFisica pessoaFisica = new Classe_PessoaFisica();
        private String pathBD = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Application.StartupPath + @"\CadastroPF.mdb";
        private String query;

        public int SalvaNovaPessoaFisica(Classe_PessoaFisica pessoaF)
        {
            OleDbConnection conexao = new OleDbConnection(pathBD);
            int intRetornado;

            try
            {
                conexao.Open();
                query = "INSERT INTO PessoaFisica (ID, Nome, DataNasc, RG, Telefone, Endereco) VALUES (" + pessoaF.ID + ",'" + pessoaF.Nome + "','" + pessoaF.DataNasc + "','" + pessoaF.RG + "','" + pessoaF.Telefone + "','" + pessoaF.Endereco + "')";
                OleDbCommand comando = new OleDbCommand(query, conexao);
                comando.ExecuteNonQuery();
                intRetornado = pessoaF.ID;
            }
            catch (Exception)
            {
                intRetornado = -1;
            }
            finally
            {
                conexao.Close();
            }

            return intRetornado;
        }

        public void DeletarRegistro (int idPessoaFisica)
        {
            OleDbConnection conexao = new OleDbConnection(pathBD);
            
            try
            {
                conexao.Open();
                query = "DELETE FROM PessoaFisica WHERE ID=" + idPessoaFisica;
                OleDbCommand comando = new OleDbCommand(query, conexao);
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                
            }
            finally
            {
                conexao.Close();
            }
        }


        public int SalvaPessoaFisicaEditada(Classe_PessoaFisica pessoaF)
        {
            OleDbConnection conexao = new OleDbConnection(pathBD);
            int intRetornado;

            try
            {
                conexao.Open();
                query = "UPDATE PessoaFisica SET Nome='" + pessoaF.Nome + "', DataNasc='" + pessoaF.DataNasc + "', RG='" + pessoaF.RG + "', Telefone='" + pessoaF.Telefone + "', Endereco='" + pessoaF.Endereco + "' WHERE ID=" + pessoaF.ID;
                OleDbCommand comando = new OleDbCommand(query, conexao);
                comando.ExecuteNonQuery();
                intRetornado = pessoaF.ID;
            }
            catch (Exception)
            {
                intRetornado = -1;
            }
            finally
            {
                conexao.Close();
            }

            return intRetornado;
        }

        public int ObtemMaiorIDSalvo()
        {
            OleDbConnection conexao = new OleDbConnection(pathBD);
            int maiorIDSalvo;
            DataTable dt = new DataTable();

            try
            {
                conexao.Open();
                query = "SELECT MAX(ID) FROM PessoaFisica";

                OleDbDataAdapter adaptador = new OleDbDataAdapter(query, conexao);
                adaptador.Fill(dt);

                maiorIDSalvo = Int32.Parse(dt.Rows[0][0].ToString());
            }
            catch (Exception)
            {
                maiorIDSalvo = -1;
            }
            finally
            {
                conexao.Close();
            }

            return maiorIDSalvo;
        }

        public DataTable ObtemRegistros(String nome)
        {
            DataTable dt = new DataTable();

            OleDbConnection conexao = new OleDbConnection(pathBD);

            try
            {
                conexao.Open();
                query = "SELECT * FROM PessoaFisica WHERE Nome LIKE '%" + nome + "%'";

                OleDbDataAdapter adaptador = new OleDbDataAdapter(query, conexao);
                adaptador.Fill(dt);
            }
            catch (Exception)
            {

            }
            finally
            {
                conexao.Close();
            }

            return dt;
        }

        public Classe_PessoaFisica ObtemRegistroPeloID(int IDPessoaFisica)
        {
            DataTable dt = new DataTable();
            Classe_PessoaFisica pessoaFRetornar = new Classe_PessoaFisica();

            OleDbConnection conexao = new OleDbConnection(pathBD);

            try
            {
                conexao.Open();
                query = "SELECT * FROM PessoaFisica WHERE ID=" + IDPessoaFisica;

                OleDbDataAdapter adaptador = new OleDbDataAdapter(query, conexao);
                adaptador.Fill(dt);

                if (dt.Rows[0][0].ToString() == IDPessoaFisica.ToString())
                {
                    pessoaFRetornar.ID = Int32.Parse(dt.Rows[0][0].ToString());
                    pessoaFRetornar.Nome = dt.Rows[0][1].ToString();
                    pessoaFRetornar.DataNasc = DateTime.Parse(dt.Rows[0][2].ToString());
                    pessoaFRetornar.RG = dt.Rows[0][3].ToString();
                    pessoaFRetornar.Telefone = dt.Rows[0][4].ToString();
                    pessoaFRetornar.Endereco = dt.Rows[0][5].ToString();

                }
            }
            catch (Exception)
            {

            }
            finally
            {
                conexao.Close();
            }

            return pessoaFRetornar;
        }

    }
}
