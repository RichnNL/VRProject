using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

/// <summary>
/// The change scene box changes to a target scene when the 
/// user gazes at it long enough
/// </summary>
public class ChangeSceneBox : MonoBehaviour, IGvrGazeResponder
{
    public string sceneName;
    public float triggerTime = 40;
    public GameObject slider;

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

        MainCamera mainCamera = GameObject.Find("VR camera").GetComponent<MainCamera>();
        mainCamera.openScene(sceneName);
    }
}