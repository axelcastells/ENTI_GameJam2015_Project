using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

    private enum PlayerState { WAIT, ALIVE, DEAD }
    private PlayerState playerState;

    public int beatsToWait;
    public TextMesh scoreText;
    public TextMesh hiScoreText;

    private int score = 0;

    private bool failedOnBeat = true;

    private double counter = 0;
	// Use this for initialization
	void Start () {
            

        playerState = PlayerState.WAIT;

        scoreText.text = "BEAT!\n" + score;
        hiScoreText.text = "HiScore!\n" + PlayerPrefs.GetInt("HiScore");
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        switch (playerState)
        {
            case PlayerState.WAIT:
                {
                    if (BeatSystem.beatNow == true)
                        counter++;

                    if (counter == beatsToWait && BeatSystem.beatNow == true)
                        playerState = PlayerState.ALIVE;
                }
                break;
            case PlayerState.ALIVE:
                {
                    
                    this.transform.Translate(BeatSystem.speed * Time.fixedDeltaTime, 0, 0);

                    //if()
                }
                break;
            case PlayerState.DEAD:
                {
                    if (PlayerPrefs.GetInt("HiScore") < score)
                    {
                        PlayerPrefs.SetInt("HiScore", score);
                    }

                    hiScoreText.text = "HiScore!\n" + PlayerPrefs.GetInt("HiScore");
                }
                break;
            default:
                break;
        }
         //transform.Translate((float)BeatSystem.bps * Time.fixedDeltaTime, 0, 0);

    }

    void OnTriggerStay(Collider other)
    {
        DetectBeatSpawned(other);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Beat1Touch" || other.transform.tag == "Beat2Touches" || other.transform.tag == "BeatNoTouch")
        {
            if (failedOnBeat == true)
            {
                Debug.Log("DEAD");
                playerState = PlayerState.DEAD;
            }

            else if (failedOnBeat == false)
            {
                scoreText.text = "BEAT!\n" + ++score;
            }

            failedOnBeat = true;
        }
    }

    private void DetectBeatSpawned(Collider aux)
    {
        if(aux.transform.tag == "Beat1Touch")
        {
            if(Input.touchCount == 1 || Input.GetKey(KeyCode.A))
            {
                failedOnBeat = false;
            }
        }
        else if(aux.transform.tag == "Beat2Touches")
        {
            if (Input.touchCount == 2 || Input.GetKey(KeyCode.S))
            {
                failedOnBeat = false;
            }
        }
        else if(aux.transform.tag == "BeatNoTouch")
        {
            if(/*Input.touchCount == 0*/Input.GetKey(KeyCode.D))
            {
                failedOnBeat = false;
            }
        }
    }
}
