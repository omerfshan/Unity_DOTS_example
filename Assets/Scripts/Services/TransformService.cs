// using Unity.Entities;
// using Unity.Transforms;
// using UnityEngine;


// public partial class TransformService : SystemBase
// {
//     protected override void OnUpdate()
//     {

//         float deltaTime = World.Time.DeltaTime; //unity dots da time.deltatime
//         Entities.ForEach((ref LocalTransform transform, in Speed speed) =>
//         {
//             //foreach de bir jobtur
//             transform.Position += new Unity.Mathematics.float3(0,0,speed.value*deltaTime);
//         }).WithoutBurst().Run();
//     }
// }

