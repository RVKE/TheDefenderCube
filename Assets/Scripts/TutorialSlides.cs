using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSlides : MonoBehaviour {

    public GameObject slide0;
    public GameObject slide1;
    public GameObject slide2;
    public GameObject slide3;
    public GameObject slide4;

    public AudioSource nextSlide;



    public void GotoSlide1()
    {
        slide1.SetActive(true);
        slide0.SetActive(false);
        randomPitch();
        nextSlide.Play();
    }
    public void GotoSlide2()
    {
        slide2.SetActive(true);
        slide1.SetActive(false);
        randomPitch();
        nextSlide.Play();
    }
    public void GotoSlide3()
    {
        slide3.SetActive(true);
        slide2.SetActive(false);
        randomPitch();
        nextSlide.Play();
    }
    public void GotoSlide4()
    {
        slide4.SetActive(true);
        slide3.SetActive(false);
        randomPitch();
        nextSlide.Play();
    }

    void randomPitch()
    {
        nextSlide.pitch = Random.Range(2.5f, 3.0f);
    }

}
