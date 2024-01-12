using Microsoft.AspNetCore.Mvc.ModelBinding;
using MultiShop.ViewModels;

namespace MultiShop.Services.Interfaces;

public interface IServiceService
{
    Task<List<ServiceGetVM>> GetAllServicesAsync();
    Task<ServiceGetVM> GetServiceAsync(int serviceId);
    Task<ServicePutVM> GetPutServiceAsync(int serviceId);

    Task<bool> CreateAsync(ServicePostVM servicePostVM, ModelStateDictionary ModelState);
    Task<bool> UpdateAsync(ServicePutVM servicePutVM, ModelStateDictionary ModelState);
    Task<bool> DeleteAsync(int serviceId);
}
