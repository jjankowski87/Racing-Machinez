namespace RacingMachinez.TrayApplication.Framework
{
    public interface IView
    {
        bool IsDisposed { get; }

        void Activate();

        void Show();
    }
}
