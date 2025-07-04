using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Management_App.Repositories
{
    public abstract class SqliteRepository
    {
        protected readonly string _connectionString = "Data Source=hotel.db";
    }
}
