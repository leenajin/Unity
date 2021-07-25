using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetEmission : MonoBehaviour
{
    public SkinnedMeshRenderer renderer;
    Material material;

    bool isAttacked = false;

    public float duration = 1.0f;
    float timeLeft = 0f;

    private void Start()
    {
        material = renderer.material;
    }

    private void FX()
    {
        isAttacked = true;
        material.EnableKeyword("_EMISSION");
    }

    private void Update()
    {
        if (isAttacked)
        {
            if (timeLeft < duration)
            {
                timeLeft += Time.deltaTime;
            }
            else
            {
                material.DisableKeyword("_EMISSION");
                isAttacked = false;
                timeLeft = 0f;
            }
        }
    }
}
