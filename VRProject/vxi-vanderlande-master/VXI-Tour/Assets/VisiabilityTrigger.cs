using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
public class VisiabilityTrigger : MonoBehaviour {
    public bool IsTriggered;
    public GameObject[] Targets;
	// Use this for initialization
	void Start ()
    {
        var c = this.GetComponent<Collider>();
        if (c)
            c.enabled = false;
	}

    public float start;
    public float end;
	
	// Update is called once per frame
	void Update ()
    {
        IsTriggered = Camera.main.transform.position.y > start && Camera.main.transform.position.y < end;
        foreach (var item in this.Targets)
        {
            item.SetActive(IsTriggered);
        }
	}

    void OnTriggerStay(Collider collider)
    {
        IsTriggered = true;
    }

    void OnTriggerExit(Collider collider)
    {
        IsTriggered = false;
    }
}
