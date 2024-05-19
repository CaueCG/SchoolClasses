using Dapper;
using Microsoft.Data.SqlClient;
using SchoolClasses.Core.Interfaces.Repositories;
using SchoolClasses.Core.Models;
using SchoolClasses.Infrastructure.DataBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolClasses.Infrastructure.Repositories
{
    public class TurmaRepository : ITurmaRepository
    {
        private readonly string _connectionString;
        public TurmaRepository(IDatabaseProvider provider)
        {
            _connectionString = provider.GetConnectionString();
        }

        public void Add(TurmaModel turma)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"
                INSERT INTO Turma
	                (Nome, IdCurso, Ano, DtCriacao, IsAtivo)
                VALUES
	                (@Nome, @IdCurso, @Ano, @DtCriacao, @IsAtivo)";

                connection.Execute(sql, turma);
            }
        }
        public void Update(TurmaModel turma)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"
                UPDATE Turma
                SET 
	                Nome = @Nome,
	                Ano = @Ano,
	                IdCurso = @IdCurso
                WHERE
	                Id = @Id";

                connection.Execute(sql, turma);
            }
        }
        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"
                DELETE FROM Turma
                WHERE 
	                Id = @Id";

                connection.Execute(sql, new { Id = id });
            }
        }
        public void ToggleActivate(int id, bool toggleActivate)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"
                UPDATE Turma
                SET
	                IsAtivo = @IsAtivo
                WHERE
	                Id = @Id";

                connection.Execute(sql, new { Id = id, IsAtivo = toggleActivate });
            }
        }
        public List<TurmaModel> getAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"
                SELECT 
	                Id, 
	                Nome, 
	                IdCurso,
	                Ano, 
	                IsAtivo,
	                DtCriacao
                FROM Turma";

                return (List<TurmaModel>)connection.Query<TurmaModel>(sql);
            }
        }
    }
}
