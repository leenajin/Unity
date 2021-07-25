using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    #region Singleton
    public static MapController instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public GameObject mapCamera;
    public int num;

    private void Update()
    {
        if (Input.GetButtonDown("Map"))
        {
            mapCamera.SetActive(!mapCamera.activeSelf);
        }

        if(mapCamera.activeSelf == true)
        {
            num = 3;
        }
        else
        {
            num = 11;
        }
    }

}
