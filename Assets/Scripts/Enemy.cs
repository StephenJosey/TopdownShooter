using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character {
    public Transform  playerTarget;
    public float SPEED = (1/100f);

    // Use this for initialization
    Enemy() : base(10, 10) { }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    protected override void Move()
    {
        float horizontalDir = playerTarget.position.x;
        float verticalDir = playerTarget.position.y;
        Transform player = GetComponent<Transform>();

        // Update position
        Vector3 newLocation = new Vector3(horizontalDir * SPEED + playerTarget.position.x, verticalDir * SPEED + playerTarget.position.y);
        player.position = Vector3.MoveTowards(player.position, newLocation, SPEED);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Bullet")
        {
            TakeDamage(10);
            Debug.Log("Enemy hit!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            TakeDamage(10);
            Debug.Log("Enemy hit!");
        }
    }
}
