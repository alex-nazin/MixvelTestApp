namespace MixvelTestApp.Models
{
    /// <summary>
    /// Модель результата поиска маршрута
    /// </summary>
    public class SearchResponseModel
    {
        /// <summary>
        /// Набор найденных маршрутов
        /// </summary>
        public RouteModel[] Routes { get; set; } = null!;

        /// <summary>
        /// Минимальная цена
        /// </summary>
        public decimal MinPrice { get; set; }

        /// <summary>
        /// Максимальная цена
        /// </summary>
        public decimal MaxPrice { get; set; }

        /// <summary>
        /// Минимальная продолжительность маршрута
        /// </summary>
        public int MinMinutesRoute { get; set; }

        /// <summary>
        /// Максимальная продолжительность маршрута
        /// </summary>
        public int MaxMinutesRoute { get; set; }
    }
}
