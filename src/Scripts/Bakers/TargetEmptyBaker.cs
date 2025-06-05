using HardCodeDev.UnityDOTSTest.Components;
using HardCodeDev.UnityDOTSTest.Authorings;
using Unity.Entities;

namespace HardCodeDev.UnityDOTSTest.Bakers
{
    class TargetEmptyBaker : Baker<TargetEmpty>
    {
        public override void Bake(TargetEmpty authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new TargetEmptyComponent { });
        }
    }
    
}
