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
    void NextStage()
    {
        //int currentIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void ReloadStage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
