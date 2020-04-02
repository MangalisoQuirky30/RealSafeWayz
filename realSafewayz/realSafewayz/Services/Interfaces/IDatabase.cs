using realSafewayz.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace realSafewayz.Services.Interfaces
{
    public interface IDatabase
    {
        //USER PROFILE RELATED QUERIES COME HERE
        ///////////////////////////////////////////////////////////////////////////////
        Task<int> SaveItemAsync(UserProfile info);
        Task<List<UserProfile>> GetAllInformationData();
        Task<UserProfile> GetPeopleById(int id);


        //INCIDENT REPORT RELATED QUERIES COME HERE
        ///////////////////////////////////////////////////////////////////////////////
        Task<List<IncidentReport>> GetAllIncidentReportInformationData();
        Task<IncidentReport> GetIncidentById(int id);
        Task<int> DeleteAllIncidentReportInformation();
        Task<int> SaveIncidentReportAsync(IncidentReport newReport);
    }
}
