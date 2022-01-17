using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCube : MonoBehaviour
{


   private void OnTriggerEnter(Collider coll) { 
            Debug.Log("collide");
            Scoring.Score += 3;
        }


    void OnCollisionEnter(Collision collisionInfo)
    {

        if (collisionInfo.gameObject.tag == "BallBasket")
         Scoring.Score += 3;
    }

}
