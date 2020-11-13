using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace trabalhoLP4.DAL
{
    public class CategoriaDAL
    {
        MySQLPersistence _bd = new MySQLPersistence();

        public int Gravar(Models.Categoria categoria)
        {
            string sql = @"insert categoria (nome, descricao) values (@nome, @descricao)";

            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@nome", categoria.Nome);
            parametros.Add("@descricao", categoria.Descricao);
            int linhas = _bd.ExecutarNonQuery(sql, parametros);

            return linhas;
        }

        public List<Models.Categoria> Ler()
        {
            List<Models.Categoria> categorias= new List<Models.Categoria>();

            string sql = "select * from categoria";
            DbDataReader dr = _bd.ExecutarSelect(sql);

            while (dr.Read())
            {
                Models.Categoria categoria = new Models.Categoria();

                categoria.Id = Convert.ToInt32(dr["id"]);
                categoria.Nome = dr["nome"].ToString();
                categoria.Descricao = dr["descricao"].ToString();

                categorias.Add(categoria);
            }

            _bd.Fechar();
            return categorias;
        }
    }
}
