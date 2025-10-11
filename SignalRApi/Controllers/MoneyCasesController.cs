using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System.Globalization;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoneyCasesController : ControllerBase
    {
        private readonly IMoneyCaseService _moneyCaseService;
        public MoneyCasesController(IMoneyCaseService moneyCaseService)
        {
            _moneyCaseService = moneyCaseService;
        }

        [HttpPost("AddTotalMoneyCaseAmount")]
        public IActionResult AddTotalMoneyCaseAmount([FromQuery] string amount)
        {
            if (decimal.TryParse(amount, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal finalAmount))
            {
                _moneyCaseService.TAddTotalMoneyCaseAmount(finalAmount);
                return Ok("Toplam tutar kasaya başarıyla eklendi.");
            }
            return BadRequest("Geçersiz tutar formatı.");
        }
    }
}