﻿
using AciesManagmentProject.DTO;
using AciesManagmentProject.help;
using AciesManagmentProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly DbA9b860AciesContext context;
        public ListsController(DbA9b860AciesContext context)
        {
            this.context = context;       
        }
        //[HttpGet]
        //[Route("Select/All/Company/SIC")]
        //public IActionResult SelectAllCompanySIC()
        //{
        //    try
        //    {
        //        using (context)
        //        {
        //            var companySICList = context.CopmanySictbs.Select
        //                (e => new { Id=e.CopmanySicid, Description=e.CopmanySicdescription }).ToList();
        //            return Ok(companySICList);
        //        }
        //    }
        //    catch(Exception)
        //    {
        //        return BadRequest("This Process Failed");
        //    }
        //}

        [HttpGet("GetDefaultSuspeciousWords")]
        public async Task<IActionResult> GetDefaultSuspeciousWords() =>
            Ok(await context.DefaultSuspeciousWords.
                Select(e=> new
            {
                e.Keyword,
            }).ToListAsync());

        [HttpPost("AddSuspeciousWords")]
        public async Task<IActionResult> AddSuspeciousWords(AddSusSto dto)
        {
            try
            {
                var list = dto.Words.Select(e => new SuspeciousWord
                {
                    EngagementId=dto.Id,
                    Word=e
                });
                await context.AddRangeAsync(list);
                await context.SaveChangesAsync();
                return Ok("add");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Select/All/Company/SIC")]
        public IActionResult SelectAllCompanySICTb()
        {
            try
            {
                using (context)
                {
                    var companySICList = context.CompanySics.Select
                        (e => new { e.Id, e.Description }).ToList();
                    return Ok(companySICList);
                }
            }
            catch (Exception)
            {
                return BadRequest("This Process Failed");
            }
        }

        [HttpGet("GetSus")]

        [HttpGet]
        [Route("GetIndustriess")]
        public IActionResult GetIndustries()
        {
            try
            {
                using (context)
                {
                    var companySICList = context.Industries.
                        Select
                        (e => new { e.Code, e.Description ,e.CompanySic}).ToList();
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
                        Include(e=>e.IndustryCodeNavigation).
                        Where(e=>e.EngagmentId==engamentId ).
                        Select(e => new
                        {
                            e.IndustryCodeNavigation.CompanySic,
                            e.ReportingFrequencyId,
                            e.FinancialMangmentSystemId,
                            e.FiscalStartDay,
                            e.IndustryCode,
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
