using TopDown_API.Models;

namespace TopDown_API.Repositories
{
    //Não será implementada a persistência e recuperação do usuário no banco de dados
    public class UsuarioRepository
    {
        public static Usuario GetUsuario(string login, string senha)
        {
            if (login != "userTopDown" || senha != "T0pD0wn" )
            {
                return null;
            }

            return new Usuario { Login = "userTopDown", Senha = "T0pD0wn", Funcao = "Usuario" };

        }
    }
}
