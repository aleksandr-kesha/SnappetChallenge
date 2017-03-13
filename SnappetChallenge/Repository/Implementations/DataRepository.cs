using System.Collections.Generic;
using System.Linq;
using SnappetChallenge.Data;
using SnappetChallenge.Models;
using SnappetChallenge.Repository.Interfaces;

namespace SnappetChallenge.Repository.Implementations
{
    public class DataRepository : IDataRepository
    {
        public List<DataModel> GetRawData()
        {
            return DataStore.RawData;
        }

        public List<ResponseModel> GetResponseData()
        {
            return DataStore.ResponseData;
        }

        public List<string> GetSubjects()
        {
           return DataStore.ResponseData.Select(s => s.Subject).Distinct().OrderBy(t => t).ToList();
        }


    }
}