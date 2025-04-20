using NUnit.Framework;
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

    //This is bad, but I want to keep track of all so that the gravity button doesn't have to look
    //up all sugar object

    //NOW IF I COULD HAVE
    //public List<SugarList>

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
