using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandJump : MonoBehaviour {
    private float groundY;
    private float ySpeed;
    [SerializeField]
    float gravity = 0.3f;
    [SerializeField]
    float jumpSpeed = 0.03f;

    void Start()
    {
        groundY = transform.position.y;
    }

    public void ClickUp()
    {
        StopCoroutine("Up");
        StartCoroutine(Up());
    }

    IEnumerator Up()
    {
        ySpeed = jumpSpeed;
        transform.position = new Vector3(transform.position.x, groundY + jumpSpeed, transform.position.z);

        while (transform.position.y > groundY)
        {
            ySpeed -= gravity * Time.deltaTime;
            transform.position = new Vector3(transform.position.x, transform.position.y + ySpeed, transform.position.z);
            yield return null;
        }

        if (transform.position.y <= groundY)
        {
            transform.position = new Vector3(transform.position.x, groundY, transform.position.z);
            ySpeed = 0.0f;
        }
    }
}
