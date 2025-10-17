﻿using GymMangementDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementDAL.Repositories.Interfaces
{
    public interface ISessionRepository 
    {
        Session GetByID(int id);
        IEnumerable<Session> GetAll();
        int Add(Session session);
        int Update(Session session);
        int Delete(int id);
    }
}
