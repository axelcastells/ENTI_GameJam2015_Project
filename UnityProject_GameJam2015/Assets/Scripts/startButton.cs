using UnityEngine;
using System.Collections;

public class startButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // When you click START the game starts
    void OnMouseDown()  {
        Application.LoadLevel("Gameplay");
    }
}
