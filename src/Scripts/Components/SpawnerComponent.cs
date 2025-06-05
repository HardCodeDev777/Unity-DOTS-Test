using Unity.Entities;
using Unity.Mathematics;

namespace HardCodeDev.UnityDOTSTest.Components
{
    public struct SpawnerComponent : IComponentData
    {
        public Entity cube;
        public int count;
        public float areaSize;
        public float3 targetPos;

        public float speed;
    }
}