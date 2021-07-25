using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingManager : MonoBehaviour
{
    public static PoolingManager instance;
    CharacterCombat combat;

    Interactable focus;
    Queue<GameObject> enemyQueue = new Queue<GameObject>();
    [SerializeField]
    private GameObject enemyPrefab;

    public int initCount = 6;
    public Transform spawnRegion;
    int count = 0;

    PlayerController playerController;
    public AudioClip winAudio = null;

    private void Awake()
    {
        instance = this;
        Initialize(initCount);
    }

    private void Start()
    {
        for(int i=0; i<initCount; i++)
        {
            GetObject();
        }
    }

    GameObject GetObject()
    {
        if(enemyQueue.Count > 0)
        {
            var obj = enemyQueue.Dequeue();
            obj.transform.SetParent(null);

            obj.transform.position = GetRandomPosition();

            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            return null;
        }
    }

    public void ReturnObject(GameObject obj)
    {
            obj.gameObject.SetActive(false);
            obj.transform.SetParent(transform);
            enemyQueue.Enqueue(obj);

        if (count == 9)
        {
            if (winAudio != null)
            {
                AudioManager.instance.source.clip = winAudio;
                AudioManager.instance.source.Play();
            }
            Invoke("Win", 1);
        }

        else
        {
            count++;
        
            Invoke("GetObject", 5f);
        }
    }

    void Win()
    {
        SceneController.instance.StartCoroutine(SceneController.instance.FadeScene(4));
    }


    Vector3 GetRandomPosition()
    {
        if (spawnRegion == null)
            return Vector3.zero;


        Vector3 center = spawnRegion.position;
        Vector3 scale = spawnRegion.localScale;

        float randX = Random.Range(center.x - scale.x * 6f, center.x + scale.x * 6f);
        float randZ = Random.Range(center.z - scale.z * 4f, center.z + scale.z * 4f);

        Vector3 randomposition = new Vector3(randX, 1, randZ);

        return randomposition;
    }

    void Initialize(int initCount)
    {
        for(int i=0; i<initCount; i++)
        {
            enemyQueue.Enqueue(CreateNewEnemy());
        }
    }

    GameObject CreateNewEnemy()
    {
        var newEnemy = Instantiate(enemyPrefab);
        newEnemy.SetActive(false);
        newEnemy.transform.SetParent(transform);

        return newEnemy;
    }

}
