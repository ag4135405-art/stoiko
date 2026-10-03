using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace GomezZuñigaAntonio.Models
{
    public class Perfil_usu : Usuario
    {
        [Key]
        public int Id_perfil { get; set; }
        public string Nom_perfil { get; set; }
        public decimal Score_total { get; set; }
        public string Division_general { get; set; }
        public DateTime Fecha_registro { get; set; }
        public string Division_musc { get; set; }
        public int Score_dm { get; set; }
        public int Id_dm { get; set; }
        public int Id_division { get; set; }

        public Perfil_usu() { }

        public Perfil_usu(int id_perfil, string nom_perfil, decimal score_total, string division_general, DateTime fecha_registro, string division_musc, int score_dm, int id_dm, int id_division, int id_usu, string email_usu, string pass_usu)
            : base(id_usu, email_usu, pass_usu)
        {
            Id_perfil = id_perfil;
            Nom_perfil = nom_perfil;
            Score_total = score_total;
            Division_general = division_general;
            Fecha_registro = fecha_registro;
            Division_musc = division_musc;
            Score_dm = score_dm;
            Id_dm = id_dm;
            Id_division = id_division;
        }

        public Perfil_usu GetPerfilById(int id_perfil)
        {
            const string sql = "SELECT * FROM perfil_usu WHERE id_perfil = @id;";
            List<NpgsqlParameter> lstParameter = new List<NpgsqlParameter>() { new NpgsqlParameter("@id", id_perfil) };

            DataTable tabla = GetQuery(sql, lstParameter);

            if (tabla.Rows.Count < 1) return new Perfil_usu();
            DataRow row = tabla.Rows[0];

            return new Perfil_usu(
                Convert.ToInt32(row["id_perfil"]),
                row["nom_perfil"].ToString(),
                Convert.ToDecimal(row["score_total"]),
                row["division_general"].ToString(),
                Convert.ToDateTime(row["fecha_registro"]),
                row["division_musc"].ToString(),
                Convert.ToInt32(row["score_dm"]),
                Convert.ToInt32(row["id_dm"]),
                Convert.ToInt32(row["id_division"]),

                0, "", ""
            );
        }

        private DataTable GetQuery(string sql, List<NpgsqlParameter> lstParameter)
        {
            throw new NotImplementedException();
        }

        public List<Perfil_usu> GetPerfiles()
        {
            const string sql = "SELECT * FROM perfil_usu;";
            List<Perfil_usu> lstPerfiles = new List<Perfil_usu>();
            DataTable tabla = GetQuery(sql);

            if (tabla.Rows.Count < 1) return lstPerfiles;

            foreach (DataRow row in tabla.Rows)
            {
                lstPerfiles.Add(new Perfil_usu(
                    Convert.ToInt32(row["id_perfil"]),
                    row["nom_perfil"].ToString(),
                    Convert.ToDecimal(row["score_total"]),
                    row["division_general"].ToString(),
                    Convert.ToDateTime(row["fecha_registro"]),
                    row["division_musc"].ToString(),
                    Convert.ToInt32(row["score_dm"]),
                    Convert.ToInt32(row["id_dm"]),
                    Convert.ToInt32(row["id_division"]),
                    0, "", ""
                ));
            }
            return lstPerfiles;
        }

        private DataTable GetQuery(string sql)
        {
            throw new NotImplementedException();
        }

        public int AddPerfil(Perfil_usu perfil)
        {
            const string SQL = "INSERT INTO perfil_usu (nom_perfil, score_total, division_general, fecha_registro, division_musc, score_dm, id_dm, id_division) VALUES (@nom, @score, @div_gen, @fecha, @div_musc, @score_dm, @id_dm, @id_div);";
            List<NpgsqlParameter> lista = new List<NpgsqlParameter>()
            {
                new NpgsqlParameter("@nom", perfil.Nom_perfil),
                new NpgsqlParameter("@score", perfil.Score_total),
                new NpgsqlParameter("@div_gen", perfil.Division_general),
                new NpgsqlParameter("@fecha", perfil.Fecha_registro),
                new NpgsqlParameter("@div_musc", perfil.Division_musc),
                new NpgsqlParameter("@score_dm", perfil.Score_dm),
                new NpgsqlParameter("@id_dm", perfil.Id_dm),
                new NpgsqlParameter("@id_div", perfil.Id_division)
            };
            return ExecuteQuery(SQL, lista);
        }

        private int ExecuteQuery(string sQL, List<NpgsqlParameter> lista)
        {
            throw new NotImplementedException();
        }

        public int EditPerfil(Perfil_usu perfil)
        {
            const string SQL = "UPDATE perfil_usu SET nom_perfil = @nom, score_total = @score, division_general = @div_gen, fecha_registro = @fecha, division_musc = @div_musc, score_dm = @score_dm, id_dm = @id_dm, id_division = @id_div WHERE id_perfil = @id;";
            List<NpgsqlParameter> lista = new List<NpgsqlParameter>()
            {
                new NpgsqlParameter("@id", perfil.Id_perfil),
                new NpgsqlParameter("@nom", perfil.Nom_perfil),
                new NpgsqlParameter("@score", perfil.Score_total),
                new NpgsqlParameter("@div_gen", perfil.Division_general),
                new NpgsqlParameter("@fecha", perfil.Fecha_registro),
                new NpgsqlParameter("@div_musc", perfil.Division_musc),
                new NpgsqlParameter("@score_dm", perfil.Score_dm),
                new NpgsqlParameter("@id_dm", perfil.Id_dm),
                new NpgsqlParameter("@id_div", perfil.Id_division)
            };
            return ExecuteQuery(SQL, lista);
        }

        public int DeletePerfil(Perfil_usu perfil)
        {
            const string SQL = "DELETE FROM perfil_usu WHERE id_perfil = @id;";
            List<NpgsqlParameter> lista = new List<NpgsqlParameter>() { new NpgsqlParameter("@id", perfil.Id_perfil) };
            return ExecuteQuery(SQL, lista);
        }
    }
}