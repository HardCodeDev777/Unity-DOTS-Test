using HardCodeDev.UnityDOTSTest.Authorings;
using HardCodeDev.UnityDOTSTest.Components;
using Unity.Entities;

namespace HardCodeDev.UnityDOTSTest.Bakers
{
    public class MoveBaker : Baker<MoveAuthoring>
    {
        public override void Bake(MoveAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);

            AddComponent(entity, new MoveComponent
            {
                speed = authoring.speed
            });
        }
    }
}