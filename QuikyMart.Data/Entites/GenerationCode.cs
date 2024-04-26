using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace QuikyMart.Data.Entites
{
    public enum InOrOutType
    {
        In = 1,
        Out = 2,
        Ret = 3
    }
    public class Code
    {
        public string Year { get; set; }
        public string Month { get; set; }
        public string Day { get; set; }
        public string ST { get; set; } = "01";
        public InOrOutType InOrOut { get; set; }
        public int Num { get; set; }
    }
    public class GenerationCode
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        //private readonly YourDbContext _dbContext;

        public GenerationCode(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;

        }

        public string Create()
        {
            var code = GetOrCreateCode();
            string datePart = $"{code.Year}{code.Month}{code.Day}";
            string numPart = $"{code.Num:D3}";

            code.Num++;

            return $"{datePart}{code.ST}{(int)code.InOrOut}{numPart}";
        }

        private Code GetOrCreateCode()
        {
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext.Session.TryGetValue("Code", out byte[] codeBytes))
            {
                return JsonSerializer.Deserialize<Code>(codeBytes);
            }
            else
            {
                var newCode = new Code
                {
                    Year = DateTime.Today.ToString("yyyy"),
                    Month = DateTime.Today.ToString("MM"),
                    Day = DateTime.Today.ToString("dd")
                };

                httpContext.Session.Set("Code", JsonSerializer.SerializeToUtf8Bytes(newCode));
                return newCode;
            }
        }
    }
    public class GenerationCodeMethod
    {

    }
}
