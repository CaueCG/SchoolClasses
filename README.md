## **Configurações necessárias**

### **Rodar Script SQL Server para criação do banco**
**Local:** `SchoolClasses/SchoolClasses.Infrastructure/DataBase/script.sql`

### **Configurar Connection String**
**Local:** `appSettings.Development.json` do projeto `SchoolClasses.API`
**Acrescentar:** `  "Constants": {
    "ConnectionString": "Data Source=YourLocal\\YourInstanceSQLServer;Initial Catalog=SchoolClasses;Persist Security Info=True;User ID=YourUser;Password=YourPassword; TrustServerCertificate=True;"
  }`

### **Configurar Prefixo da URL da API na camada Presentation**
**Local:** `appSettings.Development.json` do projeto `SchoolClasses.Presentation`  
**Acrescentar:** `
  "Constants": {
    "API_PREFIX_URL": "https://localhost:YourPortRunningAPI/"
  }`
**Exemplo:** `https://localhost:7040  OBSERVAÇÃO: Não incluir '/' no final, exemplo: https://localhost:7040/` 

### **Configure incialização do projeto selecionando multiplos projetos**
**Projetos a serem inicializados:** `SchoolClasses.API e SchoolClasses.Presentation`

---

## **Back-end está completo, atendendo todas as regras de negócios e adicionando validações extras, Design Pattern e Middleware**

**Observação:** A única regra de negócio que ficaria sob responsabilidade do front seria a força da senha, o restante está no back.

## **No projeto Presentation foi feito:**

- **Criação de todas as Models que seriam utilizadas**
- **Todos os services que fazem requisição a API**
- **Listagem de cursos, alunos e turmas**
- **Ativar e desativar cursos e alunos**
- **Excluir cursos, alunos e turmas**

## **Faltou:**

- **Implementar serviço genérico para captura de mensagens de erros padronizadas da API para expor ao usuário**
- **Criar formulário e Alterar cursos, alunos e turmas**
- **Criar formulário e Cadastrar cursos, alunos e turmas**
- **Validar senha fraca com Regex para averiguar se atende os requisitos que estipularmos (Maisculas, minúsculas, números...)**
- **Criar tabela de alunos em turma com o botão de excluir aluno da turma na tela RELACIONAR**
- **Testes unitários no contexto geral**
