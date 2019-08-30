using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity;

    [SerializeField] private Transform playerBody;

    private float xAxisClamp;

    private void Awake()
    {
        xAxisClamp = 0.0f;
    }

    void LockNadUnlockCursor()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                UnLockCursor();
            }
            else
            {
                LockCursor();
            }
        }
    } //LockNadUnlockCursor


    void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void UnLockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    private void Update()
    {
        if(GameManager.instacne.gameState== GameState.play)
        {
            CameraRotation();
            LockNadUnlockCursor();
        }
        else if(GameManager.instacne.gameState == GameState.pause && Cursor.lockState == CursorLockMode.Locked)
        {
            UnLockCursor();
        }
    }

    private void CameraRotation()
    {
        float mouseX = Input.GetAxis(HelperClass.mouseX) * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis(HelperClass.mouseY) * mouseSensitivity * Time.deltaTime;

        xAxisClamp += mouseY;

        if (xAxisClamp > 90.0f)
        {
            xAxisClamp = 90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(270.0f);
        }
        else if (xAxisClamp < -90.0f)
        {
            xAxisClamp = -90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(90.0f);
        }

        transform.Rotate(Vector3.left * mouseY);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    private void ClampXAxisRotationToValue(float value)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }
}// class

