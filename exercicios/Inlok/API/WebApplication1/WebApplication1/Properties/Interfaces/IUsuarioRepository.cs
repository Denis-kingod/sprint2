using WebApplication1.Properties.Domains;

namespace senai.inLock.webAPI.Interfaces
{
    interface IUsuarioRepository
    {
        UsuariosDomain Login(string email, string senha);
        UsuariosDomain BuscarPorEmailSenha(string email, string senha);
    }
}
