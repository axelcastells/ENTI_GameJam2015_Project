using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

    private enum PlayerState { WAIT, ALIVE, DEAD }
    private PlayerState playerState;

    public int beatsToWait;

    private double counter = 0;
	// Use this for initialization
	void Start () {
        playerState = PlayerState.WAIT;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        switch (playerState)
        {
            case PlayerState.WAIT:
                {
                    if (BeatSystem.beatNow == true)
                        counter++;

                    if (counter == beatsToWait)
                        playerState = PlayerState.ALIVE;
                }
                break;
            case PlayerState.ALIVE:
                {
                    
                    this.transform.Translate((float)BeatSystem.bps*15 * Time.fixedDeltaTime, 0, 0);
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
