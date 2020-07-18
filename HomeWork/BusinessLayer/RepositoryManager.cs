using AutoMapper;
using BusinessLayer.Models;
using DataAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{

    public class RepositoryManager
    {
        public readonly QuadraticEquationRepository _quadraticEquationRepository;
        private readonly Mapper _mapper;
        public RepositoryManager()
        {
            _quadraticEquationRepository = new QuadraticEquationRepository();
            var conf = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<QuadraticEquation, QuadraticEquationDTO>();
                cfg.CreateMap<QuadraticEquationDTO, QuadraticEquation>();
            });
            _mapper = new Mapper(conf);
        }

        public const double four = 4;   

        public QuadraticEquationDTO GetRoots(QuadraticEquationDTO quadraticEquationDTO)
        {
            double discriminant =  Math.Round(Math.Pow(quadraticEquationDTO.B, 2) - (four * (quadraticEquationDTO.A * quadraticEquationDTO.C)));
            quadraticEquationDTO.D = discriminant;
            
            if (discriminant > 0)
            {
                quadraticEquationDTO.X1 = Math.Round((-quadraticEquationDTO.B + Math.Sqrt(discriminant)) / (2 * quadraticEquationDTO.A));
                quadraticEquationDTO.X2 = Math.Round((-quadraticEquationDTO.B - Math.Sqrt(discriminant)) / (2 * quadraticEquationDTO.A)); 
            }
            else if (discriminant == 0)
            {
                quadraticEquationDTO.X1 = Math.Round((-quadraticEquationDTO.B + Math.Sqrt(discriminant)) / (2 * quadraticEquationDTO.A));
                quadraticEquationDTO.X2 = null;                
            }
            else
            {
                quadraticEquationDTO.X1 = null;
                quadraticEquationDTO.X2 = null;
                
            }
            var mapDTO = _mapper.Map<QuadraticEquation>(quadraticEquationDTO);
            _quadraticEquationRepository.SaveQuadraticEquation(mapDTO);            
            return quadraticEquationDTO;
        }


    }
}
