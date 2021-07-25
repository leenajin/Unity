using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public Image hpBar;

    public Transform target;
    public CharacterStat stat;

    Transform cam;

    public void Init(Transform target, CharacterStat stat)
    {
        this.target = target;
        this.stat = stat;
        cam = Camera.main.transform;//카메라 포지션값 위치.
    }
    private void LateUpdate()
    {
        SetHP();
    }


    public void SetHP()
    {
        //hpbar포지션지정
        transform.position = target.position;

        transform.LookAt(new Vector3(
            cam.position.x, transform.position.y, cam.position.z), Vector3.down);

        hpBar.fillAmount = NormalizeHP();
    }

    float NormalizeHP()
    {
        return Mathf.Clamp01(stat.CurrentHP / (float)stat.maxHP);
    }
}
