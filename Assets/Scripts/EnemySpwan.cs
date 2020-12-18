using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpwan : MonoBehaviour
    
{
    public GameObject EnemyPrefab;
    public float speed;
    int[] SpawnSide = { -25, 10, 0 };
    public double time;
    public GameObject Winning;
    public float spawnTime;

    void Awake()
    {
        Kill.onKill += OnNinjaDeath;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartSpawn();
    }
    public void StartSpawn()
    {
        StartCoroutine("StartSpawnCo");
    }
    IEnumerator StartSpawnCo()
    {
        while (true)
        {
            int SpawnX = Random.Range(0, 2);
            int SpawnY = Random.Range(-3, 3);
          /*  if (SpawnSide[SpawnX] < 0)
            {
                
                Vector3 BatSpawnPosition = new Vector3(SpawnSide[SpawnX], SpawnY, transform.position.z);
                GameObject bat = Instantiate(EnemyPrefab, BatSpawnPosition, Quaternion.identity);
                bat.GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
                yield return new WaitForSeconds(1);
            }*/
            if(SpawnSide[SpawnX]> 0)
            {
                Vector3 BatSpawnPosition = new Vector3(SpawnSide[SpawnX], SpawnY, transform.position.z);
                GameObject bat = Instantiate(EnemyPrefab, BatSpawnPosition, Quaternion.identity);
                bat.GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
                yield return new WaitForSeconds(spawnTime);
            }
         

        }
    }
    public void StopSpawn()
    {
        StopCoroutine("StartSpawnCo");

    }
    void OnNinjaDeath()
    {
        StopSpawn();
    }
    void OnDestroy()
    {
        Kill.onKill -= OnNinjaDeath;
    }
    // Update is called once per frame
    void Update()
    {
        
        time -= Time.deltaTime;
        if (time < 0)
        {
            StopSpawn();
            Winning.SetActive(true);
        }
        
        
    }
}
