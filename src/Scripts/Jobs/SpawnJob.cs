using HardCodeDev.UnityDOTSTest.Components;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace HardCodeDev.UnityDOTSTest.Jobs
{

    [BurstCompile]
    public partial struct SpawnJob : IJobEntity
    {
        public EntityCommandBuffer.ParallelWriter commandBuffer;
        public uint seed;

        public float3 globalTarget;
        public float entitySpeed;

        public void Execute([EntityIndexInQuery] int sortKey, in SpawnerComponent spawner)
        {
            var random = new Random(seed + (uint)sortKey);

            for (int i = 0; i < spawner.count; i++)
            {
                var entity = commandBuffer.Instantiate(sortKey, spawner.cube);

                var pos = new float3(
                random.NextFloat(-spawner.areaSize, spawner.areaSize),
                0,
                random.NextFloat(-spawner.areaSize, spawner.areaSize));

                commandBuffer.SetComponent(i, entity, new LocalTransform()
                {
                    Position = pos,
                    Rotation = quaternion.identity,
                    Scale = 1f
                });

                commandBuffer.SetComponent(i, entity, new MoveComponent()
                {
                    cubePos = pos,
                    targetPos = globalTarget,
                    speed = entitySpeed
                });
            }
        }
    }

}