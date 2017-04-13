using UnityEngine;
using System.Collections;
using System;
/// <summary>
/// This class hides an object when it gets too close
/// or moves too far away of the camera
/// </summary>
public class HideInDistance : MonoBehaviour {

    private float fadeDistance = 2;
    private float fadeClose = 2;
    private float fadeFar = 20;

    private CanvasGroup canvasGroup;

	// Use this for initialization
	void Start () {
        canvasGroup = this.GetComponent<CanvasGroup>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 target = Camera.main.transform.position;
        float cameraDistance = Vector3.Distance(transform.position, target);

        float farAlpha = 100 - (100 / (fadeFar + fadeDistance) * Math.Max(cameraDistance - fadeClose, 0));
        float closeAlpha = 100 / fadeClose * (cameraDistance - fadeDistance) / 100;

        canvasGroup.alpha = Math.Min(farAlpha, closeAlpha);
    }
}
