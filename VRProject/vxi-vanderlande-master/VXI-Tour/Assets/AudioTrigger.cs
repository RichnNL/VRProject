using UnityEngine;
using System.Collections;
using System.Linq;

[RequireComponent(typeof(AudioSource))]
public class AudioTrigger : MonoBehaviour {

    public bool hasPlayed = false;
    private AudioSource source;
	// Use this for initialization
	void Start ()
    {
        source = GetComponent<AudioSource>();
        source.Stop();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Vector3.Distance(Camera.main.transform.position, this.transform.position) <= 7)
            OnTriggerEnter(null);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (hasPlayed) return;
        hasPlayed = true;

        source.Play();
    }
}
