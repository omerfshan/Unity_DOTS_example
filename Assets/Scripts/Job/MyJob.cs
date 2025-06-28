using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

public struct MyJob : IJob
{
    [ReadOnly]//SADECE OKUNABİLİR
    public NativeArray<int> number1;
    [ReadOnly]
    public NativeArray<int> number2;
    public NativeArray<int> numberSums;
    public void Execute()
    {
        for (int i = 0; i < number1.Length; i++)
        {
            numberSums[i] = number1[i] + number2[i];

        }
    }
}
[BurstCompile]
public struct MyJobParalel : IJobParallelFor
{
    [ReadOnly]//SADECE OKUNABİLİR
    public NativeArray<int> number1;
    [ReadOnly]
    public NativeArray<int> number2;
    public NativeArray<int> numberSums;

    public void Execute(int i)
    {
        numberSums[i] = number1[i] + number2[i];

    }
}
