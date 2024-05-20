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
        public List<string> MessagesValidationsSave(CursoModel model)
        {
            List<string> messages = new List<string>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var queryRepeatName = @"
                SELECT 
                CASE WHEN EXISTS (SELECT 1 FROM Curso WHERE Nome = @Nome AND Id <> @Id) 
	                THEN 
		                CAST(1 AS BIT) 
	                ELSE 
		                CAST(0 AS BIT)
	                END;";

                bool IsRepeatName = connection.ExecuteScalar<bool>(queryRepeatName, new { Nome = model.Nome, Id = model.Id });
                if (IsRepeatName)
                    messages.Add($"Já existe um curso com o nome {model.Nome}");
                
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
