using UnityEngine;
using System.Collections;

public class CursherBehaviour : MonoBehaviour {

    private enum State { DOWN, UP, MOVINGDOWN, MOVINGUP }

    private State state;

    private Vector3 initialPosition;

    public float distanceHeight;

	// Use this for initialization
	void Start () {

        initialPosition = this.transform.position;

        if (Random.Range(0, 1) == 1)
            state = State.UP;
        
        else
            state = State.DOWN;

	}
	
	// Update is called once per frame
	void Update () {

        switch (state)
        {
            case State.DOWN:
                break;
            case State.UP:
                break;
            case State.MOVINGDOWN:
                break;
            case State.MOVINGUP:
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

    }

    private void MoveUp()
    {

    }
}
