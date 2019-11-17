using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour {
    private bool Finished = false;

    public Text killtext;
    public Text scoretext;
    public Text finalscoretext;

    public static int LifeCount;
    public float score;
    public float kills;
    public string tekst = "Score: ";
    private float startTime;

    public float t;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        if (Finished)
            return;
        scoretext.text = tekst + score;
        t = Time.time - startTime;

        //string minutes = ((int)t / 60).ToString();
        //string seconds = (t % 60).ToString("f0");

        killtext.text = "cubes killed: " + kills;
        finalscoretext.text = "final score: " + score;
    }
    public void finish()
    {
        Finished = true;
    }

    public void RestartGame()
    {
        float fadeTime = GameObject.Find("main").GetComponent<Menu>().BeginFade(1);
        SceneManager.LoadScene("project");
    }

    public void MenuGame()
    {
        float fadeTime = GameObject.Find("main").GetComponent<Menu>().BeginFade(1);
        SceneManager.LoadScene("menu");
    }
}
