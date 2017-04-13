using UnityEngine;
using System.Collections;

/// <summary>
/// This class makes attached objects look at the main camera
/// </summary>
public class Billboard : MonoBehaviour {

    //Set to false if you want the object only to rotate over
    // certain axis
    public bool rotateX = true;
    public bool rotateY = true;
    
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 targetPosition = Camera.main.transform.position;
        if (!rotateX)
            targetPosition.y = transform.position.y;
        if (!rotateY)
            targetPosition.x = transform.position.x;

        this.transform.LookAt(targetPosition);
	}
}
