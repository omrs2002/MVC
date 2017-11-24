using AutoMapper;
using MVCCourse2017.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVCCourse2017.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        { _context = new ApplicationDbContext(); }

        [HttpGet]
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers.Include(c => c.MembershipType).ToList()
                .Select
                (
                    Mapper.Map<Customer,CustomerDto>
                );
        }

        [HttpGet]
        public CustomerDto GetCustomer(int Id)
        {
            var cust = _context.Customers.Single(m => m.Id == Id);
            if (cust == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Mapper.Map<Customer,CustomerDto>(cust);
        }

        [HttpPost]
        //public CustomerDto CreateCustomer(CustomerDto custDto)
        public HttpResponseMessage CreateCustomer(CustomerDto custDto)
        {

            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.NotAcceptable);
            var cust = Mapper.Map<CustomerDto, Customer>(custDto);
            var xs = _context.Customers.Add
                (
                    cust
                );
            _context.SaveChanges();
            xs.Id = cust.Id;
            //return Mapper.Map<Customer, CustomerDto>(xs);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPut]
        public HttpResponseMessage UpdateCustomer(int cID, CustomerDto cust)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            if (!ModelState.IsValid)
            {
                //throw new HttpResponseException(HttpStatusCode.NotAcceptable);
                response = Request.CreateResponse(HttpStatusCode.NotAcceptable, "Customer Not Valid!");
                return response;
            }


            var xcustInDB = _context.Customers.Single(c => c.Id == cID);
            if (xcustInDB == null)
            {
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                response = Request.CreateResponse(HttpStatusCode.OK, "Customer Not Valid!");
            }
            Mapper.Map(xcustInDB, cust);

            _context.SaveChanges();
            return response;

        }

        [HttpDelete]
        public HttpResponseMessage DeleteCustomer(int cID)
        {
            var xcust = _context.Customers.Single(c => c.Id == cID);
            if (xcust == null)
            {
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                //return NotFound();
                //return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            _context.Customers.Remove(xcust);
            _context.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK);
        }


        [HttpPost]
        public HttpResponseMessage Delete(int cID)
        {
            var xcust = _context.Customers.Single(c => c.Id == cID);
            if (xcust == null)
            {
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                //return NotFound();
                //return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            _context.Customers.Remove(xcust);
            _context.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK);
        }




    }
}
