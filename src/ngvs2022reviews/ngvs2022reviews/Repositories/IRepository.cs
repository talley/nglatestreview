
namespace ngvs2022reviews.Repositories
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        Task<List<T>> GetAllAsync();
        int SaveOrUpdate(T model);
        Task<int> SaveOrUpdateAsync(T model);

        int Delete(T model);
        Task<int> DeleteAsync(T model);
    }
}
