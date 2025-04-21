using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;


//Scene descriptior tells Game Manager how to react
public class SceneDescriptor : MonoBehaviour
{
    //singleton to the scene
    public static SceneDescriptor localInstance;

    public float localDefaultGravityScale = 0.1f;
    public float localDefaultDelay = 0; 

    public List<ParticleSpawner> spawners;


    public Color backgroundColor;
    public Color foregroundColor;
    public Color textColor;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(localInstance != null)
        {
            Destroy(gameObject);
            return;
        }

        localInstance = this;
        //no dont destroy here.
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void OnValidate()
    {
        GameObject[] foregroundObjects = GameObject.FindGameObjectsWithTag("Foreground");
        foreach (GameObject foregroundObject in foregroundObjects)
        {
            if (foregroundObject != null)
            {
                foregroundObject.GetComponent<SpriteRenderer>().color = foregroundColor;
            }
        }
        Camera.main.backgroundColor = backgroundColor;
        
        //auto populate

    


        //GameObject[] text = GameObject.FindGameObjectsWithTag("Foreground");
    }


    public void UpdateSceneGravity(float newGravity)
    {
       localDefaultGravityScale = newGravity;
        foreach (var spawner in spawners)
        {
            spawner.UpdateGravity(newGravity);
        }
    }
}
