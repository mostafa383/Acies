using AciesManagmentProject.DTO;
using AciesManagmentProject.help;
using AciesManagmentProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AciesManagmentProject.Controllers
{
    [Route("api/[controller]"), Authorize]
    [ApiController]
    public class EngagmentController(DbA9b860AciesContext context, IWebHostEnvironment _environment) : ControllerBase
    {
        //[Route("IWebHostEnvironment")]
        //public class ServerFiles
        //{
        //    public IFormFile Files { get; set; }

        //}


        [HttpGet("GetAnalysisTypes")]
        public async Task<IActionResult> GetAnalysisTypes() =>
            Ok(await context.AnalysisTypes.Select(e=> new
            {
                e.Id,
                e.AnalysisType1
            }).ToListAsync());


        [HttpGet]
        [Route("Save/As/Server")]
        public string post_file(IFormFile file)
        {
            if (file != null)
            {
                if (file.Length > 0)
                {
                    if (!Directory.Exists(_environment.WebRootPath + "//Images_Server//"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "//Images_Server//");
                    }
                    using (FileStream filestrem = System.IO.File.Create(_environment.WebRootPath + "//Images_Server//" + file.FileName))
                    {
                        file.CopyTo(filestrem);
                        filestrem.Flush();

                        return "//Images_Server//" + file.FileName;
                    }
                }
                else
                    return "This Video Not Uploaded";
            }
            return null;

        }

        [HttpPost]
        [Route("Insert/Engagment")]
        public IActionResult InsertEngagment([FromForm] InsertEngagmentClass insertEngagmentClass)
        {
            try
            {
                var eng = context.EngagmentTbs.FirstOrDefault(e=>e.OrganizationId==insertEngagmentClass.OrganizationId && e.EngagmentName.ToLower()==insertEngagmentClass.EngagmentName.ToLower());
                if (eng is not null)
                    return BadRequest("This engagment name is found");
                EngagmentTb engagmentTb = new EngagmentTb()
                {
                    EngagmentName = insertEngagmentClass.EngagmentName,
                    EngagmentDescription = insertEngagmentClass.EngagmentDescription,
                    EngagmentCreatedDate = DateOnly.FromDateTime(DateTime.Now.Date),
                    EngagmentFile = post_file(insertEngagmentClass.EngagmentFile),
                    EngagmentStatus = true,
                    FinancialMangmentSystemId = insertEngagmentClass.FinancialMangmentSystemId,
                    OrganizationId = insertEngagmentClass.OrganizationId,
                    ReportingFrequencyId = insertEngagmentClass.ReportingFrequencyId,
                    OwnerId = insertEngagmentClass.OwnerId,
                    IndustryCode = insertEngagmentClass.Code,
                    FiscalStartDay = insertEngagmentClass.FiscalStartDay,
                    FiscalStartMonth = insertEngagmentClass.FiscalStartMonth,
                    AnalysisType = insertEngagmentClass.Type,
                    Currency=insertEngagmentClass.CurrencyId
                };
                if (insertEngagmentClass.LibraryId is not null)
                    engagmentTb.LibraryId = insertEngagmentClass.LibraryId.Value;
                context.EngagmentTbs.Add(engagmentTb);
                context.SaveChanges();
                int engagId = engagmentTb.EngagmentId;
                UserEngagmentTb userEngagmentTb = new UserEngagmentTb()
                {
                    EngagmentId = engagId,
                    UserId = insertEngagmentClass.OwnerId
                };
                context.UserEngagmentTbs.Add(userEngagmentTb);
                context.SaveChanges();

                context.Database.ExecuteSqlRaw(
                    "exec [dbo].[anlys_PrepareDefaultValues] @engagementID = {0}",
                     engagmentTb.EngagmentId);
                return Ok(engagId);
            }
            catch (Exception)
            {
                return BadRequest("This Process Failed");
            }
        }

        [HttpGet("sd")]
        public IActionResult sd()
        {
           
            return Ok(context.EngagmentTbs.Select(e=>e.EngagmentId).ToList());
        }


        [HttpPost]
        [Route("Select/User/Engagment")]
        public IActionResult SelectUserOrganization([FromForm] AllEngagmentByStatusClass allEngagmentByStatusClass)
        {
            try
            {
                if (allEngagmentByStatusClass.EngagmentStatus == null)
                {
                    var UsersCount = context.EngagmentUserViews.Where
                        (x => x.UserId == allEngagmentByStatusClass.UserId && x.OrganizationId == allEngagmentByStatusClass.OrganizationtId).Distinct().Count();
                    if (UsersCount > 0)
                    {
                        int PageCount = (UsersCount / allEngagmentByStatusClass.RowCount) + 1;

                        var orgList = context.EngagmentUserViews.Where(x => x.UserId == allEngagmentByStatusClass.UserId && x.OrganizationId == allEngagmentByStatusClass.OrganizationtId).ToList();
                        var engagments = orgList.GroupBy(e=>e.EngagmentId);
                        List<UserEngagmentClass> orgstor = new List<UserEngagmentClass>();
                        foreach (var item in engagments)
                        {
                            var engId = item.Key;
                            var userIdList = context.EngagmentUserViews.
                                Where(x => x.EngagmentId == engId)
                                .Select(e =>  e.UserId ).
                                Distinct().
                                ToList();
                            var users = context.UserTbs
                             .Where(x => userIdList.Contains(x.UserId))
                             .Select(u => new UserOrganizationAttriputeClass
                             {
                                 UserId = u.UserId,
                                 UserName = u.UserName,
                                 UserImage = u.UserImage
                             })
                             .ToList();

                            var org = context.EngagmentViews.Where(x => x.EngagmentId == engId).FirstOrDefault();

                            UserEngagmentClass userOrganizationClass = new UserEngagmentClass()
                            {
                                EngagmentId = org.EngagmentId,
                                EngagmentName = org.EngagmentName,
                                EngagmentDescription = org.EngagmentDescription,
                                EngagmentCreatedDate = DateTime.Parse(org.EngagmentCreatedDate.ToString()),
                                EngagmentStatus = org.EngagmentStatus,
                                OwnerName = org.UserName,
                                Users = users
                            };
                            orgstor.Add(userOrganizationClass);
                        }

                        return Ok((new PagingClass
                        {
                            RawCount = UsersCount,
                            PageCount = PageCount,

                        }, orgstor.OrderByDescending(x => x.EngagmentId).Skip((allEngagmentByStatusClass.PageNumber - 1) * allEngagmentByStatusClass.RowCount).Take(allEngagmentByStatusClass.RowCount).ToList()));

                    }
                    else
                        return NotFound("Not Exist Engagment");
                }
                else
                {
                    var UsersCount = context.EngagmentUserViews.Where
                        (x => x.UserId == allEngagmentByStatusClass.UserId && x.OrganizationId == allEngagmentByStatusClass.OrganizationtId && x.EngagmentStatus == allEngagmentByStatusClass.EngagmentStatus).Distinct().Count();
                    if (UsersCount > 0)
                    {
                        int PageCount = (UsersCount / allEngagmentByStatusClass.RowCount) + 1;

                        var orgList = context.EngagmentUserViews.Where(x => x.UserId == allEngagmentByStatusClass.UserId && x.OrganizationId == allEngagmentByStatusClass.OrganizationtId && x.EngagmentStatus == allEngagmentByStatusClass.EngagmentStatus).ToList();
                        var engs = orgList.GroupBy(e=>e.EngagmentId);
                        List<UserEngagmentClass> orgstor = new List<UserEngagmentClass>();
                        foreach (var item in engs)
                    
                        {
                            var engId = item.Key;

                            var userIdList = context.EngagmentUserViews.
                                Where(x => x.EngagmentId == engId && x.EngagmentStatus == allEngagmentByStatusClass.EngagmentStatus).
                                Select(e =>e.UserId ).
                                Distinct().
                                ToList();
                           var users=context.UserTbs.
                                Where(e=> userIdList.Contains(e.UserId)).
                                Select(u => new UserOrganizationAttriputeClass
                                {
                                    UserId = u.UserId,
                                    UserName = u.UserName,
                                    UserImage = u.UserImage
                                }).
                                ToList();
                            var org = context.EngagmentViews.Where(x => x.EngagmentId == engId && x.EngagmentStatus == allEngagmentByStatusClass.EngagmentStatus).FirstOrDefault();

                            UserEngagmentClass userOrganizationClass = new UserEngagmentClass()
                            {
                                EngagmentId = org.EngagmentId,
                                EngagmentName = org.EngagmentName,
                                EngagmentDescription = org.EngagmentDescription,
                                EngagmentCreatedDate = DateTime.Parse(org.EngagmentCreatedDate.ToString()),
                                EngagmentStatus = org.EngagmentStatus,
                                OwnerName = org.UserName,
                                Users = users
                            };
                            orgstor.Add(userOrganizationClass);
                        }

                        return Ok((new PagingClass
                        {
                            RawCount = UsersCount,
                            PageCount = PageCount,

                        }, orgstor.OrderByDescending(x => x.EngagmentId).Skip((allEngagmentByStatusClass.PageNumber - 1) * allEngagmentByStatusClass.RowCount).Take(allEngagmentByStatusClass.RowCount).ToList()));

                    }
                    else
                        return NotFound("Not Exist Engagment");
                }


            }
            catch (Exception)
            {
                return BadRequest("This Process Failed");
            }
        }

        [HttpGet]
        [Route("Select/Engagment/{engagmentId}")]
        public IActionResult SelectEngagment(int engagmentId)
        {
            try
            {
                var orgList = context.EngagmentTbs.
                    Include(e => e.IndustryCodeNavigation).
                    Include(e => e.Owner).
                    Include(e => e.CurrencyNavigation).
                    //Include(e => e.UserEngagmentTbs).
                    //ThenInclude(e => e.User).
                    FirstOrDefault(e => e.EngagmentId == engagmentId);
                if (orgList != null)
                {
                    var usersEngagment = context.UserEngagmentTbs.
                        Include(e => e.User).
                        Where(e => e.EngagmentId == engagmentId).ToList();
                    List<UserOrganizationAttriputeClass> stor = new List<UserOrganizationAttriputeClass>();
                    for (int i = 0; i < usersEngagment.Count; i++)
                    {
                        UserOrganizationAttriputeClass organizationByIdAttriputeClass = new UserOrganizationAttriputeClass()
                        {
                            UserId = usersEngagment[i].UserId,
                            UserName = usersEngagment[i].User.UserName,
                            UserImage = usersEngagment[i].User.UserImage,
                        };
                        stor.Add(organizationByIdAttriputeClass);
                    }
                    UserEngagmentClass organizationByIdAttriputeClass1 = new UserEngagmentClass()
                    {
                        EngagmentId = orgList.EngagmentId,
                        EngagmentName = orgList.EngagmentName,
                        EngagmentDescription = orgList.EngagmentDescription,
                        EngagmentCreatedDate = DateTime.Parse(orgList.EngagmentCreatedDate.ToString()),
                        EngagmentStatus = orgList.EngagmentStatus,
                        OrganizationId = orgList.OrganizationId,
                        Users = stor,
                        OwnerName = orgList.Owner.UserName,
                        FiscalStartDay = orgList.FiscalStartDay,
                        FiscalStartMonth = orgList.FiscalStartMonth,
                        FinancialMangmentSystemId = orgList.FinancialMangmentSystemId,
                        CopmanySicid = orgList?.IndustryCodeNavigation?.CompanySic,
                        ReportingFrequencyId = orgList.ReportingFrequencyId,
                        CurrrencyId=orgList.CurrencyNavigation?.Id,
                        CurrrencyName=orgList.CurrencyNavigation?.Name,
                        CurrrencyShortName=orgList.CurrencyNavigation?.ShortName,
                        CurrrencySymbol=orgList.CurrencyNavigation?.Symbol,
                        Code=orgList.IndustryCode
                    };
                    return Ok(organizationByIdAttriputeClass1);
                }
                else
                    return BadRequest("Not found");
            }
            catch (Exception)
            {
                return BadRequest("This Process Failed");
            }
        }


        [HttpGet]
        [Route("GetEngagmentsByOwner/{ownerId}")]
        public IActionResult GetEngagmentsByOwner(int ownerId)
        {
            try
            {
                var orgList = context.EngagmentTbs.
                    Where(e => e.OwnerId == ownerId).Select(e => new
                    {
                        e.EngagmentId,
                        e.EngagmentName
                    });
                return Ok(orgList);
            }
            catch (Exception)
            {
                return BadRequest("This Process Failed");
            }
        }


        [HttpPost]
        [Route("Insert/User/In/Engagment")]
        public IActionResult InsertUserInEngagment([FromForm] AddUserEngagment userEngagmentTb)
        {
            try
            {
                var userInEngagment = context.UserEngagmentTbs.
                    FirstOrDefault(e=>e.UserId==userEngagmentTb.UserId &&
                                   e.EngagmentId==userEngagmentTb.EngagmentId);
                if(userInEngagment == null)
                {
                    context.UserEngagmentTbs.Add(new UserEngagmentTb
                    {
                        EngagmentId = userEngagmentTb.EngagmentId,
                        UserId = userEngagmentTb.UserId,

                    });
                    context.SaveChanges();
                }
                return Ok("User Inserted In Engagment");

            }
            catch (Exception)
            {
                return BadRequest("This Process Failed");
            }

        }

        [HttpPatch]
        [Route("Update/Engagment/{EngagmentId}")]
        public IActionResult UpdateEngagment(int EngagmentId, [FromForm] UpdateEngagmentClass userUpdateClass)
        {
            try
            {

                var user = context.EngagmentTbs.Where(x => x.EngagmentId == EngagmentId).FirstOrDefault();
                if (user != null)
                {
                    if (userUpdateClass.EngagmentName != null)
                    {
                        JsonPatchDocument UpdatedData = new JsonPatchDocument();
                        UpdatedData.Replace("EngagmentName", userUpdateClass.EngagmentName);
                        UpdatedData.ApplyTo(user);
                        context.SaveChanges();
                    }
                    if (userUpdateClass.EngagmentDescription != null)
                    {
                        JsonPatchDocument UpdatedData = new JsonPatchDocument();
                        UpdatedData.Replace("EngagmentDescription", userUpdateClass.EngagmentDescription);
                        UpdatedData.ApplyTo(user);
                        context.SaveChanges();
                    }
                    if (userUpdateClass.EngagmentCreatedDate != null)
                    {
                        JsonPatchDocument UpdatedData = new JsonPatchDocument();
                        UpdatedData.Replace("EngagmentCreatedDate", userUpdateClass.EngagmentCreatedDate);
                        UpdatedData.ApplyTo(user);
                        context.SaveChanges();
                    }
                    if (userUpdateClass.EngagmentStatus != null)
                    {
                        JsonPatchDocument UpdatedData = new JsonPatchDocument();
                        UpdatedData.Replace("EngagmentStatus", userUpdateClass.EngagmentStatus);
                        UpdatedData.ApplyTo(user);
                        context.SaveChanges();
                    }
                    if (userUpdateClass.EngagmentFile != null)
                    {
                        JsonPatchDocument UpdatedData = new JsonPatchDocument();
                        UpdatedData.Replace("EngagmentFile", post_file(userUpdateClass.EngagmentFile));
                        UpdatedData.ApplyTo(user);
                        context.SaveChanges();
                    }
                    if (userUpdateClass.Code != null)
                    {
                        user.IndustryCode = userUpdateClass.Code;
                        context.SaveChanges();
                    }
                    if (userUpdateClass.CurrencyId != null)
                    {
                        user.Currency = userUpdateClass.CurrencyId;
                        context.SaveChanges();
                    }

                    if (userUpdateClass.AnalysisType != null)
                    {
                        user.AnalysisType = userUpdateClass.AnalysisType;
                        context.SaveChanges();
                    }

                    return Ok("Engagment Updated");
                }
                else
                    return NotFound("This Engagment Not Exist");


            }
            catch (Exception)
            {
                return BadRequest("This Process Failed");
            }
        }

        [HttpDelete]
        [Route("Delete/Engagment/{EngagmentId}")]
        public IActionResult DeleteEngagment(int EngagmentId)
        {
            try
            {

                var engagment = context.EngagmentTbs.Where(x => x.EngagmentId == EngagmentId).FirstOrDefault();
                if (engagment != null)
                {
                    context.EngagmentTbs.Remove(engagment);
                    context.SaveChanges();
                    return Ok("Engagment Deleted");
                }
                else
                    return NotFound("This engagment Not Exist");


            }
            catch (Exception)
            {
                return BadRequest("This Process Failed");
            }
        }


        [HttpPost]
        [Route("Upload/Engagment/File")]
        public IActionResult UploadEngagmentFile([FromForm] PostGeneralLedgerListClass postGeneralLedgerListClass)
        {
            try
            {
                for (int i = 0; i < postGeneralLedgerListClass.GeneralLedgerList.Count; i++)
                {
                    var acoount = context.OriginalAccountNames.Where
                        (x => x.AccountName == postGeneralLedgerListClass.GeneralLedgerList[i].Account &&
                            x.Engagementid == postGeneralLedgerListClass.EngagementId).
                        Select(e => new { e.Id }).FirstOrDefault();
                    int accountMaped = 0;
                    if (acoount == null)
                    {
                        OriginalAccountName originalAccountName = new OriginalAccountName()
                        {
                            Engagementid = postGeneralLedgerListClass.EngagementId,
                            AccountName = postGeneralLedgerListClass.GeneralLedgerList[i].Account,
                        };
                        context.OriginalAccountNames.Add(originalAccountName);
                        context.SaveChanges();
                        accountMaped = originalAccountName.Id;
                    }
                    else
                    {
                        accountMaped = acoount.Id;
                    }

                    Transaction transaction = new Transaction()
                    {

                        EngagementId = postGeneralLedgerListClass.EngagementId,
                        Credit = postGeneralLedgerListClass.GeneralLedgerList[i].Credit,
                        Debit = postGeneralLedgerListClass.GeneralLedgerList[i].Debit,
                        Date = postGeneralLedgerListClass.GeneralLedgerList[i].Date,
                        Details = postGeneralLedgerListClass.GeneralLedgerList[i].Details,
                        Nominal = postGeneralLedgerListClass.GeneralLedgerList[i].Nominal,
                        Reference = postGeneralLedgerListClass.GeneralLedgerList[i].Reference,
                        Notes = postGeneralLedgerListClass.GeneralLedgerList[i].Notes,
                        Tt = postGeneralLedgerListClass.GeneralLedgerList[i].Tt,
                        Account = accountMaped,

                    };

                    context.Transactions.Add(transaction);
                    context.SaveChanges();
                }
                return Ok("File Uploaded");

            }
            catch (Exception)
            {
                return BadRequest("This Process Failed");
            }
        }

        [HttpPost]
        [Route("Insert/Account/Mapping")]
        public IActionResult UploadEngagmentFile([FromBody] List<UpdateAccountMappingClass> updateAccountMappingClass)
        {
            //try
            //{
            for (int i = 0; i < updateAccountMappingClass.Count; i++)
            {
                var oreginal = context.OriginalAccountNames.Where(x => x.Id == updateAccountMappingClass[i].Id).FirstOrDefault();
                if (oreginal != null)
                {
                    if (updateAccountMappingClass[i].MappedAccountId != null)
                    {
                        JsonPatchDocument UpdatedData = new JsonPatchDocument();
                        UpdatedData.Replace("MappedAccountId", updateAccountMappingClass[i].MappedAccountId);
                        UpdatedData.ApplyTo(oreginal);
                        context.SaveChanges();
                    }
                    if (updateAccountMappingClass[i].Tags != null)
                    {
                        JsonPatchDocument UpdatedData = new JsonPatchDocument();
                        UpdatedData.Replace("Tags", updateAccountMappingClass[i].Tags);
                        UpdatedData.ApplyTo(oreginal);
                        context.SaveChanges();
                    }
                }

            }
            return Ok("Account Mapping Uploaded");

            //}
            //catch (Exception)
            //{
            //    return BadRequest("This Process Failed");
            //}
        }

        [HttpGet]
        [Route("Select/SusKeywords")]
        public IActionResult SelectSusKeywords()
        {
            return Ok(context.DefaultSusKeywords.ToList());
        }

        [HttpPost]
        [Route("Insert/Manual/Entries")]
        public IActionResult InsertManualEntries([FromBody] PostListManualEntries postListManualEntries)
        {
            List<ManualEntry> stor = new List<ManualEntry>();
            for (int i = 0; i < postListManualEntries.ManualEntries.Count; i++)
            {
                ManualEntry manualEntry = new ManualEntry()
                {
                    EngId = postListManualEntries.ManualEntries[i].EngId,
                    ColName = postListManualEntries.ManualEntries[i].ColName,
                    Entries = postListManualEntries.ManualEntries[i].Entries,
                    ExcludedKeywords = postListManualEntries.ManualEntries[i].ExcludedKeywords,
                };
                stor.Add(manualEntry);
                context.ManualEntries.Add(manualEntry);
                var engagment = context.EngagmentTbs.FirstOrDefault(e=>e.EngagmentId== postListManualEntries.ManualEntries[i].EngId);
                if(engagment is not null && postListManualEntries.ManualEntries[i].CurrencyId is not null)
                {
                    engagment.Currency = postListManualEntries.ManualEntries[i].CurrencyId;
                }
                context.SaveChanges();
            }

            var susWord = context.DefaultSusKeywords.Where(x => x.Id == 1).FirstOrDefault();
            if (susWord != null)
            {
                JsonPatchDocument UpdatedData = new JsonPatchDocument();
                UpdatedData.Replace("Keywords", postListManualEntries.SuspeciousWords);
                UpdatedData.ApplyTo(susWord);
                context.SaveChanges();
            }
            return Ok("List Uploaded ");
        }
        [HttpGet("GetCategories")]
        public IActionResult GetCategories(int engagmentId)
        {
            var results = context.Categories.FromSqlRaw(
             "exec qry_getMappedAccountsByEngagement @engagementID = {0}",
             engagmentId);
            return Ok(results.AsEnumerable().ToList());
        }

        [HttpGet("GetEngamgenetCPs"), AllowAnonymous]
        public IActionResult GetEngamgenetCPs(int engID = 9)
        {
            var results = context.Ress.FromSqlRaw(
             "exec GetEngamgenetCPs @engID={0}", engID);
            return Ok(results.ToList()
                .GroupBy(e => new { e.ControlPointId, e.ControlPointValue, e.ControlPointName })
            .Select(e => new GetECP
            {
                ControlPointId = e.Key.ControlPointId,
                ControlPointName = e.Key.ControlPointName,
                ControlPointValue = e.Key.ControlPointValue,
                Cases = e.Select(ee => new GetECPC
                {
                    ControlPointCaseId = ee.ControlPointCaseId,
                    ControlPointCaseName = ee.ControlPointCaseName,
                    ControlPointCaseValue = ee.ControlPointCaseValue,
                }).ToList()
            }));
        }

        [HttpGet("GetCurrencies")]
        public IActionResult GetCurrencies() =>
            Ok(context.Currencies.Select(e => new
            {
                e.Id,
                e.Symbol,
                e.Name,
                e.ShortName
            }));

        [HttpPost("EditCP")]
        public IActionResult EditCP([FromBody] List<EditControlPoint> dto)
        {
            try
            {
                foreach (var item in dto)
                {
                    var cp = context.ControlPoints.FirstOrDefault(e => e.ControlPointId == item.Id);
                    if (cp is not null)
                        cp.ControlPointValue = item.Value;
                }
                context.SaveChanges();
                return Ok("Updated");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("EditCPCase")]
        public IActionResult EditCPCase([FromBody] List<EditControlPoint> dto)
        {
            try
            {
                foreach (var item in dto)
                {
                    var cp = context.ControlPointCases.FirstOrDefault(e => e.ControlPointCaseId == item.Id);
                    if (cp is not null)
                        cp.ControlPointCaseValue = item.Value;
                }
                context.SaveChanges();
                return Ok("Updated");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

