using UnityEngine;

public class ColorConverter : MonoBehaviour
{
    public GameObject converterBar;

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
        collision.GetComponent<SpriteRenderer>().color 
            = converterBar.GetComponent<SpriteRenderer>().color;
    }
}
