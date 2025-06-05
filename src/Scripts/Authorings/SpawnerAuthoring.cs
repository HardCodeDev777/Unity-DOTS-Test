using UnityEngine;

namespace HardCodeDev.UnityDOTSTest.Authorings
{
    public class SpawnerAuthoring : MonoBehaviour
    {
        public int count;
        public float areaSize;
        public GameObject cubePrefab;
        public Transform target;
        [HideInInspector] public Vector3 TargetPos => target.position;
        [HideInInspector] public float speed;
    }
}