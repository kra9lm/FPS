using UnityEngine;

namespace Lession1
{
    public sealed class SelectController : BaseController
    {
        private Camera _camera;
        private Material _material;
        private Shader _shader;
        private Shader _objectShader;

        public Transform SelectedObject { get; private set; }
        public LayerMask LayerMask { get; set; }
        public bool Carry { get; private set; }

        private void Awake()
        {
            _camera = FindObjectOfType<Camera>();
            _shader = Shader.Find("Custom/OutlineShader");
            LayerMask = LayerMask.GetMask("Objects");
        }
        private void Update()
        {
            if (!Enabled) return;
            if (Carry) return;
            RaycastHit hit;
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.value))
            {
                if (SelectedObject == hit.transform) return;
                SelectedObject = hit.transform;
                SelectObject(true);
            } else
            {
                SelectObject(false);
            }
        }
        private void SelectObject (bool value)
        {
            if (value)
            {
                if (_material) _material.shader = _objectShader;
                _material = SelectedObject.gameObject.GetComponent<Renderer>().material;
                _objectShader = _material.shader;
                _material.shader = _shader;
            }
            else
            {
                if (_material) _material.shader = _objectShader;
                SelectedObject = null;
            }
        }
        public void PickSelectedObject(Transform Parent)
        {
            if (Carry) return;
            if (!SelectedObject) return;
            SelectedObject.SetParent(Parent);
            var temp = SelectedObject.GetComponent<BaseObjectScene>();
            if (temp)
            {
                temp.SwitchRigidboy(false);
            }
            Carry = true;
        }
        public void DropSelectedObject()
        {
            if (!Carry) return;
            if (!SelectedObject) return;
            SelectedObject.SetParent(null);
            var temp = SelectedObject.GetComponent<BaseObjectScene>();
            if (temp)
            {
                temp.SwitchRigidboy(true);
            }
            Carry = false;
        }
    }
}
