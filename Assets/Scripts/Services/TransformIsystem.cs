using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Unity.VisualScripting;
using UnityEngine;

public partial struct TransformIsystem : ISystem
{
     public void OnCreate(ref SystemState systemState)
    {
        
    } public void OnDestroy(ref SystemState systemState)
    {
        
    }
    [BurstCompile]
    public void OnUpdate(ref SystemState systemState)
    {
        float deltaTime = systemState.World.Time.DeltaTime; //unity dots da time.deltatime
        // Entities.ForEach((ref LocalTransform transform, in Speed speed) =>
        // {
        //     //foreach de bir jobtur
        //     transform.Position += new Unity.Mathematics.float3(0,0,speed.value*deltaTime);
        // }).Run();buna I sstemde state ulaşma imkanı hic yok
        foreach (var (transform, speed) in SystemAPI.Query<RefRW<LocalTransform>, RefRO<Speed>>())
        {
            transform.ValueRW.Position += new float3(0, 0, speed.ValueRO.value * deltaTime);
        }


    }
}