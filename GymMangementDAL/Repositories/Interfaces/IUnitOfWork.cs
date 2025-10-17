﻿using GymMangementDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementDAL.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<TEnity> GetRepository<TEnity>() where TEnity : BaseEntity;
        int SaveChanges();
    }
}
