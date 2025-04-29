using AciesManagmentProject.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AciesManagmentProject
{
    public class StoredProcedureHub : Hub
    {
        private readonly IConfiguration _configuration;

        public async Task SendData(DbA9b860AciesContext context)
        {
            var engagementID = int.Parse(Context.GetHttpContext().Request.Query["engagementID"]);
            SqlParameter param1 = new SqlParameter("@engagementID", SqlDbType.Int);
            SqlParameter param3 = new SqlParameter("@sod", SqlDbType.Time);
            SqlParameter param4 = new SqlParameter("@eod", SqlDbType.Time);
            param1.Value = engagementID;
            param3.Value = "08:00:00.0000000";
            param4.Value = "18:00:00.0000000";
            context.cc.FromSqlRaw("exec [anlys_DayOfTheWeek] @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault();
            await Clients.All.SendAsync("ReceiveMessage",(int)((1d/33)*100));
            context.cc.FromSqlRaw("exec anlys_EmptyFields @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault();
            await Clients.All.SendAsync("ReceiveMessage", (int)((2d / 33) * 100));
            context.cc.FromSqlRaw("exec [dbo].[anlys_EmptyFields]  @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault();
            await Clients.All.SendAsync("ReceiveMessage", (int)((3d / 33) * 100));
            context.cc.FromSqlRaw(" exec [dbo].[anlys_CreditOutlierAnomaly] @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault();
            await Clients.All.SendAsync("ReceiveMessage", (int)((4d / 33) * 100));
            context.cc.FromSqlRaw("exec [dbo].[anlys_DebitOutlierAnomaly] @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault();
            await Clients.All.SendAsync("ReceiveMessage", (int)((5d / 33) * 100));
            context.cc.FromSqlRaw("exec [dbo].[anlys_CreditUnusualAmount] @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault();
            await Clients.All.SendAsync("ReceiveMessage", (int)((6d / 33) * 100));
            context.cc.FromSqlRaw("exec anlys_WeekendPost @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault();
            await Clients.All.SendAsync("ReceiveMessage", (int)((7d / 33) * 100));
            context.cc.FromSqlRaw("exec anlys_OutsideworkinghoursPost @engagementID,@sod,@eod", param1, param3, param4).AsEnumerable().Select(e => e.id).FirstOrDefault();
            await Clients.All.SendAsync("ReceiveMessage", (int)((8d / 33) * 100));
            context.cc.FromSqlRaw(" exec [dbo].[anlys_StartEndOfYear] @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault();
            await Clients.All.SendAsync("ReceiveMessage", (int)((9d / 33) * 100));
            context.cc.FromSqlRaw(" exec [dbo].[anlys_Q1s] @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault();
            await Clients.All.SendAsync("ReceiveMessage", (int)((10d / 33) * 100));
            context.cc.FromSqlRaw("exec [dbo].[anlys_Q2s] @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault();
            await Clients.All.SendAsync("ReceiveMessage", (int)((11d / 33) * 100));
            context.cc.FromSqlRaw("exec [dbo].[anlys_Q3s] @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault();
            await Clients.All.SendAsync("ReceiveMessage", (int)((12d / 33) * 100));
            context.cc.FromSqlRaw("exec [dbo].[anlys_Q4s] @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault();
            await Clients.All.SendAsync("ReceiveMessage", (int)((13d / 33) * 100));
            context.cc.FromSqlRaw("exec [dbo].[anlys_Q1e] @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault();
            await Clients.All.SendAsync("ReceiveMessage",   (int)((14d / 33) * 100));
            context.cc.FromSqlRaw(" exec [dbo].[anlys_Q2e] @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault();
            await Clients.All.SendAsync("ReceiveMessage", (int)((15d / 33) * 100));
            context.cc.FromSqlRaw(" exec [dbo].[anlys_Q3e] @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault();
            await Clients.All.SendAsync("ReceiveMessage", (int)((16d / 33) * 100));
            context.cc.FromSqlRaw("exec [dbo].[anlys_Q4e] @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault();
            await Clients.All.SendAsync("ReceiveMessage", (int)((17d / 33) * 100));
            context.cc.FromSqlRaw(" exec [dbo].[anlys_StartofMonth] @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault();
            await Clients.All.SendAsync("ReceiveMessage", (int)((18d / 33) * 100));
            context.cc.FromSqlRaw(" exec [dbo].[anlys_EndofMonth]  @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault();
            await Clients.All.SendAsync("ReceiveMessage", (int)((19d / 33) * 100));
            context.cc.FromSqlRaw(" exec [dbo].[anlys_debit_credit_last_3]  @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault();
            await Clients.All.SendAsync("ReceiveMessage", (int)((20d / 33) * 100));
            context.cc.FromSqlRaw(" exec [dbo].[anlys_ZeroEntry]  @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault();
            await Clients.All.SendAsync("ReceiveMessage", (int)((21d / 33) * 100));
            context.cc.FromSqlRaw("exec [dbo].[anlys_RareFlowsCredit]  @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault();
            await Clients.All.SendAsync("ReceiveMessage", (int)((22d / 33) * 100));
            context.cc.FromSqlRaw("exec [dbo].[anlys_RareFlowsDebit]  @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault();
            await Clients.All.SendAsync("ReceiveMessage", (int)((23d / 33) * 100));
            context.cc.FromSqlRaw(" exec [dbo].[anlys_CreditMaterialValue]  @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault();
            await Clients.All.SendAsync("ReceiveMessage", (int)((24d / 33) * 100));
            context.cc.FromSqlRaw(" exec [dbo].[anlys_DebitMaterialValue]  @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault();
            await Clients.All.SendAsync("ReceiveMessage", (int)((25d / 33) * 100));
            context.cc.FromSqlRaw(" exec [dbo].[anlys_Duplicates]  @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault();
            await Clients.All.SendAsync("ReceiveMessage", (int)((26d / 33) * 100));
            context.cc.FromSqlRaw("exec [dbo].[anlys_Reversals]  @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault();
            await Clients.All.SendAsync("ReceiveMessage", (int)((27d / 33) * 100));
            context.cc.FromSqlRaw(" exec [dbo].[anlys_recon]  @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault();
            await Clients.All.SendAsync("ReceiveMessage", (int)((28d / 33) * 100));
            context.cc.FromSqlRaw(" exec [dbo].[anlys_UNBALANCED_DEBITS_CREDITS]  @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault();
            await Clients.All.SendAsync("ReceiveMessage", (int)((29d / 33) * 100));
            context.cc.FromSqlRaw("exec [dbo].[anlys_ReportingAdjustment]  @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault();
            await Clients.All.SendAsync("ReceiveMessage", (int)((30d / 33) * 100));
            context.cc.FromSqlRaw(" exec [dbo].[anlys_SusWords]  @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault();
            await Clients.All.SendAsync("ReceiveMessage", (int)((31d / 33) * 100));
            context.cc.FromSqlRaw("exec [dbo].[anlys_CashExpenditures]  @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault();
            await Clients.All.SendAsync("ReceiveMessage", (int)((32d / 33) * 100));
            context.cc.FromSqlRaw("exec [dbo].[anlys_risk_calc]  @engagementID", param1).AsEnumerable().Select(e => e.id).FirstOrDefault();
            await Clients.All.SendAsync("ReceiveMessage", (int)((33d / 33) * 100));
            
        }
    }
}
