using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dimaticaAPI.Models;
using MongoDB.Driver;

namespace dimaticaAPI.Services
{
    /// <summary>
    /// This service should be configured in startup.cs as a singleton lifetime
    /// </summary>
    public class DutyService
    {
        private readonly IMongoCollection<Duty> _duties;
        /// <summary>
        /// Constructor which uses appsettings data for establising DB connection
        /// </summary>
        /// <param name="settings"></param>
        public DutyService(IDutiesDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _duties = database.GetCollection<Duty>(settings.DutiesCollectionName);
        }
        /// <summary>
        /// Get list of existing duties
        /// </summary>
        /// <returns></returns>
        public List<Duty> Get() =>
            _duties.Find(duty => true).ToList();

        /// <summary>
        /// Get duty by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Duty Get(string id) =>
            _duties.Find<Duty>(book => book.Id == id).FirstOrDefault();

        /// <summary>
        /// Create duty
        /// </summary>
        /// <param name="duty"></param>
        /// <returns></returns>
        public Duty Create(Duty duty)
        {

            _duties.InsertOne(duty);
            return duty;
        }
        /// <summary>
        /// Update duty
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newDuty"></param>
        public void Update(string id, Duty newDuty) =>
            _duties.ReplaceOne(duty => duty.Id == id, newDuty);

        /// <summary>
        /// Remove by duty
        /// </summary>
        /// <param name="remDuty"></param>
        public void Remove(Duty remDuty) =>
            _duties.DeleteOne(duty => duty.Id == remDuty.Id);

        /// <summary>
        /// Remove by id
        /// </summary>
        /// <param name="id"></param>
        public void Remove(string id) =>
            _duties.DeleteOne(book => book.Id == id);
    }
}

