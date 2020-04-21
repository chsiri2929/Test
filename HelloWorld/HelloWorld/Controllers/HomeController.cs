using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HelloWorld.Models;
using System.Text;

namespace HelloWorld.Controllers
{
    public class HomeController : Controller
    {
        private IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {

            this._employeeRepository = employeeRepository;
        }

        //public JsonResult Index()
        //{

        //    return Json(_employeeRepository.GetEmployees());
        //}

        public StringBuilder Index()
        {
            string str = "This is Sireesha";
            string[] strSplit = str.Split(" ");
            StringBuilder strBuilder = new StringBuilder();

            foreach(var a in strSplit)
            {
                char[] charStr = a.ToCharArray();
                //char[] charTempStr = new char[charStr.Length];
                string str23= string.Empty;
                for (int i = charStr.Length-1; i >= 0; i--)
                {
                    //charTempStr[charStr.Length - (i + 1)] = charStr[i];
                    str23 = str23 + charStr[i];
                }
                strBuilder.Append(" " + str23);

            }

            //return Json(_employeeRepository.GetEmployee(1));
            return strBuilder;
        }
    }
}
