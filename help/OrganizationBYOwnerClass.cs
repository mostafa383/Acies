
using AciesManagmentProject.help;
using AciesManagmentProject.Models;
using OfficeOpenXml.ConditionalFormatting.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AciesManagmentProject.help
{
    public class OrganizationBYOwnerClass(AciesContext context)
    {
        public List<UserOrganizationClass> selectOrganizationByOwner(int onwerId)
        {
            using (context)
            {
               

                    var orgList = context.OrganizationTbs.Where(x => x.OwnerId == onwerId).ToList();
                    List<UserOrganizationClass> orgstor = new List<UserOrganizationClass>();
                    for (int i = 0; i < orgList.Count; i++)
                    {
                        var engagCount = context.EngagmentTbs.Where(x => x.OrganizationId == orgList[i].OrganizationId).Count();

                        var userIdList = context.OrganizationTbs.Where(x => x.OrganizationId == orgList[i].OrganizationId).Select(e => new { e.OwnerId }).ToList();
                        List<UserOrganizationAttriputeClass> userstor = new List<UserOrganizationAttriputeClass>();
                        for (int z = 0; z < userIdList.Count; z++)
                        {
                            var user = context.UserTbs.Where(x => x.UserId == userIdList[z].OwnerId).FirstOrDefault();
                            UserOrganizationAttriputeClass userOrganizationAttriputeClass = new UserOrganizationAttriputeClass()
                            {
                                UserId = user.UserId,
                                UserName = user.UserName,
                                UserImage = user.UserImage
                            };
                            userstor.Add(userOrganizationAttriputeClass);
                        }

                        var org = context.OrganizationTbs.Where(x => x.OrganizationId == orgList[i].OrganizationId).FirstOrDefault();
                        UserOrganizationClass userOrganizationClass = new UserOrganizationClass()
                        {
                            OrganizationId = org.OrganizationId,
                            OrganizationName = org.OrganizationName,
                            OrganizationDescription = org.OrganizationDescription,
                            OrganizationCreatedDate = DateTime.Parse( org.OrganizationCreatedDate.ToString()),
                            OrganizationStatus = org.OrganizationStatus,
                            EngagmentCount = engagCount,
                            Users = userstor
                        };
                        orgstor.Add(userOrganizationClass);
                    }
                orgstor.OrderByDescending(x => x.OrganizationId);
                return orgstor;



            }
        }
    }
}
