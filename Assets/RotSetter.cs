using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotSetter : MonoBehaviour
{
    public ArmControl armControl;
    ConfigJointController configJointController;

    private void Start()
    {
        configJointController = GetComponent<ConfigJointController>();
    }

    private void Update()
    {
        configJointController.joints[8].targetRotation = Quaternion.Inverse(armControl.currentArmRot);
        configJointController.joints[10].targetRotation = Quaternion.Inverse(armControl.currentArmRot);
    }
}
