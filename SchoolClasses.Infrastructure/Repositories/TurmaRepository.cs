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

                connection.Execute(sql, new { Nome = turma.Nome, IdCurso = turma.Curso.Id, Ano = turma.Ano, DtCriacao = turma.DtCriacao, IsAtivo = turma.IsAtivo });
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

                connection.Execute(sql, new { Nome = turma.Nome, Ano = turma.Ano, IdCurso = turma.Curso.Id, Id = turma.Id });
            }
        }
        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"
                DELETE FROM Aluno_Turma
                WHERE 
                    IdTurma = @Id

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
                    t.Id, 
                    t.Nome, 
                    t.IdCurso AS CursoId, 
                    t.Ano, 
                    t.IsAtivo, 
                    t.DtCriacao,
                    c.Id AS Id, 
                    c.Nome AS Nome
                FROM Turma t
                INNER JOIN Curso c ON t.IdCurso = c.Id";

                var turmas = connection.Query<TurmaModel, CursoModel, TurmaModel>(
                    sql,
                    (turma, curso) =>
                    {
                        turma.Curso = curso;
                        return turma;
                    },
                    splitOn: "CursoId,Id"
                ).ToList();

                return turmas;
            }
        }
        public TurmaModel GetById(int id)
        {
			using (var connection = new SqlConnection(_connectionString))
			{
				string sql = @$"
                SELECT 
                    t.Id, 
                    t.Nome, 
                    t.IdCurso AS CursoId, 
                    t.Ano, 
                    t.IsAtivo, 
                    t.DtCriacao,
                    c.Id AS Id, 
                    c.Nome AS Nome
                FROM Turma t
                INNER JOIN Curso c ON t.IdCurso = c.Id
                WHERE 
                    t.Id = {id}";

                var model = (TurmaModel)connection.Query<TurmaModel, CursoModel, TurmaModel>(sql,
                    (turma, curso) =>
                    {
                        turma.Curso = curso;
                        return turma;
                    },
                    splitOn: "CursoId,Id"
                ).SingleOrDefault() ;

                return model;
			}
		}
        public List<string> MessagesValidationsSave(TurmaModel model)
        {
            List<string> messages = new List<string>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var queryExistCurso = @"
                SELECT
                CASE WHEN EXISTS (SELECT 1 FROM Curso WHERE Id = @IdCurso) 
	                THEN 
		                CAST(1 AS BIT) 
	                ELSE 
		                CAST(0 AS BIT)
	                END;";
                bool IsExistCurso = connection.ExecuteScalar<bool>(queryExistCurso, new { IdCurso = model.Curso.Id});
                if(!IsExistCurso)
					messages.Add($"Este curso não está registrado");


				var queryRepeatName = @"
                SELECT 
                CASE WHEN EXISTS (SELECT 1 FROM Turma WHERE Nome = @Nome AND Id <> @Id) 
	                THEN 
		                CAST(1 AS BIT) 
	                ELSE 
		                CAST(0 AS BIT)
	                END;";

                bool IsRepeatName = connection.ExecuteScalar<bool>(queryRepeatName, new { Nome = model.Nome, Id = model.Id });
                if (IsRepeatName)
                    messages.Add($"Já existe uma turma com o nome {model.Nome}");

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
