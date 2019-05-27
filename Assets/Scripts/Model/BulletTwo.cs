using IgUnity.Interface;
using UnityEngine;

namespace IgUnity.Model
{
    public class BulletTwo : AmmunitionModel
    {
        private void OnCollisionEnter(Collision other)
        {
            var enemy = other.gameObject.GetComponent<ISetDamage>();

            if (enemy == null) return;

            Rigidbody.velocity = Vector3.zero;

            SetDamage(enemy);
        }

        private void SetDamage(ISetDamage damage)
        {
            damage?.ApplyDamage(CurrentDamage);
        }
    }
}