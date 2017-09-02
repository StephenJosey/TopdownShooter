using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : Character {
    public Transform  playerTarget;
    public float SPEED = (1/100f);

    // Use this for initialization
    Enemy() : base(10, 10) {
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    public void SetCoordinates(float x, float y)
    {
        Transform enemy = GetComponent<Transform>();
        Vector3 position = new Vector3(x, y);
        enemy.position = position;
    }

    protected override void Move()
    {
        float horizontalDir = playerTarget.position.x;
        float verticalDir = playerTarget.position.y;
        Transform enemy = GetComponent<Transform>();

        // Update position
        Vector3 newLocation = new Vector3(horizontalDir * SPEED + playerTarget.position.x, verticalDir * SPEED + playerTarget.position.y);
        enemy.position = Vector3.MoveTowards(enemy.position, newLocation, SPEED);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            int damage = collision.collider.GetComponent<Player>().damage;
            TakeDamage(damage);
        } 
    }
}
