using MultiShop.DAL;
using MultiShop.Models;
using MultiShop.Repositories.Implementations.Generic;
using MultiShop.Repositories.Interfaces;

namespace MultiShop.Repositories.Implementations;

public class SliderRepository : Repository<Slider>,ISliderRepository
{
    public SliderRepository(AppDbContext context):base(context)
    {
        
    }
}
