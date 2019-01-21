﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SystemetAPI.Models;

namespace SystemetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemetController : ControllerBase
    {
        [HttpGet]
        public List<SysSortTable> GetThemAll()
        {
            return SystemetService.GetAllProd();
        }
    }
} 