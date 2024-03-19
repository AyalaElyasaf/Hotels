using BL.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BLApi;

public  interface IReservationBL
{
    public List<BLReservation> GetReservationList();
    public List<BLReservation> GetReservationListByID(int id);
    public bool removeReservation(int id);
    public string addReservation(BLReservation reservation);
}
