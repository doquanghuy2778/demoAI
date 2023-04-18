using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIActionRotate : AIAction
{
    [SerializeField] private GameObject[] Enemy;
    public override void Initialization()
    {

    }
    public override void PerformAction()
    {
        transform.LookAt(_brain.Target.position);
    }
}
