using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameWorld : MonoBehaviour {
    public static int WIDTH = 5;
    public static int HEIGHT = 5;
    GameObject enemyPrefab;
    LinkedList<GameObject> enemies;

    // Use this for initialization
    void Start () {
        enemyPrefab = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Enemy.prefab", typeof(GameObject));
        enemies = new LinkedList<GameObject>();
        LoadEnemies();
    }

    // We can spawn enemies using this. Later can create a txt file with variety of enemies, and coordinates
    public void LoadEnemies()
    {
        GameObject enemy = Instantiate(enemyPrefab);
        enemy.GetComponent<Enemy>().SetCoordinates(-3, 3);
        enemy.GetComponent<Enemy>().playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
        enemies.AddLast(enemy);
        enemy = Instantiate(enemyPrefab);
        enemy.GetComponent<Enemy>().SetCoordinates(3, 3);
        enemy.GetComponent<Enemy>().playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
        enemies.AddLast(enemy);
    }
	
	// Update is called once per frame
	void Update () {

    }
}
