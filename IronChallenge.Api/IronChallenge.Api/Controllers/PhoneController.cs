using IronChallenge.Domain.Interface;
using Microsoft.AspNetCore.Mvc;

namespace IronChallenge.Api.Controllers
{
    [Route("api")]
    public class PhoneController(IPhoneRepository iPhoneRepository) : Controller
    {
        private readonly IPhoneRepository _iPhoneRepository = iPhoneRepository;

        /// <summary>
        /// Accepts a set of characters and returns its equivalent in letters 
        /// </summary>
        /// <param name="input"></param>
        /// <returns> leters or '' if has not number the input</returns>
        [HttpGet("{input}")]
        public IActionResult Index(string input)
        {
            var output = _iPhoneRepository.OldPhonePad(input);
            return StatusCode(output.Item1, new { OutPut = output.Item2});
        }
    }
}
