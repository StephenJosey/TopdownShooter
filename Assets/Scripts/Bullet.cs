using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet: MonoBehaviour {
    //public UnityEngine.GameObject sphere;
    public Vector3 direction;
    float speed = 0.1f;
    bool active;


    public void Start()
    {
        active = true;
        transform.localScale = new Vector3(.2f, .2f, .2f);
    }

    public bool IsActive() { return active; }

    // Update is called once per frame
    public void Update() {
        if (!IsActive())
            return;
        if (transform.position.x > GameWorld.WIDTH ||
            transform.position.x < (-1 * GameWorld.WIDTH) ||
            transform.position.y > GameWorld.HEIGHT ||
            transform.position.y < (-1 * GameWorld.HEIGHT))
        {
            active = false;
            Object.Destroy(gameObject);
        }
        transform.position = transform.position + (transform.rotation * new Vector3(speed,0));
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
            Object.Destroy(gameObject);
    }
}
