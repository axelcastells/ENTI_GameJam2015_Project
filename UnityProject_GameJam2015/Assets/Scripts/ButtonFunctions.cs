using UnityEngine;
using System.Collections;

public class ButtonFunctions : MonoBehaviour {

    // When you click START the game starts

    private RaycastHit hit;
    private Ray ray;

    public GameObject tutorialPopup;

    public TextMesh hiScore;

    //public GameObject options;

    void Start()
    {
        if (hiScore != null) hiScore.text = "Hi-Score !\n" + PlayerPrefs.GetInt("HiScore");


    }

    void Update()
    {

        if (Input.GetKey(KeyCode.Escape))
        {
            if (Application.loadedLevel == 1) Application.LoadLevel(0);
            else if (Application.loadedLevel == 0) Application.Quit();
        }


        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {

                if(hit.transform.tag == "ExitButton")
                {
                    Application.Quit();
                    Debug.Log("Quit!");
                }
                else if(hit.transform.tag == "StartButton")
                {
                    if (PlayerPrefs.GetInt("PlayFirstTime") == 0)
                    {
                        PlayerPrefs.SetInt("PlayFirstTime", 1);
                        tutorialPopup.SetActive(true);
                    }
                    else if (PlayerPrefs.GetInt("PlayFirstTime") == 1)
                        Application.LoadLevel(1);
                }
                else if(hit.transform.tag == "BackButton")
                {
                    Application.LoadLevel(0);
                }

                else if (hit.transform.tag == "TutorialButton")
                {
                    tutorialPopup.active = !tutorialPopup.active;
                }
                //else if (hit.transform.tag == "ConfigButton")
                //{
                //    options.active = !options.active;
                //}
            }
        }
    }
}
