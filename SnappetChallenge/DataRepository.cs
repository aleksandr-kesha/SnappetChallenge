using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using SnappetChallenge.Models;

namespace SnappetChallenge
{
    public class DataRepository
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