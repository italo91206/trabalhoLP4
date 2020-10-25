using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace trabalhoLP4.DAL
{
    public class MySQLPersistence
    {
        public MySqlConnection _conexao { get; set; }
        public MySqlCommand _comando { get; set; }
        public int UltimoId { get => ultimoId; set => ultimoId = value; }

        public int ultimoId;

        public MySQLPersistence()
        {
            _conexao = new MySqlConnection("Server=den1.mysql1.gear.host;Database=trabalholp4;Uid=trabalholp4;Pwd=unoeste#2020;");
            _comando = _conexao.CreateCommand(); 
        }

        public void Abrir()
        {
            if(_conexao.State != System.Data.ConnectionState.Open)
                _conexao.Open();
        }

        public void Fechar()
        {
            _conexao.Close();
        }

        public int ExecutarNonQuery(string sql, Dictionary<string, object> parametros = null)
        {
            Abrir();
            _comando.CommandText = sql;
            if(parametros != null){
                foreach(var p in parametros)
                    _comando.Parameters.AddWithValue(p.Key, p.Value);
            }
            int linhasAfetadas = _comando.ExecuteNonQuery();
            UltimoId = (int)_comando.LastInsertedId;
            Fechar();

            return linhasAfetadas;
        }

        public object ExecutarSelectScalar(string select, Dictionary<string, object> parametros = null)
        {
            object valor = null;
            Abrir();
            _comando.CommandText = select;
            if(parametros != null)
            {
                foreach (var p in parametros)
                    _comando.Parameters.AddWithValue(p.Key, p.Value);
            }
            valor = _comando.ExecuteScalar();
            Fechar();
            
            return valor;
        }

        public DbDataReader ExecutarSelect(string select, Dictionary<string, object> parametros = null)
        {
            Abrir();
            _comando.CommandText = select;
            if (parametros != null)
            {
                foreach (var p in parametros)
                    _comando.Parameters.AddWithValue(p.Key, p.Value);
            }
            MySqlDataReader leitorDados = _comando.ExecuteReader();
            return leitorDados;
        }
    }

}
