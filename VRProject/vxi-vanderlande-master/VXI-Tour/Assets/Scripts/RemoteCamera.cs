using UnityEngine;
using System.Collections;
using Google.Cast.RemoteDisplay;

/// <summary>
/// This class will attach a camera to the CastRemoteDisplayManager,
/// which handles Google Cast functionality if it doens't have a camera yet.
/// </summary>
public class RemoteCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject remoteManager = GameObject.Find("CastRemoteDisplayManager");
        if(remoteManager != null)
        {
            remoteManager.GetComponent<CastRemoteDisplayManager>().RemoteDisplayCamera = this.GetComponent<Camera>();
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
