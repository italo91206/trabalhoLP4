using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace trabalhoLP4.Models
{
    public class Usuario
    {
        int _id;
        string _nome;
        string _login;
        string _email;
        string _senha;

        public Usuario()
        {
        }

        public Usuario(string nome, string login, string email, string senha)
        {
            _nome = nome;
            _login = login;
            _email = email;
            _senha = senha;
            _id = new Random().Next(0, 100);
        }

        public int Id { get => _id; set => _id = value; }
        public string Nome { get => _nome; set => _nome = value; }
        public string Email { get => _email; set => _email = value; }
        public string Senha { get => _senha; set => _senha = value; }
        public string Login { get => _login; set => _login = value; }

        public void Gravar(Usuario usuario)
        {
            DAL.UsuarioDAL banco = new DAL.UsuarioDAL();
            Usuario u = new Usuario();

            banco.Gravar(usuario);
        }

        public bool Logar(string email, string senha)
        {
            DAL.UsuarioDAL banco = new DAL.UsuarioDAL();
            return banco.Logar(email, senha);
        }

        public bool Obter(int id)
        {
            DAL.UsuarioDAL banco = new DAL.UsuarioDAL();
            
            return banco.Obter(id, this);
        }
    }
}
