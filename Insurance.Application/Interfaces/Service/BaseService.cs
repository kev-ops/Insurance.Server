using Insurance.Application.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Application.Interfaces.Service
{
    public class BaseService<T> : IBaseService<T> where T: class
    {
        protected IRepository<T> _db;

        public BaseService(IRepository<T> repo)
        {
            _db = repo;
        }
    }
}
