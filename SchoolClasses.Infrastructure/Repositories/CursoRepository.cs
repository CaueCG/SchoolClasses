using Dapper;
using Microsoft.Data.SqlClient;
using SchoolClasses.Core.Interfaces.Repositories;
using SchoolClasses.Core.Models;
using SchoolClasses.Infrastructure.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolClasses.Infrastructure.Repositories
{
    public class CursoRepository : ICursoRepository
    {
        private readonly string _connectionString;
        public CursoRepository(IDatabaseProvider provider)
        {
            _connectionString = provider.GetConnectionString();
        }

        public void Add(CursoModel turma) {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"
                INSERT INTO Curso
	                (Nome)
                VALUES
	                (@Nome)";
            }
        }
        public void Update(CursoModel turma) {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"
                UPDATE Curso
                SET
	                Nome = @Nome
                WHERE
	                Id = @Id";
            }
        }
        public void Delete(int id) {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"
                DELETE FROM Curso
                WHERE
	                Id = @Id";
            }
        }
        public List<CursoModel> getAll() {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"
                SELECT 
	                Id,
	                Nome
                FROM Curso";

                return (List<CursoModel>)connection.Query<CursoModel>(sql);
            }
        }
    }
}
