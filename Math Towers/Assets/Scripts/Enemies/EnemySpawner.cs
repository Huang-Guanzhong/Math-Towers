using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject thisSpawner;
    public GameObject[] enemyList;
    public int numEnemies;
    public Sprite sprite;
    public float spawnTime;

    
    // Start is called before the first frame update
    void Start()
    {
        enemyList = new GameObject[10];
    }

    // Update is called once per frame
    void Update()
    {
        UpdateEnemies();

        
        spawnTime += Time.deltaTime;
        if (spawnTime >= 3f && numEnemies < 10){
            spawnEnemy(0.01f, 1, thisSpawner, sprite);
            spawnTime -= 3f;
        }

    }

    public void UpdateEnemies(){
        if (numEnemies != 0){
            for (int i = 0; i < numEnemies; i++){
            enemyList[i].GetComponent<Enemy>().UpdatePosition();
            }
        }
    }

    public void spawnEnemy(float speed, float life, GameObject spawn, Sprite sprite){
        GameObject enemyObj = new GameObject();

        enemyObj.AddComponent<SpriteRenderer>();
        enemyObj.GetComponent<SpriteRenderer>().sprite = sprite;

        //Enemy enemy = new Enemy(speed, life, spawn, enemyObj);
        enemyObj.AddComponent<Enemy>();
        enemyObj.GetComponent<Enemy>().SetEnemy(speed, life, spawn, enemyObj);

        enemyList[numEnemies] = enemyObj;
        numEnemies++;
    }
}
