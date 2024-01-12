using MultiShop.DAL;
using MultiShop.Models;
using MultiShop.Repositories.Implementations.Generic;
using MultiShop.Repositories.Interfaces;

namespace MultiShop.Repositories.Implementations;

public class ServiceRepository:Repository<Service>,IServiceRepository 
{
    public ServiceRepository(AppDbContext context):base(context)
    {
        
    }
}
