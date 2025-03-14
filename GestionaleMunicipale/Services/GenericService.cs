using GestionaleMunicipale.Data;
using GestionaleMunicipale.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionaleMunicipale.Services
{
    public class GenericService<T> where T : class
    {
        protected readonly GestionaleMunicipaleDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericService(GestionaleMunicipaleDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try { return await _dbSet.ToListAsync(); }
            catch (Exception ex) { throw new Exception("Errore nel recupero dei dati.", ex); }
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            try { return await _dbSet.FindAsync(id); }
            catch (Exception ex) { throw new Exception("Errore nel recupero dell'elemento.", ex); }
        }

        public async Task CreateAsync(T entity)
        {
            try { await _dbSet.AddAsync(entity); await _context.SaveChangesAsync(); }
            catch (Exception ex) { throw new Exception("Errore nella creazione dell'elemento.", ex); }
        }

        public async Task UpdateAsync(T entity)
        {
            try { _dbSet.Update(entity); await _context.SaveChangesAsync(); }
            catch (Exception ex) { throw new Exception("Errore nell'aggiornamento dell'elemento.", ex); }
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                var entity = await GetByIdAsync(id);
                if (entity != null)
                {
                    _dbSet.Remove(entity);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex) { throw new Exception("Errore nell'eliminazione dell'elemento.", ex); }
        }
    }
}
