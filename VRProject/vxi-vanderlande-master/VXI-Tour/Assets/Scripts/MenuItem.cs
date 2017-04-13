using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using Google.Cast.RemoteDisplay.Internal;
using Google.Cast.RemoteDisplay;
using System.Collections.Generic;
using SmartLocalization;

/// <summary>
/// This class handles the functionality of menu items on the
/// Main Menu
/// </summary>
public class MenuItem : MonoBehaviour, IGvrGazeResponder
{
    public enum Actions
    {
        startTour,
        changeLanguageMenu,
        selectEnglishLanguage,
        selectDutchLanguage,
        addGoogleCast,
        selectCastDevice,
        returnToMain
    };
    public Actions onTrigger;
    public float triggerTime = 40;
    public GameObject[] menus;

    private string deviceId;
    private GameObject slider;
    private float triggerTimePassed = 0;
    private bool isGazedAt = false;
    private bool isTriggered = false;

    // Use this for initialization
    void Start() {
        slider = transform.Find("Slider").gameObject;
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
        toggleActiveState(true);
    }

    public void OnGazeExit()
    {
        isGazedAt = false;
        triggerTimePassed = 0;
        toggleActiveState(false);
    }
    
    /**
     * Handle a call of the menu item.
     **/
    public void OnGazeTrigger()
    {
        isGazedAt = false;
        triggerTimePassed = 0;

        switch (onTrigger)
        {
            //Start the tour over the campus
            case Actions.startTour:
                MainCamera mainCamera = GameObject.Find("VR camera").GetComponent<MainCamera>();
                mainCamera.openScene("Presentation");
                break;

            //Open the change language menu
            case Actions.changeLanguageMenu:
                activateMenu("LanguageMenu");
                break;

            //Set the application to english
            case Actions.selectEnglishLanguage:
                LanguageManager.Instance.ChangeLanguage("en-GB");
                activateMenu("MainMenu");
                break;

            //Set the application to dutch
            case Actions.selectDutchLanguage:
                LanguageManager.Instance.ChangeLanguage("nl-NL");
                activateMenu("MainMenu");
                break;

            //Add a Google cast device
            case Actions.addGoogleCast:
                activateMenu("GoogleCastMenu");
                getAvailableCastDevices();
                break;

            //Add a Google cast device
            case Actions.selectCastDevice:
                selectCastDevice();
                activateMenu("MainMenu");
                break;

            //Return to the main menu
            case Actions.returnToMain:
                activateMenu("MainMenu");
                break;

            default:
                throw new Exception("No action assigned to menu item!");
        }
    }

    /**
     * Show the backgound of a menu item based on the boolean
     **/
    private void toggleActiveState(bool enabled)
    {
        CanvasGroup background = transform.Find("Slider/Background").GetComponent<CanvasGroup>();
        background.alpha = enabled ? 1 : 0;
    }


    /**
     * Activate a certain menu in the scene
     **/
    private void activateMenu(string name)
    {
        foreach (GameObject menu in menus)
        {
            menu.SetActive(menu.name == name);
        }
    }


    /**
     * Fetch the available Google Cast devices on the network
     **/
    private void getAvailableCastDevices()
    {
        CastRemoteDisplayManager remoteManager = GameObject.Find("CastRemoteDisplayManager").GetComponent<CastRemoteDisplayManager>();
        IList<CastDevice> castDevices = remoteManager.GetCastDevices();

        GameObject[] castListItems = GameObject.FindGameObjectsWithTag("CastListItem");
        for (int i = 0; i < castListItems.Length; i++)
        {
            bool deviceFound = castDevices != null && castDevices.Count > i;
            castListItems[i].transform.Find("Slider/Text").gameObject
                .GetComponent<Text>().text = deviceFound ? castDevices[i].DeviceName : "-";
            castListItems[i].GetComponent<BoxCollider>().enabled = deviceFound;
            castListItems[i].GetComponent<MenuItem>().setDeviceId(deviceFound ? castDevices[i].DeviceId : "");
        }

    }


    /**
     * Select a cast device to stream to
     **/
    private void selectCastDevice()
    {
        CastRemoteDisplayManager remoteManager = GameObject.Find("CastRemoteDisplayManager").GetComponent<CastRemoteDisplayManager>();
        remoteManager.SelectCastDevice(deviceId);
    }


    /**
     * Remember the selected cast device
     **/
    public void setDeviceId(string value)
    {
        this.deviceId = value;
    }


}
