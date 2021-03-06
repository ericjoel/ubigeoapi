﻿using Common.Model;

namespace Common.DataAccessContracts
{
    /// <summary>
    /// Inherit IRepository and can specified get specifis methods
    /// </summary>
    public interface IDepartmentRepository : IRepository<Department>
    {
    }
}
