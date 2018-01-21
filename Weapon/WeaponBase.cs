using UnityEngine;
using Lession1.Helpers;

namespace Lession1
{
    public abstract class WeaponBase : BaseObjectScene {
        [SerializeField] protected Transform _barrel;
        [SerializeField] protected float _force = 1000f;
        [SerializeField] protected float _cooldown = 0.2f;
        [SerializeField] protected float _recoil;

        protected bool _CanFire = true;
        private float _currentCooldown;

        protected Timer _timer = new Timer();

        public abstract void Fire(AmmunitionsBase ammunition);

        protected void Update()
        {
            _timer.Update();
            if (_timer.IsEvent())
            {
                _CanFire = true;
            }
        }
        protected void Start()
        {
            IsVisible = false;
        }

    }

}