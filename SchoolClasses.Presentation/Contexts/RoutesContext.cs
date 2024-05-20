namespace SchoolClasses.Presentation.Contexts
{
    public static class RoutesContext
    {
        private static string API_PREFIX_URL = "https://localhost:7067";

        #region ALUNOS
        public static string EndpointAlunos_Add = $"{API_PREFIX_URL}/api/aluno";
        public static string EndpointAlunos_GetAll = $"{API_PREFIX_URL}/api/aluno";
        public static string EndpointAlunos_Update(string id) => $"{API_PREFIX_URL}/api/aluno/{id}";
        public static string EndpointAlunos_Delete(string id) => $"{API_PREFIX_URL}/api/aluno/{id}";
        public static string EndpointAlunos_ToggleActivate(string id) => $"{API_PREFIX_URL}/api/aluno/{id}";
        public static string EndpointAlunos_GetByIdTurma(string idTurma) => $"{API_PREFIX_URL}/api/aluno/{idTurma}";
        #endregion

        #region TURMAS
        public static string EndpointTurma_Add = $"{API_PREFIX_URL}/api/turma";
        public static string EndpointTurma_GetAll = $"{API_PREFIX_URL}/api/turma";
        public static string EndpointTurma_Update(string id) => $"{API_PREFIX_URL}/api/turma/{id}";
        public static string EndpointTurma_Delete(string id) => $"{API_PREFIX_URL}/api/turma/{id}";
        public static string EndpointTurma_ToggleActivate(string id) => $"{API_PREFIX_URL}/api/turma/{id}";
        #endregion

        #region CURSOS
        public static string EndpointCurso_Add = $"{API_PREFIX_URL}/api/curso";
        public static string EndpointCurso_GetAll = $"{API_PREFIX_URL}/api/curso";
        public static string EndpointCurso_Update(string id) => $"{API_PREFIX_URL}/api/curso/{id}";
        public static string EndpointCurso_Delete(string id) => $"{API_PREFIX_URL}/api/curso/{id}";
        #endregion

        #region ALUNOTURMA
        public static string EndpointAlunoTurma_Add = $"{API_PREFIX_URL}/api/alunoturma";
        public static string EndpointAlunoTurma_Delete(string idAluno, string idTurma) => $"{API_PREFIX_URL}/api/aluno/{idAluno}/{idTurma}";
        #endregion
    }
}
