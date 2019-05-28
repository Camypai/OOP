using IgUnity.Enum;
using IgUnity.Interface;
using IgUnity.Model;
using IgUnity.View;
using UnityEngine;

namespace IgUnity.Controller
{
    public class WeaponController : BaseController, IUpdate
    {
        private WeaponModel _weapon;
        private int _mouseButton = (int) MouseButton.LeftButton;


        public void Update()
        {
            if (!Enabled) return;

            if (Input.GetMouseButton(_mouseButton))
            {
                _weapon.Fire();
                UI.AmmoUi.SetAmmo(_weapon.Holder.CountAmmunitionInHolder);
            }

            if (Input.GetMouseButtonUp(_mouseButton))
            {
                _weapon.FireUp();
                UI.AmmoUi.SetAmmo(_weapon.Holder.CountAmmunitionInHolder);
            }
        }

        public void ReloadHolder()
        {
            if (_weapon == null) return;
            _weapon.ReloadHolder();
            UI.AmmoUi.SetAmmo(_weapon.Holder.CountAmmunitionInHolder, _weapon.CountHolder);
        }

        public override void On(BaseObject weapon)
        {
            if (Enabled) return;
            base.On(weapon);
            _weapon = weapon as WeaponModel;
            if (_weapon == null) return;
            _weapon.IsVisible = true;
            UI.AmmoUi.SetActive(true);
            UI.AmmoUi.SetAmmo(_weapon.Holder.CountAmmunitionInHolder, _weapon.CountHolder);
        }

        public override void Off()
        {
            if (!Enabled) return;
            base.Off();
            _weapon.IsVisible = false;
            _weapon = null;
            UI.AmmoUi.SetActive(false);
        }
    }
}