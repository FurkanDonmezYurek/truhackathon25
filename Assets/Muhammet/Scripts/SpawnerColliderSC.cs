using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;
using System.Collections;


public class SpawnerColliderSC : MonoBehaviour
{
    public GameObject applePref;
    public GameObject badApplePref;

    private List<Vector3> spawnPositions = new List<Vector3>();

    private bool isWarked;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "AppleSpawnPosition")
        {
            Debug.Log("AppleSpawning");

            //GameObject apple = Instantiate(applePref, other.transform.position, Quaternion.identity);
            spawnPositions.Add(other.transform.position);
        }
    }

    private void Start()
    {
        StartCoroutine(StartEnumn());
    }

    private IEnumerator StartEnumn()
    {
        int y = 0;
        while (true)
        {

            yield return new WaitForSeconds(0.1f);
            if (y <= 20)
            {
                if (spawnPositions.Count == 0)
                {
                    y ++;
                    continue;

                }
                else
                {
                    Debug.Log("spawnPositions Count = " + spawnPositions.Count);

                    for (int i = 0; i < DataBaseMuhammet.appleCount; i++)
                    {
                        int random = Random.Range(1, spawnPositions.Count - i);
                        Instantiate(applePref, spawnPositions[random], Quaternion.identity);
                        spawnPositions.RemoveAt(random);
                        //yield return;
                    }

                    for (int i = 0; i < DataBaseMuhammet.badAppleCount; i++)
                    {
                        int random = Random.Range(1, spawnPositions.Count - i);
                        Instantiate(badApplePref, spawnPositions[random], Quaternion.identity);
                        spawnPositions.RemoveAt(random);
                        //yield return;
                    }
                }
            }

            break;

            
        }
        

    }
}
