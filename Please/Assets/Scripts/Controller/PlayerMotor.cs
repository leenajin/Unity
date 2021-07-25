using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PlayerMotor : MonoBehaviour
{
    //NavMeshAgent를 통한 이동 또는 변화를 관리
    NavMeshAgent agent;
    Transform target;

    private void OnEnable()
    {
        GetComponent<PlayerController>().onFocusChanged += OnFocusChanged;
    }

    private void OnDisable()
    {
        GetComponent<PlayerController>().onFocusChanged -= OnFocusChanged;

    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void MoveToTarget(Vector3 position)
    {
        agent.SetDestination(position);
    }

    void FaceToTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(
            new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime);
    }

    private void Update()
    {
        if (target == null) return;

        FaceToTarget();
        MoveToTarget(target.position);
    }

    void OnFocusChanged(Interactable newFocus)
    {
        if(newFocus != null)
        {
            target = newFocus.guideTransform;
            agent.updateRotation = false;
            agent.stoppingDistance = newFocus.size;
        }
        else
        {
            target = null;
            agent.updateRotation = true;
            agent.stoppingDistance = 0;
        }
    }
}
