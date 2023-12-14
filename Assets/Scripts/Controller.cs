using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.Audio;
public class Controller : MonoBehaviour
{
    int count=0;
    public AudioSource audio;
    public GameObject img_screen;
    public VideoPlayer video_1;
    public VideoPlayer video_2;
    public GameObject video_1_screen;
    public GameObject video_2_screen;
    public GameObject[] flames;
    // Start is called before the first frame update
    void Start()
    {
        
        for(int i = 0; i < flames.Length; i++)
        {
            flames[i].SetActive(false);
        }
        video_1.Pause();
        img_screen.SetActive(true);
        video_2_screen.SetActive(false);
        video_2.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0)) && count < flames.Length)
        {
            flames[count].SetActive(true);
            count++;
            img_screen.SetActive(false);
            video_1.Play();
        }
        if (count == flames.Length)
        {
            Invoke("eventCompleted",2f);
        }
    }
    public void eventCompleted()
    {
        audio.Pause();
        video_1_screen.SetActive(false);
        video_1.Pause();
        video_2_screen.SetActive(true);
        video_2.Play();
    }
}
