using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject thisSpawner;
    public GameObject[] enemyList;
    public float[] enemySpawnList;
    public int numEnemies;
    public Sprite sprite;
    public float spawnTime;
    public int deathMoney;

    
    // Start is called before the first frame update
    void Start()
    {
        //Initialize enemy lists, for the spawn list the first column is the enemy health and the second is the wave that they'll be in
        //enemySpawnList = new float[30];
        enemyList = new GameObject[10];

        deathMoney = 25;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateEnemies();

        spawnTime += Time.deltaTime;
        if (spawnTime >= 3f && enemySpawnList[0] != 0f){
            //If it has been 3 seconds since the last enemy spawn, spawn an enemy
            spawnEnemy(0.01f, enemySpawnList[0], thisSpawner, sprite);
            fixSpawnList();
            spawnTime = 0f;
        }

    }

    public void fixSpawnList(){
        //Cleans the front of the list and moves all of the items back one space
        enemySpawnList[0] = 0;
        for (int i = 1; i < enemySpawnList.Length; i++){
            enemySpawnList[i-1] = enemySpawnList[i];
        }
        
        //Cleans the back of the list
        enemySpawnList[enemySpawnList.Length-numEnemies] = 0f;
        
        
    }

    public void UpdateEnemies(){
        //Goes through the list of enemies and updates their positon
        if (numEnemies != 0){
            for (int i = 0; i < numEnemies; i++){
            enemyList[i].GetComponent<Enemy>().UpdatePosition();
            }
        }
    }

    public void spawnEnemy(float speed, float life, GameObject spawn, Sprite sprite){
        GameObject enemyObj = new GameObject();

        //Adds a sprite renderer
        enemyObj.AddComponent<SpriteRenderer>();
        enemyObj.GetComponent<SpriteRenderer>().sprite = sprite;

        //Adds the Enemy script
        enemyObj.AddComponent<Enemy>();
        enemyObj.GetComponent<Enemy>().SetEnemy(speed, life, spawn, enemyObj);

        //Adds a box collider
        enemyObj.AddComponent<BoxCollider2D>();

        //Adds a rigid body and sets its gravity to 0
        enemyObj.AddComponent<Rigidbody2D>();
        enemyObj.GetComponent<Rigidbody2D>().gravityScale = 0;

        //Makes the tag of the enemies "Enemy"
        enemyObj.tag = "Enemy";

        //Adds the enemy to the EnemyList and adds one to numEnemies
        enemyList[numEnemies] = enemyObj;
        numEnemies++;
    }

    public void destroyEnemy(GameObject enemy){
        int enemyNum = 0;

        //Finds the index of the enemy we want to destroy
        for (int i = 0; i < numEnemies; i++){
            if (enemy.transform.position.x == enemyList[i].transform.position.x) 
                enemyNum = i;
        }

        //Destroys the enemy
        Destroy(enemyList[enemyNum]);

        //Moves all enemies in the list back one index position
        for (int i = enemyNum + 1; i < numEnemies; i++){
            enemyList[i-1] = enemyList[i];
        }

        //Subtracts 1 from numEnemies and cleans the back of the array
        numEnemies--;
        enemyList[numEnemies] = null;

        //Adds the deathMoney to the players money
        Base.AddMoney(deathMoney);
    }
}
