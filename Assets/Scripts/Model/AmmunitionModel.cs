using IgUnity.Interface;
using UnityEngine;

namespace IgUnity.Model
{
    public abstract class AmmunitionModel : BaseObject, IStart
    {
        [SerializeField] protected float TimeToDestruct = 5;
        [SerializeField] protected float Damage = 20;
        [SerializeField] protected float Mass = 0.01f;

        public float CurrentDamage;
        protected float loseDamageOfTime = 0.2f;

        protected override void Awake()
        {
            base.Awake();
            CurrentDamage = Damage;
            Rigidbody.mass = Mass;
        }

        public void Start()
        {
            Destroy(gameObject, TimeToDestruct);
            InvokeRepeating(nameof(LoseDamage), 0, 1);
        }

        public void AddForce(Vector3 direction)
        {
            if (!Rigidbody) return;
            Rigidbody.AddForce(direction);
        }

        protected void LoseDamage()
        {
            CurrentDamage -= loseDamageOfTime;
        }
    }
}