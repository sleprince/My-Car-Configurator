using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SwitchCamera : MonoBehaviour
{
    public CinemachineVirtualCamera MainCam;
    public CinemachineVirtualCamera ZoomCam;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ZoomCam.m_Priority = 11;

        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ZoomCam.m_Priority = 9;

        }

        
    }
}//class
