﻿using BL.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BLApi;

public interface IRoomBL
{
    public List<BLRoom> GetListRoomsForType(int id, string type);
}
