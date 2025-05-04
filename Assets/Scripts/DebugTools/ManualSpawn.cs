using UnityEngine;

public class ManualSpawn : MonoBehaviour
{

    public KeyCode key;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }  
    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(key)){
            gameObject.GetComponent<ParticleSpawner>().remainingSugar = 1;
            gameObject.GetComponent<ParticleSpawner>().StartCoroutine("SpawnSugar");
        }
    }
}
