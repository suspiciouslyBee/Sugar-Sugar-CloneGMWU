using UnityEngine;

public class Gate : MonoBehaviour
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
        if (collision.CompareTag("Particle"))
        {
            collision.GetComponent<SpriteRenderer>().color =
                gameObject.GetComponent<SpriteRenderer>().color;
            //Debug.Log("Should be changing color!");
        }
    }
}
