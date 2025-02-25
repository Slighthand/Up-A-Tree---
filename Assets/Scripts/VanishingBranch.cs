using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class VanishingBranch : MonoBehaviour
{

    // Start is called before the first frame update
   // private bool isJumping = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("The platform has disappeared.");
        if (other.tag == "Player") {
           StartCoroutine(TimeToWait());
        }
    }
    IEnumerator TimeToWait()
    {
        yield return new WaitForSeconds(.1f);
        Destroy(this.gameObject);
    }

    // void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.CompareTag("TreeBranch") && isJumping) {
    //         Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider, true);
    //     }
    // }

    // void Update()
    // {
    //     isJumping = true;
    // }

}
