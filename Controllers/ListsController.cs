
using AciesManagmentProject.help;
using AciesManagmentProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AciesManagmentProject.Controllers
{
    [Route("api/[controller]"), Authorize]
    [ApiController]
    public class ListsController : ControllerBase
    {
        private readonly AciesContext context;
        public ListsController(AciesContext context)
        {
            this.context = context;       
        }
        [HttpGet]
        [Route("Select/All/Company/SIC")]
        public IActionResult SelectAllCompanySIC()
        {
            try
            {
                using (context)
                {
                    var companySICList = context.CopmanySictbs.Select
                        (e => new { Id=e.CopmanySicid, Description=e.CopmanySicdescription }).ToList();
                    return Ok(companySICList);
                }
            }
            catch(Exception)
            {
                return BadRequest("This Process Failed");
            }
        }

        [HttpGet]
        [Route("Select/All/Company/SICTb")]
        public IActionResult SelectAllCompanySICTb()
        {
            try
            {
                using (context)
                {
                    var companySICList = context.CopmanySictbs.Select
                        (e => new { e.CopmanySicid, e.CopmanySicdescription }).ToList();
                    return Ok(companySICList);
                }
            }
            catch (Exception)
            {
                return BadRequest("This Process Failed");
            }
        }

        [HttpGet]
        [Route("GetIndustries")]
        public IActionResult GetIndustries(int id)
        {
            try
            {
                using (context)
                {
                    var companySICList = context.Industries.
                        Where(e=>e.CompanySic==id).
                        Select
                        (e => new { e.Code, e.Description }).ToList();
                    return Ok(companySICList);
                }
            }
            catch (Exception)
            {
                return BadRequest("This Process Failed");
            }
        }



        [HttpGet]
        [Route("Select/All/FinancialMS")]
        public IActionResult SelectAllFinancialMS()
        {
            try
            {
                using (context)
                {
                    var companySICList = context.FinancialMangmentSystemTbs.Select
                        (e => new { e.FinancialMangmentSystemId, e.FinancialMangmentSystemName, e.FinancialMangmentSystemDescription}).ToList();
                    return Ok(companySICList);
                }
            }
            catch (Exception)
            {
                return BadRequest("This Process Failed");
            }
        }

        [HttpGet]
        [Route("Select/All/ReportingFrequency")]
        public IActionResult SelectAllReportingFrequency()
        {
            try
            {
                using (context)
                {
                    var companySICList = context.ReportingFrequencyTbs.Select
                        (e => new { e.ReportingFrequencyId, e.ReportingFrequencyName, e.ReportingFrequencyDescription }).ToList();
                    return Ok(companySICList);
                }
            }
            catch (Exception)
            {
                return BadRequest("This Process Failed");
            }
        }

        [HttpGet]
        [Route("Select/All/Library")]
        public IActionResult SelectAllLibrary(int engamentId)
        {
            try
            {
                using (context)
                {
                    var companySICList = context.EngagmentTbs.
                        Where(e=>e.EngagmentId==engamentId ).
                        Select(e => new
                        {
                            e.CopmanySicid,
                            e.ReportingFrequencyId,
                            e.FinancialMangmentSystemId,
                            e.FiscalStartDay,
                            e.FiscalStartMonth}).FirstOrDefault();
                    return Ok(companySICList);
                }
            }
            catch (Exception)
            {
                return BadRequest("This Process Failed");
            }
        }

    }
}
