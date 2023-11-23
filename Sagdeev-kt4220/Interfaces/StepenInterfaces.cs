using Microsoft.EntityFrameworkCore;
using Sagdeev_kt4220.Database;
using Sagdeev_kt4220.Models;
using Sagdeev_kt4220.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Sagdeev_kt4220.Interfaces
{
    public interface IStepenService
    {
        public Task<Prepod[]> GetPrepodsByStepenAsync(PrepodStepenFilter filter, CancellationToken cancellationToken);
    }

    public class StepenService : IStepenService
    {
        private readonly PrepodDbcontext _dbContext;
        public StepenService(PrepodDbcontext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Prepod[]> GetPrepodsByStepenAsync(PrepodStepenFilter filter, CancellationToken cancellationToken = default)
        {
            var stepen = _dbContext.Set<Prepod>().Where(w => w.Stepen.StepenName == filter.StepenName).ToArrayAsync(cancellationToken);

            return stepen;
        }
    }
}