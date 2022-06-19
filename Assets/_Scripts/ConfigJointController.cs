using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigJointController : MonoBehaviour
{
    public List<ConfigurableJoint> joints;
    List<float> xPositions;
    List<Quaternion> rotsToCopy;
    
    public float jointSlerpStrength;
    public float breakForce;

    private void Update()
    {
        SnapBodiesToXPositions();
    }

    private void Start()
    {
        CacheXPositions();
        SetBreakForce();
        SetJointDriveStrength();
    }

    void SetBreakForce()
    {
        foreach (var joint in joints)
        {
            joint.breakForce = breakForce;
        }
    }

    void SnapBodiesToXPositions()
    {
        for (int i = 0; i < xPositions.Count; i++)
        {
            Vector3 pos = joints[i].transform.position;
            pos.x = xPositions[i];
            joints[i].transform.position = pos;
        }
    }

    void SetJointDriveStrength()
    {
        foreach (var joint in joints)
        {
            //Debug.Log("setting joint strngth to: " + jointSlerpStrength);
            JointDrive jd = joint.slerpDrive;
            jd.positionSpring = jointSlerpStrength;
            joint.slerpDrive = jd;
        }
    }

    void CacheXPositions()
    {
        xPositions = new List<float>();
        foreach (var joint in joints)
        {
            xPositions.Add(joint.transform.position.x);
        }
    }
}
