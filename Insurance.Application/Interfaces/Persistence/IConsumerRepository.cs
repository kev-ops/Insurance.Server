using Insurance.Domain.Entities;
using Insurance.Domain.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Application.Interfaces.Persistence
{
    public interface IConsumerRepository : IRepository<Consumer>
    {
    }
}
