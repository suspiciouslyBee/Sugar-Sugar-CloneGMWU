using UnityEngine;


// Press space
// highly inefficient since each prefab will have this so all will be checking
// input
// dont use this for prod. I beg of you
public class ManuallyActivateGravityInObject : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }
}
