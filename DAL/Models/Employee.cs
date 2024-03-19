using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Employee
{
    public int Id { get; set; }

    public int HotelId { get; set; }

    public string EmployeeName { get; set; } = null!;

    public string EmployeeJob { get; set; } = null!;

    public int EmployeeSalaryForMonth { get; set; }

    public virtual Hotel Hotel { get; set; } = null!;
}
