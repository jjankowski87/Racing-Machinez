namespace RacingMachinez.TrayApplication.Framework
{
    public interface IPresenter<TView> where TView : IView
    {
        TView View { get; set; }
    }
}
