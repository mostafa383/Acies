using AciesManagmentProject.DTO;
using AciesManagmentProject.help;
using AciesManagmentProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;

namespace AciesManagmentProject.Controllers
{
    [Route("api/[controller]"), Authorize]
    [ApiController]
    public class OrganizationController(DbAciesContext context) : ControllerBase
    {

        [HttpPost]
        [Route("Insert/Organization")]
        public IActionResult InsertOrganization([FromForm]AddOrganizationDto organizationTb)
        {
            try
            {
                var org = new OrganizationTb
                {
                    OrganizationName = organizationTb.OrganizationName,

                    OrganizationDescription = organizationTb.OrganizationDescription,

                    OrganizationCreatedDate = organizationTb.OrganizationCreatedDate,

                    OrganizationStatus = organizationTb.OrganizationStatus,

                    OwnerId = organizationTb.OwnerId,

                    CompanySicid = organizationTb.CopmanySicid,
                    IndustryCode=organizationTb.Code,

                    ReportingFrequencyId = organizationTb.ReportingFrequencyId,

                    FinancialMangmentSystemId = organizationTb.FinancialMangmentSystemId
                };
                context.OrganizationTbs.Add(org); ;
                context.SaveChanges();
                int orgId = org.OrganizationId;
                UserOrganizationTb userOrganizationTb = new UserOrganizationTb()
                {
                    OrganizationId = orgId,
                    UserId = organizationTb.OwnerId
                };
                context.UserOrganizationTbs.Add(userOrganizationTb);
                context.SaveChanges();
                return Ok(orgId);

            }
            catch
            {
                return BadRequest("This Process Failed");
            }
        }

        [HttpGet]
        [Route("Select/User/Organization/{PageNumber}/{RowCount}/{UserId}")]
        public IActionResult SelectUserOrganization(int UserId, int PageNumber = 1, int RowCount = 10)
        {
            try
            {

                var UsersCount = context.UserOrganizationTbs.Where(x => x.UserId == UserId).Count();
                if (UsersCount > 0)
                {
                    int PageCount = (UsersCount / RowCount) + 1;

                    var orgList = context.UserOrganizationTbs.Where(x => x.UserId == UserId).ToList();
                    List<UserOrganizationClass> orgstor = new List<UserOrganizationClass>();
                    for (int i = 0; i < orgList.Count; i++)
                    {
                        var engagCount = context.EngagmentTbs.Where(x => x.OrganizationId == orgList[i].OrganizationId).Count();

                        var userIdList = context.UserOrganizationTbs.Where(x => x.OrganizationId == orgList[i].OrganizationId).Select(e => new { e.UserId }).ToList();
                        List<UserOrganizationAttriputeClass> userstor = new List<UserOrganizationAttriputeClass>();
                        for (int z = 0; z < userIdList.Count; z++)
                        {
                            var user = context.UserTbs.Where(x => x.UserId == userIdList[z].UserId).FirstOrDefault();
                            UserOrganizationAttriputeClass userOrganizationAttriputeClass = new UserOrganizationAttriputeClass()
                            {
                                UserId = user.UserId,
                                UserName = user.UserName,
                                UserImage = user.UserImage
                            };
                            userstor.Add(userOrganizationAttriputeClass);
                        }

                        var org = context.OrganizationTbs.Include(e=>e.Owner).Where(x => x.OrganizationId == orgList[i].OrganizationId).FirstOrDefault();
                        UserOrganizationClass userOrganizationClass = new UserOrganizationClass()
                        {
                            OrganizationId = org.OrganizationId,
                            OrganizationName = org.OrganizationName,
                            OrganizationDescription = org.OrganizationDescription,
                            OrganizationCreatedDate = DateTime.Parse(org.OrganizationCreatedDate.ToString()),
                            OrganizationStatus = org.OrganizationStatus,
                            OwnerName = org.Owner.UserName,
                            EngagmentCount = engagCount,
                            Users = userstor,
                            Code=org.IndustryCode,
                            SIC=org.CompanySicid

                        };
                        orgstor.Add(userOrganizationClass);
                    }

                    return Ok((new PagingClass
                    {
                        RawCount = UsersCount,
                        PageCount = PageCount,

                    }, orgstor.OrderByDescending(x => x.OrganizationId).Skip((PageNumber - 1) * RowCount).Take(RowCount).ToList()));

                }
                else
                    return NotFound("Not Exist Users");


            }
            catch
            {
                return BadRequest("This Process Failed");
            }
        }

        [HttpGet]
        [Route("Select/Organization/{OrganizationtId}")]
        public IActionResult SelectOrganization(int OrganizationtId)
        {
            try
            {

                var orgList = context.OrganizationTbs.
                    Include(e=>e.Owner).
                    Include(e=>e.UserOrganizationTbs).
                    ThenInclude(e=>e.User).
                    Where(x => x.OrganizationId == OrganizationtId).FirstOrDefault();
                if (orgList != null)
                {
                    List<UserOrganizationAttriputeClass> stor = new List<UserOrganizationAttriputeClass>();
                    foreach (var item in orgList.UserOrganizationTbs)
                    {
                        UserOrganizationAttriputeClass organizationByIdAttriputeClass = new UserOrganizationAttriputeClass()
                        {
                            UserId = item.UserId,
                            UserName = item.User.UserName,
                            UserImage = item.User.UserImage
                        };
                        stor.Add(organizationByIdAttriputeClass);
                    }
                    OrganizationByIdAttriputeClass organizationByIdAttriputeClass1 = new OrganizationByIdAttriputeClass()
                    {
                        OrganizationId = orgList.OrganizationId,
                        OrganizationName = orgList.OrganizationName,
                        OrganizationDescription = orgList.OrganizationDescription,
                        OrganizationCreatedDate = DateTime.Parse(orgList.OrganizationCreatedDate.ToString()),
                        OrganizationStatus = orgList.OrganizationStatus,
                        OwnerName = orgList.Owner.UserName,
                        Users = stor,
                        Code=orgList.IndustryCode,
                        SIC=orgList.CompanySicid,
                        
                    };
                    return Ok(organizationByIdAttriputeClass1);
                }
                else
                    return NotFound("This Organization Not Exist");
            }

            catch
            {
                return BadRequest("This Process Failed");
            }
        }

        [HttpPost]
        [Route("Select/Organization/Fillter")]
        public IActionResult SelectOrganizationFillter(OrganizationFillterAttriputeClass orgfillter)
        {
            try
            {
                OrganizationBYOwnerClass organizationBYOwnerClass = new OrganizationBYOwnerClass(context);
                if (orgfillter.OrganizationStartTime != orgfillter.OrganizationFinishTime &&
                    orgfillter.OrganizationStatus.ToString() != null)
                {
                    var UsersCount = context.OrganizationTbs.Count();
                    if (UsersCount > 0)
                    {
                        int PageCount = (UsersCount / orgfillter.RowCount) + 1;
                        var Userslist = organizationBYOwnerClass.selectOrganizationByOwner(orgfillter.OwnerId).Where
                            (x => x.OrganizationCreatedDate >= orgfillter.OrganizationStartTime && x.OrganizationCreatedDate <= orgfillter.OrganizationFinishTime &&
                            x.OrganizationStatus == true).ToList();
                        return Ok((new PagingClass
                        {
                            RawCount = UsersCount,
                            PageCount = PageCount,

                        }, Userslist.Skip((orgfillter.PageNumber - 1) * orgfillter.RowCount).Take(orgfillter.RowCount).ToList()));
                    }
                    else
                        return NotFound("Not Exist Organization");
                }

                if (orgfillter.OrganizationStartTime != orgfillter.OrganizationFinishTime &&
                    orgfillter.OrganizationStatus.ToString() == null)
                {
                    var UsersCount = context.OrganizationTbs.Count();
                    if (UsersCount > 0)
                    {
                        int PageCount = (UsersCount / orgfillter.RowCount) + 1;

                        var Userslist = organizationBYOwnerClass.selectOrganizationByOwner(orgfillter.OwnerId).Where
                       (x => x.OrganizationCreatedDate <= orgfillter.OrganizationStartTime && x.OrganizationCreatedDate >= orgfillter.OrganizationFinishTime &&
                       x.OrganizationStatus == false).ToList();

                        return Ok((new PagingClass
                        {
                            RawCount = UsersCount,
                            PageCount = PageCount,

                        }, Userslist.Skip((orgfillter.PageNumber - 1) * orgfillter.RowCount).Take(orgfillter.RowCount).ToList()));
                    }
                    else
                        return NotFound("Not Exist Organization");
                }
                if (orgfillter.OrganizationStartTime == orgfillter.OrganizationFinishTime &&
                    orgfillter.OrganizationStatus == true)
                {
                    var UsersCount = context.OrganizationTbs.Count();
                    if (UsersCount > 0)
                    {
                        int PageCount = (UsersCount / orgfillter.RowCount) + 1;

                        var Userslist = organizationBYOwnerClass.selectOrganizationByOwner(orgfillter.OwnerId).Where
                       (x => x.OrganizationStatus == true).ToList();

                        return Ok((new PagingClass
                        {
                            RawCount = UsersCount,
                            PageCount = PageCount,

                        }, Userslist.Skip((orgfillter.PageNumber - 1) * orgfillter.RowCount).Take(orgfillter.RowCount).ToList()));

                    }
                    else
                        return NotFound("Not Exist Organization");
                }
                if (orgfillter.OrganizationStartTime == orgfillter.OrganizationFinishTime &&
                    orgfillter.OrganizationStatus == false)
                {
                    var UsersCount = context.OrganizationTbs.Count();
                    if (UsersCount > 0)
                    {
                        int PageCount = (UsersCount / orgfillter.RowCount) + 1;

                        var Userslist = organizationBYOwnerClass.selectOrganizationByOwner(orgfillter.OwnerId).ToList();

                        return Ok((new PagingClass
                        {
                            RawCount = UsersCount,
                            PageCount = PageCount,

                        }, Userslist.Skip((orgfillter.PageNumber - 1) * orgfillter.RowCount).Take(orgfillter.RowCount).ToList()));

                    }
                    else
                        return NotFound("Not Exist Organization");
                }
                else
                    return NotFound();
            }
            catch
            {
                return BadRequest("This Process Failed");
            }
        }

        [HttpPost]
        [Route("Insert/User/In/Organization")]
        public IActionResult InsertUserInOrganization([FromForm] AddUserInOrgananization userOrganizationTb)
        {
            try
            {
                context.UserOrganizationTbs.Add( new UserOrganizationTb
                {
                    UserId= userOrganizationTb.UserId,
                    OrganizationId= userOrganizationTb.OrganizationId,

                });
                context.SaveChanges();
                return Ok("User Inserted In Organization");
            }
            catch
            {
                return BadRequest("This Process Failed");
            }
        }

        [HttpDelete]
        [Route("Delete/User/From/Organization/{UserId}/{OrganizationtId}")]
        public IActionResult DeleteUserFromOrganization(int UserId, int OrganizationtId)
        {
            try
            {
                var userOrg = context.UserOrganizationTbs.Where(x => x.UserId == UserId && x.OrganizationId == OrganizationtId).FirstOrDefault();
                if (userOrg != null)
                {
                    context.UserOrganizationTbs.Remove(userOrg);
                    context.SaveChanges();
                    return Ok("User Deleted");
                }
                else
                    return NotFound("Not Exist This User");
            }
            catch
            {
                return BadRequest("This Process Failed");
            }
        }

        [HttpPatch]
        [Route("Update/Organization/{OrganizationtId}")]
        public IActionResult UpdateOrganization(int OrganizationtId, [FromForm] UpdateOrganizationtClass userUpdateClass)
        {
            try
            {
                var user = context.OrganizationTbs.Where(x => x.OrganizationId == OrganizationtId).FirstOrDefault();
                if (user != null)
                {
                    if(userUpdateClass.OrganizationName is not null)
                        user.OrganizationName = userUpdateClass.OrganizationName;
                    if(userUpdateClass.OrganizationDescription is not null)
                        user.OrganizationDescription= userUpdateClass.OrganizationDescription;
                    if(userUpdateClass.OrganizationCreatedDate is not null)
                        user.OrganizationCreatedDate = DateOnly.Parse( userUpdateClass.OrganizationCreatedDate.Value.ToString("yyyy/MM/dd"));
                    if(userUpdateClass.OrganizationStatus is not null)
                         user.OrganizationStatus= userUpdateClass.OrganizationStatus;
                    if (userUpdateClass.Code is not null)
                        user.IndustryCode = userUpdateClass.Code;
                    if (userUpdateClass.SIC is not null)
                        user.CompanySicid = userUpdateClass.SIC;
                    context.SaveChanges();
                    return Ok("Organization Updated");
                }
                else
                    return NotFound("This Organization Not Exist");
            }
            catch
            {
                return BadRequest("This Process Failed");
            }
        }

        [HttpDelete]
        [Route("Delete/Organization/{OrganizationtId}")]
        public IActionResult DeleteOrganization(int OrganizationtId)
        {
            try
            {
                var org = context.OrganizationTbs.Where(x => x.OrganizationId == OrganizationtId).FirstOrDefault();
                if (org != null)
                {
                    var organizationUsers = context.UserOrganizationTbs.Where(e => e.OrganizationId == OrganizationtId).ToList();
                    var engagments = context.EngagmentTbs.Where(e => e.OrganizationId == OrganizationtId).ToList();
                    var controlPoints = context.ControlPoints
                        .Where(cp => context.EngagmentTbs.Any(e => e.OrganizationId == OrganizationtId && cp.EngagementId == e.EngagmentId)) // Assuming you have EngagmentId in ControlPoints
                        .ToList();
                    var ControlPointCases=context.ControlPointCases.Where(cp => context.EngagmentTbs.Any(e => e.OrganizationId == OrganizationtId && cp.EngagementId == e.EngagmentId)) // Assuming you have EngagmentId in ControlPoints
                        .ToList();
                    context.UserOrganizationTbs.RemoveRange(organizationUsers);
                    context.ControlPointCases.RemoveRange(ControlPointCases);
                    context.ControlPoints.RemoveRange(controlPoints);
                    context.EngagmentTbs.RemoveRange(engagments);
                    context.OrganizationTbs.Remove(org);
                    context.SaveChanges();
                    return Ok("Organization Deleted");
                }
                else
                    return NotFound("This Organization Not Exist");
            }
            catch
            {
                return BadRequest("This Process Failed");
            }
        }
    }
}