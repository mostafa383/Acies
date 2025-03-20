
using AciesManagmentProject.help;
using AciesManagmentProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace AciesManagmentProject.Controllers
{
    [Route("api/[controller]"), Authorize]
    [ApiController]
    public class ScriptController : ControllerBase
    {
        private readonly DbAciesContext context;
        
        private readonly IConfiguration _configuration;
        
        public ScriptController(IConfiguration configuration, DbAciesContext context)
        {
            _configuration = configuration;
            this.context = context;
            
        }


        [HttpGet]
        [Route("Select/vizbaddebt")]
        public IActionResult vizbaddebt()
        {
            //try
            //{
                using (SqlConnection Connection = new SqlConnection(_configuration.GetConnectionString("Aciess")))
                {
                    if (Connection.State == ConnectionState.Open)
                    {
                        Connection.Close();
                    }
                    else
                        Connection.Open();

                    using (SqlDataAdapter SDAConnection = new SqlDataAdapter("viz_baddebt", Connection))
                    {
                        string JsonPath = "";
                        SDAConnection.SelectCommand.CommandType = CommandType.StoredProcedure;
                        SDAConnection.SelectCommand.Parameters.AddWithValue("@tableName", "General_Ledger");
                        SDAConnection.SelectCommand.Parameters.AddWithValue("@engagementID", 1);
                        SDAConnection.SelectCommand.Parameters.AddWithValue("@prevYear", 10);
                        SDAConnection.SelectCommand.Parameters.AddWithValue("@isJson", 1);

                        DataSet DSConnection = new DataSet();
                        SDAConnection.Fill(DSConnection, "Debt");

                        if (DSConnection.Tables["Debt"].Rows.Count > 0)
                        {
                            for (int i = 0; i < DSConnection.Tables["Debt"].Rows.Count; i++)
                            {
                                DataRow DRConnection = DSConnection.Tables["Debt"].Rows[i];
                                JsonPath += DRConnection[0].ToString();
                            }

                            return Ok(JsonPath);
                        }
                        else
                            return NotFound("Exam NotFound");
                    }
                }
    //    }
    //        catch (Exception)
    //        {
    //            return BadRequest("This Process Failed");
    //}
}

        [HttpGet]
        [Route("Select/vizbaddebtcredit")]
        public IActionResult vizbaddebtcredit()
        {
            try
            {
                using (SqlConnection Connection = new SqlConnection(_configuration.GetConnectionString("Aciess")))
                {
                    if (Connection.State == ConnectionState.Open)
                    {
                        Connection.Close();
                    }
                    else
                        Connection.Open();

                    using (SqlDataAdapter SDAConnection = new SqlDataAdapter("viz_baddebtcredit", Connection))
                    {
                        string JsonPath = "";
                        SDAConnection.SelectCommand.CommandType = CommandType.StoredProcedure;
                        
                        SDAConnection.SelectCommand.Parameters.AddWithValue("@tableName", "General_Ledger");
                        SDAConnection.SelectCommand.Parameters.AddWithValue("@engagementID", 1);
                        SDAConnection.SelectCommand.Parameters.AddWithValue("@prevYear", 10);
                        SDAConnection.SelectCommand.Parameters.AddWithValue("@isJson", 1);

                        DataSet DSConnection = new DataSet();
                        SDAConnection.Fill(DSConnection, "Debt");

                        if (DSConnection.Tables["Debt"].Rows.Count > 0)
                        {
                            for (int i = 0; i < DSConnection.Tables["Debt"].Rows.Count; i++)
                            {
                                DataRow DRConnection = DSConnection.Tables["Debt"].Rows[i];
                                JsonPath += DRConnection[0].ToString();
                            }

                            return Ok(JsonPath);
                        }
                        else
                            return NotFound("Exam NotFound");
                    }
                }
            }
            catch (Exception)
            {
                return BadRequest("This Process Failed");
            }
        }

        [HttpGet]
        [Route("Select/vizcashholt")]
        public IActionResult vizcashholt()
        {
            try
            {
                using (SqlConnection Connection = new SqlConnection(_configuration.GetConnectionString("Aciess")))
                {
                    if (Connection.State == ConnectionState.Open)
                    {
                        Connection.Close();
                    }
                    else
                        Connection.Open();

                    using (SqlDataAdapter SDAConnection = new SqlDataAdapter("viz_cashholt", Connection))
                    {
                        string JsonPath = "";
                        SDAConnection.SelectCommand.CommandType = CommandType.StoredProcedure;
                       
                        SDAConnection.SelectCommand.Parameters.AddWithValue("@tableName", "General_Ledger");
                        SDAConnection.SelectCommand.Parameters.AddWithValue("@engagementID", 1);
                        SDAConnection.SelectCommand.Parameters.AddWithValue("@prevYear", 10);
                        SDAConnection.SelectCommand.Parameters.AddWithValue("@isJson", 1);


                        DataSet DSConnection = new DataSet();
                        SDAConnection.Fill(DSConnection, "Debt");

                        if (DSConnection.Tables["Debt"].Rows.Count > 0)
                        {
                            for (int i = 0; i < DSConnection.Tables["Debt"].Rows.Count; i++)
                            {
                                DataRow DRConnection = DSConnection.Tables["Debt"].Rows[i];
                                JsonPath += DRConnection[0].ToString();
                            }

                            return Ok(JsonPath);
                        }
                        else
                            return NotFound("Exam NotFound");
                    }
                }
            }
            catch (Exception)
            {
                return BadRequest("This Process Failed");
            }
        }

        [HttpGet]
        [Route("Select/vizincomeasset")]
        public IActionResult vizincomeasset()
        {
            try
            {
                using (SqlConnection Connection = new SqlConnection(_configuration.GetConnectionString("Aciess")))
                {
                    if (Connection.State == ConnectionState.Open)
                    {
                        Connection.Close();
                    }
                    else
                        Connection.Open();

                    using (SqlDataAdapter SDAConnection = new SqlDataAdapter("viz_incomeasset", Connection))
                    {
                        string JsonPath = "";
                        SDAConnection.SelectCommand.CommandType = CommandType.StoredProcedure;
                        SDAConnection.SelectCommand.Parameters.AddWithValue("@tableName", "General_Ledger");
                        SDAConnection.SelectCommand.Parameters.AddWithValue("@engagementID", 1);
                        SDAConnection.SelectCommand.Parameters.AddWithValue("@prevYear", 10);
                        SDAConnection.SelectCommand.Parameters.AddWithValue("@isJson", 1);
                        SDAConnection.SelectCommand.Parameters.AddWithValue("@Category", "tangible assets");


                        DataSet DSConnection = new DataSet();
                        SDAConnection.Fill(DSConnection, "Debt");

                        if (DSConnection.Tables["Debt"].Rows.Count > 0)
                        {
                            for (int i = 0; i < DSConnection.Tables["Debt"].Rows.Count; i++)
                            {
                                DataRow DRConnection = DSConnection.Tables["Debt"].Rows[i];
                                JsonPath += DRConnection[0].ToString();
                            }

                            return Ok(JsonPath);
                        }
                        else
                            return NotFound("Exam NotFound");
                    }
                }
            }
            catch (Exception)
            {
                return BadRequest("This Process Failed");
            }
        }

        [HttpGet]
        [Route("Select/vizintangible")]
        public IActionResult vizintangible()
        {
            try
            {
                using (SqlConnection Connection = new SqlConnection(_configuration.GetConnectionString("Aciess")))
                {
                    if (Connection.State == ConnectionState.Open)
                    {
                        Connection.Close();
                    }
                    else
                        Connection.Open();

                    using (SqlDataAdapter SDAConnection = new SqlDataAdapter("viz_intangible", Connection))
                    {
                        string JsonPath = "";
                        SDAConnection.SelectCommand.CommandType = CommandType.StoredProcedure;
                        SDAConnection.SelectCommand.Parameters.AddWithValue("@tableName", "General_Ledger");
                        SDAConnection.SelectCommand.Parameters.AddWithValue("@engagementID", 1);
                        SDAConnection.SelectCommand.Parameters.AddWithValue("@prevYear", 10);
                        SDAConnection.SelectCommand.Parameters.AddWithValue("@isJson", 1);


                        DataSet DSConnection = new DataSet();
                        SDAConnection.Fill(DSConnection, "Debt");

                        if (DSConnection.Tables["Debt"].Rows.Count > 0)
                        {
                            for (int i = 0; i < DSConnection.Tables["Debt"].Rows.Count; i++)
                            {
                                DataRow DRConnection = DSConnection.Tables["Debt"].Rows[i];
                                JsonPath += DRConnection[0].ToString();
                            }

                            return Ok(JsonPath);
                        }
                        else
                            return NotFound("Exam NotFound");
                    }
                }
            }
            catch (Exception)
            {
                return BadRequest("This Process Failed");
            }
        }

        [HttpGet]
        [Route("Select/vizInventory")]
        public IActionResult vizInventory()
        {
            try
            {
                using (SqlConnection Connection = new SqlConnection(_configuration.GetConnectionString("Aciess")))
                {
                    if (Connection.State == ConnectionState.Open)
                    {
                        Connection.Close();
                    }
                    else
                        Connection.Open();

                    using (SqlDataAdapter SDAConnection = new SqlDataAdapter("viz_Inventory", Connection))
                    {
                        string JsonPath = "";
                        SDAConnection.SelectCommand.CommandType = CommandType.StoredProcedure;
                        SDAConnection.SelectCommand.Parameters.AddWithValue("@tableName", "General_Ledger");
                        SDAConnection.SelectCommand.Parameters.AddWithValue("@enagementID", 1);
                        SDAConnection.SelectCommand.Parameters.AddWithValue("@prevYear", 10);
                        SDAConnection.SelectCommand.Parameters.AddWithValue("@isJson", 1);



                        DataSet DSConnection = new DataSet();
                        SDAConnection.Fill(DSConnection, "Debt");

                        if (DSConnection.Tables["Debt"].Rows.Count > 0)
                        {
                            for (int i = 0; i < DSConnection.Tables["Debt"].Rows.Count; i++)
                            {
                                DataRow DRConnection = DSConnection.Tables["Debt"].Rows[i];
                                JsonPath += DRConnection[0].ToString();
                            }

                            return Ok(JsonPath);
                        }
                        else
                            return NotFound("Exam NotFound");
                    }
                }
            }
            catch (Exception)
            {
                return BadRequest("This Process Failed");
            }
        }

        [HttpPost]
        [Route("Select/FuzzyMatching")]
        public IActionResult FuzzyMatching([FromForm] FuzzyMatchingClass fuzzyMatchingClass)
        {
            try
            {
                using (SqlConnection Connection = new SqlConnection(_configuration.GetConnectionString("Aciess")))
                {
                    if (Connection.State == ConnectionState.Open)
                    {
                        Connection.Close();
                    }
                    else
                        Connection.Open();

                    using (SqlDataAdapter SDAConnection = new SqlDataAdapter("FuzzyMatching", Connection))
                    {
                        string JsonPath = "";
                        SDAConnection.SelectCommand.CommandType = CommandType.StoredProcedure;
                        SDAConnection.SelectCommand.Parameters.AddWithValue("@engagementID", fuzzyMatchingClass.EngagementID);
                        SDAConnection.SelectCommand.Parameters.AddWithValue("@isJson", 1);



                        DataSet DSConnection = new DataSet();
                        SDAConnection.Fill(DSConnection, "Debt");

                        if (DSConnection.Tables["Debt"].Rows.Count > 0)
                        {
                            for (int i = 0; i < DSConnection.Tables["Debt"].Rows.Count; i++)
                            {
                                DataRow DRConnection = DSConnection.Tables["Debt"].Rows[i];
                                JsonPath += DRConnection[0].ToString();
                            }

                            return Ok(JsonPath);
                        }
                        else
                            return NotFound("Exam NotFound");
                    }
                }
            }
            catch (Exception)
            {
                return BadRequest("This Process Failed");
            }
        }

        [HttpGet("ExecuteProcedure")]
        public async Task<IActionResult> ExecuteProcedure()
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Local"));
            SqlCommand command = new SqlCommand("anlys_DayOfTheWeek", connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@engagementID", SqlDbType.Int);
            param1.Value = 1;
            command.Parameters.Add(param1);
            SqlParameter param2 = new SqlParameter("@tablename", SqlDbType.NVarChar,100);
            param2.Value = "General_Ledger";
            command.Parameters.Add(param2);

            connection.Open();
           var res= command.ExecuteScalar();
            connection.Close();
            return Ok(context.cc.FromSqlRaw("exec anlys_EmptyFields @engagementID, @tablename", param1,param2).AsEnumerable().Select(e=>e.id).FirstOrDefault());
        }

    }
}
