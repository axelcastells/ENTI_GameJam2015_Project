using UnityEngine;
using System.Collections;

public class ButtonFunctions : MonoBehaviour {

    // When you click START the game starts
    private RaycastHit hit;
    private Ray ray;

    public GameObject options;

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
                }
                else if(hit.transform.tag == "StartButton")
                {
                    Application.LoadLevel(2);
                }
                else if(hit.transform.tag == "ConfigButton")
                {
                    options.active = !options.active;
                }
            }
        }
    }
}
