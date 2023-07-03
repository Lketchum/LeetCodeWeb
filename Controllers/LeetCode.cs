using LeetCodeWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class LeetCode : ControllerBase
    {
        private readonly LeetCodeServices _leetCodeServices;

        public LeetCode(LeetCodeServices leetcodeServices)
        {
            _leetCodeServices = leetcodeServices;
        }

        [HttpPost("EasyAdd")]
        public int EasyAdd(int num1, int num2)
        {
            var result = _leetCodeServices.EasyAdd(num1, num2);
            return result;
        }

        [HttpPost("DecodeString")]
        public string DecodeString(string s)
        {
            string result = _leetCodeServices.DecodeString(s);
            return result;
        }

    }
}

