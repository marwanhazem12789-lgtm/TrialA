using Microsoft.EntityFrameworkCore;
using TrialA.Models;

namespace TrialA.GenaricRepos
{
    public class GenaricRepo<T> : IGenaricRepo<T> where T : class
    {
        private readonly Context _context;
        public GenaricRepo(Context context)
        {
            _context = context;
        }

        public async Task Add(T item)
        {
            await _context.Set<T>().AddAsync(item);
        }

        public void Delete(T item)
        {
            _context.Set<T>().Remove(item);
        }

        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync(); 

        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public void Update(T item)
        {
            _context.Set<T>().Update(item);

        }
    }
}
