﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Management_App.Repositories
{
    public interface IRepository<T>
    {
        void Add(T item);
        void Update(T item);
        void Delete(int id);
        T? Get(int id);
        List<T> GetAll();
    }
}
