using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBranch : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("squirrel_left");
    }

    // Update is called once per frame
    void Update()
    {
        // if (player.transform.position.y - transform.position.y > 10) {
        //     Destroy(this.gameObject);
        // }
    }
    
}
