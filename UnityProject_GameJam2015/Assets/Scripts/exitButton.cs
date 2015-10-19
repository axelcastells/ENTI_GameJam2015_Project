using UnityEngine;
using System.Collections;

public class exitButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // When click on Exit button you quit the game
    void OnMouseDown()
    {
        Application.Quit();
    }
}
