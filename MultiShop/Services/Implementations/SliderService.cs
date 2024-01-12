using AutoMapper;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using MultiShop.Models;
using MultiShop.Repositories.Interfaces;
using MultiShop.Services.Interfaces;
using MultiShop.Utilities;
using MultiShop.ViewModels;

namespace MultiShop.Services.Implementations;

public class SliderService : ISliderService
{
    private readonly ISliderRepository _repository;
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IMapper _mapper;


    public SliderService(ISliderRepository repository, IMapper mapper, IWebHostEnvironment webHostEnvironment)
    {
        _repository = repository;
        _mapper = mapper;
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task<bool> CreateAsync(SliderPostVM sliderPostVM, ModelStateDictionary ModelState)
    {
        if (!ModelState.IsValid)
        {
            return false;
        }
        if (!sliderPostVM.Image.ValidateType())
        {
            ModelState.AddModelError("Image", "Please enter image");
            return false;
        }
        if (!sliderPostVM.Image.ValidateSize(2))
        {
            ModelState.AddModelError("Image", "Image size max size is");
            return false;

        }
        string fileName = sliderPostVM.Image.GenerateName();
        await sliderPostVM.Image.CreateFormFile(_webHostEnvironment.ContentRootPath, "wwwroot", "img", fileName);
        var slider = _mapper.Map<Slider>(sliderPostVM);
        slider.ImagePath = fileName;
        await _repository.CreateAsync(slider);
        await _repository.SaveAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int sliderId)
    {
        var slider = await _repository.GetSingleAsync(x => x.Id == sliderId);
        if (slider is null)
            throw new Exception("Slider is not found");

        _repository.HardDelete(slider);
        slider.ImagePath.DeleteFormFile(_webHostEnvironment.ContentRootPath, "wwwroot", "img");

        await _repository.SaveAsync();
        return true;
;    }

    public async Task<List<SliderGetVM>> GetAllSlidersAsync()
    {
        var sliders = await _repository.GetAll().ToListAsync();
        var vms = _mapper.Map<List<SliderGetVM>>(sliders);
        return vms;
    }

    public async Task<SliderPutVM> GetPutSliderAsync(int sliderId)
    {
        var sliderVM=await GetSliderAsync(sliderId);
        var vm=_mapper.Map<SliderPutVM>(sliderVM);
        return vm;
    }

    public async Task<SliderGetVM> GetSliderAsync(int sliderId)
    {
        var slider =await _repository.GetSingleAsync(x => x.Id == sliderId);
        if (slider is null)
            throw new Exception("Slider not found");
        var vm = _mapper.Map<SliderGetVM>(slider);
        return vm;
    }

    public async Task<bool> UpdateAsync(SliderPutVM sliderPutVM, ModelStateDictionary ModelState)
    {
        if (!ModelState.IsValid)
        {
            return false;
        }
        var existedSlider = await _repository.GetSingleAsync(x => x.Id == sliderPutVM.Id);
        if (existedSlider is null)
            throw new Exception("Slider not found");
        existedSlider=_mapper.Map(sliderPutVM,existedSlider);

        if(sliderPutVM.Image is not null)
        {
            if (!sliderPutVM.Image.ValidateType())
            {
                ModelState.AddModelError("Image", "Please enter image");
                return false;
            }
            if (!sliderPutVM.Image.ValidateSize(2))
            {
                ModelState.AddModelError("Image", "Image size max size is 2mb");
                return false;

            }
            string fileName = sliderPutVM.Image.GenerateName();
            await sliderPutVM.Image.CreateFormFile(_webHostEnvironment.ContentRootPath, "wwwroot", "img", fileName);
            existedSlider.ImagePath.DeleteFormFile(_webHostEnvironment.ContentRootPath,"wwwroot","img");
            existedSlider.ImagePath = fileName;
        }

        _repository.Update(existedSlider);
        await _repository.SaveAsync();
        return true;
    }
}
