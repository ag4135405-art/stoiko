using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace GomezZuñigaAntonio.Models
{
    public class Musculo
    {
        [Key]
        public int Id_musculo { get; set; }
        public string Nom_musculo { get; set; }
        public string Grupo_muscular { get; set; }

        public Musculo() { }

        public Musculo(int id_musculo, string nom_musculo, string grupo_muscular)
        {
            Id_musculo = id_musculo;
            Nom_musculo = nom_musculo;
            Grupo_muscular = grupo_muscular;
        }

        public Musculo GetMusculoById(int id_musculo)
        {
            const string sql = "SELECT * FROM musculo WHERE id_musculo = @id;";
            List<NpgsqlParameter> lstParameter = new List<NpgsqlParameter>() { new NpgsqlParameter("@id", id_musculo) };
            DataTable tabla = GetQuery(sql, lstParameter);

            if (tabla.Rows.Count < 1) return new Musculo();
            DataRow row = tabla.Rows[0];

            return new Musculo(
                Convert.ToInt32(row["id_musculo"]),
                row["nom_musculo"].ToString(),
                row["grupo_muscular"].ToString()
            );
        }

        public List<Musculo> GetMusculos()
        {
            const string sql = "SELECT * FROM musculo;";
            List<Musculo> lstMusculos = new List<Musculo>();
            DataTable tabla = GetQuery(sql);

            if (tabla.Rows.Count < 1) return lstMusculos;

            foreach (DataRow row in tabla.Rows)
            {
                lstMusculos.Add(new Musculo(
                    Convert.ToInt32(row["id_musculo"]),
                    row["nom_musculo"].ToString(),
                    row["grupo_muscular"].ToString()
                ));
            }
            return lstMusculos;
        }

        public int AddMusculo(Musculo musculo)
        {
            const string SQL = "INSERT INTO musculo (nom_musculo, grupo_muscular) VALUES (@nom, @grupo);";
            List<NpgsqlParameter> lista = new List<NpgsqlParameter>()
            {
                new NpgsqlParameter("@nom", musculo.Nom_musculo),
                new NpgsqlParameter("@grupo", musculo.Grupo_muscular)
            };
            return ExecuteQuery(SQL, lista);
        }

        public int EditMusculo(Musculo musculo)
        {
            const string SQL = "UPDATE musculo SET nom_musculo = @nom, grupo_muscular = @grupo WHERE id_musculo = @id;";
            List<NpgsqlParameter> lista = new List<NpgsqlParameter>()
            {
                new NpgsqlParameter("@id", musculo.Id_musculo),
                new NpgsqlParameter("@nom", musculo.Nom_musculo),
                new NpgsqlParameter("@grupo", musculo.Grupo_muscular)
            };
            return ExecuteQuery(SQL, lista);
        }

        public int DeleteMusculo(Musculo musculo)
        {
            const string SQL = "DELETE FROM musculo WHERE id_musculo = @id;";
            List<NpgsqlParameter> lista = new List<NpgsqlParameter>() { new NpgsqlParameter("@id", musculo.Id_musculo) };
            return ExecuteQuery(SQL, lista);
        }

        private int ExecuteQuery(string sQL, List<NpgsqlParameter> lista)
        {
            throw new NotImplementedException();
        }

        private DataTable GetQuery(string sql, List<NpgsqlParameter> lstParameter = null)
        {
            throw new NotImplementedException();
        }
    }
}