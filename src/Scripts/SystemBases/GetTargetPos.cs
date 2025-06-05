using HardCodeDev.UnityDOTSTest.Components;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace HardCodeDev.UnityDOTSTest.SystemBases
{
    public partial class GetTargetPos : SystemBase
    {
        public static float3 CurrentTargetPos { get; private set; }
        protected override void OnUpdate()
        {
            var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

            var query = entityManager.CreateEntityQuery(typeof(TargetEmptyComponent));

            var targets = query.ToEntityArray(Allocator.Temp);

            if (targets.Length > 1)
            {
                targets.Dispose();
                return;
            }

            if (entityManager.HasComponent<LocalTransform>(targets[0]))
            {
                var currentTransform = entityManager.GetComponentData<LocalTransform>(targets[0]);
                CurrentTargetPos = currentTransform.Position;
            }
            targets.Dispose();
        }
    }
}