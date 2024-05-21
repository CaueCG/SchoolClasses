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
                DELETE FROM Aluno_Turma
                WHERE 
                    IdAluno = @Id

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
		public AlunoModel GetById(int id)
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
                FROM Aluno
                WHERE
                    Id = @Id";

				return connection.QueryFirstOrDefault<AlunoModel>(sql, new { Id = id });
			}
		}
		public List<AlunoModel> GetByIdTurma(int idTurma)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"
                SELECT 
	                a.Id,
	                a.Nome,
	                a.Usuario, 
	                a.IsAtivo,
	                a.DtCriacao
                FROM Aluno a
                INNER JOIN Aluno_Turma at
	                ON a.Id = at.IdAluno
                WHERE 
	                IdTurma= @IdTurma";

                return (List<AlunoModel>)connection.Query<AlunoModel>(sql, new { IdTurma = idTurma });
            }
        }
        public List<string> MessagesValidationsSave(AlunoModel model)
        {
            List<string> messages = new List<string>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var queryRepeatUsuario = @"
                SELECT 
                CASE WHEN EXISTS (SELECT 1 FROM Aluno WHERE Usuario = @Usuario AND Id <> @Id) 
	                THEN 
		                CAST(1 AS BIT) 
	                ELSE 
		                CAST(0 AS BIT)
	                END;";

                bool IsRepeatUsuario = connection.ExecuteScalar<bool>(queryRepeatUsuario, new { Usuario = model.Usuario, Id = model.Id });
                if (IsRepeatUsuario)
                    messages.Add($"Este email já está sendo utilizado no sistema");

                //EXEMPLO PARA ADICIONAR OUTRA VALIDAÇÃO COM MENSAGEM
                //var queryOtherValidation = @"query sql server";
                //bool IsOtherValidation = connection.ExecuteScalar<bool>(queryRepeatName, new { Nome = model.Nome });
                //if (IsOtherValidation)
                //    messages.Add($"Message Other Validation");
            }

            return messages;
        }
    }
}
