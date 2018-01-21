using UnityEngine;
namespace Lession1
{
    public abstract class Garbage : BaseObjectScene
    {
        [HideInInspector] public Rigidbody MyRigidbody;
        protected sealed override void Awake()
        {
            base.Awake();
            MyRigidbody = InstanceObject.GetComponent<Rigidbody>();
        }
    }
}
