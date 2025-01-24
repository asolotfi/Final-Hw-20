


using HW_20.Domain.Contract.Repositoris;
using HW_20.Domain.Contract.Service;

namespace HW_20.Service.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationRepository _authenticationRepository;

        public AuthenticationService(IAuthenticationRepository authenticationRepository)
        {
            _authenticationRepository = authenticationRepository;
        }
        public bool Login(string userName, string password)
        {
            var result = _authenticationRepository.Login(userName, password);
            return result;
        }
    }
}

