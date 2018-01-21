using UnityEngine;
namespace Lession1
{
    public abstract class BaseObjectScene : MonoBehaviour
    {
        private int _layer;
        private bool _isVisible;
        private Vector3 _center;
        private Bounds _bound;
        private Color _color;

        [HideInInspector] public Transform Transform;
        [HideInInspector] public GameObject InstanceObject;
        [HideInInspector] public Rigidbody Rigidbody;

        protected virtual void Awake()
        {
            InstanceObject = gameObject;
            Transform = transform;
            Rigidbody = InstanceObject.GetComponent<Rigidbody>();
            _layer = gameObject.layer;

            var renderer = Transform.GetComponent<Renderer>();
            if (renderer)
            {
                Color = renderer.material.color;
            }
        }

        public string Name
        {
            get { return InstanceObject.name; }
            set { InstanceObject.name = value; }
        }
        public int Layer
        {
            get { return _layer; }
            set
            {
                _layer = value;
                SetLayer(Transform, _layer);
            }
        }
        public Color Color
        {
            get { return _color; }
            set
            {
                _color = value;
                SetColor(Transform, _color);
            }
        }
        public bool IsVisible
        {
            get { return _isVisible; }
            set
            {
                _isVisible = value;
                SetVisible(Transform, _isVisible);
            }
        }
        public Vector3 Center
        {
            get
            {
                Renderer[] renderers = InstanceObject.GetComponentsInChildren<Renderer>();
                Bounds bounds = renderers[0].bounds;
                foreach (Renderer item in renderers)
                {
                    bounds.Encapsulate(item.bounds);
                }
                _center = bounds.center;
                return _center;
            }
        }
        public Bounds Bound
        {
            get
            {
                Renderer[] renderers = InstanceObject.GetComponentsInChildren<Renderer>();
                Bounds bounds = renderers[0].bounds;
                foreach (Renderer item in renderers)
                {
                    bounds.Encapsulate(item.bounds);
                }
                _bound = bounds;
                return _bound;
            }
        }
        private void SetVisible(Transform MyTransform, bool value)
        {
            var renderer = MyTransform.GetComponent<Renderer>();
            if (renderer)
            {
                renderer.enabled = value;
            }
            if (Transform.childCount <= 0) return;
            foreach (Transform obj in MyTransform)
            {
                SetVisible(obj, value);
            }
        }
        private void SetLayer(Transform MyTransform, int layer)
        {
            MyTransform.gameObject.layer = layer;
            if (MyTransform.childCount <= 0) return;
            foreach (Transform obj in MyTransform)
            {
                SetLayer(obj, layer);
            }
        }
        private void SetColor(Transform MyTransform, Color color)
        {
            var renderer = MyTransform.GetComponent<Renderer>();
            if (renderer)
            {
                var materials = renderer.materials;
                foreach (var material in materials)
                {
                    material.color = color;
                }
            }
            if (MyTransform.childCount <= 0) return;
            foreach (Transform obj in MyTransform)
            {
                SetColor(obj, color);
            }
        }
        public void SetParent(Transform Parent)
        {
            Transform.parent = Parent;
        }
        public bool IsRigidbody()
        {
            return Rigidbody;
        }
        public void SwitchRigidboy(bool value)
        {
            if (!IsRigidbody()) return;
            Rigidbody[] rigidbodies = InstanceObject.GetComponentsInChildren<Rigidbody>();
            foreach (Rigidbody item in rigidbodies)
            {
                item.isKinematic = !value;
            }
        }
        public void ConstraintsRigidbody(RigidbodyConstraints rigidbodyConstraints)
        {
            Rigidbody[] rigidbodies = InstanceObject.GetComponentsInChildren<Rigidbody>();
            foreach (var item in rigidbodies)
            {
                item.constraints = rigidbodyConstraints;
            }
        }
    }
}
