using System.Collections;
using UnityEngine;

public class SpawnLightning : MonoBehaviour
{
    [SerializeField] private float minSpawnTime = 3f;
    [SerializeField] private float maxSpawnTime = 10f;

    private void Start()
    {
        StartCoroutine(SpawnBolt());
    }
    IEnumerator SpawnBolt()
    {
        while (true)
        {
            Debug.Log("sfsdf");
            GameObject bolt = LightningPool.instance.GetPooledObject();

            bolt.transform.position = transform.position;
            bolt.transform.rotation = transform.rotation;

            if (bolt != null)
            {

                bolt.transform.position = transform.position;
                bolt.transform.rotation = transform.rotation;
                bolt.SetActive(true);

                StartCoroutine(ReturnToPoolAfterTime(bolt, 10f));
            }

            float randomDelay = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(randomDelay);
            
            
        }
        
    }

    private IEnumerator ReturnToPoolAfterTime(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);

        LightningPool.instance.ReturnPooledObject(obj);
    }
}
