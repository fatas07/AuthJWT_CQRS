using AuthJWT_CQRS.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace AuthJWT_CQRS.Data.Repositories.User
{
    public class UserRepo : IUserRepo
    {
        private readonly UserManager<UserEntity> userManager;

        public UserRepo(UserManager<UserEntity> _userManager)
        {
            userManager = _userManager;
        }

        #region CREATE
        public async Task<IdentityResult> CreateUser(UserEntity user, string password)
        {
            return await userManager.CreateAsync(user, password);
        }
        public async Task<IdentityResult> AddDefaultRoleToUser(UserEntity user)
        {
            return await userManager.AddToRoleAsync(user, Settings.Default.RolesUser);
        }
        #endregion

        #region READ
        public async Task<bool> CheckUserPassword(UserEntity user, string password)
        {
            return await userManager.CheckPasswordAsync(user, password);
        }
        public async Task<UserEntity> GetUserByEmail(string email)
        {
            return await userManager.FindByEmailAsync(email);
        }

        public async Task<IList<string>> GetUserRoles(UserEntity user)
        {
            return await userManager.GetRolesAsync(user);
        }
        #endregion

        #region UPDATE
        public async Task<IdentityResult> UpdateUser(UserEntity user)
        {
            return await userManager.UpdateAsync(user);
        }
        #endregion

        #region DELETE
        #endregion



    }
}
