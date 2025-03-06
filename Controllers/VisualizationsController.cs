using AciesManagmentProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AciesManagmentProject.Controllers
{
    [Route("api/[controller]"), ApiController, Authorize]
    public class VisualizationsController(AciesContext context) : ControllerBase
    {

        [HttpGet]
        public IActionResult GetBalanceCheckResults(int engagementID=9, string sop=null, string eop=null, string returnFormat="table")
        {
            var results =  context.BalanceCheckResults.FromSqlRaw(
                "EXEC viz_rsk_check_balance @engagementID = {0}, @sop = {1}, @eop = {2}, @returnFormat = {3}",
                engagementID, sop ?? (object)DBNull.Value, eop ?? (object)DBNull.Value, returnFormat);

            return Ok(results);
        }
        [HttpGet("GetTotalLevels")]
        public IActionResult GetTotalLevels(int engagementID=9, string sop=null, string eop=null, string returnFormat="table")
        {

                var results =  context.TotalLevelResults.FromSqlRaw(
                    "EXEC [dbo].[viz_rsk_total_levels] @engagementID = {0}, @sop = {1}, @eop = {2}, @returnFormat = {3}",
                    engagementID, sop ?? (object)DBNull.Value, eop ?? (object)DBNull.Value, returnFormat);

                return Ok(results);
            
        }

        [HttpGet("viz_rsk_breakdown")]
        public IActionResult viz_rsk_breakdown(int engagementID = 9, string sop = "2014-01-01", string groupingType = "monthly", string eop = "2015-08-10", string returnFormat = "table")
        {
            if (groupingType == "yearly")
            {
                var results = context.breakdownYearlys.FromSqlRaw(
                  "exec [dbo].[viz_rsk_breakdown]  @engagementID = {0}, @sop = {1}, @eop = {2}, @groupingType={3}, @returnFormat = {4}",
                  engagementID, sop ?? (object)DBNull.Value, eop ?? (object)DBNull.Value, groupingType, returnFormat);
                return Ok(results);
            }
            else
            {
                var results = context.Breakdowns.FromSqlRaw(
                    "exec [dbo].[viz_rsk_breakdown]  @engagementID = {0}, @sop = {1}, @eop = {2}, @groupingType={3}, @returnFormat = {4}",
                    engagementID, sop ?? (object)DBNull.Value, eop ?? (object)DBNull.Value, groupingType, returnFormat);
                return Ok(results);
            }
        }

        [HttpGet("rsk_by_account")]
        public IActionResult rsk_by_account(int engagementID=9, string sop = "2014-01-01", string eop = "2014-08-10", string returnFormat = "table")
        {
            var results =  context.rsk_by_accounts.FromSqlRaw(
                "exec viz_rsk_by_account @engagementID = {0}, @sop = {1}, @eop = {2}, @returnFormat = {3}",
                engagementID, sop ?? (object)DBNull.Value, eop ?? (object)DBNull.Value, returnFormat);
            return Ok(results);
        }

        [HttpGet("rsk_by_account_monthly")]
        public IActionResult rsk_by_account_monthly(string category= "Income from shares in group undertakings", int engagementID=9, string sop = "2014-01-01", string eop = "2018-08-10", string returnFormat = "table")
        {
            var results =  context.account_monthlys.FromSqlRaw(
                "exec viz_rsk_by_account_monthly @engagementID = {0}, @sop = {1}, @eop = {2}, @category={3}, @returnFormat = {4}",
                engagementID, sop ?? (object)DBNull.Value, eop ?? (object)DBNull.Value, category, returnFormat);
            return Ok(results);
        }


        [HttpGet("rsk_ControlPointSummary")]
        public IActionResult rsk_ControlPointSummary(int engagementID=9, string sop = null, string eop = null, string returnFormat = "table")
        {
            var results =  context.ControlPointSummaries.FromSqlRaw(
                "exec [viz_rsk_ControlPointSummary] @engagementID = {0}, @sop = {1}, @eop = {2}, @returnFormat = {3}",
                engagementID, sop ?? (object)DBNull.Value, eop ?? (object)DBNull.Value, returnFormat);
            return Ok(results);
        }

        [HttpGet("viz_baddebt")]
        public IActionResult viz_baddebt(int engagementID=9, string sop = "2014-11-24", string eop = "2024-11-24", string returnFormat = "table")
        {
            var results =  context.viz_baddebts.FromSqlRaw(
                "exec  [dbo].[viz_baddebt] @engagementID = {0}, @sop = {1}, @eop = {2}, @returnFormat = {3}",
                engagementID, sop ?? (object)DBNull.Value, eop ?? (object)DBNull.Value, returnFormat);
            return Ok(results);
        }

        [HttpGet("viz_baddebtcredit")]
        public IActionResult viz_baddebtcredit(int engagementID = 9, string sop = null, string eop =  null, string returnFormat = "table")
        {
            var results = context.viz_baddebts.FromSqlRaw(
                "exec  [dbo].[viz_baddebtcredit] @engagementID = {0}, @sop = {1}, @eop = {2}, @returnFormat = {3}",
                engagementID, sop ?? (object)DBNull.Value, eop ?? (object)DBNull.Value, returnFormat);
            return Ok(results);
        }


        [HttpGet("cashholt")]
        public IActionResult cashholt(int engagementID=9, string sop = null, string eop = null, string returnFormat = "table")
        {
            var sopValue = sop ?? (object)DBNull.Value;
            var eopValue = eop ?? (object)DBNull.Value;

            var results =  context.cashholts
                .FromSqlRaw(
                    "EXEC [dbo].[viz_cashholt] @engagementID = {0}, @sop = {1}, @eop = {2}, @returnFormat = {3}",
                    engagementID, sopValue, eopValue, returnFormat
                )
                ;

            return Ok(results);
        }


        [HttpGet("FinStatSum")]
        public IActionResult FinStatSum(string category="sales",int engagementID=9, string sop = null, string eop = null, string returnFormat = "table")
        {
            var results =  context.FinStatSums.FromSqlRaw(
                "exec [dbo].[viz_FinStatSum] @category = {0}, @engagementID = {1},@sop={2}, @eop = {3}, @returnFormat = {4}",
                category, engagementID, sop ?? (object)DBNull.Value, eop ?? (object)DBNull.Value, returnFormat);
            return Ok(results);
        } 
        [HttpGet("Incomeasset")]
        public IActionResult Incomeasset(string category="sales",int engagementID=9, string sop = null, string eop = null, string returnFormat = "table")
        {
            var results =  context.Incomeassets.FromSqlRaw(
                "exec [dbo].[viz_incomeasset] @category = {0}, @engagementID = {1},@sop={2}, @eop = {3}, @returnFormat = {4}",
                category, engagementID, sop ?? (object)DBNull.Value, eop ?? (object)DBNull.Value, returnFormat);
            return Ok(results);
        }

        [HttpGet("Intangible")]
        public IActionResult Intangible(int engagementID = 9, string sop = null, string eop = null, string returnFormat = "table")
        {
            var results = context.Intangibles.FromSqlRaw(
                "exec [dbo].[viz_intangible] @engagementID = {0},@sop={1}, @eop = {2}, @returnFormat = {3}",
                 engagementID, sop ?? (object)DBNull.Value, eop ?? (object)DBNull.Value, returnFormat);
            return Ok(results);
        }

        [HttpGet("Inventory")]
        public IActionResult Inventory(int engagementID = 9, string sop = null, string eop = null, string returnFormat = "table")
        {
            var results = context.Incomeassets.FromSqlRaw(
                "exec [dbo].[viz_Inventory] @engagementID = {0},@sop={1}, @eop = {2}, @returnFormat = {3}",
                 engagementID, sop ?? (object)DBNull.Value, eop ?? (object)DBNull.Value, returnFormat);
            return Ok(results);
        }

    }
}
