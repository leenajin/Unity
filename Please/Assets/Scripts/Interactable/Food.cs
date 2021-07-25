using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Food", menuName = "Inventory/Food", order = 0)]
public class Food : Item
{
    public int strength;

    public override void Use()
    {
            Player.instance.stat.Stronger(strength);
            RemoveFromInventory();
    }
}
