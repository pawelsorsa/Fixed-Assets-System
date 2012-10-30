using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FixedAssetsApp.Presenters
{
    public class PresenterBase<T>: Notifier
    {
        private readonly T _view;

        public PresenterBase(T view)
        {
            _view = view;
        }

        public T View
        {
            get { return _view; }
        }
    }
}
