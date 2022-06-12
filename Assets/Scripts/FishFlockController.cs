using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using Random = UnityEngine.Random;
public struct FishBehaviour
{
    public Vector3 position;
    public Vector3 velocity;
    public float speed;
    public float rot_speed;
    public float speed_offset;
}

public class FishFlockController : MonoBehaviour
{
    public struct CollisionArea
    {
        public Vector3 position;
        public Vector3 size;
    }

    [Header("Settings")]
    [Tooltip("The width limit of the swimming area where the group can swim.")]
    public float swimmingAreaWidth = 10;
    [Tooltip("The height limit of the swimming area where the group can swim.")]
    public float swimmingAreaHeight = 10;
    [Tooltip("The depth limit of the swimming area where the group can swim.")]
    public float swimmingAreaDepth = 10;
    [Tooltip("The width limit that the fishes will force themselves to swim inside.")]
    public float groupAreaWidth = 20;
    [Tooltip("The height limit that the fishes will force themselves to swim inside.")]
    public float groupAreaHeight = 20;
    [Tooltip("The depth limit that the fishes will force themselves to swim inside.")]
    public float groupAreaDepth = 20;
    [Tooltip("The prefab that will be instantiated to manipulate the fishes. If you are using instancing this is not going to be used.")]
    public GameObject prefab;

    [Tooltip("Draw the gizmos or debug lines on the scene view.")]
    public bool debugDraw = true;

    [Header("Flocking")]
    public int fishesCount;
    [Tooltip("Minimum speed to be applied on the fish direction vector.")]
    public float minSpeed = 3;
    [Tooltip("Maximum speed to be applied on the fish direction vector.")]
    public float maxSpeed = 8;
    [Tooltip("Minimum turn speed when rotating the fish to it's direction vector.")]
    public float minRotationSpeed = 5;
    [Tooltip("Maximum turn speed when rotating the fish to it's direction vector.")]
    public float maxRotationSpeed = 10;
    [Tooltip("Desired distance between neighbours.")]
    public float neighbourDistance = 1f;
    [Tooltip("Spawn Radius of the fishes.")]
    public float spawnRadius;
    [Tooltip("Variation speed that will be applied to the normal speed of the fishes.")]
    public float speedVariation = 0.6f;
    [Tooltip("In case you are not using instancing, this will cast a sphere and filter with this layer to find near fishes to each other.")]
    public LayerMask searchLayer;

    [Header("Random Target Points Following")]
    [Tooltip("Minimum target points that will randomly be generated to follow if not following a target.")]
    public int minTargetPoints = 5;
    [Tooltip("Maximum target points that will randomly be generated to follow if not following a target.")]
    public int maxTargetPoints = 12;
    [Tooltip("Recalculate points after the group reaches the last one.")]
    public bool recalculatePoints = false;
    [Tooltip("The speed in which the group area will move")]
    public float groupAreaSpeed = 0.8f;
    Vector3[] targetPositions;
    int currentTargetPosIndex = 0;

    [Header("Collision Avoidance"), Tooltip("Avoidance force when checking collisions with the boxes.")]
    public float force = 1;
    [Tooltip("Colliders that the fishes will try to avoid (for now it's only Box Colliders)")]
    public BoxCollider[] boxColliders = null;
    CollisionArea[] collisionData;
    int collisionDataLength;

    Vector3 groupAnchor;
    Transform myTransform;

    public FishBehaviour[] fishesData;
    Transform[] fishesTransforms;

    int currentFishesCount;
    int oldFishesCount;

    GameObject[] allFishs;
    SimpleCounter refreshFishCounter = new SimpleCounter();

    private void Awake()
    {
        myTransform = transform;

        InitializeFishes();

        refreshFishCounter.Start(0.6f);
    }

    void InitializeFishes()
    {
        int collidersLength = boxColliders.Length;
        if (boxColliders != null && collidersLength > 0)
        {
            collisionData = new CollisionArea[collidersLength];

            for (int i = 0; i < collidersLength; i++)
            {
                CollisionArea ca = new CollisionArea();
                BoxCollider bc = boxColliders[i];
                if (bc == null)
                {
                    Debug.LogError("One of the Box Colliders is null!");

                    boxColliders = new BoxCollider[0];
                    return;
                }

                Transform bcTransform = bc.transform;
                Vector3 localScale = bcTransform.localScale;

                Vector3 coll_pos = bc.transform.position;

                Vector3 coll_size = bc.size;
                coll_size.x *= localScale.x;
                coll_size.y *= localScale.y;
                coll_size.z *= localScale.z;

                coll_pos.x -= coll_size.x / 2.0f;
                coll_pos.y -= coll_size.y / 2.0f;
                coll_pos.z -= coll_size.z / 2.0f;

                ca.position = coll_pos;
                ca.size = coll_size;

                collisionData[i] = ca;
            }
        }

        currentFishesCount = fishesCount;
        oldFishesCount = currentFishesCount;
        allFishs = new GameObject[currentFishesCount];

    }

    void CreateFishData()
    {
        fishesData = new FishBehaviour[currentFishesCount];
        fishesTransforms = new Transform[currentFishesCount];

        for (int i = 0; i < currentFishesCount; i++)
        {
            fishesData[i] = CreateBehaviour();
            fishesData[i].speed_offset = Random.value * 10.0f;

            allFishs[i] = Instantiate(prefab, fishesData[i].position, Quaternion.identity);
            fishesTransforms[i] = allFishs[i].transform;
        }

        if (boxColliders.Length <= 0)
            collisionData = new CollisionArea[1] { new CollisionArea() };

        collisionDataLength = boxColliders.Length <= 0 ? 0 : collisionData.Length;

    }

    void Start()
    {
        GeneratePath();
        groupAnchor = targetPositions[0];
        
        CreateFishData();
    }

    FishBehaviour CreateBehaviour()
    {
        FishBehaviour behaviour = new FishBehaviour();
        Vector3 pos = groupAnchor + Random.insideUnitSphere * spawnRadius;
        Quaternion rot = Quaternion.Slerp(transform.rotation, Random.rotation, 0.3f);

        behaviour.position = pos;
        behaviour.velocity = rot.eulerAngles;

        behaviour.speed = Random.Range(minSpeed, maxSpeed);
        behaviour.rot_speed = Random.Range(minRotationSpeed, maxRotationSpeed);

        return behaviour;
    }

    void Update()
    {
        /*if (oldFishesCount != fishesCount)
        {
            if (refreshFishCounter.Ended())
            {
                // Dynamically change the fishes
                ClearAll();
                InitializeFishes();
                CreateFishData();
                //GC.Collect(); // Maybe?

                refreshFishCounter.Reset();
            }
        }*/

        UpdateGroupAnchor();
        var time = Time.time;
        var deltaTime = Time.deltaTime;

        for (int i = 0; i < currentFishesCount; i++)
        {
            FishBehaviour fish = fishesData[i];

            Transform fish_transform = fishesTransforms[i];

            fish.position = fish_transform.position;

            var current_pos = fish.position;
            var current_rot = fish_transform.rotation;

            var noise = Mathf.PerlinNoise(time, fish.speed_offset) * 2.0f - 1.0f;
            var fish_velocity = fish.speed * (1.0f + /*noise **/ speedVariation);

            var separation = Vector3.zero;
            var alignment = Vector3.zero;
            var cohesion = groupAnchor;

            //@Collisions!
            Vector3 next_position = fish.position + (fish.velocity * 3) * (fish_velocity * deltaTime);
            Vector3 avoidance = new Vector3(0, 0, 0);
            for (int c = 0; c < collisionDataLength; c++)
            {
                CollisionArea ca = collisionData[c];

                Vector3 collider_pos = ca.position;
                Vector3 collider_size = ca.size;

                if ((next_position.x >= collider_pos.x && next_position.x <= collider_pos.x + collider_size.x)
                    && (next_position.y >= collider_pos.y && next_position.y <= collider_pos.y + collider_size.y)
                    && (next_position.z >= collider_pos.z && next_position.z <= collider_pos.z + collider_size.z))
                {

                    Vector3 coll_point = collider_pos;
                    coll_point.x += collider_size.x / 2.0f;
                    coll_point.y += collider_size.y / 2.0f;
                    coll_point.z += collider_size.z / 2.0f;

                    avoidance += next_position - coll_point;
                    avoidance = (avoidance).normalized;
                    avoidance *= force;
                }
            }

            var nearby_fishes_count = 1;

            List<GameObject> nearbyBoids = new List<GameObject>(); 
            //= Physics.OverlapSphere(current_pos, neighbourDistance, searchLayer);
            
            for (int j = 0; j < currentFishesCount; j++) {
                var dis = allFishs[i].transform.position - allFishs[j].transform.position;
                if (dis.sqrMagnitude < neighbourDistance * neighbourDistance) {
                    nearbyBoids.Add(allFishs[j]);
                }
            }
            

            foreach (var boid in nearbyBoids)
            {
                if (boid.gameObject == fish_transform.gameObject) continue;

                var t = boid.transform;
                separation += GetSeparationVector(current_pos, t.position);
                alignment += t.forward;
                cohesion += t.position;
            }

            nearby_fishes_count = nearbyBoids.Count;

            var avg = 1.0f / nearby_fishes_count;
            alignment *= avg;
            cohesion *= avg;
            cohesion = (cohesion - current_pos).normalized;

            var velocity = separation + alignment + cohesion;
            velocity += avoidance;

            var ip = Mathf.Exp(-fish.rot_speed * deltaTime);

            fish.velocity = velocity.normalized;
            var rotation = Quaternion.FromToRotation(Vector3.forward, velocity.normalized);
            if (rotation != current_rot)
            {
                fish_transform.rotation = Quaternion.Lerp(rotation, current_rot, ip);
            }

            fish.position += fish_transform.forward * (fish_velocity * deltaTime);

            fish_transform.position = fish.position;

            fishesData[i] = fish;
        }
    }

    Vector3 GetSeparationVector(Vector3 my_pos, Vector3 target_pos)
    {
        var diff = my_pos - target_pos;
        var diffLen = diff.magnitude;
        var scaler = Mathf.Clamp01(1.0f - diffLen / neighbourDistance);
        return diff * (scaler / diffLen);
    }

    void OnDestroy()
    {
        ClearAll();
    }

    void ClearAll()
    {
        for (int i = 0; i < fishesTransforms.Length; i++)
        {
            Transform t = fishesTransforms[i];

            if (t)
            {
                GameObject obj = t.gameObject;
                obj.SetActive(false);

                Destroy(obj, 0.3f);
            }
        }
        
    }

    void UpdateGroupAnchor()
    {
        float minX = myTransform.position.x - (swimmingAreaWidth / 2) + (groupAreaWidth / 2);
        float maxX = myTransform.position.x + (swimmingAreaWidth / 2) - (groupAreaWidth / 2);

        float minY = myTransform.position.y - (swimmingAreaHeight / 2) + (groupAreaHeight / 2);
        float maxY = myTransform.position.y + (swimmingAreaHeight / 2) - (groupAreaHeight / 2);

        float minZ = myTransform.position.z - (swimmingAreaDepth / 2) + (groupAreaDepth / 2);
        float maxZ = myTransform.position.z + (swimmingAreaDepth / 2) - (groupAreaDepth / 2);

        Vector3 futurePosition = myTransform.position;

        if (targetPositions.Length > 0)
        {
            if ((groupAnchor - targetPositions[currentTargetPosIndex]).magnitude < 1)
            {
                currentTargetPosIndex++;

                if (currentTargetPosIndex >= targetPositions.Length)
                {
                    if (recalculatePoints)
                        GeneratePath();
                    else
                        currentTargetPosIndex = targetPositions.Length - 1;
                }
            }

            Vector3 vel = (targetPositions[currentTargetPosIndex] - groupAnchor);
            futurePosition = groupAnchor + vel * Time.deltaTime * groupAreaSpeed;
        }
        

        futurePosition.x = Mathf.Clamp(futurePosition.x, minX, maxX);
        futurePosition.y = Mathf.Clamp(futurePosition.y, minY, maxY);
        futurePosition.z = Mathf.Clamp(futurePosition.z, minZ, maxZ);

        groupAnchor = futurePosition;
    }

    void GeneratePath()
    {
        float minX = myTransform.position.x - (swimmingAreaWidth / 2) + (groupAreaWidth / 2);
        float maxX = myTransform.position.x + (swimmingAreaWidth / 2) - (groupAreaWidth / 2);

        float minY = myTransform.position.y - (swimmingAreaHeight / 2) + (groupAreaHeight / 2);
        float maxY = myTransform.position.y + (swimmingAreaHeight / 2) - (groupAreaHeight / 2);

        float minZ = myTransform.position.z - (swimmingAreaDepth / 2) + (groupAreaDepth / 2);
        float maxZ = myTransform.position.z + (swimmingAreaDepth / 2) - (groupAreaDepth / 2);

        targetPositions = new Vector3[Random.Range(minTargetPoints, maxTargetPoints)];

        Vector3 tempPos;
        for (int i = 0; i < targetPositions.Length; i++)
        {
            tempPos.x = Random.Range(minX, maxX);
            tempPos.y = Random.Range(minY, maxY);
            tempPos.z = Random.Range(minZ, maxZ);

            targetPositions[i] = tempPos;
        }

        currentTargetPosIndex = 0;
    }

    Vector3 volumeSize;
    private void OnDrawGizmos()
    {
        if (groupAreaWidth > swimmingAreaWidth || groupAreaHeight > swimmingAreaHeight || groupAreaDepth > swimmingAreaDepth)
        {
            groupAreaWidth = swimmingAreaWidth;
            groupAreaHeight = swimmingAreaHeight;
            groupAreaDepth = swimmingAreaDepth;

            Debug.Log("[Flocking Behaviour] The group area can't be bigger than the bounds.");
        }

        if (!debugDraw) return;

        volumeSize.x = swimmingAreaWidth;
        volumeSize.y = swimmingAreaHeight;
        volumeSize.z = swimmingAreaDepth;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, volumeSize);

        volumeSize.x = groupAreaWidth;
        volumeSize.y = groupAreaHeight;
        volumeSize.z = groupAreaDepth;

        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(Application.isPlaying ? groupAnchor : transform.position, volumeSize);

        /*if (Application.isPlaying)
        {
            Gizmos.color = Color.green;
            for (int i = 0; i < targetPositions.Length - 1; i++)
            {
                Gizmos.DrawLine(targetPositions[i], targetPositions[i + 1]);

                Gizmos.DrawWireSphere(targetPositions[i], 1f);

                if ((i + 1) == targetPositions.Length - 1)
                    Gizmos.DrawWireSphere(targetPositions[i + 1], 1f);
            }
        }*/
    }
}
