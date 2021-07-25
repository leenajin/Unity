using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIconManager : MonoBehaviour
{
    public Icon icon;
    public static EnemyIconManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void Create(Transform target)
    {
        Icon newIcon = Instantiate(icon, transform) as Icon;
        newIcon.Init(target);
    }
}
