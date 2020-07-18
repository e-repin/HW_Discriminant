using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    class ContextQuadraticEquation : DbContext
    {
        public ContextQuadraticEquation() : base("DefaultConnection")
        {            
        }
        public DbSet<QuadraticEquation> QuadraticEquations { get; set; }
    }
}
