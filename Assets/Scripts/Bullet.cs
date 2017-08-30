using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet {
    GameObject sphere;
    public Vector3 direction;
    float speed = 0.1f;
    bool active;

    public Bullet() { active = false; }

    public Bullet(float x, float y)
    {
        active = true;
        sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.localScale = new Vector3(.2f, .2f, .2f);
        direction = Input.mousePosition;
        direction = Camera.main.ScreenToWorldPoint(direction);
        sphere.transform.position = new Vector3(x, y);
    }

    public bool IsActive() { return active; }

    // Update is called once per frame
    public void Update() {
        if (!IsActive())
            return;
        if (sphere.transform.position.x > GameWorld.WIDTH ||
            sphere.transform.position.x < (-1 * GameWorld.WIDTH) ||
            sphere.transform.position.y > GameWorld.HEIGHT ||
            sphere.transform.position.y < (-1 * GameWorld.HEIGHT))
        {
            active = false;
            Object.Destroy(sphere);
        }
        sphere.transform.position = Vector3.MoveTowards(sphere.transform.position, new Vector3(sphere.transform.position.x + 
            (direction.x*speed), sphere.transform.position.y + (direction.y*speed)), speed);
    }
}
