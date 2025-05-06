using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

public class GenericRepository<T> : IGenericDal<T> where T : class
{
    protected readonly DbContext _context;  // protected olarak değiştirildi
    private readonly DbSet<T> _dbSet;

    public GenericRepository(DbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public void Add(T entity)
    {
        _dbSet.Add(entity);
        _context.SaveChanges();
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
        _context.SaveChanges();
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
        _context.SaveChanges();
    }

    public T GetById(int id)
    {
        return _dbSet.Find(id);
    }

    public List<T> GetAll()
    {
        return _dbSet.ToList();
    }

    public List<T> GetAll(Expression<Func<T, bool>> filter)
    {
        return _dbSet.Where(filter).ToList();
    }

    public T GetByFilter(Expression<Func<T, bool>> filter)
    {
        return _dbSet.FirstOrDefault(filter);
    }
}
