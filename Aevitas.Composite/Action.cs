using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aevitas.Composite
{
    public class Action : Component
    {
        private System.Action _func;

        public Action(System.Action func)
        {
            _func = func;
        }

        public override void Execute()
        {
            if (_func != null)
                _func();
        }
    }
}
