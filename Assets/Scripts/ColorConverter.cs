using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ColorConverter : MonoBehaviour
{
    public GameObject converterBar;
    public List<SpriteRenderer> nubList;

    public Color colorToConvertTo = Color.white;
    public float nubColorOffset = 0.2f;


    //left private as i dont need to know this for editing
    
    private Color nubColor = Color.white;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //converterBar.
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<SpriteRenderer>().color = colorToConvertTo;
    }

    //Validate runs every time something is changed in the inspector
    //Basically automates assigning a color
    private void OnValidate()
    {
        UpdateBaseColor();
    }

    //seperated from OnValidate incase I'd like to run this elsewhere in the future
    void UpdateBaseColor()
    {
        //Raw color to the Bar/Gate
        converterBar.GetComponent<SpriteRenderer>().color = colorToConvertTo;

        //Calc the nubColor now
        nubColor = colorToConvertTo;
        nubColor -= new Color(nubColorOffset, nubColorOffset, nubColorOffset);
        nubColor.a = 1;

        //Apply offset to Nubs, ballasts, idk what to call them
        
        foreach (SpriteRenderer nub in nubList)
        {
            nub.color = nubColor;
        }

    }

}
