using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float size;
    public Transform guideTransform;
    //public Transform playerTransform;

    bool isFocus = false;
    bool isInteracted = false;

    public virtual void Interact()
    {

    }

    private void Update()
    {
        if(isFocus)
        {
            float distance = Vector3.Distance(guideTransform.position,
                Player.instance.transform.position);

            if(distance < size && !isInteracted)
            {
                    isInteracted = true;
                    Interact();
            }
        }
    }

    public void OnFocused()
    {
        isFocus = true;
        isInteracted = false;
    }

    public void OnDefocused()
    {
        isFocus = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(guideTransform.position, size);
    }

}
