using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemCollection : MonoBehaviour
{
    public ScoreManager scoreManager;
    
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Bone")) {
            Destroy(collision.gameObject);
            scoreManager.IncreaseScore();
        } else if (collision.gameObject.CompareTag("Enemy")) {
            scoreManager.Die();
        }
     }

}
