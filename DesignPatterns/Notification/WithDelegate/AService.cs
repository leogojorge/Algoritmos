namespace DesignPatterns.Notification.WithDelegate
{
    public class AService
    {
        public int Counter { get; private set; }

        public delegate void ShowCountHandler(int counter);
        public event ShowCountHandler? ShowCount;

        public void DoSomething()
        {
            Counter++;
            ShowCount.Invoke(Counter);
        }
    }
}
