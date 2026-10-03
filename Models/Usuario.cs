using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace GomezZuñigaAntonio.Models
{
    public class Usuario
    {
        [Key]
        public int Id_usu { get; set; }
        public string Email_usu { get; set; }
        public string Pass_usu { get; set; }

        public Usuario() { }

        public Usuario(int id_usu, string email_usu, string pass_usu)
        {
            Id_usu = id_usu;
            Email_usu = email_usu;
            Pass_usu = pass_usu;
        }

        public Usuario GetUsuarioById(int id_usu)
        {
            const string sql = "SELECT * FROM usuario WHERE id_usu = @id;";
            List<NpgsqlParameter> lstParameter = new List<NpgsqlParameter>() { new NpgsqlParameter("@id", id_usu) };
            DataTable tabla = GetQuery(sql, lstParameter);

            if (tabla.Rows.Count < 1) return new Usuario();
            DataRow row = tabla.Rows[0];

            return new Usuario(
                Convert.ToInt32(row["id_usu"]),
                row["email_usu"].ToString(),
                row["pass_usu"].ToString()
            );
        }

        private DataTable GetQuery(string sql, List<NpgsqlParameter> lstParameter)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> GetUsuarios()
        {
            const string sql = "SELECT * FROM usuario;";
            List<Usuario> lstUsuarios = new List<Usuario>();
            DataTable tabla = GetQuery(sql);

            if (tabla.Rows.Count < 1) return lstUsuarios;

            foreach (DataRow row in tabla.Rows)
            {
                lstUsuarios.Add(new Usuario(
                    Convert.ToInt32(row["id_usu"]),
                    row["email_usu"].ToString(),
                    row["pass_usu"].ToString()
                ));
            }
            return lstUsuarios;
        }

        private DataTable GetQuery(string sql)
        {
            throw new NotImplementedException();
        }

        public int AddUsuario(Usuario usu)
        {
            const string SQL = "INSERT INTO usuario (email_usu, pass_usu) VALUES (@email, @pass);";
            List<NpgsqlParameter> lista = new List<NpgsqlParameter>()
            {
                new NpgsqlParameter("@email", usu.Email_usu),
                new NpgsqlParameter("@pass", usu.Pass_usu)
            };
            return ExecuteQuery(SQL, lista);
        }

        public int EditUsuario(Usuario usu)
        {
            const string SQL = "UPDATE usuario SET email_usu = @email, pass_usu = @pass WHERE id_usu = @id;";
            List<NpgsqlParameter> lista = new List<NpgsqlParameter>()
            {
                new NpgsqlParameter("@id", usu.Id_usu),
                new NpgsqlParameter("@email", usu.Email_usu),
                new NpgsqlParameter("@pass", usu.Pass_usu)
            };
            return ExecuteQuery(SQL, lista);
        }

        private int ExecuteQuery(string sQL, List<NpgsqlParameter> lista)
        {
            throw new NotImplementedException();
        }

        public int DeleteUsuario(Usuario usu)
        {
            const string SQL = "DELETE FROM usuario WHERE id_usu = @id;";
            List<NpgsqlParameter> lista = new List<NpgsqlParameter>() { new NpgsqlParameter("@id", usu.Id_usu) };
            return ExecuteQuery(SQL, lista);
        }
    }
}