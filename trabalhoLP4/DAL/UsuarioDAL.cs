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

        public bool Logar(string login, string senha)
        {
            string sql = @"select count(*) from usuario where login  = @login and senha = @senha";
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@login", login);
            parametros.Add("@senha", senha);

            object retorno = _bd.ExecutarSelectScalar(sql, parametros);
            if (retorno == null || Convert.ToInt32(retorno) == 0)
                return false;
            else
                return true;
        }

        public bool Obter(int id, Models.Usuario usuario)
        {
            bool ok = false;
            string sql = $@"select * from usuario where UsuarioId = {id}";
            DbDataReader dr = _bd.ExecutarSelect(sql);

            if (dr.HasRows)
            {
                ok = true;
                usuario = new Models.Usuario();
                dr.Read(); // move para a primeira linha
                
                usuario.Id = Convert.ToInt32(dr["UsuarioId"]);
                usuario.Nome = dr["nome"].ToString();
                usuario.Email = dr["Email"].ToString();
            }
            
            _bd.Fechar();
            return ok;
        }
    }
}
