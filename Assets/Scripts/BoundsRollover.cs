using UnityEngine;

public class BoundsRollover : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 correctedPos = Camera.main.WorldToViewportPoint(
                               transform.position);
        float horizontalBound = Camera.main.ScreenToWorldPoint(Vector3.right).x;
        float verticalBound = Camera.main.ScreenToWorldPoint(Vector3.up).y;


        //bounds checking before moving

        //physics handles motion so i should be able to just only check bounds
        if (0 > correctedPos.y || correctedPos.y > 1)
        {
            transform.position = new Vector3(transform.position.x,
            transform.position.y < 0 ? -verticalBound : verticalBound,
            transform.position.z);
        }

    }
}
