using IgUnity.Extention;
using IgUnity.Interface;
using UnityEngine;

namespace IgUnity.Model
{
    public class EnemyScale : EnemyModel
    {
        private readonly Vector3 _deathScale = new Vector3(1f, 1f, 1f);

        public override void Update()
        {
            if (!isDead) return;

            var scale = transform.localScale;

            if (!scale.Less(_deathScale))
            {
                transform.localScale = scale.Subtraction(step);
            }
            else
            {
                Destroy(InstanceObject.GetComponent<Collider>());
                Destroy(InstanceObject, 1f);
            }
        }
    }
}