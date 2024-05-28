using ProjectManagement.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Shared.Repos.Contacts
{
    public interface IBaseRepository<TModel>
        where TModel : BaseModel
    {
        Task<IEnumerable<TModel>> GetAllAsync();
        Task<TModel> GetByIdIfExistsAsync(int id);
        Task CreateAsync(TModel model);
        Task UpdateAsync(TModel model);
        Task SaveAsync(TModel model);
        Task DeleteAsync(int id);
        Task<bool> ExistsByIdAsync(int id);
        Task<IEnumerable<TModel>> GetWithPaginatioAsync(int pageSize, int pageNumber);
    }
}
