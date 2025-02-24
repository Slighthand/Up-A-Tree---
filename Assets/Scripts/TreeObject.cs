using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeObject : MonoBehaviour
{
    public GameObject treeBranch;
    public Transform player;
    public Transform camera;
    private float DistanceBetweenBranches = 2.5f;
    private float LastBranchY = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++) {
            SpawnBranch(LastBranchY);
            LastBranchY += DistanceBetweenBranches;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.y - LastBranchY > -6) {
            SpawnBranch(LastBranchY);
            LastBranchY += DistanceBetweenBranches;
        }
        
        transform.position = new Vector3(0,camera.position.y,0);
    }
    
    void SpawnBranch(float newBranchHeight)
    {

        Instantiate(treeBranch, new Vector3(UnityEngine.Random.Range(-5,5),newBranchHeight,0), Quaternion.identity);
    }
}
