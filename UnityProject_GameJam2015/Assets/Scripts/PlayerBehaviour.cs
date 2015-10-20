using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

    private enum PlayerState { ALIVE, DEAD }
    private PlayerState playerState;

	// Use this for initialization
	void Start () {
        playerState = PlayerState.ALIVE;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        switch (playerState)
        {
            case PlayerState.ALIVE:
                {
                    this.transform.Translate((float)BeatSystem.bps * Time.deltaTime, 0, 0);
                }
                break;
            case PlayerState.DEAD:
                {

                }
                break;
            default:
                break;
        }
         //transform.Translate((float)BeatSystem.bps * Time.fixedDeltaTime, 0, 0);
    }
}
