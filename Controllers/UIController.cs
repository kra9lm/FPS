using UnityEngine;
using UnityEngine.UI;
namespace Lession1
{
    public sealed class UIController : BaseController
    {
        private InterfaceCache _interfaceCache;
        private Slider _slider;
        private Image _flashlightRays;
        private Image _capacityFill; 

        private Color MaxCapacity;
        private Color MinCapacity;

        private void Awake()
        {
            MaxCapacity = Color.green;
            MinCapacity = Color.red;

            _interfaceCache = FindObjectOfType<InterfaceCache>();
            _slider         = _interfaceCache.BatteryBar;
            _flashlightRays = _interfaceCache.FlashLightRays;
            _capacityFill   = _interfaceCache.CapacityFill;
        }
        private void OnGUI()
        {
            if (!Enabled) return;
            UpdateCapacity(Main.Instance.FlashLightController.Capacity);
        }
        private void UpdateCapacity(float value)
        {
            _slider.value = value;
            _capacityFill.color = Color.Lerp(MinCapacity, MaxCapacity, value * 0.01f);
        }
        public void SwitchFlashlight(bool value)
        {
            _flashlightRays.enabled = value;
        }
    }
}
