using HealHub.CrossCutting.Helpers;
using HealHub.Domain.Entities;

namespace HealHub.Domain.Interfaces
{
    public interface IPrognosisService
    {
        Result<Prognosis> getPrognosis(int id);

        Result<Prognosis> createPrognosis(int formId);

        Result<bool> deletePrognosis(int id);
    }
}
