using HardCodeDev.UnityDOTSTest.Components;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace HardCodeDev.UnityDOTSTest.Jobs
{
    [BurstCompile]
    public partial struct MoveJob : IJobEntity
    {
        public float deltaTime;

        public void Execute(ref MoveComponent move, ref LocalTransform transform)
        {
            move.cubePos = math.lerp(move.cubePos, move.targetPos, move.speed * deltaTime);
            transform.Position = move.cubePos;
        }
    }
}
