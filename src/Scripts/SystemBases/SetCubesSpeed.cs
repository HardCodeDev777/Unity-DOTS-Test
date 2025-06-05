using HardCodeDev.UnityDOTSTest.Components;
using Unity.Collections;
using Unity.Entities;

namespace HardCodeDev.UnityDOTSTest.SystemBases
{
    public partial class SetCubesSpeed : SystemBase
    {
        protected override void OnUpdate()
        {
            var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

            var query = entityManager.CreateEntityQuery(typeof(MoveComponent));

            var moves = query.ToEntityArray(Allocator.Temp);

            if (entityManager.HasComponent<MoveComponent>(moves[0]))
            {
                var moveSpeed = entityManager.GetComponentData<MoveComponent>(moves[0]).speed;

                var currentSingleton = SystemAPI.GetSingleton<SpawnerComponent>();
                SystemAPI.SetSingleton(new SpawnerComponent
                {
                    cube = currentSingleton.cube,
                    areaSize = currentSingleton.areaSize,
                    count = currentSingleton.count,
                    targetPos = currentSingleton.targetPos,
                    speed = moveSpeed
                });
                moves.Dispose();
            }
        }
    }
}
