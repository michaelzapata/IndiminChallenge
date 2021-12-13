using Indimin.Challenge.Tasking.Domain.Contracts;

namespace Indimin.Challenge.Tasking.Domain.Models
{
    public class CitizenTask : Entity<long>, IAggregateRoot
    {
        private int _dayOfWeek;
        private string _citizenId;
        private string _description;
        private bool _isActive;
        protected CitizenTask() { }

        public CitizenTask(int dayOfWeek, string citizenId, string description, bool isActive)
        {
            _dayOfWeek = DayOfWeek.From(dayOfWeek).Id;
            _citizenId = citizenId;
            _description = description;
            _isActive = isActive;
        }
        public DayOfWeek DayOfWeek => DayOfWeek.From(_dayOfWeek);
        public string CitizenId => _citizenId;
        public string Description => _description;
        public bool IsActive => _isActive;
        public void DesactivateCitizenTask() { _isActive = false; }
        public void ChangeDescription(string description) { _description = description; }
        public void ChangeDayOfWeek(int dayOfWeek) { _dayOfWeek = dayOfWeek;}
        public void ChangeState(bool isActive) { _isActive = isActive;}
    }
}
