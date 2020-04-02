using realSafewayz.Models;
using realSafewayz.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SQLite;
using System.Threading.Tasks;

namespace realSafewayz.Services
{
    public class SafeWayZDatabase : IDatabase
    {
        private SQLiteAsyncConnection userDatabase;

        public SafeWayZDatabase()
        {
            var dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "Information.db3");

            userDatabase = new SQLiteAsyncConnection(dbPath);
            userDatabase.CreateTableAsync<UserProfile>().Wait();
            userDatabase.CreateTableAsync<IncidentReport>().Wait();
        }


        //USER PROFILE DATABASE STUFF
        /////////////////////////////////////////////////////////////////////////////

        public Task<List<UserProfile>> GetAllInformationData()
        {
            return userDatabase.Table<UserProfile>().ToListAsync();
        }

        public Task<UserProfile> GetPeopleById(int id)
        {
            return userDatabase.Table<UserProfile>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> DeleteAllInformation()
        {
            return userDatabase.DeleteAllAsync<UserProfile>();
        }

        public Task<int> SaveItemAsync(UserProfile info)
        {
            return userDatabase.InsertAsync(info);
        }

        //INCIDENT REPORTS DATABASE STUFF
        /////////////////////////////////////////////////////////////////////////////
        public async Task<List<IncidentReport>> GetAllIncidentReportInformationData()
        {
            return await userDatabase.Table<IncidentReport>().ToListAsync();
        }

        public Task<IncidentReport> GetIncidentById(int id)
        {
            return userDatabase.Table<IncidentReport>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> DeleteAllIncidentReportInformation()
        {
            return userDatabase.DeleteAllAsync<IncidentReport>();
        }

        public Task<int> SaveIncidentReportAsync(IncidentReport newReport)
        {
            return userDatabase.InsertAsync(newReport);
        }

        //POINT ALLOCATION STUFF
        /////////////////////////////////////////////////////////////////////////////
        public void BeginnerPointAllocation()
        {
            var gamification = new UserProfile
            {
                UserPoints = 200
            };
        }

        public void addPoints(UserProfile currentUser, int pointsToAdd)
        {
            currentUser.UserPoints += pointsToAdd;
            //UPDATE THE USERS POINTS IN THE DATABASE
            //userDatabase.UpdateUsersPointsAsync();
        }
    }
}
