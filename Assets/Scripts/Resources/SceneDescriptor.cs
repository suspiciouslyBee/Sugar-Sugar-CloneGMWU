using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


//Scene descriptior tells Game Manager how to react
public class SceneDescriptor : MonoBehaviour
{
    //singleton to the scene
    public static SceneDescriptor localInstance;

    public float localDefaultGravityScale = 0.1f;
    public float localDefaultDelay = 0;

    public GameObject[] spawners;


    public Color backgroundColor = Color.grey;
    public Color foregroundColor = Color.white;
    public Color textColor = Color.white;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (localInstance != null)
        {
            Destroy(gameObject);
            return;
        }

        localInstance = this;
        //no dont destroy here.

        
        GameManager.Instance.UpdateDrawColor(foregroundColor);
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnValidate()
    {
        SyncData();

        //GameObject[] text = GameObject.FindGameObjectsWithTag("Foreground");
    }


    public void SyncData()
    {
        GameObject[]
        foregroundObjects = GameObject.FindGameObjectsWithTag("Foreground");
        foreach (GameObject foregroundObject in foregroundObjects)
        {
            if (foregroundObject != null)
            {
                foregroundObject.GetComponent<SpriteRenderer>().color = foregroundColor;
            }
        }
        Camera.main.backgroundColor = backgroundColor;

        //auto populate
        spawners = GameObject.FindGameObjectsWithTag("Spawner");
        foreach (GameObject spawner in spawners)
        {
            spawner.gameObject.GetComponent<ParticleSpawner>().spawnDelay = localDefaultDelay;
        }

        UpdateSceneGravity(localDefaultGravityScale);
    }



    public void UpdateSceneGravity(float newGravity)
    {
        localDefaultGravityScale = newGravity;
        foreach (var spawner in spawners)
        {
            spawner.gameObject.GetComponent<ParticleSpawner>().UpdateGravity(newGravity);
        }
    }
}
