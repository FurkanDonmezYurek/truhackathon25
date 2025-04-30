using UnityEngine;

public class AppleSpawn : MonoBehaviour
{   
    public GameObject applePref;
    void Start()
    {
        CreateShoulderCollider();
    }
    void Update()
    {
        
    }
    private void CreateShoulderCollider()
    {
        Debug.Log("ColliderSpawned");
        var go = new GameObject("ShoulderReachCollider");
        go.transform.parent = transform;
        go.transform.localPosition = Vector3.zero;


        var sph = go.AddComponent<SphereCollider>();
        sph.isTrigger = true;
        var spawner = go.AddComponent<SpawnerColliderSC>();
        spawner.applePref = applePref;
        sph.radius = DataBaseMuhammet.colliderRadius;
        
    }


}
