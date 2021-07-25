using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Potion", menuName = "Inventory/Potion", order = 0)]
public class Potion : Item
{
    public int heal;

    
    public override void Use()
    {
        //base.Use();

        if (Player.instance.stat.currentHP != 100)
        {
            Player.instance.stat.Heal(heal);
            RemoveFromInventory();
        }

        else
        {
            Debug.Log("체력이 꽉 차있습니다.");
        }
        
    }
}
