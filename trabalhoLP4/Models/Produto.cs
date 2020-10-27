using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using trabalhoLP4.DAL;

namespace trabalhoLP4.Models
{
    public class Produto
    {
        private int _id;
        private string _nome;
        private string _descricao;
        private float _preco;
        private float _qtd;
        private string _categoria;

        public Produto()
        {
        }


        public int Id { get => _id; set => _id = value; }
        public string Nome { get => _nome; set => _nome = value; }
        public string Descricao { get => _descricao; set => _descricao = value; }
        public float Preco { get => _preco; set => _preco = value; }
        public float Qtd { get => _qtd; set => _qtd = value; }
        public string Categoria { get => _categoria; set => _categoria = value; }

        public int Cadastrar()
        {
            ProdutoDAL banco = new ProdutoDAL();
            return banco.Gravar(this); ;
        }

        public List<Produto> Ler()
        {
            ProdutoDAL banco = new ProdutoDAL();
            return banco.Ler();
        }
    }
}
