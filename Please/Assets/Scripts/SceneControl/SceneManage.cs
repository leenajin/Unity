using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManage : MonoBehaviour
{

    public void LoadScene(int index)
    {
        SceneController.instance.StartCoroutine(SceneController.instance.FadeScene(index));
    }
}
