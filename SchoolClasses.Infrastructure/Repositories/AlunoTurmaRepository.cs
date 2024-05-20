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
	public class AlunoTurmaRepository : IAlunoTurmaRepository
	{
		private readonly string _connectionString;
		public AlunoTurmaRepository(IDatabaseProvider provider)
		{
			_connectionString = provider.GetConnectionString();
		}

		public void Add(AlunoTurmaModel alunoTurma)
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				string sql = @"
                INSERT INTO Aluno_Turma
	                (IdAluno, IdTurma)
                VALUES
	                (@IdAluno, @IdTurma)";

				connection.Execute(sql, alunoTurma);
			}
		}

		public void Delete(AlunoTurmaModel alunoTurma)
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				string sql = @"
                DELETE FROM Aluno_Turma
                WHERE 
	                IdAluno = @IdAluno AND 
	                IdTurma = @IdTurma";

				connection.Execute(sql, alunoTurma);
			}
		}

		public List<string> MessagesValidationsSave(AlunoTurmaModel alunoTurma)
		{
			List<string> messages = new List<string>();

			using (var connection = new SqlConnection(_connectionString))
			{
				var queryExistsRelation = @"
                SELECT
                CASE WHEN EXISTS (SELECT 1 FROM Aluno_Turma WHERE IdAluno = @IdAluno AND IdTurma = @IdTurma)
                    THEN 
                        CAST(1 AS BIT) 
                    ELSE 
                        CAST(0 AS BIT)
                    END;";

				bool IsExistRelation = connection.ExecuteScalar<bool>(queryExistsRelation, alunoTurma);
				if (IsExistRelation)
					messages.Add("Este aluno já existe nesta turma");

				//--------------------------------------------------------------------------------------------

				var queryInactiveUser = @"
                SELECT 
	                IsAtivo
                FROM Aluno
                WHERE 
	                Id = @IdAluno";

				bool isActiveUser = connection.ExecuteScalar<bool>(queryInactiveUser, alunoTurma);
				if (!isActiveUser)
					messages.Add("Este aluno está inativo, não pode ser relacionado a uma turma");

				//--------------------------------------------------------------------------------------------

				var queryInactiveTurma = @"
                SELECT 
	                IsAtivo 
                FROM Turma
                WHERE 
	                Id = @IdTurma";

				bool isActiveTurma = connection.ExecuteScalar<bool>(queryInactiveTurma, alunoTurma);
				if (!isActiveTurma)
					messages.Add("Esta turma está inativa, não é possível adicionar um aluno");
			}
			return messages;
		}
	}
}
