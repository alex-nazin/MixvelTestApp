using Microsoft.AspNetCore.Mvc;

namespace ProviderOneApp.Controllers
{
    /// <summary>
    /// Контроллер проверки состояния сервиса
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PingController : ControllerBase
    {
        /// <summary>
        /// Запрос доступности сервиса
        /// </summary>
        [HttpGet]
        public IActionResult Ping()
        {
            // Эмуляция нестабильности в работе:
            // - берём текущее время
            // - если секунды находятся в диапазонах 0-15, 20-35, 40-50, то сервис работает нормально
            // - для остальных значений секунд сервис не работает

            return DateTime.UtcNow.Second switch
            {
                (>= 0 and <= 15) or (>= 20 and <= 35) or (>= 40 and <= 50) => Ok(),
                _ => new StatusCodeResult(StatusCodes.Status500InternalServerError)
            };
        }
    }
}
