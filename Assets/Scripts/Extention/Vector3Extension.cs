using UnityEngine;

namespace IgUnity.Extention
{
    public static class Vector3Extension
    {
        public static Vector3 Subtraction(this Vector3 vector3, float f)
        {
            var x = vector3.x - f;
            var y = vector3.y - f;
            var z = vector3.z - f;

            return new Vector3(x, y, z);
        }

        public static Vector3 Addition(this Vector3 vector3, float f)
        {
            var x = vector3.x + f;
            var y = vector3.y + f;
            var z = vector3.z + f;

            return new Vector3(x, y, z);
        }

        public static bool Less(this Vector3 first, Vector3 second)
        {
            return first.x <= second.x || first.y <= second.y || first.z <= second.z;
        }
    }
}