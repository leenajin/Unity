using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimator : MonoBehaviour
{
    //캐릭터들의 애니메이터 파라미터 조절하는 부분

    NavMeshAgent agent;

    CharacterCombat combat;
    Animator animator;

    MapController map;
    int count = 0;

    public AudioClip walkAudio = null;

    private void Awake()
    {
        combat = GetComponent<CharacterCombat>();
        animator = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void OnEnable()
    {
        combat.OnIdle += OnIdle;
        combat.OnAttack += OnAttack;
        combat.OnHitted += OnHitted;
        combat.OnDie += OnDie;
    }

    private void Update()
    {
        animator.SetFloat("Walk", agent.velocity.magnitude);
        if(agent.velocity.magnitude > 0.1)
        {
                if (count % MapController.instance.num == 0)
                {
                    if (walkAudio != null)
                    {
                        AudioManager.instance.source.clip = walkAudio;
                        AudioManager.instance.source.Play();
                    }
                }
            }

        
        count++;
    }


    void OnAttack()
    {
        animator.SetTrigger("Attack");
    }

    void OnHitted()
    {
        animator.SetTrigger("Hitted");
    }

    void OnDie()
    {
        animator.SetTrigger("Die");
    }

    void OnIdle()
    {
        animator.SetFloat("Walk", 0f);
    }

    private void OnDisable()
    {
        combat.OnIdle -= OnIdle;
        combat.OnAttack -= OnAttack;
        combat.OnHitted -= OnHitted;
        combat.OnDie -= OnDie;
    }
}
