using AutoMapper;
using BusinessLayer;
using BusinessLayer.Models;
using DataAccess;
using DataAccess.Models;
using HomeWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeWork.Controllers
{
    
    public class QuadraticEquationController : Controller
    {
        public readonly QuadraticEquationRepository _quadraticEquationRepository;
        private readonly Mapper _mapper;
       
        private readonly RepositoryManager _repositoryManager;
        public QuadraticEquationController()
        {
            _repositoryManager = new RepositoryManager();
            _quadraticEquationRepository = new QuadraticEquationRepository();
            var conf = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<QuadraticEquationPL, QuadraticEquationDTO>();
                cfg.CreateMap<QuadraticEquationDTO, QuadraticEquationPL>();
            });
            _mapper = new Mapper(conf);
        }

        public ActionResult CreateEquation()
        {
            return View();
        }        

        [HttpPost]
        public ActionResult CreateEquation(QuadraticEquationPL quadraticEquationPL)
        {
            var mapPL =_mapper.Map<QuadraticEquationDTO>(quadraticEquationPL);            
            _repositoryManager.GetRoots(mapPL);
            var modelPL = _mapper.Map<QuadraticEquationPL>(mapPL);
            return View("SolvedEquation", modelPL);
        }



    }
}