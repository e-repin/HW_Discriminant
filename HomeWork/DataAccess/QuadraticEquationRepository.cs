using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class QuadraticEquationRepository
    {
        public void SaveQuadraticEquation(QuadraticEquation quadraticEquation)
        {
            using (var context = new ContextQuadraticEquation())
            {
                context.QuadraticEquations.Add(quadraticEquation);              
                context.SaveChanges();
            }
        }        
    }
}
