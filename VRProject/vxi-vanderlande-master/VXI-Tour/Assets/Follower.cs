using UnityEngine;
using System.Collections;

public class Follower : MonoBehaviour {

    Vector3 delta;
	// Use this for initialization
	void Start () {
        delta = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = Camera.main.transform.position;
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 1.690004f, this.transform.position.z);

    }
}
