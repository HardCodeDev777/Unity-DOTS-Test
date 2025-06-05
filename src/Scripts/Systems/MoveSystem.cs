using HardCodeDev.UnityDOTSTest.Components;
using HardCodeDev.UnityDOTSTest.SystemBases;
using HardCodeDev.UnityDOTSTest.Jobs;
using Unity.Burst;
using Unity.Entities;

namespace HardCodeDev.UnityDOTSTest.Systems
{
    partial struct MoveSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<MoveComponent>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var spawner = SystemAPI.GetSingletonRW<SpawnerComponent>();
            spawner.ValueRW.targetPos = GetTargetPos.CurrentTargetPos;

            foreach (var move in SystemAPI.Query<RefRW<MoveComponent>>())
            {
                move.ValueRW.targetPos = spawner.ValueRW.targetPos;
            }

            var deltaTime = SystemAPI.Time.DeltaTime;

            var moveJob = new MoveJob
            {
                deltaTime = deltaTime
            };
            state.Dependency = moveJob.ScheduleParallel(state.Dependency);

        }
    }
}
