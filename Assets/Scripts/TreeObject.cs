using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeObject : MonoBehaviour
{
    public GameObject treeBranch;
    public Transform player;
    public Transform camera;
    private float DistanceBetweenBranches = 2.5;
    private float LastBranchY = 0;
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
        if (player_max_height - LastBranchY > -6) {
            LastBranchY += DistanceBetweenBranches;
            SpawnBranch(LastBranchY);
        }
        
        transform.position = new Vector3(0,camera.position.y,0);
    }
    
    void SpawnBranch(float newBranchHeight)
    {
        Instantiate(treeBranch, new Vector3(Random.Range(-6,6),newBranchHeight,0), Quaternion.identity);
    }
}
