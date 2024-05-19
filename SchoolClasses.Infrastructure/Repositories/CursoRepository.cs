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

        public void Add(CursoModel curso)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"
                INSERT INTO Curso
	                (Nome)
                VALUES
	                (@Nome)";

                connection.Execute(sql, curso);
            }
        }
        public void Update(CursoModel curso)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"
                UPDATE Curso
                SET
	                Nome = @Nome
                WHERE
	                Id = @Id";

                connection.Execute(sql, curso);
            }
        }
        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"
                DELETE FROM Curso
                WHERE
	                Id = @Id";

                connection.Execute(sql, new { Id = id });
            }
        }
        public List<CursoModel> getAll()
        {
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
