using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ASP5.Models;

namespace ASP5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private static List<Car> cars = new List<Car>
        {
            new Car { Id = 1, Brand = "Toyota", Model = "Camry", Year = 2020, Price = 25000 },
            new Car { Id = 2, Brand = "Honda", Model = "Civic", Year = 2021, Price = 23000 },
            new Car { Id = 3, Brand = "BMW", Model = "X5", Year = 2022, Price = 60000 }
        };

        // 1) Отримати всі машини з пагінацією
        [HttpGet]
        public ActionResult<IEnumerable<Car>> GetCars(int page = 1, int pageSize = 10)
        {
            var paginatedCars = cars.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return Ok(paginatedCars);
        }

        // 2) Отримати машину по Id
        [HttpGet("{id}")]
        public ActionResult<Car> GetCar(int id)
        {
            var car = cars.FirstOrDefault(c => c.Id == id);
            if (car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }

        // 3) Отримати усі машини по бренду
        [HttpGet("brand/{brand}")]
        public ActionResult<IEnumerable<Car>> GetCarsByBrand(string brand)
        {
            var filteredCars = cars.Where(c => c.Brand.ToLower() == brand.ToLower()).ToList();
            if (filteredCars.Count == 0)
            {
                return NotFound();
            }
            return Ok(filteredCars);
        }

        // 4) Додати машину
        [HttpPost]
        public ActionResult<Car> AddCar(Car car)
        {
            car.Id = cars.Max(c => c.Id) + 1; // генеруємо новий Id
            cars.Add(car);
            return CreatedAtAction(nameof(GetCar), new { id = car.Id }, car);
        }

        // 5) Видалити машину по id
        [HttpDelete("{id}")]
        public IActionResult DeleteCar(int id)
        {
            var car = cars.FirstOrDefault(c => c.Id == id);
            if (car == null)
            {
                return NotFound();
            }
            cars.Remove(car);
            return NoContent();
        }

        // 6) Оновити машину
        [HttpPut("{id}")]
        public IActionResult UpdateCar(int id, Car car)
        {
            var existingCar = cars.FirstOrDefault(c => c.Id == id);
            if (existingCar == null)
            {
                return NotFound();
            }
            existingCar.Brand = car.Brand;
            existingCar.Model = car.Model;
            existingCar.Year = car.Year;
            existingCar.Price = car.Price;

            return NoContent();
        }
    }
}
