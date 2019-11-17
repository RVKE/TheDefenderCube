using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Base : MonoBehaviour {

    public GameObject wait;

    public AudioSource click;

    public Text splash;
    public GameObject player;
    public GameObject GameOver;
    public GameObject Counters;
    public GameObject secondPlayer;
    public AudioSource Music;

    bool lose = false;

    void Start()
    {

        GameOver.SetActive(false);
        Counters.SetActive(true);
    }
    void OnCollisionEnter(Collision col)
    {
        string[] biomes = new string[] { "Stop it!", "Don't give up!", "FRICK!", "Not bad...", "Not that bad...", "You're getting better!", "Also check R4KE on Github!", "NOOOOO!!11!", "!!!!", "Sad gamer moment.", "Wow, you're decent.", "Help", "Get good, noob!", "Unfair!!!", "Just play better...", "Try that again.", ":(", "Stupid!", "So sad ;(", "Please, try again!", "Don't do that again, thanks!", "Try getting better...", "Nice.", "Go play again!", "Cubes", "aaaaaaaaaaa"};
        string randomString = biomes[Random.Range(0, biomes.Length)];
        if (lose == false)
        {
            splash.text = randomString;
            if (col.gameObject.tag == "Enemy")
            {
                GetComponent<CameraShaker>().shouldShake = true;
                Renderer rend = GetComponent<Renderer>();
                rend.material.shader = Shader.Find("Specular");
                rend.material.SetColor("_SpecColor", Color.red);
                Music.Stop();
                click.Play();
                //GameObject.Find("Main").SendMessage("Finish");
                wait.SetActive(false);
                GameOver.SetActive(true);
                Counters.SetActive(false);
                Instantiate(secondPlayer, new Vector3(0, 0, -10), Quaternion.identity);
                Destroy(player);
                lose = true;
            }
            else if (col.gameObject.tag == "Enemy2")
            {
                GetComponent<CameraShaker>().shouldShake = true;
                Renderer rend = GetComponent<Renderer>();
                rend.material.shader = Shader.Find("Specular");
                rend.material.SetColor("_SpecColor", Color.red);
                Music.Stop();
                click.Play();
                //GameObject.Find("Main").SendMessage("Finish");;
                wait.SetActive(false);
                GameOver.SetActive(true);
                Counters.SetActive(false);
                Instantiate(secondPlayer, new Vector3(0, 0, -10), Quaternion.identity);
                Destroy(player);
                lose = true;
            }
            else if (col.gameObject.tag == "Enemy3")
            {
                GetComponent<CameraShaker>().shouldShake = true;
                Renderer rend = GetComponent<Renderer>();
                rend.material.shader = Shader.Find("Specular");
                rend.material.SetColor("_SpecColor", Color.red);
                Music.Stop();
                click.Play();
                //GameObject.Find("Main").SendMessage("Finish");
                wait.SetActive(false);
                GameOver.SetActive(true);
                Counters.SetActive(false);
                Instantiate(secondPlayer, new Vector3(0, 0, -10), Quaternion.identity);
                Destroy(player);
                lose = true;
            }
        }
    }
}
