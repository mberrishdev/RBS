using RBS.Application.Services.HashService;
using RBS.Data.Repositories;
using RBS.Data.UnitOfWorks;
using RBS.Domain.Enums;
using RBS.Domain.UsersAndRoles;
using RBS.Domain.UsersAndRoles.Commands;

namespace RBS.Application.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IRepository<ApplicationUser> _repository;
        private readonly IUnitOfWork<ApplicationUser> _unitOfWork;
        private readonly IHashService _hashSercice;

        public UserService(IUnitOfWork<ApplicationUser> unitOfWork, IHashService hashSercice)
        {
            _unitOfWork = unitOfWork;
            _repository = unitOfWork.Repository;
            _hashSercice = hashSercice;
        }

        public bool CheckPassword(ApplicationUser user, string password)
        {
            return user.PasswordHash.Equals(_hashSercice.Hash(password));
        }

        public async Task<int> CreateAsync(RegisterCommand command)
        {
            command.Password = _hashSercice.Hash(command.Password);
            command.UserType = UserType.ApplicationUser;
            var user = new ApplicationUser(command);
            await _repository.CreateAsync(user);
            await _unitOfWork.CommitAsync();

            return user.Id;
        }

        public async Task<int> RegisterGuestUser(GuestUserRegitrationCommand command)
        {
            var user = new ApplicationUser(command);
            await _repository.CreateAsync(user);
            await _unitOfWork.CommitAsync();
            return user.Id;
        }

        public async Task<ApplicationUser> FindByName(string username)
        {
            return await _repository.GetAsync(predicate: x => x.UserName.Equals(username));
        }


        public async Task UpdateUser(ApplicationUser user)
        {
            _repository.Update(user);
            _unitOfWork.CommitAsync();
        }
    }
}
