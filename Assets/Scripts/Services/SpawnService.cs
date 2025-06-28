using System.Diagnostics;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public partial class SpawnService : SystemBase
{
    protected override void OnStartRunning()
    {
        DoTheJob();
        SpawnParameters parameters = SystemAPI.GetSingleton<SpawnParameters>();
        LocalTransform localTransform;
        for (var w = 0; w < parameters.GridWidth; w++)
        {
            for (var h = 0; h < parameters.GridHeigth; h++)
            {
                var newEntity = EntityManager.Instantiate(parameters.entityObject);
                localTransform = new LocalTransform()
                {
                    Position = new float3(w * parameters.spacing, 0, h * parameters.spacing),
                    Rotation = quaternion.identity,
                    Scale = 1f

                };
                EntityManager.SetComponentData(newEntity, localTransform);
            }
        }
    }

    protected override void OnUpdate()
    {
        return;
    }
    public void DoTheJob()
    {
        NativeArray<int> num1 = new NativeArray<int>(new int[] { 1, 3, 5, 7 }, Allocator.Persistent);
        NativeArray<int> num2 = new NativeArray<int>(new int[] { 4, 6, 1, 5 }, Allocator.Persistent);
        NativeArray<int> numsums = new NativeArray<int>(new int[] { 0, 0, 0, 0 }, Allocator.Persistent);
        var newJob = new MyJobParalel()
        {
            number1 = num1,
            number2 = num2,
            numberSums=numsums
        };

        var handle = newJob.Schedule(numsums.Length, numsums.Length);
        handle.Complete();
        
        for (var i = 0; i < numsums.Length; i++)
        {
            UnityEngine.Debug.Log(numsums[i]);
        }
        num1.Dispose();
        num2.Dispose();
        numsums.Dispose();

    }
}