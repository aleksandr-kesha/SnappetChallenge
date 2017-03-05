using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using SnappetChallenge.Models;
using SnappetChallenge.Repository.Interfaces;

namespace SnappetChallenge.Repository.Implementations
{
    public class DataRepository : IDataRepository
    {
        public List<DataModel> GetData()
        {
            var path = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/work.json");

            List<DataModel> obj;

            using (var reader = new StreamReader(path))
            {
                using (var jsonReader = new JsonTextReader(reader))
                {
                    var serializer = new Newtonsoft.Json.JsonSerializer();
                    obj = serializer.Deserialize<List<DataModel>>(jsonReader);
                }
            }

            return obj;
        } 
    }
}