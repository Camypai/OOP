using IgUnity.Helper;
using IgUnity.Interface;
using UnityEngine;

namespace IgUnity.Controller
{
    public sealed class InputController : BaseController, IUpdate
    {
        private int _indexWeapons = 0;
        private ScrollWheel _scrollWheel;

        public override void On()
        {
            if (Enabled) return;
            base.On();
            _scrollWheel = new ScrollWheel(Main.Instance.ObjectManager.GetWeapons.Count);
            _scrollWheel.ScrollWheelChanged += ScrollWheelChanged;
        }

        public void Update()
        {
            if (!Enabled) return;

            var wheel = Input.GetAxisRaw("Wheel");
            _indexWeapons += -(int) wheel;

            if (_scrollWheel.ScrollId != _indexWeapons)
            {
                _scrollWheel.ScrollId = _indexWeapons;
                _indexWeapons = _scrollWheel.ScrollId;
            }


            if (Input.GetKeyDown(KeyCode.F))
            {
                Main.Instance.FlashlightController.Toggle();
            }


            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _indexWeapons = 0;
                SelectWeapon(_indexWeapons);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _indexWeapons = 1;
                SelectWeapon(_indexWeapons);
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                _indexWeapons = 2;
                SelectWeapon(_indexWeapons);
            }


            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Main.Instance.WeaponController.Off();
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                Main.Instance.WeaponController.ReloadHolder();
            }
        }

        private void SelectWeapon(int i)
        {
            Main.Instance.WeaponController.Off();
            var weapon = Main.Instance.ObjectManager.GetWeapons[i];
            if (weapon != null)
            {
                Main.Instance.WeaponController.On(weapon);
            }
        }

        private void ScrollWheelChanged(ScrollWheelEventArgs args)
        {
            SelectWeapon(args.Id);
        }
    }
}