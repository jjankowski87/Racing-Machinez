using System;
using System.Collections.Generic;

namespace RacingMachinez.TrayApplication.Framework
{
    public class FormManager : IFormManager
    {
        private readonly IDictionary<Type, Func<IView>> _viewsFactory;

        private readonly IDictionary<Type, IView> _views;

        public FormManager(IDictionary<Type, Func<IView>> viewsFactory)
        {
            _viewsFactory = viewsFactory;
            _views = new Dictionary<Type, IView>();
        }

        public IView ShowView<TView>() where TView : IView
        {
            Func<IView> viewFactory = null;
            if (_viewsFactory.TryGetValue(typeof(TView), out viewFactory))
            {
                return (TView)ShowView<TView>(viewFactory);
            }

            throw new ArgumentOutOfRangeException("View not registered.");
        }

        private IView ShowView<TView>(Func<IView> viewFactory) where TView : IView
        {
            IView view = null;
            if (_views.TryGetValue(typeof(TView), out view))
            {
                if (!view.IsDisposed)
                {
                    view.Activate();
                    return view;
                }
            }

            view = viewFactory();
            view.Show();
            _views[typeof(TView)] = view;

            return view;
        }
    }
}
