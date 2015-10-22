using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

    private enum PlayerState { WAIT, ALIVE, DEAD }
    private PlayerState playerState;

    public int beatsToWait;
    public TextMesh scoreText;
    public TextMesh scoreTextGameOver;
    public TextMesh hiScoreText;
    public TextMesh hiScoreTextGameOver;
    public TextMesh startText;

    public Material pickSilverMat;
    public Material pickGoldMat;

    public GameObject playerRender;
    public Material goldMat;
    public Material silverMat;

    private int score = 0;

    private bool failedOnBeat = true;

    public GameObject gameOver;

	// Use this for initialization
	void Start () {

        //DEBUG
        //PlayerPrefs.SetInt("HiScore", 5);
        //DEBUG END

        startText.text = (--beatsToWait).ToString();

        playerState = PlayerState.WAIT;

        scoreText.text = "BEAT!\n" + score;
        hiScoreText.text = "Hi-Score!\n" + PlayerPrefs.GetInt("HiScore");

        SetSilver();
    }

	// Update is called once per frame
	void FixedUpdate () {

        switch (playerState)
        {
            case PlayerState.WAIT:
                {
                    if (BeatSystem.beatNow == true)
                    {
                        startText.text = (--beatsToWait).ToString();
                    }
                    if (beatsToWait == 0 && BeatSystem.beatNow == true)
                    {
                        playerState = PlayerState.ALIVE;
                        startText.text = "GO!";
                    }
                }
                break;
            case PlayerState.ALIVE:
                {
                    if(BeatSystem.beatNow == true && startText.gameObject.activeSelf == true)
                        startText.gameObject.SetActive(false);

                    this.transform.Translate(BeatSystem.speed * Time.fixedDeltaTime, 0, 0);

                    if (PlayerPrefs.GetInt("HiScore") == score)
                        SetGold();
                    //if()

                }
                break;
            case PlayerState.DEAD:
                {

                    //if (PlayerPrefs.GetInt("HiScore") < score)
                    //{
                    //    PlayerPrefs.SetInt("HiScore", score);
                    //}

                    SetScores();

                    if (BeatSystem.pause == false) BeatSystem.TogglePause(gameOver);
                }
                break;
            default:
                break;
        }
         //transform.Translate((float)BeatSystem.bps * Time.fixedDeltaTime, 0, 0);

    }

    private void SetSilver()
    {
        playerRender.GetComponent<MeshRenderer>().material = silverMat;
        scoreText.transform.parent.GetComponent<MeshRenderer>().material = pickSilverMat;
        hiScoreText.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
    }

    private void SetGold()
    {
        playerRender.GetComponent<MeshRenderer>().material = goldMat;
        hiScoreText.transform.parent.GetComponent<MeshRenderer>().material = pickGoldMat;
        scoreText.gameObject.SetActive(false);
        hiScoreText.gameObject.SetActive(true);
    }

    private void SetScores()
    {
        //if (PlayerPrefs.GetInt("HiScore") <= score) PlayerPrefs.SetInt("HiScore", score);

        scoreText.text = "BEAT!\n" + score;
        hiScoreText.text = "Hi-Score!\n" + PlayerPrefs.GetInt("HiScore");
        hiScoreTextGameOver.text = hiScoreText.text;

        scoreTextGameOver.text = "Your Score!\n" + score.ToString();
    }

    void OnTriggerStay(Collider other)
    {
        DetectBeatSpawned(other);
    }

    void OnTriggerExit(Collider other)
    {
        if (failedOnBeat == true)
        {
            Debug.Log("DEAD");
            playerState = PlayerState.DEAD;
        }
    }

    private void DetectIfSucceded()
    {
        if (PlayerPrefs.GetInt("HiScore") > score)
        {
            score++;
        }

        else if (PlayerPrefs.GetInt("HiScore") <= score)
        {
            PlayerPrefs.SetInt("HiScore", ++score);
        }


        //Lauch Particle System


        SetScores();

        //if (other.transform.tag == "Beat1Touch" || other.transform.tag == "Beat2Touches" || other.transform.tag == "BeatNoTouch")
        //{

        //    if (failedOnBeat == false)
        //    {
        //        if (PlayerPrefs.GetInt("HiScore") > score)
        //        {
        //            score++;
        //        }

        //        else if (PlayerPrefs.GetInt("HiScore") <= score)
        //        {
        //            PlayerPrefs.SetInt("HiScore", ++score);
        //        }

        //        SetScores();
        //    }

        //    failedOnBeat = true;
        //    //SetScores();
        //}
    }

    private void DetectBeatSpawned(Collider aux)
    {
        if (aux.transform.tag == "Beat1Touch")
        {
            if (Input.touchCount == 1 || Input.GetKey(KeyCode.A))
            {
                failedOnBeat = false;
                Destroy(aux.gameObject);
                DetectIfSucceded();
            }
            else
                failedOnBeat = true;
        }
        else if (aux.transform.tag == "Beat2Touches")
        {
            if (Input.touchCount == 2 || Input.GetKey(KeyCode.S))
            {
                failedOnBeat = false;
                Destroy(aux.gameObject);
                DetectIfSucceded();
            }
            else
                failedOnBeat = true;
        }
        else if (aux.transform.tag == "BeatNoTouch")
        {
            if (Input.touchCount == 0 || Input.GetKey(KeyCode.D))
            {
                failedOnBeat = false;
                Destroy(aux.gameObject);
                DetectIfSucceded();
            }
            else
                failedOnBeat = true;
        }

        //If player touch out of the beat he lose

        else if (Input.touchCount != 0)
        {
            failedOnBeat = true;

        }
    }
}
