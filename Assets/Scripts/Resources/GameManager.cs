using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    //int currentSceneIndex;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //bruteforce bindings

        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadStage();
        }

        if (Input.GetKeyDown(KeyCode.Plus))
        {
            NextStage();
        }

        if (Input.GetKeyDown(KeyCode.Minus))
        {
            PreviousStage();
        }
    }


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }


    //called when any cup is filled
    void CheckFilledCups()
    {
        GameObject[] mugs = GameObject.FindGameObjectsWithTag("Mug");

        if(mugs == null) { return; }

        int numberOfFilledMugs = 0;

        foreach (GameObject mug in mugs)
        {
            //because i didnt want to do a forloop *titanic recorder cover music*
            numberOfFilledMugs += mug.gameObject.GetComponent<Mug>().isFilled.ConvertTo<int>();
        }
    }

    //Loads the next stage by build index
    //does nothing if invalid
    //has the side effect of 0 being reachable once
    void ChangeStage(int number)
    {
        int newIndex = SceneManager.GetActiveScene().buildIndex + number;

        //bounds check
        if(0 > newIndex || newIndex > SceneManager.sceneCountInBuildSettings - 1)
        {
            Debug.Log("No more scenes!");
            return;
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + number);
    }

    void PreviousStage()
    {
        ChangeStage(-1);
    }

    void NextStage()
    {
        ChangeStage(1);
    }

    void ReloadStage()
    {
        ChangeStage(0);
    }


}
