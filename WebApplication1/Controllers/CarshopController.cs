using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication1.DB;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CarshopController : Controller
    {
        // GET: Carshop
        public ActionResult Index()
        {
            var carshops = Database.Get().Carshops.ToList();
            var carDTOs = new List<CarDTO>();

            foreach (var carshop in carshops)
            {
                var carDTO = new CarDTO()
                {
                    Id = carshop.Id,
                    Model = carshop.Model,
                    Year = carshop.Year,
                };
                carDTOs.Add(carDTO);
            }

            return View(carDTOs);
        }

        public ActionResult Details(int id)
        {
            //var carshops = Database.Get().Carshops.ToList();
            //var carDetailDTO = new CarDetailsDTO();

            //foreach (var carshop in carshops)
            //{
            //    if (carshop.Id == id)
            //    {
            //        carDetailDTO.Id = carshop.Id;
            //        carDetailDTO.Model = carshop.Model;
            //        carDetailDTO.Year = carshop.Year;
            //        carDetailDTO.MaxSpeed = carshop.MaxSpeed;
            //        carDetailDTO.Color = carshop.Color;
            //        carDetailDTO.MotorCapalist = carshop.MotorCapalist;
            //    }
            //}


            var carshop = Database.Get().Carshops.FirstOrDefault(x => x.Id == id);
            var carDetailDTO = new CarDetailsDTO();

            carDetailDTO.Id = carshop.Id;
            carDetailDTO.Model = carshop.Model;
            carDetailDTO.Year = carshop.Year;
            carDetailDTO.MaxSpeed = carshop.MaxSpeed;
            carDetailDTO.Color = carshop.Color;
            carDetailDTO.MotorCapalist = carshop.MotorCapalist;

            return View(carDetailDTO);
        }

        public ActionResult Delete(int id)
        {
            //var carshops = Database.Get().Carshops.ToList();

            //foreach (var carshop in carshops)
            //{
            //    if (carshop.Id == id)
            //    {
            //        Database.Get().Carshops.DeleteOnSubmit(carshop);
            //        Database.Get().SubmitChanges();
            //    }
            //}
            var carshop = Database.Get().Carshops.FirstOrDefault(x => x.Id == id);

            Database.Get().Carshops.DeleteOnSubmit(carshop);
            Database.Get().SubmitChanges();

            return View(carshop);
        }

        public ActionResult Edit(int id)
        {
            var carshop = Database.Get().Carshops.FirstOrDefault(x => x.Id == id);
            var carDetailsDTO = new CarDetailsDTO();

            carDetailsDTO.Id = carshop.Id;
            carDetailsDTO.Model = carshop.Model;
            carDetailsDTO.Year = carshop.Year;
            carDetailsDTO.Color = carshop.Color;
            carDetailsDTO.MaxSpeed = carshop.MaxSpeed;
            carDetailsDTO.MotorCapalist = carshop.MotorCapalist;

            return View(carDetailsDTO);
        }

        public ActionResult EditeSawe(CarDetailsDTO carDetailsDTO)
        {
            var carshop = Database.Get().Carshops.FirstOrDefault(x => x.Id == carDetailsDTO.Id);

            carshop.Model = carDetailsDTO.Model;
            carshop.Year = carDetailsDTO.Year;
            carshop.Color = carDetailsDTO.Color;
            carshop.MaxSpeed = carDetailsDTO.MaxSpeed;
            carshop.MotorCapalist = carDetailsDTO.MotorCapalist;

            Database.Get().SubmitChanges();

            return View(carDetailsDTO);
        }

        public ActionResult Create()
        {
            var carDetailsDTO = new CarDetailsDTO();


            return View(carDetailsDTO);
        }

        public ActionResult CreateNew(CarCreateDTO carCreateDTO)
        {
            var carshop = new Carshop();

            carshop.Model = carCreateDTO.Model;
            carshop.Year = carCreateDTO.Year;
            carshop.Color = carCreateDTO.Color;
            carshop.MaxSpeed = carCreateDTO.MaxSpeed;
            carshop.MotorCapalist = carCreateDTO.MotorCapalist;

            Database.Get().Carshops.InsertOnSubmit(carshop);
            Database.Get().SubmitChanges();

            return View(carCreateDTO);
        }
    }
}