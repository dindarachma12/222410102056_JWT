using percobaan1.Repositories.Impl;
using percobaan1.DTO;
using percobaan1.Entities;

namespace percobaan1.Services.Impl
{
    public class AuthServiceImpl
    {
        private AuthRepositoryImpl authRepository;
        public AuthServiceImpl(AuthRepositoryImpl authRepository)
        {
            this.authRepository = authRepository;
        }
        public User register(RegisterDTO dto)
        {
            User user = new User();
            user.nama = dto.nama;
            user.email = dto.email;
            user.password = dto.password;
            return authRepository.register(user);
        }

        public User Login(LoginDTO dto, IConfiguration configuration)
        {
            User user = new User();
            user.email = dto.email;
            user.password = dto.password;
            if (this.authRepository.Login(user, configuration) == null)
            {
                return null;
            }
            return this.authRepository.Login(user, configuration);
        }
    }
}
