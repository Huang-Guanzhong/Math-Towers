using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float movementSpeed;
    public float health;
    public GameObject spawner;
    public GameObject enemySprite;

    public Enemy(float speed, float life, GameObject spawn, GameObject enemyObj){
        movementSpeed = speed;
        health = life;
        spawner = spawn;
        enemySprite = enemyObj;
        enemySprite.transform.position = spawn.transform.position;
    }

    public void SetEnemy(float speed, float life, GameObject spawn, GameObject enemyObj){
        movementSpeed = speed;
        health = life;
        spawner = spawn;
        enemySprite = enemyObj;
        enemySprite.transform.position = spawn.transform.position;
    }

    public void SetPosition(float x, float y){
        enemySprite.transform.position = new Vector3(x, y, 0f);
    }
        
    public void UpdatePosition(){
         enemySprite.transform.position = new Vector3(enemySprite.transform.position.x - movementSpeed, enemySprite.transform.position.y, 0f);
    }

}
