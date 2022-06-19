using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ArmControl : MonoBehaviour
{
    public Vector2 moveArmsValue, leanBodyValue;
    public GameObject leftArmBone, rightArmBone;
    public GameObject leftThighBone, rightThighBone, leftShinBone, rightShinBone;
    public Quaternion currentArmRot;

    Quaternion leftArmStartRot, rightArmStartRot;
    Vector3 leftArmStartDir, rightArmStartDir;
    PlayerInput playerInput;
    InputAction moveArms, leanBody;
    private void Start()
    {
        leftArmStartRot = leftArmBone.transform.localRotation;
        rightArmStartRot = rightArmBone.transform.localRotation;
        currentArmRot = leftArmStartRot;
        leftArmStartDir = new Vector3(0, 0, 1f);
        rightArmStartDir = new Vector3(0, 0, 1f);
    }
    private void Update()
    {
        GatherInputs();
        RotateArmsLocal();
    }
    void GatherInputs()
    {
        var gamepad = Gamepad.current;
        if (gamepad == null) Debug.Log("gamepad null");

        leanBodyValue = gamepad.leftStick.ReadValue();
        moveArmsValue = gamepad.rightStick.ReadValue();
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
