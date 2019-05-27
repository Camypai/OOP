namespace IgUnity.Model
{
    public class PistolModel : WeaponModel
    {
        public override void Fire()
        {
            countHolder = 5;

            if (!_canFire) return;
            if (Holder.CountAmmunitionInHolder <= 0) return;
            if (!Ammunition) return;
            var ammunition = Instantiate(Ammunition, _gun.position, Ammunition.Rotation);
            ammunition.AddForce(_gun.forward * _force);
            Holder.CountAmmunitionInHolder--;
            _canFire = false;
            Invoke(nameof(ReadyForShoot), _rechargeTime);
        }
    }
}