using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

/// <summary>
/// The info panel shows information when the user gazes 
/// at it long enough
/// </summary>
public class InfoPanel : MonoBehaviour, IGvrGazeResponder {
    public float triggerTime = 40;

    public GameObject textObject;
    public GameObject informationTextObject;
    public GameObject slider;

    private float triggerTimePassed = 0;
    private bool isGazedAt = false;
    private bool isTriggered = false;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (isGazedAt && !isTriggered)
            triggerTimePassed++;
        if(triggerTimePassed >= triggerTime)
            OnGazeTrigger();

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
        isTriggered = true;
        triggerTimePassed = 0;

        //Show expanded text
        this.GetComponent<BoxCollider>().size = new Vector3(0,0,0);
        this.GetComponent<RectTransform>().sizeDelta = new Vector2(20, 20);
        slider.GetComponent<RectTransform>().sizeDelta = new Vector2(20, 20);

        informationTextObject.SetActive(true);
        textObject.SetActive(false);
    }
}
