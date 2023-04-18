using MoreMountains.TopDownEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIActionSkills : AIAction
{
    [SerializeField] private GameObject[] Enemy;
    [SerializeField] private GameObject Bullet_Skill;
    [SerializeField] private Transform spawn;
    [SerializeField] private float speed_skill;
    [SerializeField] private LayerMask boss_layer;
    [SerializeField] private float timeShoot;
    [SerializeField] private float timeNext;

    private Vector3 direction_skill;
    private Collider[] colliders;
    private GameObject bullet_skill;
    private AIActionAtack actionAtack;
    public override void Initialization()
    {
        actionAtack = gameObject.GetComponent<AIActionAtack>(); 
    }

    public override void PerformAction()
    {
        Attack();
    }

    private void Skill_Readly()
    {
        direction_skill = _brain.Target.position - transform.position;
        bullet_skill = Instantiate(Bullet_Skill, spawn.position, Quaternion.identity);
        bullet_skill.GetComponent<Rigidbody>().velocity = direction_skill.normalized * speed_skill;
    }

    private void Attack()
    {
        colliders = Physics.OverlapSphere(transform.position, actionAtack.radius, boss_layer);
        foreach (Collider collider in colliders)
        {
            if (Time.time < timeNext)
            {
                return;
            }
            timeNext = Time.time + timeShoot;
            Skill_Readly();
        }
    }
}