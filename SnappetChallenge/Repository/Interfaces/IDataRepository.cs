using System.Collections.Generic;
using SnappetChallenge.Models;

namespace SnappetChallenge.Repository.Interfaces
{
    public interface IDataRepository
    {
        List<DataModel> GetRawData();
        List<ResponseModel> GetResponseData();

        List<string> GetSubjects();
    }
}