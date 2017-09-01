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
        GetComponent<Transform>().localScale = new Vector3(.2f, .2f, .2f);
        direction = Input.mousePosition;
        direction = Camera.main.ScreenToWorldPoint(direction);

    }

    public void setDirection(float x, float y)
    {
        GetComponent<Transform>().position = new Vector3(x, y);
    }

    public bool IsActive() { return active; }

    // Update is called once per frame
    public void Update() {
        if (!IsActive())
            return;
        if (GetComponent<Transform>().position.x > GameWorld.WIDTH ||
            GetComponent<Transform>().position.x < (-1 * GameWorld.WIDTH) ||
            GetComponent<Transform>().position.y > GameWorld.HEIGHT ||
            GetComponent<Transform>().position.y < (-1 * GameWorld.HEIGHT))
        {
            active = false;
            Object.Destroy(gameObject);
        }
        GetComponent<Transform>().position = Vector3.MoveTowards(GetComponent<Transform>().transform.position, 
            new Vector3(GetComponent<Transform>().position.x + 
            (direction.x*speed), GetComponent<Transform>().position.y + (direction.y*speed)), speed);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
            Object.Destroy(gameObject);
    }
}
