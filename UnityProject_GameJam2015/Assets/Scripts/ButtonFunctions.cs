using UnityEngine;
using System.Collections;

public class ButtonFunctions : MonoBehaviour {

    // When you click START the game starts
    private RaycastHit hit;
    private Ray ray;

    public TextMesh hiScore;

    //public GameObject options;

    void Start()
    {
        hiScore.text = "Hi-Score !\n" + PlayerPrefs.GetInt("HiScore");
    }

    void Update()
    {

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
                    Application.LoadLevel(1);
                }
                //else if (hit.transform.tag == "ConfigButton")
                //{
                //    options.active = !options.active;
                //}
            }
        }
    }
}
