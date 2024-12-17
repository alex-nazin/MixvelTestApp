namespace MixvelTestApp.Models
{
    /// <summary>
    /// Модель найденного маршрута
    /// </summary>
    public class RouteModel
    {
        /// <summary>
        /// Идентификатор маршрута
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Начальная точка маршрута
        /// </summary>
        public string Origin { get; set; } = null!;

        /// <summary>
        /// Конечная точка маршрута
        /// </summary>
        public string Destination { get; set; } = null!;

        /// <summary>
        /// Дата начала путешествия
        /// </summary>
        public DateTime OriginDateTime { get; set; }

        /// <summary>
        /// Дата завершения путешествия
        /// </summary>
        public DateTime DestinationDateTime { get; set; }

        /// <summary>
        /// Цена путешествия
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Дата/время актуальности маршрута
        /// </summary>
        public DateTime TimeLimit { get; set; }
    }
}
