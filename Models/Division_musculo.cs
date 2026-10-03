using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace GomezZuñigaAntonio.Models
{
    public class Division_musculo : Divicion_General
    {
        [Key]
        public int Id_dm { get; set; }
        public decimal Score_dm { get; set; }
        public int Id_musculo { get; set; }

        public Division_musculo() { }

        public Division_musculo(int id_dm, string nom_division, decimal score_dm, int id_musculo, int id_division, double score_division = 0)
            : base(id_division, nom_division, score_division)
        {
            Id_dm = id_dm;
            Score_dm = score_dm;
            Id_musculo = id_musculo;
        }

        public Division_musculo GetDivision_musculoById(int id_dm)
        {
            const string sql = "SELECT * FROM division_musculo WHERE id_dm = @id;";

            List<NpgsqlParameter> lstParameter = new List<NpgsqlParameter>();
            lstParameter.Add(new NpgsqlParameter("@id", id_dm));

            DataTable tabla = GetQuery(sql, lstParameter);

            if (tabla.Rows.Count < 1)
            {
                return new Division_musculo();
            }

            DataRow row = tabla.Rows[0];

            return new Division_musculo(
                Convert.ToInt32(row["id_dm"]),
                row["nom_division"].ToString(),
                Convert.ToDecimal(row["score_dm"]),
                Convert.ToInt32(row["id_musculo"]),
                Convert.ToInt32(row["id_division"])
            );
        }

        public List<Division_musculo> GetDivision_musculos()
        {
            const string sql = "SELECT * FROM division_musculo;";
            List<Division_musculo> lstDivision_musculos = new List<Division_musculo>();
            DataTable tabla = GetQuery(sql);

            if (tabla.Rows.Count < 1) return lstDivision_musculos;

            foreach (DataRow row in tabla.Rows)
            {
                lstDivision_musculos.Add(new Division_musculo(
                    Convert.ToInt32(row["id_dm"]),
                    row["nom_division"].ToString(),
                    Convert.ToDecimal(row["score_dm"]),
                    Convert.ToInt32(row["id_musculo"]),
                    Convert.ToInt32(row["id_division"])
                ));
            }

            return lstDivision_musculos;
        }

        private DataTable GetQuery(string sql)
        {
            throw new NotImplementedException();
        }

        private DataTable GetQuery(string sql, List<NpgsqlParameter> lstParameter)
        {
            throw new NotImplementedException();
        }

        public int EditDivision_musculo(Division_musculo div_musculo)
        {
            const string SQL = "UPDATE division_musculo SET nom_division = @nom_division, score_dm = @score_dm, id_musculo = @id_musculo, id_division = @id_division WHERE id_dm = @id_dm;";

            List<NpgsqlParameter> lista = new List<NpgsqlParameter>()
            {
                new NpgsqlParameter("@id_dm", div_musculo.Id_dm),
                new NpgsqlParameter("@nom_division", div_musculo.Nom_division),
                new NpgsqlParameter("@score_dm", div_musculo.Score_dm),
                new NpgsqlParameter("@id_musculo", div_musculo.Id_musculo),
                new NpgsqlParameter("@id_division", div_musculo.Id_division)
            };

            return ExecuteQuery(SQL, lista);
        }

        public int AddDivision_musculo(Division_musculo div_musculo)
        {
            const string SQL = "INSERT INTO division_musculo (nom_division, score_dm, id_musculo, id_division) VALUES (@nom_division, @score_dm, @id_musculo, @id_division);";

            List<NpgsqlParameter> lista = new List<NpgsqlParameter>()
            {
                new NpgsqlParameter("@nom_division", div_musculo.Nom_division),
                new NpgsqlParameter("@score_dm", div_musculo.Score_dm),
                new NpgsqlParameter("@id_musculo", div_musculo.Id_musculo),
                new NpgsqlParameter("@id_division", div_musculo.Id_division)
            };

            return ExecuteQuery(SQL, lista);
        }

        private int ExecuteQuery(string sQL, List<NpgsqlParameter> lista)
        {
            throw new NotImplementedException();
        }

        public int DeleteDivision_musculo(Division_musculo div_musculo)
        {
            const string SQL = "DELETE FROM division_musculo WHERE id_dm = @id_dm;";

            List<NpgsqlParameter> lista = new List<NpgsqlParameter>()
            {
                new NpgsqlParameter("@id_dm", div_musculo.Id_dm)
            };

            return ExecuteQuery(SQL, lista);
        }
    }
}