using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCombat : MonoBehaviour
{
    #region Singleton
    public static CharacterCombat instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public event Action OnIdle;
    public event Action OnAttack;
    public event Action OnHitted;
    public event Action OnDie;

    #region COOLTIME
    const float cooltime = 1.5f;
    public float attackCooltime = 0f;
    //public float attackSpeed = 1f;
    //public float attackDelay = 1f;
    float lastAttackTime;

    public bool isInCombat = false;
    #endregion

    CharacterStat myStat;
    CharacterCombat combat;
    public Transform hpBarTf;
    public Transform iconTf = null;
    public Transform enemyIconTf = null;

    public ParticleSystem ps; //이펙트

    public AudioClip attackAudio = null;

    private void Start()
    {
        myStat = GetComponent<CharacterStat>();

        HPBarManager.instance.Create(hpBarTf, myStat);
        IconManager.instance.Create(iconTf);
        EnemyIconManager.instance.Create(enemyIconTf);
    }

    public void Idle()
    {
        OnIdle?.Invoke();
    }
    
    public void Attack(CharacterStat enemyStat)
    {
        if (enemyStat.currentHP != 0)
        {
            if (attackCooltime <= 0f)
            {
                Debug.Log("공격");

                StartCoroutine(GetDamage(enemyStat, 0.5f));

                enemyStat.GetComponent<CharacterCombat>().Hitted();

                if (OnAttack != null)
                    OnAttack();
                isInCombat = true;
                attackCooltime = cooltime;
                lastAttackTime = Time.time;


                if (attackAudio != null)
                {
                    AudioManager.instance.source.clip = attackAudio;
                    AudioManager.instance.source.Play();
                }

            }


        }
    }

    public void Died()
    {
        OnDie();
    }

    IEnumerator GetDamage(CharacterStat enemyStat, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (enemyStat != null)
            enemyStat.Hitted(myStat.power);
        else
            Idle();
    }

    public void Hitted()
    {
        if (ps != null)
        {
            ps.Play();
        }
        OnHitted?.Invoke();
    }

    private void Update()
    {
        attackCooltime -= Time.deltaTime;

        if(Time.time - lastAttackTime > cooltime)
        {
            isInCombat = false;
        }
        
    }

}
