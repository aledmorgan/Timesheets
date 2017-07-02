using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timesheets.Contracts;
using Timesheets.Dtos;

namespace Timesheets.Implementations.TimesheetRepository
{
    public class TimesheetRepository : ITimesheetRepository
    {
        private IMongoCollection<Timesheet> _collection;
        private const string _databaseName = "timesheets";
        private const string _collectionsName = "timesheets";

        public TimesheetRepository()
        {
            var client = new MongoClient();
            var db = client.GetDatabase(_databaseName);
            _collection = db.GetCollection<Timesheet>(_collectionsName);
        }

        public void Insert(Timesheet newTimesheet)
        {
            try
            {
                _collection.InsertOne(newTimesheet);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InsertMany(IEnumerable<Timesheet> newTimesheets)
        {
            try
            {
                _collection.InsertMany(newTimesheets);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(string id)
        {
            try
            {
                var filter = Builders<Timesheet>.Filter.Eq("Id", id);
                _collection.DeleteOne(filter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Timesheet Get(string id)
        {
            try
            {
                var filter = Builders<Timesheet>.Filter.Eq("Id", id);
                return _collection.Find(filter).First();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Timesheet> GetAll()
        {
            try
            {
                return _collection.Find(_ => true).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteMany(IEnumerable<string> ids)
        {
            try
            {
                var filter = Builders<Timesheet>.Filter.In("Id", ids);
                _collection.DeleteMany(filter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Timesheet> Search(SearchRequest request)
        {
            try
            {
                var filter = Builders<Timesheet>.Filter.And(
                    Builders<Timesheet>.Filter.Where(x => x.CandidateName.ToLower().Contains(request.CandidateName.ToLower())),
                    Builders<Timesheet>.Filter.Where(x => x.ClientName.ToLower().Contains(request.ClientName.ToLower())),
                    Builders<Timesheet>.Filter.Gte(new StringFieldDefinition<Timesheet, BsonDateTime>("StartDate"), new BsonDateTime(request.From)),
                    Builders<Timesheet>.Filter.Lte(new StringFieldDefinition<Timesheet, BsonDateTime>("EndDate"), new BsonDateTime(request.To))
                    );

                return _collection.Find(filter).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
