using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
public class Controller : MonoBehaviour
{
    int count=0;
    public GameObject img_screen;
    public VideoPlayer video;
    public GameObject[] flames;
    // Start is called before the first frame update
    void Start()
    {
        screen_1.transform.position=transform.position+(Vector3.right*speed*Time.deltaTime,0,0);
        for(int i = 0; i < flames.Length; i++)
        {
            flames[i].SetActive(false);
        }
        video.Pause();
        img_screen.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0)) && count < flames.Length)
        {
            flames[count].SetActive(true);
            count++;
            img_screen.SetActive(false);
            video.Play();
        }
    }
}
