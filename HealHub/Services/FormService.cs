using HealHub.CrossCutting.Helpers;
using HealHub.Domain.Entities;
using HealHub.Domain.Interfaces;
using HealHub.Infra;

namespace HealHub.Services
{
    public class FormService : IFormService
    {

        private readonly OracleDbContext _context;

        public FormService(OracleDbContext context)
        {
            _context = context;
        }

        public Result<Form> createForm(Form form)
        {
            try
            {
                var optional = _context.Users.Find(form.userId);

                if (optional == null)
                {
                    return new()
                    {
                        Success = false,
                        Message =  "Usuario não existe"
                    };
                }

                _context.Forms.Add(form);
                _context.SaveChanges();

                return new()
                {
                    Success = true,
                    Data = form,
                    Message = "Formulario cadastrado com Sucesso"
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

        public Result<bool> deleteForm(int id)
        {
            try
            {
                var optional = _context.Forms.Find(id);

                if (optional != null)
                {

                    _context.Forms.Remove(optional);

                    _context.SaveChanges();

                    return new()
                    {
                        Success = true,
                        Message = "Formulario apagado"
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

        public Result<List<Form>> getAllForms()
        {
            try
            {
                return new()
                {
                    Success = true,
                    Data = _context.Forms.ToList(),
                    Message = "Dados encontrados"
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

        public Result<Form> updateForm(int id, Form form)
        {
            try
            {
                var optional = _context.Forms.Find(id);

                if (optional != null)
                {
                    
                    optional.userId = form.userId;

                    var optionalUser = _context.Users.Find(form.userId);
                     
                    if (optionalUser == null)
                    {
                        return new()
                        {
                            Success = false,
                            Message = "Usuario não existe"
                        };
                    }
                    optional.weight = form.weight;
                    optional.height = form.height;
                    optional.age = form.age;
                    optional.symptoms = form.symptoms;
                    optional.diseaseHistory = form.diseaseHistory;
                    optional.duration = form.duration;

                    _context.SaveChanges();

                    return new()
                    {
                        Success = true,
                        Data = optional,
                        Message = "Formulario atualizado"
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
