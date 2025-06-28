using Unity.Entities;
using UnityEngine;



public class SpeedAuthoring : MonoBehaviour
{
    public float value;
    
}
public class BakedSpeed : Baker<SpeedAuthoring>
{
    public override void Bake(SpeedAuthoring authoring)
    {
        //transform özellik ekleme
        //  TransformUsageFlags usageFlags = new TransformUsageFlags();//Static objeler icin
        Entity entity = GetEntity(TransformUsageFlags.Dynamic);
        //component ekleme
        AddComponent(entity, new Speed {

            value = authoring.value
        });

    }
}
