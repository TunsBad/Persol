using Persol.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Persol.API
{
    public class CarsController : ApiController
    {
        [HttpGet]
        public List<Car> GetAllCars()
        {
            List<Car> cars = new List<Car>() { };

            try
            {
                cars = DbHelper.Instance.GetCars();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            };

            return cars;
        }

        [HttpGet]
        public Car GetCar(int id)
        {
            Car carInfo = new Car { };

            try
            {
                carInfo = DbHelper.Instance.GetCar(id);
            } 
            catch(Exception ex)
            {
                Console.Write(ex);
            }

            return carInfo;
        }

        [HttpPost]
        public string StoreCar([FromBody]Car car)
        {
            var response = "";

            try
            {
                var id = DbHelper.Instance.StoreCar(car);
                if(id > 0)
                    return "Car details has successfully been stored";
            } 
            catch(Exception ex)
            {
                Console.Write(ex);
                response = "An Error Occured";
            }

            return response;
        }

        [HttpPut]
        public string UpdateCar([FromBody]Car car)
        {
            var response = "";

            try
            {
                int id = DbHelper.Instance.UpdateCar(car);
                if (id > 0)
                    return "Car details Has successfully Been Stored";
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                response = "An Error Occured";
            }

            return response;
        }

        [HttpGet]
        public string DeleteCar(int id)
        {
            var response = "";
            try
            {
                int cardId = DbHelper.Instance.DeleteCar(id);
                if(id == cardId)
                {
                    return "The car has been removed";
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                response = "An Error Occured";
            }

            return response;
        }
    }
}
