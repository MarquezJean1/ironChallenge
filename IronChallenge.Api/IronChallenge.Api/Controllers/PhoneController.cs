using IronChallenge.Domain.Interface;
using Microsoft.AspNetCore.Mvc;

namespace IronChallenge.Api.Controllers
{
    [Route("api")]
    public class PhoneController(IPhoneRepository iPhoneRepository) : Controller
    {
        private readonly IPhoneRepository _iPhoneRepository = iPhoneRepository;

        [HttpGet("{input}")]
        public IActionResult Index(string input)
        {
            var output = _iPhoneRepository.OldPhonePad(input);
            return StatusCode(output.Item1, new { OutPut = output.Item2});
        }
    }
}
