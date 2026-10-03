using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace GomezZuñigaAntonio.Models
{
    public class Divicion_General
    {
        [Key]
        public int Id_division { get; set; }
        public string Nom_division { get; set; }
        public double Score_division { get; set; }

        public Divicion_General() { }

        public Divicion_General(int id_division, string nom_division, double score_division)
        {
            Id_division = id_division;
            Nom_division = nom_division;
            Score_division = score_division;
        }

        public Divicion_General GetDivision_GeneralById(int id_Division)
        {
            const string sql = "SELECT * FROM division_general WHERE id_division = @id;";

            List<NpgsqlParameter> lstParameter = new List<NpgsqlParameter>();
            lstParameter.Add(new NpgsqlParameter("@id", id_Division));

            DataTable tabla = GetQuery(sql, lstParameter);

            if (tabla.Rows.Count < 1)
            {
                return new Divicion_General();
            }

            DataRow row = tabla.Rows[0];

            return new Divicion_General(
                Convert.ToInt32(row["id_division"]),
                row["nom_division"].ToString(),
                Convert.ToDouble(row["score_division"])
            );
        }

        private DataTable GetQuery(string sql, List<NpgsqlParameter> lstParameter)
        {
            throw new NotImplementedException();
        }

        public List<Divicion_General> GetDivicion_Generals()
        {
            const string sql = "SELECT * FROM division_general;";
            List<Divicion_General> lstdivicion_Generals = new List<Divicion_General>();
            DataTable tabla = GetQuery(sql);

            if (tabla.Rows.Count < 1) return lstdivicion_Generals;

            foreach (DataRow row in tabla.Rows)
            {
                lstdivicion_Generals.Add(new Divicion_General(
                    Convert.ToInt32(row["id_division"]),
                    row["nom_division"].ToString(),
                    Convert.ToDouble(row["score_division"])
                ));
            }

            return lstdivicion_Generals;
        }

        private DataTable GetQuery(string sql)
        {
            throw new NotImplementedException();
        }

        public int EditDivision_General(Divicion_General divi_general)
        {
            const string SQL = "UPDATE division_general SET nom_division = @nom_division, score_division = @score_division WHERE id_division = @id;";

            NpgsqlParameter paramId = new NpgsqlParameter("@id", divi_general.Id_division);
            NpgsqlParameter paramNom = new NpgsqlParameter("@nom_division", divi_general.Nom_division);
            NpgsqlParameter paramScore = new NpgsqlParameter("@score_division", divi_general.Score_division);

            List<NpgsqlParameter> lista = new List<NpgsqlParameter>() { paramId, paramNom, paramScore };
            return ExecuteQuery(SQL, lista);
        }

        private int ExecuteQuery(string sQL, List<NpgsqlParameter> lista)
        {
            throw new NotImplementedException();
        }

        public int AddDivision_General(Divicion_General divi_general)
        {
            const string SQL = "INSERT INTO division_general (nom_division, score_division) VALUES (@nom_division, @score_division);";

            NpgsqlParameter paramNom = new NpgsqlParameter("@nom_division", divi_general.Nom_division);
            NpgsqlParameter paramScore = new NpgsqlParameter("@score_division", divi_general.Score_division);

            List<NpgsqlParameter> lista = new List<NpgsqlParameter>() { paramNom, paramScore };

            return ExecuteQuery(SQL, lista);
        }

        public int DeleteDivision_general(Divicion_General divi_general)
        {
            const string SQL = "DELETE FROM division_general WHERE id_division = @id;";
            NpgsqlParameter paramId = new NpgsqlParameter("@id", divi_general.Id_division);
            List<NpgsqlParameter> lista = new List<NpgsqlParameter>() { paramId };
            return ExecuteQuery(SQL, lista);
        }

        internal void Details(Divicion_General divi_general)
        {
            throw new NotImplementedException();
        }
    }
}