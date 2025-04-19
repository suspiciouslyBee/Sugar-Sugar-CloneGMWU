using UnityEngine;

public class Mug : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if && works like C/C++, the object tag will get checked first
        //mouthful, just checking if the collider is a particle, then checking if our (mug's) color
        //matches

        if(collision.CompareTag("Particle") 
            && collision.GetComponent<SpriteRenderer>().color 
            == gameObject.GetComponent<SpriteRenderer>().color)
        {
            Destroy(collision.gameObject);
        }
    }
}
