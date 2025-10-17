using GymMangementDAL.Contexts;
using GymMangementDAL.Entities;
using GymMangementDAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementDAL.Repositories.Classes
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GymDbContext _context;
        private readonly Dictionary<string, object> _repositories = [];

        public UnitOfWork(GymDbContext context)
        {
            _context = context;
        }
        public IGenericRepository<TEnity> GetRepository<TEnity>() where TEnity : BaseEntity
        {
            string typeName = typeof(TEnity).Name;
            if(_repositories.TryGetValue(typeName, out object? repository))
            {
                return (IGenericRepository<TEnity>)repository;
            }
            var newRepository = new GenericRepository<TEnity>(_context);
            _repositories.Add(typeName, newRepository);
            return newRepository;

        }

        public int SaveChanges() => _context.SaveChanges();
        
    }
}
