using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumbersController : ControllerBase
    {
        List<int> numbersList = new List<int>() { 1, 2, 3, 15, 19, 7, 8 ,13, 16 ,10 };

        // GET api/numbers
        [HttpGet]
        public ActionResult<IEnumerable<int>> GetNumbers()
        {
            return numbersList;
        }

        [HttpGet("{arg}")]
        public ActionResult<bool> IsExist(int arg)
        {
            return (numbersList.Contains(arg));
        }
    }
}