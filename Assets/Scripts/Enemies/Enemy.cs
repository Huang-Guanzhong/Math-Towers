using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float movementSpeed;
    public float health;
    public GameObject spawner;
    public GameObject enemySprite;

    //Initializer (no longer needed)
    public Enemy(float speed, float life, GameObject spawn, GameObject enemyObj){
        movementSpeed = speed;
        health = life;
        spawner = spawn;
        enemySprite = enemyObj;
        enemySprite.transform.position = spawn.transform.position;
    }

    //Sets the initial values of the Enemy
    public void SetEnemy(float speed, float life, GameObject spawn, GameObject enemyObj){
        movementSpeed = speed;
        health = life;
        spawner = spawn;
        enemySprite = enemyObj;
        enemySprite.transform.position = spawn.transform.position;
    }

    //Sets the position of the enemy
    public void SetPosition(float x, float y){
        enemySprite.transform.position = new Vector3(x, y, 0f);
    }
        
    //Updates the position of the enemy
    public void UpdatePosition(){
         enemySprite.transform.position = new Vector3(enemySprite.transform.position.x - movementSpeed, enemySprite.transform.position.y, 0f);
    }

}
