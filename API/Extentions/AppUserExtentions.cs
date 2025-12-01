using API.DTOs;
using API.Entities;
using API.Interfaces;

namespace API.Extentions
{
    public static class AppUserExtentions
    {
        public static UserDTO toDto(this AppUser user , ITokenService tokenService)
        {
            return new UserDTO
            {
                Id = user.Id.ToString(),
                Name = user.Name,
                Email = user.Email,
                Token = tokenService.CreateToken(user)
            };
        }
    }
}
