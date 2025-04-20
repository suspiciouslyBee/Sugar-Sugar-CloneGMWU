using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Mug : MonoBehaviour
{


    //bake
  
    public TextMeshProUGUI scoreTextObj; //just store the ref


    public delegate void TriggerHandler(Collider2D collision);
    TriggerHandler mugTrigger;


    public MugColors colorMatrix;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //mugRemaining = colorMatrix.RemainingTotalSugar();
        //scoreTextObj.text = mugRemaining.ToString();

        scoreTextObj.text = colorMatrix.RemainingTotalSugar().ToString();

        //set the behavior mode between single or dynamic

        if (colorMatrix.ColorCount() > 1)
        {
            mugTrigger = MultipleColorTrigger;
        }
        else
        {
            mugTrigger = SingleColorTrigger;
        }


    }

    // Update is called once per frame
    void Update()
    {
        //scoreTextObj.text = mugRemaining.ToString();

        scoreTextObj.text = colorMatrix.RemainingTotalSugar().ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        mugTrigger(collision);
    }


    void SingleColorTrigger(Collider2D collision)
    {

        Debug.Log("Single Color Trigger Activated");
        //if && works like C/C++, the first item will get checked first

        //order of elimination:
        //mugRemaining (broadest) - will not accept anything if < 1
        //only accepts particles from then on

        //the original Sugar Sugar game would accept/destroy all particles at this point, but
        //wouldnt decrement the counter. so ive replicated this with a nested if

        int mugRemaining = colorMatrix.RemainingTotalSugar();

        if (mugRemaining > 0 && collision.CompareTag("Particle"))
        {
            if (collision.GetComponent<SpriteRenderer>().color
                == gameObject.GetComponent<SpriteRenderer>().color)
            {
                mugRemaining--;
            }

            

        }
    }





    //heavier, so seperated
    void MultipleColorTrigger(Collider2D collision)
    {

        int remainingColoredSugar;

        //see if the color exists in the dictionary
        if(!colorMatrix.GetDictionary().TryGetValue(
           collision.GetComponent<SpriteRenderer>().color, out remainingColoredSugar))
        {
            Debug.Log("No Match " + collision.GetComponent<SpriteRenderer>().color + " " 
                      + colorMatrix.GetDictionary()[Color.white]);
            Destroy(collision.gameObject);
            return;
        }

        if(remainingColoredSugar < 1 || !collision.CompareTag("Particle"))
        {
            Debug.Log("Not Particle or sugar filled");
            Destroy(collision.gameObject);
            return;
        }

        Debug.Log("decrement time");
        colorMatrix.GetDictionary()[collision.GetComponent<SpriteRenderer>().color]--;

        //remainingColoredSugar--;
        Destroy(collision.gameObject);
        return;



    }


}
