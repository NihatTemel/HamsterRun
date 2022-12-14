using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiktok : MonoBehaviour
{
    float moveSpeed = 10.0f;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0.0f, vertical);

        transform.position += movement * Time.deltaTime * moveSpeed;
    }
}
