using UnityEngine;

namespace Lession1
{
    public class Box : BaseObjectScene, ISetDamage
    {
        [SerializeField] private float _health = 100f;
        [SerializeField] private bool _isDead = false;

        public void Hit(float damage)
        {
            if (_health <= 0) return;
            _health -= damage;
            if (_health <= 0)
            {
                _isDead = true;
                Color = Color.green;
                Destroy(InstanceObject, 10f);
            }
        }
    }
}
