﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Trainingcenter.Domain.DomainModels;
using Trainingcenter.Domain.DTOs.PortfolioDTO_s;
using Trainingcenter.Domain.DTOs.UserDTOs;
using Trainingcenter.Domain.Repositories;
using Trainingcenter.Domain.Services.PortfolioServices;

namespace Trainingcenter.Domain.Services.UserServices
{
    public class UserServices : IUserServices
    {
        #region DependencyInjection

        private readonly IGenericRepository _genericRepo;
        private readonly IUserRepository _userRepo;
        private readonly IPortfolioServices _portfolioService;

        public UserServices(IGenericRepository genericRepo, IUserRepository userRepo, IPortfolioServices portfolioService)
        {
            _genericRepo = genericRepo;
            _userRepo = userRepo;
            _portfolioService = portfolioService;
        }

        #endregion

        #region Services

        public async Task<UserDTO> Login(UserToLoginDTO userToLogin)
        {
            try
            {
                userToLogin.Username = userToLogin.Username.ToLower();
                var userFromDB = await _userRepo.GetFromUsernameAsync(userToLogin.Username);

                if (userFromDB == null)
                {
                    return null;
                }
                if (!VerifyPasswordHash(userToLogin.Password, userFromDB.PasswordHash, userFromDB.PasswordSalt))
                {
                    return null;
                }

                userFromDB.LastActive = DateTime.Now;
                await _genericRepo.UpdateAsync(userFromDB);

                return ConvertUser(userFromDB);
            }
            catch(Exception ex)
            {
                throw new Exception("UserService failed to login server");
            }
        }

        public async Task<UserDTO> Register(UserToRegisterDTO userToRegister)
        {
            try
            {

                //Set username to lowercase
                userToRegister.Username = userToRegister.Username.ToLower();

                //Hash password
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(userToRegister.Password, out passwordHash, out passwordSalt);

                //Prepare to save user in databse
                var userToCreate = new User
                {
                    Username = userToRegister.Username,
                    Email = userToRegister.Email
                };
                userToCreate.PasswordHash = passwordHash;
                userToCreate.PasswordSalt = passwordSalt;
                userToCreate.CreatedOn = DateTime.Now;

                //Create the user
                await _genericRepo.AddAsync(userToCreate);

                //Convert user
                var createdUser = await _userRepo.GetFromUsernameAsync(userToRegister.Username);

                //Create default portfolio
                var defaultPortfolio = new PortfolioToCreateDTO
                {
                    Name = "default",
                };
                await _portfolioService.CreatePortfolioAsync(defaultPortfolio, createdUser.UserId, true);

                var userToReturn = new UserDTO
                {
                    UserId = createdUser.UserId,
                    Username = createdUser.Username
                    //More fields here
                };

                return userToReturn;
            }
            catch (Exception ex)
            {
                throw new Exception("UserService failed to register user");
            }
        }

        public async Task<bool> UserExists(string username)
        {
            if (await _userRepo.GetFromUsernameAsync(username.ToLower()) == null)
            {
                return false;
            }
            return true;
        }

        public bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Helpers

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        #endregion

        #region Converters

        private UserDTO ConvertUser(User user)
        {
            var userDTO = new UserDTO
            {
                UserId = user.UserId,
                Username = user.Username
                //More fields here
            };
            return userDTO;
        }

        #endregion
    }
}
