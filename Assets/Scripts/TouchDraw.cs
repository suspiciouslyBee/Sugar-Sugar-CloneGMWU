using System.Collections;
using UnityEngine;

public class TouchDraw : MonoBehaviour
{

    //used a tutorial from zero kelvin tutorial. it was very handy
    //the major roadblock behind doing this clone
    //i did 

    //TODO: may need to refactor to an input manager
    //worry about that later
    Coroutine drawing;
    public GameObject lineAsset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //Was considering replacing with switch statement. but i realized that finish line needs to 
        //repeat once

        if(Input.GetMouseButtonDown(0)){
            StartLine();
        }

        if(Input.GetMouseButtonUp(0)) {
            FinishLine();
        }
    }

    void StartLine() {
        if(drawing != null) {
            StopCoroutine(drawing);
        }

        drawing = StartCoroutine(DrawLine());
    }


    void FinishLine() {
        StopCoroutine(drawing);
    }


    //tutorial was instantiating it by looking up the prefab
    //i thought that was a bit inefficient and unclear when this could just have stored the prefab
    IEnumerator DrawLine() {


        GameObject newStroke = Instantiate(lineAsset, Vector3.zero, Quaternion.identity);
        //need to store the LR
        LineRenderer line = newStroke.GetComponent<LineRenderer>();
        line.positionCount = 0;

        while(true) {

            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position.z = 0;
            line.positionCount++;
            line.SetPosition(line.positionCount-1, position);

            yield return null;
        }

    }

}
