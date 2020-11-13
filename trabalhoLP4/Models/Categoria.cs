using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using trabalhoLP4.DAL;

namespace trabalhoLP4.Models
{
    public class Categoria
    {
        private int _id;
        private string _nome;
        private string _descricao;

        public Categoria()
        {
        }

        public int Id { get => _id; set => _id = value; }
        public string Nome { get => _nome; set => _nome = value; }
        public string Descricao { get => _descricao; set => _descricao = value; }

        public int Cadastrar()
        {
            CategoriaDAL banco = new CategoriaDAL();
            return banco.Gravar(this);
        }

        public List<Categoria> Ler()
        {
            CategoriaDAL banco = new CategoriaDAL();
            return banco.Ler();
        }
    }
}
