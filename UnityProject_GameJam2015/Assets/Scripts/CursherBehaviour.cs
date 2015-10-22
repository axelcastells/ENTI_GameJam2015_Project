using UnityEngine;
using System.Collections;

public class CursherBehaviour : MonoBehaviour {

    private enum State { DOWN, UP, MOVINGDOWN, MOVINGUP }

    private State state;

    public float distanceHeight;

    private Vector3 downPosition;
    private Vector3 upPosition;

    private float initPosition;

	// Use this for initialization
	void Start () {

        downPosition = this.transform.localPosition;
        upPosition = this.transform.localPosition + new Vector3(0, distanceHeight, 0);

        //Randomize the start position: UP / DOWN
        if (Random.Range(0, 2) == 1)
        {
            state = State.UP;
            this.transform.localPosition = upPosition;
        }


        else
        {
            state = State.DOWN;
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        //this.transform.localPosition = Vector3.Lerp(upPosition, downPosition, 2 * Time.fixedDeltaTime);
        Debug.Log(state);

        switch (state)
        {
            case State.DOWN:
                {
                    state = State.MOVINGUP;
                    //initPosition = downPosition.y;
                }
                break;
            case State.UP:
                {
                    state = State.MOVINGDOWN;
                    //initPosition = upPosition.y;
                }
                break;
            case State.MOVINGDOWN:
                {

                    MoveDown();

                    if (BeatSystem.beatNow == true)
                        state = State.DOWN;
                }
                break;
            case State.MOVINGUP:
                {

                    MoveUp();

                    if (BeatSystem.beatNow == true)
                        state = State.UP;
                }
                break;
            default:
                break;
        }
    }

    private void GoDown()
    {

    }

    private void GoUp()
    {

    }

    private void MoveDown()
    {
        this.transform.Translate(0, (float)((downPosition.y - upPosition.y) / BeatSystem.bps) * Time.deltaTime, 0);

        //this.transform.position = Vector3.Lerp(downPosition, upPosition, (float)(BeatSystem.bps / 10) * 2);
        /*this.transform.localPosition = new Vector3(Mathf.Lerp(upPosition.x, downPosition.x, (float)(BeatSystem.bps / 10) * 2),
                                                Mathf.Lerp(upPosition.y, downPosition.y, (float)(BeatSystem.bps / 10) * 2),
                                                Mathf.Lerp(upPosition.z, downPosition.z, (float)(BeatSystem.bps / 10) * 2));*/
    }

    private void MoveUp()
    {
        this.transform.Translate(0, (float)((upPosition.y - downPosition.y) / BeatSystem.bps) * Time.deltaTime, 0);

        //this.transform.position = Vector3.Lerp(upPosition, downPosition, (float)(BeatSystem.bps / 10) * 8);
        /*this.transform.localPosition = new Vector3(Mathf.Lerp(downPosition.x, upPosition.x, (float)(BeatSystem.bps / 10) * 8),
                                                Mathf.Lerp(downPosition.y, upPosition.y, (float)(BeatSystem.bps / 10) * 8),
                                                Mathf.Lerp(downPosition.z, upPosition.z, (float)(BeatSystem.bps / 10) * 8));*/
    }
}
