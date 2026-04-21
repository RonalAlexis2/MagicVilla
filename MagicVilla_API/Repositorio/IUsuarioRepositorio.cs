using MagicVilla_API.Modelos;
using MagicVilla_API.Modelos.Dto;

namespace MagicVilla_API.Repositorio
{
    public interface IUsuarioRepositorio
    {
        bool IsUsuarioUnico(string username);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<UsuarioDto> Registrar (RegistroRequestDTO registroRequestDTO);
    }
}
