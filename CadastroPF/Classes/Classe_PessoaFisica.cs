using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace CadastroPF.Classes
{
    class Classe_PessoaFisica
    {
        private int id;
        private String nome;
        private DateTime dataNasc;
        private String rg;
        private String telefone;
        private String endereco;

        public int ID { get { return id; } set { id = value; } }
        public String Nome { get { return nome; } set { nome = value; } }
        public DateTime DataNasc { get { return dataNasc; } set { dataNasc = value; } }
        public String RG { get { return rg; } set { rg = value; } }
        public String Telefone { get { return telefone; } set { telefone = value; } }
        public String Endereco { get { return endereco; } set { endereco = value; } }

        public Classe_PessoaFisica()
        {
            id = 0;
            nome = "";
            dataNasc = DateTime.Today;
            rg = "";
            telefone = "";
            endereco = "";
        }

    }
}
