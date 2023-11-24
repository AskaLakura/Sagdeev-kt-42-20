using Microsoft.EntityFrameworkCore;
using Sagdeev_kt4220.Database;
using Sagdeev_kt4220.Models;
using Sagdeev_kt4220.Filters;
using Microsoft.AspNetCore.Mvc;


namespace Sagdeev_kt4220.Interfaces
{
    public interface IPrepodService
    {
        public Task<Prepod[]> GetPrepodsByKafedraAsync(PrepodKafedraFilter filter, CancellationToken cancellationToken);
        public Task<Prepod[]> GetPrepodsByNameAsync(PrepodNameFilter filter, CancellationToken cancellationToken);
    }
    public class PrepodService : IPrepodService
    {
        private readonly PrepodDbcontext _dbContext;
        public PrepodService(PrepodDbcontext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Prepod[]> GetPrepodsByKafedraAsync(PrepodKafedraFilter filter, CancellationToken cancellationToken = default)
        {
            var prepod = _dbContext.Set<Prepod>().Where(w => w.Kafedra.KafedraName == filter.KafedraName).ToArrayAsync(cancellationToken);

            return prepod;
        }

        public Task<Prepod[]> GetPrepodsByNameAsync(PrepodNameFilter filter, CancellationToken cancellationToken = default)
        {
            var prepod = _dbContext.Set<Prepod>().Where(w => w.LastName == filter.LastName).ToArrayAsync(cancellationToken);

            return prepod;
        }

        public Task<Prepod[]> GetPrepodsByStepenAsync(PrepodStepenFilter filter, CancellationToken cancellationToken = default)
        {
            var prepod = _dbContext.Set<Prepod>().Where(w => w.Stepen.StepenName == filter.StepenName).ToArrayAsync(cancellationToken);

            return prepod;
        }
    }

}