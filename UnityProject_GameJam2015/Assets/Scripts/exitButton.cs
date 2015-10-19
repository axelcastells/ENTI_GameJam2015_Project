using UnityEngine;
using System.Collections;

public class exitButton : MonoBehaviour {

    // When click on Exit button you quit the game
    void OnMouseDown()
    {
        Application.Quit();
    }
}
