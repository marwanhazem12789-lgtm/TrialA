namespace TrialA.GenaricRepos
{
    public interface IGenaricRepo<T> where T : class


    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task Add(T item);   
        void Delete(T item);
        void Update(T item);

    }
}
