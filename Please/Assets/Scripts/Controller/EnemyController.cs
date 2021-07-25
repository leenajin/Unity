using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyController : MonoBehaviour
{
    NavMeshAgent agent;
    CharacterCombat combat;
    Transform target;
    CharacterStat stat;

    public float detectionSize;

    private void Start()
    {
        target = Player.instance.transform;
        agent = GetComponent<NavMeshAgent>();
        combat = GetComponent<CharacterCombat>();
    }

    private void Update()
    {
            float distance = (target.position - transform.position).magnitude;
        if (Player.instance.stat.currentHP > 0)
        {
            if (distance < detectionSize)
            {
                agent.SetDestination(target.position);
                if (distance < agent.stoppingDistance)
                {
                    //공격하기
                    combat.Attack(Player.instance.stat);
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionSize);
    }
}
