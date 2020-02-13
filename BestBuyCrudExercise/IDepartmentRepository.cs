using System;
using System.Collections.Generic;

namespace BestBuyCrudExercise
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAllDepartments();
    }
}
