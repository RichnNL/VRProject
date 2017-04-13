using UnityEngine;
using System.Collections;

/// <summary>
/// This class makes an object follow another object
/// without taking the y axis into account
/// </summary>
public class FollowObject : MonoBehaviour {
    public GameObject target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 targetPosition = target.transform.position;
        targetPosition.y = transform.position.y;

        targetPosition += Vector3.forward * 0.1f;

        transform.position = targetPosition;
    }
}
