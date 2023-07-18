using LeetCodeWeb.IServices;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeWeb.Services
{
    public class LeetCodeServices : ILeetCodeServices
    {
        private readonly ILogger<LeetCodeServices> _logger;

        public LeetCodeServices(ILogger<LeetCodeServices> logger)
        {
            _logger = logger;
            //test
        }

        public int EasyAdd(int num1, int num2)
        {
            return num1 + num2;
        }

        public string DecodeString(string s)
        {
            string res = "";
            char[] charS = s.ToCharArray();
            int n = charS.Length;
            int multi = 0;
            Stack<int> stack_multi = new Stack<int>();
            Stack<string> stack_res = new Stack<string>();

            for (int i = 0; i < n; i++)
            {
                if (charS[i] >= '0' && charS[i] <= '9')
                {
                    multi = multi * 10 + (int)(charS[i] - '0');
                }
                else if (charS[i] == '[')
                {
                    stack_multi.Push(multi);
                    stack_res.Push(res.ToString());
                    multi = 0;
                    res = "";
                }
                else if (charS[i] == ']')
                {
                    string tmp = "";
                    int cur_multi = stack_multi.Pop();
                    for (int j = 0; j < cur_multi; j++)
                        tmp = String.Concat(tmp, res);
                    res = String.Concat(stack_res.Pop() + tmp);
                }
                else
                    res = String.Concat(res, charS[i]);
            }
            return res.ToString();
        }
    }
}
