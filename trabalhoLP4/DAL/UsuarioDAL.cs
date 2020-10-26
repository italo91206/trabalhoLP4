using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace trabalhoLP4.DAL
{
    public class UsuarioDAL
    {
        MySQLPersistence _bd = new MySQLPersistence();
        public void Gravar(Models.Usuario usuario)
        {
            string sql = @"insert usuario (nome, login, email, senha) values (@nome, @login, @email, @senha)";
            
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@nome", usuario.Nome);
            parametros.Add("@login", usuario.Login);
            parametros.Add("@email", usuario.Email);
            parametros.Add("@senha", usuario.Senha);
            _bd.ExecutarNonQuery(sql, parametros);
        }

        public int Logar(string login, string senha)
        {
            int retorno = -1;
            string sql = @"select UsuarioId from usuario where login  = @login and senha = @senha";
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@login", login);
            parametros.Add("@senha", senha);

            DbDataReader dr = _bd.ExecutarSelect(sql, parametros);
            if (dr.HasRows)
            {
                dr.Read();
                retorno = Convert.ToInt32(dr["UsuarioId"]);
            }
            
            return retorno;
            
        }

        public Models.Usuario Obter(int id, Models.Usuario usuario)
        {
            Models.Usuario novo = new Models.Usuario();
            string sql = $@"select * from usuario where UsuarioId = {id}";
            DbDataReader dr = _bd.ExecutarSelect(sql);

            if (dr.HasRows)
            {
                usuario = new Models.Usuario();
                dr.Read(); // move para a primeira linha
                
                novo.Id = Convert.ToInt32(dr["UsuarioId"]);
                novo.Nome = dr["nome"].ToString();
                novo.Email = dr["Email"].ToString();
            }
            
            _bd.Fechar();
            return novo;
        }
    }
}
