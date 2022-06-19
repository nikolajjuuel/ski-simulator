using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    public Vector2 moveArmsValue, leanBodyValue;
    public bool resetSkiierValue = false;
    public GameObject skiier;
    public GameObject leftArmBone, rightArmBone;
    public GameObject leftThighBone, rightThighBone, leftShinBone, rightShinBone;
    public Quaternion currentArmRot;

    Vector3 skiierStartPosition;
    Quaternion skiierStartRotation;
    Quaternion leftArmStartRot, rightArmStartRot;
    Vector3 leftArmStartDir, rightArmStartDir;
    //PlayerInput playerInput;
    //InputAction moveArms, leanBody, resetSkiier;
    private void Start()
    {
        leftArmStartRot = leftArmBone.transform.localRotation;
        rightArmStartRot = rightArmBone.transform.localRotation;
        currentArmRot = leftArmStartRot;
        leftArmStartDir = new Vector3(0, 0, 1f);
        rightArmStartDir = new Vector3(0, 0, 1f);
        skiierStartPosition = transform.position;
        skiierStartRotation = transform.rotation;
    }
    private void Update()
    {
        GatherInputs();
        RotateArmsLocal();
        if(resetSkiierValue) ResetSkiier();
    }
    void ResetSkiier()
    {
        Debug.Log("reset skiier called");
        skiier.transform.position = skiierStartPosition;
        skiier.transform.rotation = skiierStartRotation;
        //skiier position, rotation back to start
    }
    void GatherInputs()
    {
        var gamepad = Gamepad.current;
        if (gamepad == null) Debug.Log("gamepad null");

        leanBodyValue = gamepad.leftStick.ReadValue();
        moveArmsValue = gamepad.rightStick.ReadValue();
        resetSkiierValue = gamepad.buttonEast.wasPressedThisFrame;
    }

    void RotateArmsLocal()
    {
        if (moveArmsValue.magnitude < 0.9) return;
        Vector3 armDirection = new Vector3(0f, moveArmsValue.y, moveArmsValue.x);
        Quaternion rotFromStart = Quaternion.FromToRotation(leftArmStartDir, armDirection);
        currentArmRot = leftArmStartRot * rotFromStart;
        leftArmBone.transform.localRotation = currentArmRot;
        rightArmBone.transform.localRotation = currentArmRot;
    }
}
