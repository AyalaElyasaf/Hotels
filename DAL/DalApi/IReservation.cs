using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DalApi;

public interface IReservation
{
    public List<Reservation> getReservationList();
    public List<Reservation> getReservationListByID(int id);

    public bool removeReservationt(int id);
    public bool addReservation(Reservation reservation);
}
