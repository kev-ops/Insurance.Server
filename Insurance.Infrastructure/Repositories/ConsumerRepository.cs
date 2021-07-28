using Insurance.Application;
using Insurance.Application.Interfaces.Persistence;
using Insurance.Domain.Entities;
using Insurance.Domain.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Infrastructure.Repositories
{
    public class ConsumerRepository : Repository<Consumer>, IConsumerRepository
    {
 
        public ConsumerRepository(DbContext context) : base(context)
        {
            
        }
      
    }
}
