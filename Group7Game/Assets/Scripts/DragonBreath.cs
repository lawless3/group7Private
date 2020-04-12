using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class DragonBreath : MonoBehaviour
{
    public float speed; // the speed of the dragons breath
    public float timeInterval; // the time it takes for the dragon to reappear
    private float timePassed = 0; // the time passed
    public float stopShake; // the time it takes for the camera to stop shaking
    private bool reduceBar = false; //determines if the bar is reducing or filling
    private float currentShake = 0; //determines how long the camera has been shaking
    private float barReduction; //the ammount of fill the bar has currently when reducing
    public float barReductionTime; //the time it takes for the bar to fully reduce
    public GameObject Fill;
    // Use this for initialization
    void Start()
    {
        barReduction = barReductionTime;
    }

    // Update is called once per frame
    void Update()
    {
        // Makes the dragon appear after the specified time interval
        if (timePassed >= timeInterval)
        {
            reduceBar = true;
            transform.position = new Vector3(GameObject.Find("Character").transform.position.x - 60, GameObject.Find("Character").transform.position.y + 18, 0);
            timePassed = 0;
            currentShake = 0;
            //shakes the camera
            CinemachineVirtualCamera vcam = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
            vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0.5f;

        }

        //stops the camera from shaking after a the specified time
        if (currentShake >= stopShake && GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain != 0)
        {
            CinemachineVirtualCamera vcam = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
            vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
        }

        //determines if the bar is filling up or going down
        if (reduceBar == false)
        {
            //fills the bar
            timePassed += Time.deltaTime;
            Fill.GetComponent<Image>().fillAmount = timePassed / timeInterval;
        }
        else
        {
            //reduces the bar
            Fill.GetComponent<Image>().fillAmount = barReduction / barReductionTime;
            if (barReduction <= 0)
            {
                barReduction = barReductionTime;
                reduceBar = false;
            }
            barReduction -= Time.deltaTime;
        }

        currentShake += Time.deltaTime;

    }

    //moves the dragons breath
    private void FixedUpdate()
    {
        transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
    }

    //resets the dragon timer
    public void resetTime()
    {
        timePassed = 0;
    }
    
}
