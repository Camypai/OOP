using System.Collections.Generic;
using IgUnity.Enum;
using IgUnity.Helper;
using IgUnity.Interface;
using UnityEngine;

namespace IgUnity.Model
{
    public abstract class WeaponModel : BaseObject
    {
        private readonly Queue<HolderModel> _holders = new Queue<HolderModel>();

        public AmmunitionModel Ammunition;
        public HolderModel Holder;

        protected bool _canFire = true;
        protected int countHolder = 4;

        [SerializeField] protected Transform _gun;
        [SerializeField] protected float _force = 500;
        [SerializeField] protected float _rechargeTime = 0.2f;

        public abstract void Fire();

        public virtual void FireUp()
        {
        }

        private void Start()
        {
            for (var i = 0; i <= countHolder; i++)
            {
                var model = new HolderModel {CountAmmunitionInHolder = 10};
                AddHolder(model);
            }

            ReloadHolder();
        }

        private void AddHolder(HolderModel holder)
        {
            _holders.Enqueue(holder);
        }

        public void ReloadHolder()
        {
            if (CountHolder <= 0) return;
            Holder = _holders.Dequeue();
        }

        protected void ReadyForShoot()
        {
            _canFire = true;
        }

        public int CountHolder => _holders.Count;
    }
}