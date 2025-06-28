using Unity.Entities;
using UnityEngine;



public class SpawnAuthoring : MonoBehaviour
{
    public GameObject entityObject;
    public int GridWidth;
    public int GridHeigth;
    public float spacing;
    
}
public class BakedSpawn : Baker<SpawnAuthoring>
{
    public override void Bake(SpawnAuthoring authoring)
    {
        //transform özellik ekleme
        //  TransformUsageFlags usageFlags = new TransformUsageFlags();//Static objeler icin
        Entity entity = GetEntity(TransformUsageFlags.Dynamic);
        //component ekleme
        AddComponent(entity, new SpawnParameters
        {
            entityObject = GetEntity(authoring.entityObject, TransformUsageFlags.Dynamic),
            GridWidth = authoring.GridWidth,
            GridHeigth = authoring.GridHeigth,
            spacing=authoring.spacing
            
        });

    }
}
