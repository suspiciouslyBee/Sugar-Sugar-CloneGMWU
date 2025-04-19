using System.Collections;
using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{

    //-1 for infinite
    public int remainingSugar;
    public bool infiniteSpawn;
    public float spawnInterval = 0.1f; //estimate
    public float spawnDelay;
    public GameObject SugarObject; //reminder configure the sugar with the color!

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine("SpawnSugar");
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    IEnumerator SpawnSugar()
    {
        yield return new WaitForSeconds(spawnDelay);

        while (infiniteSpawn || remainingSugar > 0)
        {
            {
                //spawn the sugar
                Instantiate(SugarObject, transform.position,
                            SugarObject.transform.rotation);

                yield return new WaitForSeconds(spawnInterval);

                if (!infiniteSpawn) { remainingSugar--; }
         
            }

            yield return null;
        }
    }




}
