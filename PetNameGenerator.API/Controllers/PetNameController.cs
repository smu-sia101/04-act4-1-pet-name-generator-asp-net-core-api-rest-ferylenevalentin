using Microsoft.AspNetCore.Mvc;

namespace PetNameGenerator.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetNameController : ControllerBase
    {
        [HttpPost("/generate")]
        public IActionResult Post([FromQuery] string animalType, [FromQuery] bool? hasLastName)
        {

            if (string.IsNullOrEmpty(animalType))
            {
                return BadRequest(new { error = "The 'animalType' field is required." });
            }

            animalType = animalType.ToLower();

            if (animalType != "dog" && animalType != "cat" && animalType != "bird")
            {
                return BadRequest(new { error = "Invalid animal type. Allowed values: dog, cat, bird." });
            }

            if (hasLastName.HasValue && !hasLastName.HasValue)
            {
                return BadRequest(new { error = "The 'hasLastName' field must be a boolean (true or false)." });
            }


            bool useLastName = hasLastName ?? false;

            string firstName = "";
            string lastName = "";

            Random rnd = new Random();
            int randomIndex = rnd.Next(0, 5);


            if (animalType == "dog")
            {
                firstName = Constants.Names.Dog.First[randomIndex];
                if (useLastName)
                {
                    lastName = Constants.Names.Dog.Last[randomIndex];
                }
            }
            else if (animalType == "cat")
            {
                firstName = Constants.Names.Cat.First[randomIndex];
                if (useLastName)
                {
                    lastName = Constants.Names.Cat.Last[randomIndex];
                }
            }
            else if (animalType == "bird")
            {
                firstName = Constants.Names.Bird.First[randomIndex];
                if (useLastName)
                {
                    lastName = Constants.Names.Bird.Last[randomIndex];
                }
            }


            if (useLastName)
            {
                return Ok(new { firstName, lastName });
            }
            else
            {
                return Ok(new { firstName });
            }
        }
    }
}
    