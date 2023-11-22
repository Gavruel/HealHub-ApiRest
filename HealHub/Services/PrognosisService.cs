using HealHub.CrossCutting.Helpers;
using HealHub.Domain.Entities;
using HealHub.Domain.Interfaces;
using HealHub.Infra;

namespace HealHub.Services
{
    public class PrognosisService : IPrognosisService
    {
        private readonly OracleDbContext _context;

        public PrognosisService(OracleDbContext context)
        {
            _context = context;
        }

        public Result<Prognosis> createPrognosis(int formId)
        {
            try
            {
                var optional = _context.Forms.Find(formId);

                if (optional == null)
                {
                    return new()
                    {
                        Success = false,
                        Message = "Formulario não encontrado"
                    };

                }

                var userOptional = _context.Users.Find(optional.userId);

                if (userOptional == null)
                {
                    return new()
                    {
                        Success = false,
                        Message = "Usuario do formulario não encontrado"
                    };

                }

                Prognosis prognosis = new();

                prognosis.formId = formId;
                prognosis.description = $"Caro Senhor(a) {userOptional.name}, segue o diagnostico de uma pessoa com {optional.age} anos, {optional.height}m de altura e {optional.weight}KG de peso, de acordo com os seguintes sintomas:{optional.symptoms}. Você deverá descansar X quantidade de dias";

                _context.Prognosis.Add(prognosis);
                _context.SaveChanges();

                return new()
                {
                    Success = true,
                    Data = prognosis,
                    Message = "Prognostico criado"
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

        public Result<bool> deletePrognosis(int id)
        {
            try
            {
                var optional = _context.Prognosis.Find(id);

                if (optional != null)
                {

                    _context.Prognosis.Remove(optional);

                    _context.SaveChanges();

                    return new()
                    {
                        Success = true,
                        Message = "Prognosico apagado"
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

        public Result<Prognosis> getPrognosis(int id)
        {
            try
            {
                var optional = _context.Prognosis.Find(id);

                if (optional == null)
                {
                    return new()
                    {
                        Success = false,
                        Message = "Prognostico não encontrado"
                    };
                }

                return new()
                {
                    Success = true,
                    Data = optional,
                    Message = "Dados encontrados"
                };
            }
            catch(Exception e)
            {
                return new()
                {
                    Success = false,
                    Message = e.Message
                };
            }
        }
    }
}
