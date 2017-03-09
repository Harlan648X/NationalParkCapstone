using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public interface IParkListDAL
    {
        List<ParkListModel> GetAllParks();
        ParkListModel GetPark(string parkCode, char unit);
    }
}