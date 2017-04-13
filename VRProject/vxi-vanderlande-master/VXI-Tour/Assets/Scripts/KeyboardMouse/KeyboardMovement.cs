using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class KeyboardMovement : MonoBehaviour
{
    public MouseLook Eyes;
    public float Speed = 5;
    // Use this for initialization
    void Start()
    {
        Eyes = GetComponentInChildren<MouseLook>();
    }

    // Update is called once per frame
    void Update()
    {
        float speed = Speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.W))
            this.transform.position += this.Eyes.transform.forward * speed;
        if (Input.GetKey(KeyCode.A))
            this.transform.position += this.Eyes.transform.right * -speed;
        if (Input.GetKey(KeyCode.S))
            this.transform.position += this.Eyes.transform.forward * -speed;
        if (Input.GetKey(KeyCode.D))
            this.transform.position += this.Eyes.transform.right * speed;
    }
}