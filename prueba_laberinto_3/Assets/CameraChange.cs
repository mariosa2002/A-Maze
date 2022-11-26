using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{

    public Camera firstPersonCamera;
    public Camera overheadCamera;

    public GameObject playerPointer;

    void Start()
    {
        firstPersonCamera.enabled = true;
        overheadCamera.enabled = false;
        playerPointer.SetActive(false);
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ShowFirstPersonView();
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            ShowOverheadView();
        }

    }

    public void ShowOverheadView()
    {
        firstPersonCamera.enabled = false;
        overheadCamera.enabled = true;
        playerPointer.SetActive(true);
    }

    public void ShowFirstPersonView()
    {
        firstPersonCamera.enabled = true;
        overheadCamera.enabled = false;
        playerPointer.SetActive(false);
    }

}
