using AutoMapper;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using MultiShop.Models;
using MultiShop.Repositories.Interfaces;
using MultiShop.Services.Interfaces;
using MultiShop.Utilities;
using MultiShop.ViewModels;

namespace MultiShop.Services.Implementations
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _repository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ServiceService(IServiceRepository repository, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _repository = repository;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<bool> CreateAsync(ServicePostVM servicePostVM, ModelStateDictionary ModelState)
        {
            if (!ModelState.IsValid)
            {
                return false;
            }
            var service = _mapper.Map<Service>(servicePostVM);
            await _repository.CreateAsync(service);
            await _repository.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int serviceId)
        {

            var service = await _repository.GetSingleAsync(x => x.Id == serviceId);
            if (service is null)
                throw new Exception("Service is not found");

            _repository.HardDelete(service);
            await _repository.SaveAsync();
            return true;
        }

        public async Task<List<ServiceGetVM>> GetAllServicesAsync()
        {
            var services = await _repository.GetAll().ToListAsync();
            var vms = _mapper.Map<List<ServiceGetVM>>(services);
            return vms;
        }

        public async Task<ServicePutVM> GetPutServiceAsync(int serviceId)
        {

            var serviceVM = await GetServiceAsync(serviceId);
            var vm = _mapper.Map<ServicePutVM>(serviceVM);
            return vm;
        }

        public async Task<ServiceGetVM> GetServiceAsync(int serviceId)
        {
            var service = await _repository.GetSingleAsync(x => x.Id == serviceId);
            if (service is null)
                throw new Exception("Service not found");
            var vm = _mapper.Map<ServiceGetVM>(service);
            return vm;
        }

        public async Task<bool> UpdateAsync(ServicePutVM servicePutVM, ModelStateDictionary ModelState)
        {
            if (!ModelState.IsValid)
            {
                return false;
            }
            var existedService = await _repository.GetSingleAsync(x => x.Id == servicePutVM.Id);
            if (existedService is null)
                throw new Exception("Service not found");
            existedService = _mapper.Map(servicePutVM, existedService);


            _repository.Update(existedService);
            await _repository.SaveAsync();
            return true;
        }
    }
}
