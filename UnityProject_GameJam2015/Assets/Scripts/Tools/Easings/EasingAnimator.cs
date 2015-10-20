using UnityEngine;
using System.Collections;

public class EasingAnimator : MonoBehaviour
{

    #region Variables
	
	public Easing.EasingTargetRelativeSpace easingTargetRelativeSpace;
    public Easing.EasingTarget easingTarget;
    public Easing.EasingFunctionType easingFunctionType;

    public Transform targetTransform;

	public float initialValue;
	public float finalValue;

	private double currentValue;
	private double timeDuration;
	private float timeCounter;

    private bool startEasing;

	//public Transform targetValue;

	public float timeDelay;
    private float timeDelayAux;

    public bool playOnAwake;
    public bool loopOnAwake;
    #endregion

    // Use this for initialization
	void Start () {
        timeDuration = BeatSystem.bps;

        timeDelayAux = timeDelay;

		timeCounter = 0.0f;
		currentValue = initialValue;

        if (playOnAwake || loopOnAwake) startEasing = true;
        else startEasing = false;

        if (targetTransform == null)
            targetTransform = this.transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (startEasing == true)
        {
            EasingsUpdate();
            
            if (BeatSystem.beatNow == true)
                Restart();
                
        }
        else { }		
	}

    //Call this function on OnClick() Event in the UI Button.
    //This is the only function you need to start an easing, it will restart automatically when it ends.
    public void StartEasing()
    {
        Restart();
        startEasing = true;
    }

    void Restart()
    {
        if (!loopOnAwake)
            startEasing = false;
        else
            startEasing = true;

        timeDelay = timeDelayAux;
        timeCounter = 0;
    }

    void EasingsUpdate()
    {
        if (timeDelay > 0) timeDelay -= Time.deltaTime;
        else if (timeCounter < timeDuration)
        {
            timeCounter += Time.deltaTime;
            //Make Switch Here
            //currentValue = (double)Easing.BounceEaseOut(timeCounter, initialValue, (finalValue - initialValue), timeDuration);

            #region Easings List
            switch (easingFunctionType)
            {
                case Easing.EasingFunctionType.BackEaseIn:
                    {
                        currentValue = (double)Easing.BackEaseIn(timeCounter, initialValue, (finalValue - initialValue), timeDuration);
                    } break;

                case Easing.EasingFunctionType.BackEaseInOut:
                    {
                        currentValue = (double)Easing.BackEaseInOut(timeCounter, initialValue, (finalValue - initialValue), timeDuration);
                    } break;

                case Easing.EasingFunctionType.BackEaseOut:
                    {
                        currentValue = (double)Easing.BackEaseOut(timeCounter, initialValue, (finalValue - initialValue), timeDuration);
                    } break;

                case Easing.EasingFunctionType.BackEaseOutIn:
                    {
                        currentValue = (double)Easing.BackEaseOutIn(timeCounter, initialValue, (finalValue - initialValue), timeDuration);
                    } break;

                case Easing.EasingFunctionType.BounceEaseIn:
                    {
                        currentValue = (double)Easing.BounceEaseIn(timeCounter, initialValue, (finalValue - initialValue), timeDuration);
                    } break;

                case Easing.EasingFunctionType.BounceEaseInOut:
                    {
                        currentValue = (double)Easing.BounceEaseInOut(timeCounter, initialValue, (finalValue - initialValue), timeDuration);
                    } break;

                case Easing.EasingFunctionType.BounceEaseOut:
                    {
                        currentValue = (double)Easing.BounceEaseOut(timeCounter, initialValue, (finalValue - initialValue), timeDuration);
                    } break;

                case Easing.EasingFunctionType.BounceEaseOutIn:
                    {
                        currentValue = (double)Easing.BounceEaseOutIn(timeCounter, initialValue, (finalValue - initialValue), timeDuration);
                    } break;

                case Easing.EasingFunctionType.CircEaseIn:
                    {
                        currentValue = (double)Easing.CircEaseIn(timeCounter, initialValue, (finalValue - initialValue), timeDuration);
                    } break;

                case Easing.EasingFunctionType.CircEaseInOut:
                    {
                        currentValue = (double)Easing.CircEaseInOut(timeCounter, initialValue, (finalValue - initialValue), timeDuration);
                    } break;

                case Easing.EasingFunctionType.CircEaseOut:
                    {
                        currentValue = (double)Easing.CircEaseOut(timeCounter, initialValue, (finalValue - initialValue), timeDuration);
                    } break;

                case Easing.EasingFunctionType.CircEaseOutIn:
                    {
                        currentValue = (double)Easing.CircEaseOutIn(timeCounter, initialValue, (finalValue - initialValue), timeDuration);
                    } break;

                case Easing.EasingFunctionType.CubicEaseIn:
                    {
                        currentValue = (double)Easing.CubicEaseIn(timeCounter, initialValue, (finalValue - initialValue), timeDuration);
                    } break;

                case Easing.EasingFunctionType.CubicEaseInOut:
                    {
                        currentValue = (double)Easing.CubicEaseInOut(timeCounter, initialValue, (finalValue - initialValue), timeDuration);
                    } break;

                case Easing.EasingFunctionType.CubicEaseOut:
                    {
                        currentValue = (double)Easing.CubicEaseOut(timeCounter, initialValue, (finalValue - initialValue), timeDuration);
                    } break;

                case Easing.EasingFunctionType.CubicEaseOutIn:
                    {
                        currentValue = (double)Easing.CubicEaseOutIn(timeCounter, initialValue, (finalValue - initialValue), timeDuration);
                    } break;

                case Easing.EasingFunctionType.ElasticEaseIn:
                    {
                        currentValue = (double)Easing.ElasticEaseIn(timeCounter, initialValue, (finalValue - initialValue), timeDuration);
                    } break;

                case Easing.EasingFunctionType.ElasticEaseInOut:
                    {
                        currentValue = (double)Easing.ElasticEaseInOut(timeCounter, initialValue, (finalValue - initialValue), timeDuration);
                    } break;

                case Easing.EasingFunctionType.ElasticEaseOut:
                    {
                        currentValue = (double)Easing.ElasticEaseOut(timeCounter, initialValue, (finalValue - initialValue), timeDuration);
                    } break;

                case Easing.EasingFunctionType.ElasticEaseOutIn:
                    {
                        currentValue = (double)Easing.ElasticEaseOutIn(timeCounter, initialValue, (finalValue - initialValue), timeDuration);
                    } break;

                case Easing.EasingFunctionType.ExpoEaseIn:
                    {
                        currentValue = (double)Easing.ExpoEaseIn(timeCounter, initialValue, (finalValue - initialValue), timeDuration);
                    } break;

                case Easing.EasingFunctionType.ExpoEaseInOut:
                    {
                        currentValue = (double)Easing.ExpoEaseInOut(timeCounter, initialValue, (finalValue - initialValue), timeDuration);
                    } break;

                case Easing.EasingFunctionType.ExpoEaseOut:
                    {
                        currentValue = (double)Easing.ExpoEaseOut(timeCounter, initialValue, (finalValue - initialValue), timeDuration);
                    } break;

                case Easing.EasingFunctionType.ExpoEaseOutIn:
                    {
                        currentValue = (double)Easing.ExpoEaseOutIn(timeCounter, initialValue, (finalValue - initialValue), timeDuration);
                    } break;

                case Easing.EasingFunctionType.Linear:
                    {
                        currentValue = (double)Easing.Linear(timeCounter, initialValue, (finalValue - initialValue), timeDuration);
                    } break;

                case Easing.EasingFunctionType.QuadEaseIn:
                    {
                        currentValue = (double)Easing.QuadEaseIn(timeCounter, initialValue, (finalValue - initialValue), timeDuration);
                    } break;

                case Easing.EasingFunctionType.QuadEaseInOut:
                    {
                        currentValue = (double)Easing.QuadEaseInOut(timeCounter, initialValue, (finalValue - initialValue), timeDuration);
                    } break;

                case Easing.EasingFunctionType.QuadEaseOut:
                    {
                        currentValue = (double)Easing.QuadEaseOut(timeCounter, initialValue, (finalValue - initialValue), timeDuration);
                    } break;

                case Easing.EasingFunctionType.QuadEaseOutIn:
                    {
                        currentValue = (double)Easing.QuadEaseOutIn(timeCounter, initialValue, (finalValue - initialValue), timeDuration);
                    } break;

                case Easing.EasingFunctionType.QuartEaseIn:
                    {
                        currentValue = (double)Easing.QuartEaseIn(timeCounter, initialValue, (finalValue - initialValue), timeDuration);
                    } break;

                case Easing.EasingFunctionType.QuartEaseInOut:
                    {
                        currentValue = (double)Easing.QuartEaseInOut(timeCounter, initialValue, (finalValue - initialValue), timeDuration);
                    } break;

                case Easing.EasingFunctionType.QuartEaseOut:
                    {
                        currentValue = (double)Easing.QuartEaseOut(timeCounter, initialValue, (finalValue - initialValue), timeDuration);
                    } break;

                case Easing.EasingFunctionType.QuartEaseOutIn:
                    {
                        currentValue = (double)Easing.QuartEaseOutIn(timeCounter, initialValue, (finalValue - initialValue), timeDuration);
                    } break;

                case Easing.EasingFunctionType.QuintEaseIn:
                    {
                        currentValue = (double)Easing.QuintEaseIn(timeCounter, initialValue, (finalValue - initialValue), timeDuration);
                    } break;

                case Easing.EasingFunctionType.QuintEaseInOut:
                    {
                        currentValue = (double)Easing.QuintEaseInOut(timeCounter, initialValue, (finalValue - initialValue), timeDuration);
                    } break;

                case Easing.EasingFunctionType.QuintEaseOut:
                    {
                        currentValue = (double)Easing.QuintEaseOut(timeCounter, initialValue, (finalValue - initialValue), timeDuration);
                    } break;

                case Easing.EasingFunctionType.QuintEaseOutIn:
                    {
                        currentValue = (double)Easing.QuintEaseOutIn(timeCounter, initialValue, (finalValue - initialValue), timeDuration);
                    } break;

                case Easing.EasingFunctionType.SineEaseIn:
                    {
                        currentValue = (double)Easing.SineEaseIn(timeCounter, initialValue, (finalValue - initialValue), timeDuration);
                    } break;

                case Easing.EasingFunctionType.SineEaseInOut:
                    {
                        currentValue = (double)Easing.SineEaseInOut(timeCounter, initialValue, (finalValue - initialValue), timeDuration);
                    } break;

                case Easing.EasingFunctionType.SineEaseOut:
                    {
                        currentValue = (double)Easing.SineEaseOut(timeCounter, initialValue, (finalValue - initialValue), timeDuration);
                    } break;

                case Easing.EasingFunctionType.SineEaseOutIn:
                    {
                        currentValue = (double)Easing.SineEaseOutIn(timeCounter, initialValue, (finalValue - initialValue), timeDuration);
                    } break;
            }
            //End Switch Here
            #endregion

            #region Easing Target Colors

            switch (easingTarget)
            {
                case Easing.EasingTarget.ColorR:
                    {
                        targetTransform.GetComponent<Renderer>().material.color = new Color((float)currentValue,
                                                                                    targetTransform.GetComponent<Renderer>().material.color.g,
                                                                                    targetTransform.GetComponent<Renderer>().material.color.b,
                                                                                    targetTransform.GetComponent<Renderer>().material.color.a);
                    } break;

                case Easing.EasingTarget.ColorG:
                    {
                        targetTransform.GetComponent<Renderer>().material.color = new Color(targetTransform.GetComponent<Renderer>().material.color.r,
                                                                                    (float)currentValue,
                                                                                    targetTransform.GetComponent<Renderer>().material.color.b,
                                                                                    targetTransform.GetComponent<Renderer>().material.color.a);
                    } break;

                case Easing.EasingTarget.ColorB:
                    {
                        targetTransform.GetComponent<Renderer>().material.color = new Color(targetTransform.GetComponent<Renderer>().material.color.r,
                                                                                    targetTransform.GetComponent<Renderer>().material.color.g,
                                                                                    (float)currentValue,
                                                                                    targetTransform.GetComponent<Renderer>().material.color.a);
                    } break;

                case Easing.EasingTarget.ColorA:
                    {
                        targetTransform.GetComponent<Renderer>().material.color = new Color(targetTransform.GetComponent<Renderer>().material.color.r,
                                                                                    targetTransform.GetComponent<Renderer>().material.color.g,
                                                                                    targetTransform.GetComponent<Renderer>().material.color.b,
                                                                                    (float)currentValue);
                    } break;
            }
            #endregion

            #region Easing Transform Targets

            if (easingTargetRelativeSpace == Easing.EasingTargetRelativeSpace.WORLD)
                switch (easingTarget)
                {
                    case Easing.EasingTarget.PositionX:
                        {
                            targetTransform.position = new Vector3((float)currentValue, targetTransform.position.y, targetTransform.position.z);
                        } break;

                    case Easing.EasingTarget.PositionY:
                        {
                            targetTransform.position = new Vector3(targetTransform.position.x, (float)currentValue, targetTransform.position.z);
                        } break;

                    case Easing.EasingTarget.PositionZ:
                        {
                            targetTransform.position = new Vector3(targetTransform.position.x, targetTransform.position.y, (float)currentValue);
                        } break;

                    case Easing.EasingTarget.RotationX:
                        {
                            targetTransform.eulerAngles = new Vector3((float)currentValue, targetTransform.eulerAngles.y, targetTransform.eulerAngles.z);
                        } break;

                    case Easing.EasingTarget.RotationY:
                        {
                            targetTransform.eulerAngles = new Vector3(targetTransform.eulerAngles.x, (float)currentValue, targetTransform.eulerAngles.z);
                        } break;

                    case Easing.EasingTarget.RotationZ:
                        {
                            targetTransform.eulerAngles = new Vector3(targetTransform.eulerAngles.x, targetTransform.eulerAngles.y, (float)currentValue);
                        } break;

                    case Easing.EasingTarget.ScaleX:
                        {
                            Debug.Log("Unity Engine doesn't have 'WORLD Scale'");
                        } break;

                    case Easing.EasingTarget.ScaleY:
                        {
                            Debug.Log("Unity Engine doesn't have 'WORLD Scale'");
                        } break;

                    case Easing.EasingTarget.ScaleZ:
                        {
                            Debug.Log("Unity Engine doesn't have 'WORLD Scale'");
                        } break;

                    case Easing.EasingTarget.ScaleALL:
                        {
                            Debug.Log("Unity Engine doesn't have 'WORLD Scale'");
                        } break;
                }

            else if (easingTargetRelativeSpace == Easing.EasingTargetRelativeSpace.LOCAL)
                switch (easingTarget)
                {
                    case Easing.EasingTarget.PositionX:
                        {
                            targetTransform.localPosition = new Vector3((float)currentValue, targetTransform.localPosition.y, targetTransform.localPosition.z);
                        } break;

                    case Easing.EasingTarget.PositionY:
                        {
                            targetTransform.localPosition = new Vector3(targetTransform.position.x, (float)currentValue, targetTransform.localPosition.z);
                        } break;

                    case Easing.EasingTarget.PositionZ:
                        {
                            targetTransform.localPosition = new Vector3(targetTransform.localPosition.x, targetTransform.localPosition.y, (float)currentValue);
                        } break;

                    case Easing.EasingTarget.RotationX:
                        {
                            targetTransform.localEulerAngles = new Vector3((float)currentValue, targetTransform.localEulerAngles.y, targetTransform.localEulerAngles.z);
                        } break;

                    case Easing.EasingTarget.RotationY:
                        {
                            targetTransform.localEulerAngles = new Vector3(targetTransform.localEulerAngles.x, (float)currentValue, targetTransform.localEulerAngles.z);
                        } break;

                    case Easing.EasingTarget.RotationZ:
                        {
                            targetTransform.localEulerAngles = new Vector3(targetTransform.localEulerAngles.x, targetTransform.localEulerAngles.y, (float)currentValue);
                        } break;

                    case Easing.EasingTarget.ScaleX:
                        {
                            targetTransform.localScale = new Vector3((float)currentValue, targetTransform.localScale.y, targetTransform.localScale.z);
                        } break;

                    case Easing.EasingTarget.ScaleY:
                        {
                            targetTransform.localScale = new Vector3(targetTransform.localScale.x, (float)currentValue, targetTransform.localScale.z);
                        } break;

                    case Easing.EasingTarget.ScaleZ:
                        {
                            targetTransform.localScale = new Vector3(targetTransform.localScale.x, targetTransform.localScale.y, (float)currentValue);
                        } break;
                    case Easing.EasingTarget.ScaleALL:
                        {
                            targetTransform.localScale = new Vector3((float)currentValue, (float)currentValue, (float)currentValue);
                        } break;
                }
            #endregion
        }
        else
            Restart();
    }
}
