using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Interactable
{
    CharacterStat stat;
    CharacterCombat combat;
    PlayerController playerController;

    private void OnEnable()
    {
        stat = GetComponent<CharacterStat>();
        stat.OnHPZero += Die;
    }

    private void OnDisable()
    {
        stat.OnHPZero -= Die;
    }

    public override void Interact()
    {
        //base.Interact();
        Debug.Log("Enemy - Player 만났습니다.");
        Player.instance.combat.Attack(stat);
        //Debug.Log("d이거다" + Player.instance.stat.currentHP);
    }

    void Die()
    {
        Debug.Log("적캐릭터사망");
        CharacterCombat.instance.Idle();
        PlayerController.instance.SetFocus(null);
        //Destroy(this.gameObject, 1f);
        PoolingManager.instance.ReturnObject(this.gameObject);
    }

}
