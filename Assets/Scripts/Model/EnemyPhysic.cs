using UnityEngine;

namespace IgUnity.Model
{
    public class EnemyPhysic : EnemyModel
    {
        public override void Update()
        {
            if (!isDead) return;

            var tempRigidbody = GetComponent<Rigidbody>();
            if (!tempRigidbody)
            {
                gameObject.AddComponent<Rigidbody>();
            }

            Destroy(InstanceObject, 5);
        }
    }
}