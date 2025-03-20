using AciesManagmentProject.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AciesManagmentProject
{
    public class StoredProcedureHub : Hub
    {
        private readonly IConfiguration _configuration;

        public async Task SendData(DbAciesContext context)
        {
            var engagementID = int.Parse(Context.GetHttpContext().Request.Query["engagementID"]);
            SqlParameter param1 = new SqlParameter("@engagementID", SqlDbType.Int);
            SqlParameter param3 = new SqlParameter("@sod", SqlDbType.Time);
            SqlParameter param4 = new SqlParameter("@eod", SqlDbType.Time);
            param1.Value = engagementID;
            param3.Value = "08:00:00.0000000";
            param4.Value = "18:00:00.0000000";
            await Clients.All.SendAsync("ReceiveMessage", context.cc.FromSqlRaw("exec [anlys_DayOfTheWeek] @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault());
            await Clients.All.SendAsync("ReceiveMessage", context.cc.FromSqlRaw("exec anlys_EmptyFields @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault());
            await Clients.All.SendAsync("ReceiveMessage", context.cc.FromSqlRaw("exec [dbo].[anlys_EmptyFields]  @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault());
            await Clients.All.SendAsync("ReceiveMessage", context.cc.FromSqlRaw(" exec [dbo].[anlys_CreditOutlierAnomaly] @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault());
            await Clients.All.SendAsync("ReceiveMessage", context.cc.FromSqlRaw(" exec [dbo].[anlys_CreditOutlierAnomaly] @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault());
            await Clients.All.SendAsync("ReceiveMessage", context.cc.FromSqlRaw("exec [dbo].[anlys_DebitOutlierAnomaly] @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault());
            await Clients.All.SendAsync("ReceiveMessage", context.cc.FromSqlRaw("exec [dbo].[anlys_CreditUnusualAmount] @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault());
            await Clients.All.SendAsync("ReceiveMessage", context.cc.FromSqlRaw("exec anlys_WeekendPost @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault());
            await Clients.All.SendAsync("ReceiveMessage", context.cc.FromSqlRaw("exec anlys_OutsideworkinghoursPost @engagementID,@sod,@eod", param1, param3, param4).AsEnumerable().Select(e => e.id).FirstOrDefault());
            await Clients.All.SendAsync("ReceiveMessage", context.cc.FromSqlRaw(" exec [dbo].[anlys_StartEndOfYear] @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault());
            await Clients.All.SendAsync("ReceiveMessage", context.cc.FromSqlRaw(" exec [dbo].[anlys_Q1s] @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault());
            await Clients.All.SendAsync("ReceiveMessage", context.cc.FromSqlRaw("exec [dbo].[anlys_Q2s] @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault());
            await Clients.All.SendAsync("ReceiveMessage", context.cc.FromSqlRaw("exec [dbo].[anlys_Q3s] @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault());
            await Clients.All.SendAsync("ReceiveMessage", context.cc.FromSqlRaw("exec [dbo].[anlys_Q4s] @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault());
            await Clients.All.SendAsync("ReceiveMessage", context.cc.FromSqlRaw("exec [dbo].[anlys_Q1e] @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault());
            await Clients.All.SendAsync("ReceiveMessage", context.cc.FromSqlRaw(" exec [dbo].[anlys_Q2e] @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault());
            await Clients.All.SendAsync("ReceiveMessage", context.cc.FromSqlRaw(" exec [dbo].[anlys_Q3e] @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault());
            await Clients.All.SendAsync("ReceiveMessage", context.cc.FromSqlRaw("exec [dbo].[anlys_Q4e] @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault());
            await Clients.All.SendAsync("ReceiveMessage", context.cc.FromSqlRaw(" exec [dbo].[anlys_StartofMonth] @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault());
            await Clients.All.SendAsync("ReceiveMessage", context.cc.FromSqlRaw(" exec [dbo].[anlys_EndofMonth]  @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault());
            await Clients.All.SendAsync("ReceiveMessage", context.cc.FromSqlRaw(" exec [dbo].[anlys_debit_credit_last_3]  @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault());
            await Clients.All.SendAsync("ReceiveMessage", context.cc.FromSqlRaw(" exec [dbo].[anlys_ZeroEntry]  @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault());
            await Clients.All.SendAsync("ReceiveMessage", context.cc.FromSqlRaw("exec [dbo].[anlys_RareFlowsCredit]  @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault());
            await Clients.All.SendAsync("ReceiveMessage", context.cc.FromSqlRaw("exec [dbo].[anlys_RareFlowsDebit]  @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault());
            await Clients.All.SendAsync("ReceiveMessage", context.cc.FromSqlRaw(" exec [dbo].[anlys_CreditMaterialValue]  @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault());
            await Clients.All.SendAsync("ReceiveMessage", context.cc.FromSqlRaw(" exec [dbo].[anlys_DebitMaterialValue]  @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault());
            await Clients.All.SendAsync("ReceiveMessage", context.cc.FromSqlRaw(" exec [dbo].[anlys_Duplicates]  @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault());
            await Clients.All.SendAsync("ReceiveMessage", context.cc.FromSqlRaw("exec [dbo].[anlys_Reversals]  @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault());
            await Clients.All.SendAsync("ReceiveMessage", context.cc.FromSqlRaw(" exec [dbo].[anlys_recon]  @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault());
            await Clients.All.SendAsync("ReceiveMessage", context.cc.FromSqlRaw(" exec [dbo].[anlys_UNBALANCED_DEBITS_CREDITS]  @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault());
            await Clients.All.SendAsync("ReceiveMessage", context.cc.FromSqlRaw("exec [dbo].[anlys_ReportingAdjustment]  @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault());
            await Clients.All.SendAsync("ReceiveMessage", context.cc.FromSqlRaw(" exec [dbo].[anlys_SusWords]  @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault());
            await Clients.All.SendAsync("ReceiveMessage", context.cc.FromSqlRaw("exec [dbo].[anlys_CashExpenditures]  @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault());
            await Clients.All.SendAsync("ReceiveMessage", context.cc.FromSqlRaw("exec [dbo].[anlys_risk_calc]  @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault());
            
        }
    }
}
