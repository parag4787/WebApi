using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiDemo.Models;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public DepartmentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            MongoClient mongoClient = new MongoClient(_configuration.GetConnectionString("EmployeeAppCon"));

            var dbList = mongoClient.GetDatabase("Test").GetCollection<DepartmentModel>("Department").AsQueryable();

            return new JsonResult(dbList);
        }

        [HttpPost]
        public JsonResult Post(DepartmentModel departmentModel)
        {
            MongoClient mongoClient = new MongoClient(_configuration.GetConnectionString("EmployeeAppCon"));

            int lastid = mongoClient.GetDatabase("Test").GetCollection<DepartmentModel>("Department").AsQueryable().Count();

            departmentModel.DepartmentID = lastid + 1;
            mongoClient.GetDatabase("Test").GetCollection<DepartmentModel>("Department").InsertOne(departmentModel);

            return new JsonResult("Added successfully");
        }
    }
}
