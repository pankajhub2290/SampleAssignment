using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SampleAssignment.Shared.Models;
using SampleAssignment.WebApp.Models;
using SampleAssignment.WebApp.Services;

namespace SampleAssignment.WebApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;
        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _customerService.GetCustomers();
            var customers = _mapper.Map<List<CustomerListViewModel>>(result);
            return View(customers);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerViewModel customer)
        {
            if (ModelState.IsValid)
            {
                var requestModel = _mapper.Map<CustomerRequestModel>(customer);
                await _customerService.CreateCustomer(requestModel);
                TempData["ResultOk"] = "Record Added Successfully !";
                return RedirectToAction("Index");
            }

            return View(customer);
        }
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var customer = await _customerService.GetCustomerById(id);

            if (customer == null)
            {
                return NotFound();
            }
            var customerModel = _mapper.Map<CustomerViewModel>(customer);
            return View(customerModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CustomerViewModel customer)
        {
            if (ModelState.IsValid)
            {
                var requestModel = _mapper.Map<CustomerRequestModel>(customer);
                await _customerService.UpdateCustomer(customer.Id, requestModel);
                TempData["ResultOk"] = "Data Updated Successfully !";
                return RedirectToAction("Index");
            }

            return View(customer);
        }
        //[HttpDelete]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var isDeleted = await _customerService.DeleteCustomer(id);

        //    if (isDeleted)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return NotFound();
        //}

        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var customer = await _customerService.GetCustomerById(id);

            if (customer == null)
            {
                return NotFound();
            }
            var customerModel = _mapper.Map<CustomerViewModel>(customer);
            return View(customerModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            await _customerService.DeleteCustomer(id);
            TempData["ResultOk"] = "Data Deleted Successfully !";
            return RedirectToAction("Index");
        }
    }
}
