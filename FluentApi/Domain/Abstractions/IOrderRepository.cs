using FluentApi.Domain.Abstractions;
using FluentApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentApi.Domain.Abstractions
{
    public interface IOrderRepository :IOrderRepository<Order>
    {
    }
}
