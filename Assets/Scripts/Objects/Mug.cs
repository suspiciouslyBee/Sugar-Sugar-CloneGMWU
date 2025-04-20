using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Mug : MonoBehaviour
{


    //bake
  
    public TextMeshProUGUI scoreTextObj; //just store the ref


    public delegate void TriggerHandler(Collider2D collision);
    TriggerHandler mugTrigger;
   
    


    //NOTE: only officially supports two colors, but this format lets me expand with more colors
    //in a future revision
    //public MugColors colorMatrix;

    //which makes this super silly;

    
    public Color primary = Color.white;
    public SpriteRenderer baseColorObject;
    public int primaryRemaining = 100;
    public Color secondary = Color.white;
    public SpriteRenderer secondaryColorObject;
    public int secondaryRemaining = 0;
   
    public bool isFilled = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //mugRemaining = colorMatrix.RemainingTotalSugar();
        //scoreTextObj.text = mugRemaining.ToString();

        scoreTextObj.text = (primaryRemaining + secondaryRemaining).ToString();

        //set the behavior mode between single or dynamic

        if (primary == secondary || secondaryRemaining < 1)
        {
            mugTrigger = SingleColorTrigger;
        }
        else
        {
            mugTrigger = DoubleColorTrigger;
        }


    }

    // Update is called once per frame
    void Update()
    {
        //scoreTextObj.text = mugRemaining.ToString();

        scoreTextObj.text = (primaryRemaining + secondaryRemaining).ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isFilled)
        {
            return;
        }

        if (TotalRemaining() < 1 || !collision.CompareTag("Particle"))
        {
            return;
        }
        mugTrigger(collision);
        Destroy(collision.gameObject);

        if(TotalRemaining() < 1)
        {
            isFilled = true;
            //function to the scene manager

            //doing this asyncly because its not imparitive that this happens right now, holding
            //up game updates
            GameManager.Instance.SendMessage("CheckFilledCups");
        }

    }

    int TotalRemaining()
    {
        return primaryRemaining + secondaryRemaining;
    }

    void SingleColorTrigger(Collider2D collision)
    {

        //Debug.Log("Single Color Trigger Activated");
        //if && works like C/C++, the first item will get checked first

        //order of elimination:
        //mugRemaining (broadest) - will not accept anything if < 1
        //only accepts particles from then on

        //the original Sugar Sugar game would accept/destroy all particles at this point, but
        //wouldnt decrement the counter. so ive replicated this with a nested if



        if (primary == collision.GetComponent<SpriteRenderer>().color)
        {
            primaryRemaining--;
        }

        
    }




    //nested ifs for bounds checking
    //heavier, so seperated
    void DoubleColorTrigger(Collider2D collision)
    {

        if (primary == collision.GetComponent<SpriteRenderer>().color)
        {
            if (primaryRemaining > 0)
            {
                primaryRemaining--;
            }
        }
        else if (secondary == collision.GetComponent<SpriteRenderer>().color) {
            if (secondaryRemaining > 0)
            {
                secondaryRemaining--;
            }
        }

       




    }


    //change at this level, update both the mug color and secondary color
    //this is a stopgap automation tool but i just want to move on to doing levels
    //changes stripes if secondary remaining is larger than 0
    

    private void OnValidate()
    {
        baseColorObject.color = primary;
        if(secondaryRemaining < 1)
        {
            secondaryColorObject.color = primary;
            return;
        }

        secondaryColorObject.color = secondary;

    }
    

}
