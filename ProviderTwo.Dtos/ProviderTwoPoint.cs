using System.ComponentModel.DataAnnotations;

namespace ProviderTwo.Dtos
{
    /// <summary>
    /// Точка отправления или прибытия
    /// </summary>
    public class ProviderTwoPoint
    {
        /// <summary>
        /// Название точки
        /// </summary>
        [Required]
        public string Point { get; set; } = null!;

        /// <summary>
        /// Дата, в корорую необходимо быть в точке
        /// </summary>
        [Required]
        public DateTime Date { get; set; }
    }
}
