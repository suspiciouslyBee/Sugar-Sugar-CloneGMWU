using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Mug : MonoBehaviour
{
    //bake
    public int mugRemaining = 100;
    public TextMeshProUGUI scoreTextObj; //just store the ref


    //
    public Dictionary<Color, int> capacityPerColor = new Dictionary<Color, int>();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreTextObj.text = mugRemaining.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        scoreTextObj.text = mugRemaining.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if && works like C/C++, the first item will get checked first

        //order of elimination:
        //mugRemaining (broadest) - will not accept anything if < 1
        //only accepts particles from then on

        //the original Sugar Sugar game would accept/destroy all particles at this point, but
        //wouldnt decrement the counter. so ive replicated this with a nested if


        if (mugRemaining > 0 && collision.CompareTag("Particle"))
        {
            if (collision.GetComponent<SpriteRenderer>().color
                == gameObject.GetComponent<SpriteRenderer>().color)
            {
                mugRemaining--;
            }

            Destroy(collision.gameObject);

        }
    }
}
