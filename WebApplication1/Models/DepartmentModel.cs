using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDemo.Models
{
    public class DepartmentModel
    {

        public ObjectId Id { get; set; } 
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
    }
}
