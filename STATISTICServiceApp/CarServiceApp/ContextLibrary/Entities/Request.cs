using CarServiceApp.ContextLibrary.Enums;
using ContextLibrary.Enums;

namespace ContextLibrary.Entities
{
    /// <summary>
    /// Сущность "Заявка"
    /// </summary>
    public class Request
    {
        /// <summary>
        /// Номер заявки
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Дата добавления
        /// </summary>
        public DateTime AddedDate { get; set; }
        /// <summary>
        /// Дата окончания заявки
        /// </summary>
        public DateTime? CompletionDate { get; set; }

        /// <summary>
        /// Время выполнения заявки (в часах)
        /// </summary>
        public double? Duration => CompletionDate.HasValue ? (CompletionDate.Value - AddedDate).TotalHours : (double?)null;

        /// <summary>
        /// Тип техники
        /// </summary>
        public DeviceType DeviceType { get; set; }

        /// <summary>
        /// Модель техники
        /// </summary>
        public required string DeviceModel { get; set; }

        /// <summary>
        /// Описание проблемы
        /// </summary>
        public required string ProblemDescription { get; set; }

        /// <summary>
        /// ФИО клиента
        /// </summary>
        public required string ClientLFP { get; set; }

        /// <summary>
        /// Номер телефона клиента
        /// </summary>
        public required string PhoneNumber { get; set; }

        /// <summary>
        /// Статус заявки
        /// </summary>
        public RequestStatus Status { get; set; }

        /// <summary>
        /// Ответственный мастер
        /// </summary>
        public Mechanic ResponsibleMechanic { get; set; }
        public Mechanic? Mechanic { get; set; } // Связь с мастером

        /// <summary>
        /// Этап выполнения
        /// </summary>
        public RequestStage Stage { get; set; }
    }
}