﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MrKool.Data;
using MrKool.DTO;
using MrKool.Interface;
using MrKool.Models;
using MrKool.Repository;
using MrKoolApplication.DTO;
using MrKoolApplication.Interface;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MrKool.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("Customers")]
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetCustomers()
        {
            var customers = await _customerRepository.GetAllCustomersAsync();
            var customerDTOs = _mapper.Map<IEnumerable<CustomerDTO>>(customers);
            return Ok(customerDTOs);
        }

        [HttpGet]
        [Route("/Customer/{customid}")]
        public async Task<ActionResult<CustomerDTO>> GetCustomerByIdAsync(int customid)
        {
            var customer = await _customerRepository.GetById(customid);
            if (customer == null)
            {
                return NotFound();
            }

            var customerDTO = _mapper.Map<CustomerDTO>(customer);
            return Ok(customerDTO);
        }

        [HttpGet("Customer/{email}")]
        public IActionResult GetCustomerByEmail(string email)
        {
            var customer = _customerRepository.GetCustomerByEmail(email);
            if (customer == null)
            {
                return NotFound();
            }

            var customerDto = _mapper.Map<CustomerDTO>(customer);
            return Ok(customerDto);
        }

        [HttpGet]
        [Route("search/{keyword}")]
        public ActionResult<IEnumerable<CustomerDTO>> SearchCustomers(string keyword)
        {
            var customers = _customerRepository.GetByNameContaining(keyword);
            var customerDTOs = _mapper.Map<IEnumerable<CustomerDTO>>(customers);
            return Ok(customerDTOs);
        }


        [HttpPost]
        [Route("CreateCustomer")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCustomer([FromBody] CustomerDTO customerCreate)
        {
            if (customerCreate == null) return BadRequest();

            var customer = _customerRepository.GetCustomers().FirstOrDefault(c => c.Email == customerCreate.Email);
            if (customer != null)
            {
                return BadRequest("Customer with the same email already exists.");
            }

            var customerMap = _mapper.Map<Customer>(customerCreate);
            if (!_customerRepository.CreateCustomer(customerMap))
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return Ok("Successfully created the Customer.");
        }

        [HttpPut]
        [Route("UpdateCustomer/{customerID}")]
        public IActionResult UpdateCustomer(int customerID, [FromBody] CustomerDTO customerUpdate)
        {
            if (customerUpdate == null) return BadRequest();
            if (!_customerRepository.CustomerExist(customerID)) return BadRequest();

            var customerMap = _mapper.Map<Customer>(customerUpdate);
            if (!_customerRepository.UpdateCustomer(customerMap))
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return NoContent();
        }

        [HttpPut]
        [Route("UpdateCustomerArea/{customerID}")]
        public async Task<IActionResult> UpdateCustomerArea(int customerID, int areaID)
        {
            if (areaID == null) return BadRequest();
            if (!_customerRepository.CustomerExist(customerID)) return BadRequest();

           var customer = await _customerRepository.GetById(customerID);
            customer.AreaID = areaID;
            
            _customerRepository.UpdateCustomer(customer);
            return NoContent();
        }

        [HttpDelete]
        [Route("DeleteCustomer/{id}")]
        public async Task<IActionResult> DeleteCustomerAsync(int id)
        {
            var customer = await _customerRepository.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }

            customer.IsDeleted = false;
            return NoContent();
        }
    }
}
