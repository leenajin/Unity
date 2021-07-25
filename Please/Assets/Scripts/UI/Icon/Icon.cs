using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Icon : MonoBehaviour
{
    public Image icon;
    public Transform target;

    Transform cam;

    public void Init(Transform target)
    {
        this.target = target;
        //cam = Camera.current.transform;
    }

    private void LateUpdate()
    {
        SetIcon();
    }

    public void SetIcon()
    {
        transform.position = target.position;
        //transform.LookAt(new Vector3(cam.position.x, transform.position.y, cam.position.z), Vector3.down);
    }
}
