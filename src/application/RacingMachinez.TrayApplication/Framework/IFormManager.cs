using System.Windows.Forms;

namespace RacingMachinez.TrayApplication.Framework
{
    public interface IFormManager
    {
        IView ShowView<T>() where T : IView;
    }
}
