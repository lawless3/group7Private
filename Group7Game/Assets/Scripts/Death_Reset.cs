using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathRe : MonoBehaviour
{

    public CheckPointManager checkPointManager;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        checkPointManager.resetPuzzle();
    }
}
