using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace trabalhoLP4.DAL
{
    public class ProdutoDAL
    {
        MySQLPersistence _bd = new MySQLPersistence();

        public int Gravar(Models.Produto produto)
        {
            bool response = true;

            string sql = @"insert produto (nome, descricao, preco, qtd, categoria) values (@nome, @descricao, @preco, @qtd, @categoria)";

            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@nome", produto.Nome);
            parametros.Add("@descricao", produto.Descricao);
            parametros.Add("@preco", produto.Preco);
            parametros.Add("@qtd", produto.Qtd);
            parametros.Add("@categoria", produto.Categoria);
            int linhas = _bd.ExecutarNonQuery(sql, parametros);

            return linhas;
        }

        public List<Models.Produto> Ler()
        {
            List<Models.Produto> produtos = new List<Models.Produto>();

            string sql = "select * from produto";
            DbDataReader dr = _bd.ExecutarSelect(sql);

            while (dr.Read())
            {
                Models.Produto produto = new Models.Produto();

                produto.Id = Convert.ToInt32(dr["idproduto"]);
                produto.Nome = dr["nome"].ToString();
                produto.Descricao = dr["descricao"].ToString();
                produto.Preco = Convert.ToInt32(dr["preco"]);
                produto.Qtd = Convert.ToInt32(dr["qtd"]);
                produto.Categoria = dr["categoria"].ToString();

                produtos.Add(produto);
            }

            _bd.Fechar();
            return produtos;
        }
    }
}
