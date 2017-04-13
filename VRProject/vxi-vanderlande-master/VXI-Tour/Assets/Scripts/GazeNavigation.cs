using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// The gaze navigation moves an bject to its location when
/// the user gazes at it long enough
/// </summary>
public class GazeNavigation : MonoBehaviour, IGvrGazeResponder
{
    public float triggerTime = 40;
    public float movementSpeed = 2;
    
    public GameObject slider;
    public GameObject navigator;

    private float triggerTimePassed = 0;
    private bool isGazedAt = false;
    private bool isTriggered = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isGazedAt && !isTriggered)
            triggerTimePassed++;
        if (triggerTimePassed >= triggerTime)
            OnGazeTrigger();

        Vector3 navigationPosition = transform.position;
        //navigationPosition.y = navigator.transform.position.y; //Put y on same level as navigator
        if (isTriggered)
        {
            if (navigator.transform.position == navigationPosition)
                isTriggered = false;

            navigator.transform.position = Vector3.Lerp(navigator.transform.position, navigationPosition, movementSpeed * Time.deltaTime);
        }
        

        slider.GetComponent<Slider>().value = 100 / triggerTime * triggerTimePassed / 100;
    }

    public void OnGazeEnter()
    {
        isGazedAt = true;
        triggerTimePassed = 0;
    }

    public void OnGazeExit()
    {
        isGazedAt = false;
        triggerTimePassed = 0;
    }

    //Show the provided information in the textbox
    public void OnGazeTrigger()
    {
        GazeNavigation[] components = GameObject.FindObjectsOfType<GazeNavigation>();
        foreach(GazeNavigation gazeNavigation in components)
        {
            gazeNavigation.setIsTriggered(false);
        }

        isTriggered = true;
        triggerTimePassed = 0;
    }

   public void setIsTriggered(bool value)
    {
        this.isTriggered = value;
    }
}
