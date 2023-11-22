using HealHub.CrossCutting.Helpers;
using HealHub.Domain.Entities;
using HealHub.Domain.Interfaces;
using HealHub.Infra;
using Microsoft.EntityFrameworkCore;

namespace HealHub.Services
{
    public class UserService : IUserService
    {
        private readonly OracleDbContext _context;

        public UserService(OracleDbContext context) 
        {
            _context = context;
        }

        public Result<List<User>> getAllUsers() 
        {
            try
            {
                return new()
                {
                    Success = true,
                    Data = _context.Users.ToList(),
                    Message = "Dados encontrados"
                };
            }
            catch(Exception ex)
            {
                return new()
                {
                    Success = false,
                    Message = ex.Message
                };
            }
            

           
        }

        public Result<User> createUser(User user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();

                return new()
                {
                    Success = true,
                    Data = user,
                    Message = "Usuario Cadastrado com Sucesso"
                };
            }
            catch (Exception ex)
            {
                return new()
                {
                    Success = false,
                    Message = ex.Message
                };
            }
            
        }

        public Result<User> updateUser(int id, User user)
        {
            try
            {
                var optional = _context.Users.Find(id);

                if (optional != null)
                {
                    user.id = optional.id;

                    optional.email = user.email;

                    optional.name = user.name;

                    _context.SaveChanges();

                    return new()
                    {
                        Success = true,
                        Data = optional,
                        Message = "Usuario atualizado"
                    };
                }
                else
                {
                    return new()
                    {
                        Success = false,
                        Message = "ID inexistente"
                    };
                }
            }
            catch(Exception ex)
            {
                return new()
                {
                    Success = false,
                    Message = ex.Message
                };
            }
            
        }

        public Result<bool> deleteUser(int id)
        {
            try
            {
                var optional = _context.Users.Find(id);

                if (optional != null)
                {

                    _context.Users.Remove(optional);

                    _context.SaveChanges();

                    return new()
                    {
                        Success = true,
                        Message = "Usuario apagado"
                    };
                }
                else
                {
                    return new()
                    {
                        Success = false,
                        Message = "ID inexistente"
                    };
                }
            }
            catch (Exception ex)
            {
                return new()
                {
                    Success = false,
                    Message = ex.Message
                };
            }

        }
    }
}
