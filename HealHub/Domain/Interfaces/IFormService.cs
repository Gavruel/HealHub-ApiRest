using HealHub.CrossCutting.Helpers;
using HealHub.Domain.Entities;

namespace HealHub.Domain.Interfaces
{
    public interface IFormService
    {
        Result<List<Form>> getAllForms();

        Result<Form> createForm(Form form);

        Result<Form> updateForm(int id, Form form);

        Result<bool> deleteForm(int id);
    }
}
