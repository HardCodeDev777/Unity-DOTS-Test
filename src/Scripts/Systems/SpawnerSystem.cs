using HardCodeDev.UnityDOTSTest.Components;
using HardCodeDev.UnityDOTSTest.Jobs;
using Unity.Burst;
using Unity.Entities;
using ESECB = Unity.Entities.EndSimulationEntityCommandBufferSystem;
using Random = UnityEngine.Random;

namespace HardCodeDev.UnityDOTSTest.Systems
{
    partial struct SpawnerSystem : ISystem
    {
        public static bool SpawnWasEnded { get; private set; }
        private float timer;

        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<SpawnerComponent>();
            timer = 0.5f;
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var deltaTime = SystemAPI.Time.DeltaTime;
            timer -= deltaTime;
            if (timer <= 0)
            {
                if (!SpawnWasEnded)
                {
                    var ecbSystemSingletone = SystemAPI.GetSingleton<ESECB.Singleton>();
                    var ecb = ecbSystemSingletone.CreateCommandBuffer(state.WorldUnmanaged).AsParallelWriter();
                    var ecbSystem = state.World.GetOrCreateSystemManaged<ESECB>();

                    var spawner = SystemAPI.GetSingleton<SpawnerComponent>();

                    var spawnJob = new SpawnJob
                    {
                        commandBuffer = ecb,
                        seed = (uint)Random.Range(1, int.MaxValue),
                        globalTarget = spawner.targetPos,
                        entitySpeed = spawner.speed
                    };

                    state.Dependency = spawnJob.ScheduleParallel(state.Dependency);

                    ecbSystem.AddJobHandleForProducer(state.Dependency);

                    state.Dependency.Complete();

                    SpawnWasEnded = true;
                }
            }
        }
    }
}