using UnityEngine;

namespace Lession1
{
    public class FlashLightController : BaseController
    {
        private Flashlight _flashligh;
        private Battery _battery;

        public float Capacity
        {
            get
            {
                if (_battery == null) return 0f;
                return _battery.CurrentCapacity;
            }
        }

        private void Start()
        {
            _flashligh = FindObjectOfType<Flashlight>();
            SetData(false);
        }
        private void Update()
        {
            if (!Enabled) return;
            if (!CheckPrerequisites()) return;
            _battery.DrainCapacity(_flashligh.BatteryConsumption * Time.deltaTime);
            if (_battery.CurrentCapacity <= 0)
            {
                Switch();
            }
        }
        private void SetData(bool value)
        {
            _flashligh.Switch(value);
            Main.Instance.UiController.SwitchFlashlight(value);
        }
        private bool CheckPrerequisites()
        {
            if (_battery == null) return false;
            if (_battery.CurrentCapacity <= 0) return false;
            return true;
        }
        public override void On()
        {
            if (Enabled) return;
            if (!CheckPrerequisites()) return;
            base.On();
            SetData(true);
        }
        public override void Off()
        {
            if (!Enabled) return;
            base.Off();
            SetData(false);
        }
        public void LoadBattery(Battery battery)
        {
            if (_battery != null) UnloadBattery();
            _battery = battery;
        }
        public void UnloadBattery()
        {
            _battery = null;
        }
        public void Switch()
        {
            if(Enabled)
            {
                Off();
            }
            else
            {
                if (!CheckPrerequisites()) return;
                On();
            }
        }
    }
}
