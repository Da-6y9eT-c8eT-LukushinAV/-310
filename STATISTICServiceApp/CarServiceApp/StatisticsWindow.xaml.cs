using System.Linq;
using System.Windows;
using ContextLibrary;
using ContextLibrary.Enums;

namespace CarServiceApp
{
    public partial class StatisticsWindow : Window
    {
        private readonly ApplicationContext _context;

        public StatisticsWindow(ApplicationContext context)
        {
            InitializeComponent();
            _context = context;
            LoadStatistics();
        }

        private void LoadStatistics()
        {
            int totalRequests = _context.Requests.Count();
            int newRequests = _context.Requests.Count(r => r.Status == RequestStatus.New);
            int inProcessRequests = _context.Requests.Count(r => r.Status == RequestStatus.InProcess);
            int completedRequests = _context.Requests.Count(r => r.Status == RequestStatus.Completed);

            TotalRequests.Text = $"Всего заявок: {totalRequests}";
            NewRequests.Text = $"Новые: {newRequests}";
            InProcessRequests.Text = $"В процессе: {inProcessRequests}";
            CompletedRequests.Text = $"Завершенные: {completedRequests}";

            // Загрузка данных по механикам и их заявкам
            var mechanicStats = _context.Mechanics
                .Select(m => new
                {
                    Id = m.Id,  // Добавьте Id механика
                    Name = m.LFP,  // ФИО мастера
                    Count = m.Requests.Count(r => r.ResponsibleMechanic.Id == m.Id),  // Количество заявок по Id механика
                    AverageDuration = m.Requests.Where(r => r.Duration.HasValue).Average(r => r.Duration) // Среднее время выполнения
                })
                .ToList();

            MechanicStats.ItemsSource = mechanicStats;

        }





        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
