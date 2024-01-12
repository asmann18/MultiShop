using Microsoft.AspNetCore.Mvc.ModelBinding;
using MultiShop.ViewModels;

namespace MultiShop.Services.Interfaces;

public interface ISliderService
{
    Task<List<SliderGetVM>> GetAllSlidersAsync();
    Task<SliderGetVM> GetSliderAsync(int sliderId);
    Task<SliderPutVM> GetPutSliderAsync(int sliderId);

    Task<bool> CreateAsync(SliderPostVM sliderPostVM,ModelStateDictionary ModelState);
    Task<bool> UpdateAsync(SliderPutVM sliderPutVM,ModelStateDictionary ModelState);
    Task<bool> DeleteAsync(int sliderId);

    
}
