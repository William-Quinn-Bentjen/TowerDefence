using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public static Canvas GameOverScreen;
    public static Canvas UI;
    public Text AliveNonStatic;
    public static Text TimeAlive;
    public Text HPNonStatic;
    public static Text HP;
    public static void PlayerDied()
    {
        UI.gameObject.SetActive(false);
        GameOverScreen.gameObject.SetActive(true);
        Time.timeScale = 0;
        SetTimeAlive();
    }
    public static void SetTimeAlive()
    {
        TimeAlive.text = "You survived " + Time.time + " seconds";
    }
    public static void GameOver()
    {
        Application.Quit();
    }
	// Use this for initialization
	void Start () {
        TimeAlive = AliveNonStatic;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
