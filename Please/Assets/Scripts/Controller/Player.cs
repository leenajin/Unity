using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    #region Singleton
    public static Player instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public CharacterStat stat;
    public CharacterCombat combat;
    public AudioClip gameOverAudio = null;
    public AudioClip gameOverMusic = null;

    Animator animator;

    private void OnEnable()
    {
        stat.OnHPZero += Die;
    }

    private void OnDisable()
    {
        stat.OnHPZero -= Die;
    }

    void Die()
    {
        if (gameOverAudio != null)
        {
            AudioManager.instance.source.clip = gameOverAudio;
            AudioManager.instance.source.Play();
        }
        Debug.Log("플레이어 사망");
        combat.Died();

        Invoke("Lose", 5);
    }

    void Lose()
    {
        SceneController.instance.StartCoroutine(SceneController.instance.FadeScene(3));
    }
}
