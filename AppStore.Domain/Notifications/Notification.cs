using AppStore.Domain.Notifications.Interfaces;

namespace AppStore.Domain.Notifications
{
    public class Notification<T> : INotification
    {
        public object Data { get; init; }
        public object DataOpt { get; init; }
        private List<string> _listErrors { get; init; } = new();
        public IReadOnlyCollection<string> Notifications => _listErrors;

        public Notification(object data, List<string> errors)
        {
            Data = data;
            _listErrors = errors;
        }
        public Notification(object data)
        {
            Data = data;
        
        }
        public Notification(object data, object dataOpt)
        {
            Data = data;
            DataOpt = dataOpt;
        }

        public Notification(List<string> errors) =>_listErrors = errors;
        public Notification(string error) => _listErrors.Add(error);
    }
}
