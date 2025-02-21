using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Private float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        float h = Input.GetAxis("Horizantal");
        float v = Input.GetAxis("Vertical");


        Vector2 pos = transform.position;

        pos.x += h; *Time.deltaTime;
        pos.y += v; *Time.deltaTime;

        transform.postion = pos;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
