﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace InMemory.Caching.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        readonly IMemoryCache _memoryCache;

        public ValuesController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        //[HttpGet("set/{name}")]
        //public void SetName(string name)
        //{
        //    _memoryCache.Set("name", name);
        //}

        //[HttpGet]
        //public string GetName()
        //{
        //    if (_memoryCache.TryGetValue<string>(("name"),out string name))
        //    {
        //        return name.Substring(3, 1);
        //    }
        //    return "";
        //}

        [HttpGet("setDate")]
        public void SetDate()
        {
            _memoryCache.Set<DateTime>("date", DateTime.Now, options: new()
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(30),
                SlidingExpiration = TimeSpan.FromSeconds(5),
            });
        }

        [HttpGet("getDate")]
        public DateTime GetDate()
        {
            return _memoryCache.Get<DateTime>("date");
        }

    }
}