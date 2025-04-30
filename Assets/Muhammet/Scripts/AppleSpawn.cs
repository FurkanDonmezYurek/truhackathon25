using UnityEngine;

public class AppleSpawn : MonoBehaviour
{   
    public GameObject applePref;
    public GameObject badApplePref;
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
        spawner.badApplePref = badApplePref;
        sph.radius = DataBaseMuhammet.colliderRadius;
        
    }


}
