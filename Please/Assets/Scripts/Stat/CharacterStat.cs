using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStat : MonoBehaviour
{
    public event Action OnHPZero;

    public int currentHP;
    public int CurrentHP { get { return currentHP; } }
    public int maxHP;

    public int power = 10;

    public bool isDebug = false;

    CharacterCombat combat;

    private void OnEnable()
    {
        currentHP = maxHP;
    }


    public void Heal(int heal)
    {
        currentHP += heal;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        Debug.Log(heal + "만큼 회복되었습니다. 현재 체력 : " + currentHP);
    }

    public void Stronger(int strength)
    {
        power += strength;
        Debug.Log("공격력 " + strength + "만큼 증가");
    }

    public void Hitted(int damage)
    {
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHP -= damage;

        if(currentHP <= 0)
        {
            //Die();
            OnHPZero?.Invoke();
        }
        Debug.Log(currentHP);
    }

    /*void Die()
    {
        Debug.LogFormat("{0} : Die", transform.name);
    }*/

}

