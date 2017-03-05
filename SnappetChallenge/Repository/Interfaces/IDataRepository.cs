using System.Collections.Generic;
using SnappetChallenge.Models;

namespace SnappetChallenge.Repository.Interfaces
{
    public interface IDataRepository : IRepository
    {
        List<DataModel> GetData();
    }
}