using ProjectManagement.Shared.Dtos;
using ProjectManagement.Shared.Repos.Contacts;
using ProjectManagement.Shared.Services.Contracts;

namespace ProjectManagement.Services
{
    public abstract class BaseCrudService<TModel, TRepository> : IBaseCrudService<TModel, TRepository>
         where TModel : BaseModel
         where TRepository : IBaseRepository<TModel>
    {
        protected readonly TRepository _repository;
        protected BaseCrudService(TRepository repository)
        {
            this._repository = repository;
        }
        public virtual async Task SaveAsync(TModel model)
        {
            if (Equals(model, null))
            {
                throw new ArgumentNullException(nameof(model));
            }

            await this._repository.SaveAsync(model);
        }

        public virtual Task<IEnumerable<TModel>> GetAllAsync()
            => this._repository.GetAllAsync();

        public virtual Task DeleteAsync(int id)
        => this._repository.DeleteAsync(id);

        public virtual Task<TModel> GetByIdIfExistsAsync(int id)
            => this._repository.GetByIdAsync(id);



        public virtual Task<IEnumerable<TModel>> GetWithPaginationAsync(int pageSize, int pageNumber)
            => this._repository.GetWithPaginationAsync(pageSize, pageNumber);

        public Task<bool> ExistsByIdAsync(int id)
            => this._repository.ExistsByIdAsync(id);
    }
}
