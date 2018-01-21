using UnityEngine;
using Lession1.Helpers;
using System;

namespace Lession1
{
    public sealed class InputController : BaseController
    {
        private int _currentWeapon = -1;
        private void Update()
        {
            if (!Enabled) return;
            if (Input.GetButtonDown("Flashlight"))
            {
                Main.Instance.FlashLightController.Switch();
            }
            if (Input.GetButtonDown("ReloadBattery"))
            {
                Battery battery = new Battery();
                Main.Instance.FlashLightController.LoadBattery(battery);
            }
            if (Input.GetButton("Fire1"))
            {
                if (_currentWeapon != -1)
                {
                    Main.Instance.WeaponController.Fire();
                }
            }
            if (Input.GetButtonDown("Fire1"))
            {
                if (_currentWeapon == -1)
                {
                    if (Main.Instance.SelectController.Carry)
                    {
                        Main.Instance.SelectController.DropSelectedObject();
                    }
                    else
                    {
                        Main.Instance.SelectController.PickSelectedObject(Main.Instance.Player);
                    }
                }
            }
            if (Input.GetButtonDown("PrimaryWeapon"))
            {
                if (!Main.Instance.SelectController.Carry)
                {
                    SelectWeapon(0);
                }
            }
        }

        private void SelectWeapon(int index)
        {
            Main.Instance.WeaponController.Off();
            if (_currentWeapon == index)
            {
                _currentWeapon = -1;
                return;
            }
            var tempWeapons = Main.Instance.ObjectManager.Weapons[index];
            var tempAmmunitions = Main.Instance.ObjectManager.Ammunitions[index];
            if (tempWeapons)
            {
                Main.Instance.WeaponController.On(tempWeapons, tempAmmunitions);
            }
            _currentWeapon = index;
        }
    }
}
