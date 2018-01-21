using System;
using UnityEngine;

namespace Lession1
{
    public class RifleBullet : AmmunitionsBase
    {
        [SerializeField] private float _timeToDestruct = 10f;
        [SerializeField] private float _damage = 20f;
        [SerializeField] private float _mass = 0.2f;

        private float _currentDamage;

        protected override void Awake()
        {
            base.Awake();
            Rigidbody.mass = _mass;
        }

        private void Start()
        {
            Destroy(InstanceObject, _timeToDestruct);
            _currentDamage = _damage;
        }

        private void OnCollisionEnter(Collision collision)
        {
            Hit(collision.gameObject.GetComponent<ISetDamage>());
            Destroy(InstanceObject);
        }

        private void Hit(ISetDamage obj)
        {
            if (obj == null) return;
            obj.Hit(_currentDamage);
        }
    }
}
