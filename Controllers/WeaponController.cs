using UnityEngine;

namespace Lession1
{
    public sealed class WeaponController : BaseController
    {
        private WeaponBase _weapon;
        private AmmunitionsBase _ammunition;

        public void On(WeaponBase weapon, AmmunitionsBase ammunition)
        {
            if (Enabled) return;
            base.On();
            _weapon = weapon;
            _weapon.IsVisible = true;
            _ammunition = ammunition;
        }

        public override void Off()
        {
            if (!Enabled) return;
            base.Off();
            _weapon.IsVisible = false;
            _weapon = null;
            _ammunition = null;
        }

        public void Fire()
        {
            if (!Enabled) return;
            if (_weapon)
            {
                _weapon.Fire(_ammunition);
            }
        }
    }
}
