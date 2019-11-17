using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public GameObject main;
    public GameObject setting;
    public GameObject music;
    public Texture2D fadeOutTexture;
    public AudioMixer audioMixer;
    public float fadeSpeed = 0.8f;

    public AudioSource colorChangeSound;

    public AudioSource click;
    
    private int drawDepth = -1000;
    private float alpha = 1.0f;
    private int fadeDir = -1;

    void OnGUI()
    {
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
    }

    public float BeginFade (int direction)
    {
        fadeDir = direction;
        return (fadeSpeed);
    }

    void OnLevelWasLoaded(int level)
    {
        // alpha = 1;
        BeginFade(-1);
    }
    public void PlayGame()
    {
        BeginFade(1);
        SceneManager.LoadScene("project");
    }
    public void PlayTutorial()
    {
        BeginFade(1);
        SceneManager.LoadScene("howtoplay");
    }
    public void Custom()
    {
        BeginFade(1);
        SceneManager.LoadScene("customize");
    }

    public void BackToMenu()
    {
        BeginFade(-1);
        SceneManager.LoadScene("menu");
    }

    public void Quitgame()
    {
        BeginFade(1);
        Application.Quit();
    }
    
    public void changeColor()
    {
        colorChangeSound.Play();
    }

    public void Settings()
    {
        main.SetActive(false);
        setting.SetActive(true);
        click.Play();
    }

    public void BackToMenu2()
    {
        main.SetActive(true);
        setting.SetActive(false);
        click.Play();
    }

    public void MuteAllAudio()
    {
        AudioListener.pause = !AudioListener.pause;
    }

    public void SetMusicVolume(float volume)
    {
        Debug.Log(volume);
        audioMixer.SetFloat("MusicVolume", volume);
    }
}
