using IgUnity.Extention;
using UnityEngine;

namespace IgUnity.Model
{
    public class GunModel : WeaponModel
    {
        private AmmunitionModel _ammunitionModel;
        private readonly Vector3 _maxScale = new Vector3(1, 1, 1);

        protected override void Awake()
        {
            base.Awake();
            _rechargeTime = 5;
        }

        public override void Fire()
        {
            if (!_canFire) return;
            if (Holder.CountAmmunitionInHolder <= 0) return;
            if (!Ammunition) return;
            if (!_ammunitionModel)
            {
                _ammunitionModel = Instantiate(Ammunition, _gun.position, _gun.rotation);
            }

            var scale = _ammunitionModel.transform.localScale;
            if (scale.Less(_maxScale))
            {
                _ammunitionModel.transform.localScale = scale.Addition(0.01f);
                _ammunitionModel.CurrentDamage += 3;
            }
        }

        public override void FireUp()
        {
            base.FireUp();
            _ammunitionModel.AddForce(_gun.forward * _force);
            Holder.CountAmmunitionInHolder--;
            _canFire = false;
            Invoke(nameof(ReadyForShoot), _rechargeTime);
        }
    }
}