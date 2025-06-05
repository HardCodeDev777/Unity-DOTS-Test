using Unity.Entities;
using Unity.Mathematics;

namespace HardCodeDev.UnityDOTSTest.Components
{
    public struct MoveComponent : IComponentData
    {
        public float3 targetPos, cubePos;
        public float speed;
    }
}