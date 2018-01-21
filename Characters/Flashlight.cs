using System.Collections;
using UnityEngine;
namespace Lession1
{
    public class Flashlight : BaseObjectScene
    {
        public float FadeTime;
        public float BatteryConsumption;
        public float MaxIntensity;

        private Light _light;
        private bool _isFading;
        private Coroutine _fade;
        private Vector3 _vectorOffset;
        [SerializeField] private Transform _goFollow;
        private float _speed = 3f;

        protected override void Awake()
        {
            base.Awake();
            _light = GetComponent<Light>();
            Switch(false);
            
        }
        private void Update()
        {
            if (!_light && !_light.enabled) return;
            Transform.position = _goFollow.position + _vectorOffset;
            Transform.rotation = Quaternion.Slerp(Transform.rotation, _goFollow.rotation, _speed * Time.deltaTime);
        }

        public void Switch(bool value)
        {
            if (!_light) return;
            if (_isFading) StopCoroutine(_fade);
            _fade = StartCoroutine(Fade(value));
        }

        public void SetLightColor(Color color)
        {
            _light.color = color;
        }

        private IEnumerator Fade(bool value)
        {
            _isFading = true;
            float end;
            float current;
            if (value)
            {
                end = MaxIntensity;
                current = _light.intensity;
                while (current < end)
                {
                    current += Time.deltaTime;
                    _light.intensity = Mathf.Lerp(current, end, current/FadeTime);
                    yield return null;
                }
            }
            else
            {
                end = 0f;
                current = _light.intensity;
                while (current > end)
                {
                    current -= Time.deltaTime;
                    _light.intensity = Mathf.Lerp(end, current, current/FadeTime);
                    yield return null;
                }
            }
            _isFading = false;
        }
    }
}
