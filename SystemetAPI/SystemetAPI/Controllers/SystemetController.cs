using System;
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
        private readonly VRContext context;

        public SystemetController(VRContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public List<SysSortTable> GetThemAll()
        {
            return context.SysSortTable.ToList();
        }

        [HttpGet("producers")]
        public string[] GetTheProducers()
        {
            return context.SysSortTable.Select(s => s.Producent).Distinct().ToArray();
        }

        [HttpGet("producers/{name}")]
        public string[] GetBeersFromProdcuer(string name)
        {
            string[] beers = context.SysSortTable.Where(w => w.Producent == name).Select(s => s.ArtikelId + ", " + s.Namn + ", " + s.Namn2).ToArray();
            return beers;
        }

        [HttpGet("beer/{id}")]
        public ActionResult<SysSortTable> GetItem(int id)
        {
            return context.SysSortTable.First(f => f.ArtikelId == id);
        }
    }
} 