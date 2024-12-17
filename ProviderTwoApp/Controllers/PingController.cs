using Microsoft.AspNetCore.Mvc;

namespace ProviderTwoApp.Controllers
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
        public IActionResult Ping(CancellationToken cancellationToken)
        {
            // Эмуляция нестабильности в работе:
            // - берём текущее время
            // - если секунды находятся в диапазоне 0-50, то сервис работает нормально
            // - для остальных значений секунд сервис не работает

            return DateTime.UtcNow.Second switch
            {
                >= 0 and <= 50 => Ok(),
                _ => new StatusCodeResult(StatusCodes.Status500InternalServerError)
            };
        }
    }
}
