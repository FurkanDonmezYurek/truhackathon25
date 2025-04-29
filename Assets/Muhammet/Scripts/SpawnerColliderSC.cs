using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class SpawnerColliderSC : MonoBehaviour
{
    public GameObject applePref;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.CompareTag("AppleSpawnPosition"))
        {
            Debug.Log("AppleSpawning");

            GameObject apple = Instantiate(applePref, other.transform.position, Quaternion.identity);

        }
    }
    //private void OnTriggerStay(Collider other)
    //{
    //    Debug.Log(other.gameObject.name);
    //    if (other.gameObject.tag == "AppleSpawnPosition")
    //    {
    //        Debug.Log("AppleSpawning");

    //        GameObject apple = Instantiate(applePref, other.transform.position, Quaternion.identity);

    //    }
    //}

}
