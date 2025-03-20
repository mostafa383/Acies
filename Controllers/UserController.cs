using AciesManagmentProject.DTO;
using AciesManagmentProject.help;
using AciesManagmentProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;

namespace AciesManagmentProject.Controllers
{
    [Route("api/[controller]"), Authorize]
    [ApiController]
    public class UserController : ControllerBase
    {
        private DbAciesContext context;
        private IWebHostEnvironment _environment;
        public UserController(DbAciesContext context, IWebHostEnvironment _environment)
        {
            this.context = context;
            this._environment = _environment;
        }
        //[Route("IWebHostEnvironment")]
        //public class ServerFiles
        //{
        //    public IFormFile Files { get; set; }
        //}

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
        [Route("Insert/User"), AllowAnonymous]
        public IActionResult InsertUser([FromForm] AddUserDto userTb)
        {
            try
            {
                string image = "";
                if (!Directory.Exists(_environment.WebRootPath + "//Images_Server//"))
                {
                    Directory.CreateDirectory(_environment.WebRootPath + "//Images_Server//");
                }
                if (userTb.UserImage is not null)
                {
                    using (FileStream filestrem = System.IO.File.Create(_environment.WebRootPath + "//Images_Server//" + userTb.UserImage.FileName))
                    {
                        userTb.UserImage.CopyTo(filestrem);
                        filestrem.Flush();
                        image = "//Images_Server//" + userTb.UserImage.FileName;
                    }
                }
                context.UserTbs.Add(new UserTb
                {
                    UserEmail = userTb.UserEmail,
                    UserName = userTb.UserName,
                    UserPassword = userTb.UserPassword,
                    UserPhone = userTb.UserPhone,
                    UserImage = image == "" ? null : image,
                });
                context.SaveChanges();
                return Ok("User Acount Created");

            }
            catch (Exception)
            {
                return BadRequest("This Process Failed");
            }

        }

        [HttpGet]
        [Route("Select/All/User/{PageNumber}/{RowCount}")]
        public IActionResult SelectAllUser(int PageNumber = 1, int RowCount = 10)
        {
            //try
            //{

            var UsersCount = context.UserTbs.Count();
            if (UsersCount > 0)
            {
                int PageCount = (UsersCount / RowCount) + 1;

                var Userslist = context.UserTbs.Select(e => new { e.UserId, e.UserName, e.UserPhone, e.UserEmail, e.UserPassword, e.UserImage }).ToList();
                return Ok((new PagingClass
                {
                    RawCount = UsersCount,
                    PageCount = PageCount,

                }, Userslist.Skip((PageNumber - 1) * RowCount).Take(RowCount).ToList()));

            }
            else
                return NotFound("Not Exist Users");


            //}
            //catch(Exception)
            //{
            //    return BadRequest("This Process Failed");
            //}
        }

        [HttpPost]
        [Route("Select/User/By/UserName/{PageNumber}/{RowCount}")]
        public IActionResult SelectQuestionByQustionText([FromForm] GetUserDto usersTb, int PageNumber = 1, int RowCount = 10)
        {
            try
            {
                var userName = context.UserTbs.Select(e => new { e.UserName }).ToList();
                var userContaintNameCount = userName.Where(x => x.UserName.Contains(usersTb.UserName, StringComparison.OrdinalIgnoreCase));
                var userCount = userContaintNameCount.Count();
                if (userCount > 0)
                {
                    int PageCount = (userCount / RowCount) + 1;
                    var userlist = context.UserTbs.Select
                        (e => new { e.UserId, e.UserName, e.UserPhone, e.UserEmail, e.UserPassword, e.UserImage }).ToList();
                    var userListName = userlist.Where(x => x.UserName.Contains(usersTb.UserName, StringComparison.OrdinalIgnoreCase));
                    return Ok((new PagingClass
                    {
                        RawCount = userCount,
                        PageCount = PageCount,

                    }, userListName.Skip((PageNumber - 1) * RowCount).Take(RowCount).ToList()));

                }
                else
                    return NotFound("Not Exist users");
            }
            catch
            {
                return BadRequest("This Process Failed");
            }
        }

        [HttpPost]
        [Route("User/Login"), AllowAnonymous]
        public IActionResult UserLogin([FromForm] UserLoginClass userLoginClass, IJwt jwt)
        {
            try
            {

                var user = context.UserTbs.FirstOrDefault
                    (x => x.UserEmail == userLoginClass.UserEmail && x.UserPassword == userLoginClass.UserPassword);
                if (user != null)
                {
                    return Ok(new loginDto
                    {
                        token = jwt.CreateToken(user),
                        UserId = user.UserId,
                        UserEmail=user.UserEmail,
                        UserImage=user.UserImage is null?"": user.UserImage,
                        UserName=user.UserName,
                        UserPhone=user.UserPhone is null?"":user.UserPhone
                    });

                }
                else
                    return NotFound("Email OR Password Is Wrong");

            }
            catch (Exception)
            {
                return BadRequest("This Process Failed");
            }
        }

        [HttpPatch]
        [Route("Update/User/{UserId}")]
        public IActionResult UpdateUser(int UserId, [FromForm] UserUpdateClass userUpdateClass)
        {
            try
            {

                var user = context.UserTbs.Where(x => x.UserId == UserId).FirstOrDefault();
                if (user != null)
                {
                    if (userUpdateClass.UserName != null)
                    {
                        JsonPatchDocument UpdatedData = new JsonPatchDocument();
                        UpdatedData.Replace("UserName", userUpdateClass.UserName);
                        UpdatedData.ApplyTo(user);
                        context.SaveChanges();
                    }
                    if (userUpdateClass.UserPhone != null)
                    {
                        JsonPatchDocument UpdatedData = new JsonPatchDocument();
                        UpdatedData.Replace("UserPhone", userUpdateClass.UserPhone);
                        UpdatedData.ApplyTo(user);
                        context.SaveChanges();
                    }
                    if (userUpdateClass.UserEmail != null)
                    {
                        JsonPatchDocument UpdatedData = new JsonPatchDocument();
                        UpdatedData.Replace("UserEmail", userUpdateClass.UserEmail);
                        UpdatedData.ApplyTo(user);
                        context.SaveChanges();
                    }
                    if (userUpdateClass.UserPassword != null)
                    {
                        JsonPatchDocument UpdatedData = new JsonPatchDocument();
                        UpdatedData.Replace("UserPassword", userUpdateClass.UserPassword);
                        UpdatedData.ApplyTo(user);
                        context.SaveChanges();
                    }
                    if (userUpdateClass.UserImage != null)
                    {
                        JsonPatchDocument UpdatedData = new JsonPatchDocument();
                        UpdatedData.Replace("UserImage", post_file(userUpdateClass.UserImage));
                        UpdatedData.ApplyTo(user);
                        context.SaveChanges();
                    }
                    return Ok("User Updated");
                }
                else
                    return NotFound("This User Not Exist");

            }
            catch (Exception)
            {
                return NotFound("Not Exist Users");
            }
        }
    }
}
