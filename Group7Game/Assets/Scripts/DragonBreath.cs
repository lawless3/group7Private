using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class DragonBreath : MonoBehaviour
{
    public float speed;
    public float timeInterval;
    private float timePassed = 0;
    public float stopShake;
    private bool reduceBar = false;
    private float currentShake = 0;
    private float barReduction;
    public float barReductionTime;
    public GameObject Fill;
    // Use this for initialization
    void Start()
    {
        barReduction = barReductionTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (timePassed >= timeInterval)
        {
            reduceBar = true;
            transform.position = new Vector3(GameObject.Find("Character").transform.position.x - 60, GameObject.Find("Character").transform.position.y + 18, 0);
            timePassed = 0;
            currentShake = 0;
            CinemachineVirtualCamera vcam = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
            vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0.5f;

        }

        if (currentShake < stopShake)
        {
            currentShake += Time.deltaTime;
            if (currentShake >= stopShake)
            {
                CinemachineVirtualCamera vcam = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
                vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
            }
        }

        if (reduceBar == false)
        {
            timePassed += Time.deltaTime;
            Fill.GetComponent<Image>().fillAmount = timePassed / timeInterval;
        }
        else
        {
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

    private void FixedUpdate()
    {
        transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
    }

    public void resetTime()
    {
        timePassed = 0;
    }

}
