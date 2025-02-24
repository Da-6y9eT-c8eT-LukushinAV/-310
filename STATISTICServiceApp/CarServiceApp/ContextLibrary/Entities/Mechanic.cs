using ContextLibrary.Entities;

public class Mechanic
{
    public int Id { get; set; }  // Добавьте это свойство

    /// <summary>
    /// ФИО
    /// </summary>
    public string LFP { get; set; }

    /// <summary>
    /// Список заявок, которые закреплены за мастером
    /// </summary>
    public List<Request> Requests { get; set; } = new List<Request>();
}
