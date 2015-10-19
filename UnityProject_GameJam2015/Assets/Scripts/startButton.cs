using UnityEngine;
using System.Collections;

public class startButton : MonoBehaviour {

    // When you click START the game starts
    void OnMouseDown()  {
        Application.LoadLevel("Gameplay");
    }
}
