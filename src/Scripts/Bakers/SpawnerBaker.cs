using HardCodeDev.UnityDOTSTest.Authorings;
using HardCodeDev.UnityDOTSTest.Components;
using Unity.Entities;

namespace HardCodeDev.UnityDOTSTest.Bakers
{
    public class SpawnerBaker : Baker<SpawnerAuthoring>
    {
        public override void Bake(SpawnerAuthoring authoring)
        {
            var spawnerEntity = GetEntity(authoring, TransformUsageFlags.Dynamic);
            var cubeEntity = GetEntity(authoring.cubePrefab, TransformUsageFlags.Dynamic);

            AddComponent(spawnerEntity, new SpawnerComponent
            {
                cube = cubeEntity,
                areaSize = authoring.areaSize,
                count = authoring.count,
                speed = authoring.speed
            });
        }
    }
}
