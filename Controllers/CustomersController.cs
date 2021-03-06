﻿using MVCCourse2017.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCourse2017.ViewModels;
using AutoMapper;

namespace MVCCourse2017.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: Customers
        public ActionResult Index()
        {
            var xcust = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(xcust);
        }
  
        // GET: Customers
        public ActionResult CustomersGrid()
        {
            var xcust = _context.Customers.Include(c => c.MembershipType).ToList(); 
            return View(xcust);
        }
        public ViewResult Index2()
        {return View();}



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(NewCustomerVM viewModel)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    var viewM = new NewCustomerVM
                    {
                        Customer = viewModel.Customer,
                        MembershipTypes = _context.MembershipTypes.ToList()
                    };
                    return View("Create",viewM);
                }

                if(viewModel.Customer.Id < 1)
                    _context.Customers.Add(viewModel.Customer);
                else
                {
                    var xcust = _context.Customers.Include(c => c.MembershipType).Single(c => c.Id == viewModel.Customer.Id);
                    xcust.IsSubscribedToNewsletter = viewModel.Customer.IsSubscribedToNewsletter;
                    xcust.MembershipTypeId = viewModel.Customer.MembershipTypeId;
                    xcust.Name= viewModel.Customer.Name;
                    xcust.Birthdate = viewModel.Customer.Birthdate;
                }
                _context.SaveChanges();
                return RedirectToAction("Index", "Customers");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                throw ex;
                //return RedirectToAction("Index", "Customers");
            }
            
        }


        // GET: Customers
        public ActionResult Create()
        {
            NewCustomerVM vm = new NewCustomerVM
            {
                Customer = new Customer(),
                MembershipTypes = _context.MembershipTypes
            };
            return View(vm);
        }

        // GET: Customers
        public ActionResult Details(int id)
        {
            var xcust = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            //var xustDto =  Mapper.Map<Customer, CustomerDto>(xcust);
            //return View(xustDto);
            return View(xcust);

        }


        // GET: Customers
        public ActionResult Delete(int id)
        {
            var xcust = _context.Customers.Single(c => c.Id == id);
            if (xcust == null)
                throw new Exception("Customer Not Found" );
            _context.Customers.Remove(xcust);
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }


        // GET: Customers
        public ActionResult Edit(int id)
        {
            var xcust = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            NewCustomerVM vm = new NewCustomerVM
            {
                MembershipTypes = _context.MembershipTypes,
                Customer = xcust
            };
            return View("Create", vm);
        }
    }
}