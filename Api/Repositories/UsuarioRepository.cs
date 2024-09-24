using ToDo_API.Models;

namespace ToDo_API.Repositories
{
    //Não será implementada a persistência e recuperação do usuário no banco de dados
    public class UsuarioRepository
    {
        public static Usuario GetUsuario(string login, string senha)
        {
            if (login != "userToDo" || senha != "T0pD0wn" )
            {
                return null;
            }

            return new Usuario { Login = "userToDo", Senha = "T0pD0wn", Funcao = "Usuario" };

        }
    }
}
