using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDefeat : MonoBehaviour {
    public GameObject gameOverMenu;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameOverMenu.SetActive(true);
        }
    }
}
