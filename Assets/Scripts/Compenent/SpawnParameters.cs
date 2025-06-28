using UnityEngine;
using Unity.Entities;
public struct SpawnParameters : IComponentData
{
    public Entity entityObject;
    public int GridWidth;
    public int GridHeigth;
    public float spacing;

    
}
