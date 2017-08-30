/*
 * Created by SJ on 8/30/17
 * Character class is a base class for player/enemies
 * All common attributes and functions should reside here
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour {
    public int health = 100;
    int damage;

    protected Character(int health, int damage)
    {
        this.health = health;
        this.damage = damage;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    void TakeDamage(int damage)
    {
        health -= damage;
    }
    
    bool IsDead() { return health <= 0; }
    
    protected void attack(Character opponent)
    {
        opponent.TakeDamage(damage);
    }

    abstract protected void Move();
}
