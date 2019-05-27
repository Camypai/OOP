using IgUnity.Interface;
using UnityEngine;

namespace IgUnity.Model
{
    public abstract class EnemyModel : BaseObject, ISetDamage, IUpdate
    {
        [SerializeField] private float Hp = 100;

        protected bool isDead = false;
        protected float step = 1f;


        public virtual void ApplyDamage(float damage)
        {
            if (Hp > 0)
            {
                Hp -= damage;
            }

            if (Hp <= 0)
            {
                Hp = 0;
                isDead = true;
            }
        }

        public virtual void Update()
        {
            if (!isDead) return;

            Destroy(InstanceObject.GetComponent<Collider>());
            Destroy(InstanceObject, 1f);
        }
    }
}