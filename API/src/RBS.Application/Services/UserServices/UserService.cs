using Common.Repository.Repository;
using RBS.Application.Services.HashService;
using RBS.Domain.Enums;
using RBS.Domain.UsersAndRoles;
using RBS.Domain.UsersAndRoles.Commands;

namespace RBS.Application.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IRepository<ApplicationUser> _repository;
        private readonly IQueryRepository<ApplicationUser> _queryRepository;
        private readonly IHashService _hashSercice;

        public UserService(IRepository<ApplicationUser> repository, IQueryRepository<ApplicationUser> queryRepository,
            IHashService hashSercice)
        {
            _repository = repository;
            _queryRepository = queryRepository;
            _hashSercice = hashSercice;
        }

        public bool CheckPassword(ApplicationUser user, string password)
        {
            return user.PasswordHash.Equals(_hashSercice.Hash(password));
        }

        public async Task<int> CreateAsync(RegisterCommand command, CancellationToken cancellationToken)
        {
            command.Password = _hashSercice.Hash(command.Password);
            command.UserType = UserType.ApplicationUser;
            var user = new ApplicationUser(command);

            await _repository.InsertAsync(user, cancellationToken);
            return user.Id;
        }

        public async Task<int> RegisterGuestUser(GuestUserRegitrationCommand command, CancellationToken cancellationToken)
        {
            var user = new ApplicationUser(command);
            await _repository.InsertAsync(user, cancellationToken);
            return user.Id;
        }

        public async Task<ApplicationUser> FindByName(string username, CancellationToken cancellationToken)
        {
            return await _queryRepository.GetAsync(predicate: x => x.UserName.Equals(username), cancellationToken: cancellationToken);
        }

        public async Task UpdateUser(ApplicationUser user, CancellationToken cancellationToken)
        {
            await _repository.UpdateAsync(user, cancellationToken);
        }
    }
}
