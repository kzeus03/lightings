using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Lightings : MonoBehaviour
{
    int count=0;
    public InputField LightsCount;
    int no_of_lights;
    /*public GameObject lights;
    public GameObject[] Light_Arr;*/
    public GameObject Q_Panel;
    //private int currentIndex = 0;
    private bool over;
    public GameObject[] Lamp_Arr;
    public Camera cam;
    public GameObject[] particles;
    public GameObject[] screens;
    int screen_controller=0;
    public AudioSource claps;
    private void Start()
    {
        claps.Pause();
        Q_Panel.SetActive(true);
        
        over = false;
        for (int i= 0;i< Lamp_Arr.Length; i++){
            Lamp_Arr[i].gameObject.SetActive(false);
        }

        for(int i = 0; i < particles.Length; i++)
        {
            particles[i].SetActive(false);
        }
        for(int i = 0; i < screens.Length; i++)
        {
            screens[i].SetActive(false);
        }
    }
    public void SetCount()
    {
        try
        {
            no_of_lights = int.Parse(LightsCount.text);
        }
        catch
        {
            print("Enter a correct count");
        }
        if (no_of_lights > 0)
        {
           // Light_Arr = new GameObject[no_of_lights];
            print("Array set of length "+no_of_lights);
            Q_Panel.SetActive(false);

            //single lamp
            if (no_of_lights <= 5)
            {
                Lamp_Arr[0].gameObject.SetActive(true);
                Lamp_Arr[0].gameObject.transform.position = new Vector3(1.64f, 0.437f, -5.434f);
                cam.transform.position = new Vector3(1.486f, 1.61f, -2.277f);
            }

            //double lamps
            else if (no_of_lights > 5)
            {
                Lamp_Arr[0].gameObject.SetActive(true);
                Lamp_Arr[0].gameObject.transform.position = new Vector3(2.5f, 0.437f, -4.35f);
                Lamp_Arr[1].gameObject.SetActive(true);
                Lamp_Arr[1].gameObject.transform.position = new Vector3(0.71f, 0.437f, -4.35f);
                cam.transform.position = new Vector3(1.36f, 1.21f, -2.62f);
            }
        }
        /*Light_Arr[0] = lights;
        Light_Arr[0].gameObject.SetActive(false);
        for (int i = 1; i < no_of_lights; i++)
        {
            Vector3 position = new Vector3(i * 2.0f, 0.0f, 0.0f);
            Light_Arr[i] = Instantiate(lights, position, Quaternion.identity);
            Light_Arr[i].gameObject.name = "lights" + i;
            Light_Arr[i].gameObject.SetActive(false);
        }  */      
        
    }     
    void Update()
    {
       /* if (Input.GetKeyDown(KeyCode.E))
        {
            print("Key Pressed");

            if (currentIndex >= 0 && currentIndex < Light_Arr.Length)
            {
                Light_Arr[currentIndex].gameObject.SetActive(true);
            }
            currentIndex++;
            over = true;
        }
        if (over==true && currentIndex == Light_Arr.Length)
        {
            Greeting_Panel.SetActive(true);
        }*/


        if (no_of_lights <= 5)
        {
            if ((Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0)) && count<no_of_lights)
            {    
                particles[count].SetActive(true);
                count++;
                if (screen_controller > 1)
                {
                    for(int i = 0; i < screen_controller; i++)
                    {
                        screens[i].SetActive(false);
                    }
                }
                screens[screen_controller].SetActive(true);                
                screen_controller++;
                screens[screen_controller].SetActive(true);
                screen_controller++;
                claps.Play();
                
            }
            
        }
        else if (no_of_lights > 5)
        {
            if ((Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0)) && count < no_of_lights)
            {
                particles[count].SetActive(true);
                count++;
                claps.Play();
            }
            
        }
    }

}
