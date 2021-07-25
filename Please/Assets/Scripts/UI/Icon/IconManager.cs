using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconManager : MonoBehaviour
{
    public Icon icon;
    public static IconManager instance;

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
