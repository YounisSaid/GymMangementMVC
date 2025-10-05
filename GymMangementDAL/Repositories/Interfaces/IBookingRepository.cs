﻿using GymMangementDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementDAL.Repositories.Interfaces
{
    public interface IBookingRepository
    {
        Booking GetByID(int id);
        IEnumerable<Booking> GetAll();
        int Add(Booking booking);
        int Update(Booking booking);
        int Delete(int id);
    }
}
