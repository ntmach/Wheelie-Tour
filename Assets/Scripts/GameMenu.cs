using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour {
    public GameObject main;
    public GameObject howToPlay;

    public void enableHowToPlayMenu()
    {
        howToPlay.SetActive(true);
        main.SetActive(false);
    }

    public void disableHowToPlayMenu()
    {
        main.SetActive(true);
        howToPlay.SetActive(false);
    }
}
