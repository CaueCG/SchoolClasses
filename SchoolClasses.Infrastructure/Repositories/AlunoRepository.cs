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
    public class AlunoRepository : IAlunoRepository
    {
        private readonly string _connectionString;
        public AlunoRepository(IDatabaseProvider provider)
        {
            _connectionString = provider.GetConnectionString();
        }

        public void Add(AlunoModel turma)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"
                INSERT INTO Aluno 
	                (Nome, Usuario, Senha, DtCriacao, IsAtivo)
                VALUES
	                (@Nome, @Usuario, @Senha, @DtCriacao, @IsAtivo)";

                connection.Execute(sql, turma);
            }
        }
        public void Update(AlunoModel turma)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"
                UPDATE Aluno
                SET
	                Nome = @Nome,
	                Usuario = @Usuario
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
                DELETE FROM Aluno
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
                UPDATE Aluno 
                SET
	                IsAtivo = @IsAtivo
                WHERE 
	                Id = @Id";

                connection.Execute(sql, new { Id = id, IsAtivo = toggleActivate });
            }
        }
        public List<AlunoModel> getAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"
                SELECT 
	                Id,
	                Nome,
	                Usuario, 
	                IsAtivo,
	                DtCriacao
                FROM Aluno";

                return (List<AlunoModel>)connection.Query<AlunoModel>(sql);
            }
        }
    }
}
