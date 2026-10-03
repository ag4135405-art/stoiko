using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace GomezZuñigaAntonio.Models
{
    public class Ejercicio
    {
        [Key]
        public int Id_ejercicio { get; set; }
        public string Nom_ejercicio { get; set; }
        public string Descripcion { get; set; }
        public string Tipo_ejercicio { get; set; }
        public string Musculos_especializados { get; set; }
        public int Id_musculo { get; set; }
        public decimal Puntos_ejercicios { get; set; }

        public Ejercicio() { }

        public Ejercicio(int id_ejercicio, string nom_ejercicio, string descripcion, string tipo_ejercicio, string musculos_especializados, int id_musculo, decimal puntos_ejercicios)
        {
            Id_ejercicio = id_ejercicio;
            Nom_ejercicio = nom_ejercicio;
            Descripcion = descripcion;
            Tipo_ejercicio = tipo_ejercicio;
            Musculos_especializados = musculos_especializados;
            Id_musculo = id_musculo;
            Puntos_ejercicios = puntos_ejercicios;
        }

        public Ejercicio GetEjercicioById(int id_ejercicio)
        {
            const string sql = "SELECT * FROM ejercicio WHERE id_ejercicio = @id;";
            List<NpgsqlParameter> lstParameter = new List<NpgsqlParameter>() { new NpgsqlParameter("@id", id_ejercicio) };
            DataTable tabla = GetQuery(sql, lstParameter);

            if (tabla.Rows.Count < 1) return new Ejercicio();
            DataRow row = tabla.Rows[0];

            return new Ejercicio(
                Convert.ToInt32(row["id_ejercicio"]),
                row["nom_ejercicio"].ToString(),
                row["descripcion"].ToString(),
                row["tipo_ejercicio"].ToString(),
                row["musculos_especializados"].ToString(),
                Convert.ToInt32(row["id_musculo"]),
                Convert.ToDecimal(row["puntos_ejercicios"])
            );
        }

        public List<Ejercicio> GetEjercicios()
        {
            const string sql = "SELECT * FROM ejercicio;";
            List<Ejercicio> lstEjercicios = new List<Ejercicio>();
            DataTable tabla = GetQuery(sql);

            if (tabla.Rows.Count < 1) return lstEjercicios;

            foreach (DataRow row in tabla.Rows)
            {
                lstEjercicios.Add(new Ejercicio(
                    Convert.ToInt32(row["id_ejercicio"]),
                    row["nom_ejercicio"].ToString(),
                    row["descripcion"].ToString(),
                    row["tipo_ejercicio"].ToString(),
                    row["musculos_especializados"].ToString(),
                    Convert.ToInt32(row["id_musculo"]),
                    Convert.ToDecimal(row["puntos_ejercicios"])
                ));
            }
            return lstEjercicios;
        }

        private DataTable GetQuery(string sql)
        {
            throw new NotImplementedException();
        }

        private DataTable GetQuery(string sql, List<NpgsqlParameter> lstParameter)
        {
            throw new NotImplementedException();
        }

        public int AddEjercicio(Ejercicio ejercicio)
        {
            const string SQL = "INSERT INTO ejercicio (nom_ejercicio, descripcion, tipo_ejercicio, musculos_especializados, id_musculo, puntos_ejercicios) VALUES (@nom, @desc, @tipo, @musc_esp, @id_musc, @puntos);";
            List<NpgsqlParameter> lista = new List<NpgsqlParameter>()
            {
                new NpgsqlParameter("@nom", ejercicio.Nom_ejercicio),
                new NpgsqlParameter("@desc", ejercicio.Descripcion),
                new NpgsqlParameter("@tipo", ejercicio.Tipo_ejercicio),
                new NpgsqlParameter("@musc_esp", ejercicio.Musculos_especializados),
                new NpgsqlParameter("@id_musc", ejercicio.Id_musculo),
                new NpgsqlParameter("@puntos", ejercicio.Puntos_ejercicios)
            };
            return ExecuteQuery(SQL, lista);
        }

        public int EditEjercicio(Ejercicio ejercicio)
        {
            const string SQL = "UPDATE ejercicio SET nom_ejercicio = @nom, descripcion = @desc, tipo_ejercicio = @tipo, musculos_especializados = @musc_esp, id_musculo = @id_musc, puntos_ejercicios = @puntos WHERE id_ejercicio = @id;";
            List<NpgsqlParameter> lista = new List<NpgsqlParameter>()
            {
                new NpgsqlParameter("@id", ejercicio.Id_ejercicio),
                new NpgsqlParameter("@nom", ejercicio.Nom_ejercicio),
                new NpgsqlParameter("@desc", ejercicio.Descripcion),
                new NpgsqlParameter("@tipo", ejercicio.Tipo_ejercicio),
                new NpgsqlParameter("@musc_esp", ejercicio.Musculos_especializados),
                new NpgsqlParameter("@id_musc", ejercicio.Id_musculo),
                new NpgsqlParameter("@puntos", ejercicio.Puntos_ejercicios)
            };
            return ExecuteQuery(SQL, lista);
        }

        public int DeleteEjercicio(Ejercicio ejercicio)
        {
            const string SQL = "DELETE FROM ejercicio WHERE id_ejercicio = @id;";
            List<NpgsqlParameter> lista = new List<NpgsqlParameter>() { new NpgsqlParameter("@id", ejercicio.Id_ejercicio) };
            return ExecuteQuery(SQL, lista);
        }

        private int ExecuteQuery(string sQL, List<NpgsqlParameter> lista)
        {
            throw new NotImplementedException();
        }
    }
}