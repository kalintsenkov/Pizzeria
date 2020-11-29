namespace Pizzeria.Server.Infrastructure.Services.Common
{
    using System.Linq;
    using AutoMapper;
    using Data;
    using Microsoft.EntityFrameworkCore;

    public abstract class BaseService<TEntity>
        where TEntity : class
    {
        protected BaseService(PizzeriaDbContext data, IMapper mapper)
        {
            this.Data = data;
            this.Mapper = mapper;
        }

        protected PizzeriaDbContext Data { get; }

        protected IMapper Mapper { get; }

        protected IQueryable<TEntity> All() => this.Data.Set<TEntity>();

        protected IQueryable<TEntity> AllAsNoTracking() => this.All().AsNoTracking();
    }
}
