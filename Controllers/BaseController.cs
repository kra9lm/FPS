using UnityEngine;

namespace Lession1
{
    public abstract class BaseController : MonoBehaviour
    {
        private bool _enabled;
        protected bool Enabled
        {
            get { return _enabled; }
            set { _enabled = value; }
        }

        public virtual void On()
        {
            _enabled = true;
        }
        public virtual void Off()
        {
            _enabled = false;
        }
    }
}
