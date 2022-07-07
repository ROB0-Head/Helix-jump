using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody _player;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "SafePlatform")
        {
            GameManager._levelCompleted = true;
        }
        if (collision.gameObject.tag == "UnsafePlatform")
        {
            GameManager._gameOver = true;
        }
    }
}
