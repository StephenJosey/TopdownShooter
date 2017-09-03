using UnityEditor;
using UnityEngine;

public class Player : Character {
    const float SPEED = 0.1f;
    const int MAX_BULLETS = 10;
    public GameObject bullet;
    public float fireRate = 0.5F;
    private float nextFire = 0.0F;
    // Use this for initialization
    Player() : base(100, 10) { }

    void Update()
    {
        Move();
        if (Input.GetAxis("Fire1") != 0)
            Shoot();
    }

    private void OnGUI()
    {
        DrawHealth();
    }

    void DrawHealth()
    {
        double rectX = GetComponent<Transform>().position.x + GetComponent<Transform>().localScale.x + .2;
        double rectY = GetComponent<Transform>().position.y + GetComponent<Transform>().localScale.y + .2;
        Rect rect = new Rect(10, 300, health, 10);
        EditorGUI.DrawRect(rect, Color.black);
    }

    protected override void Move()
    {
        float horizontalDir = Input.GetAxis("Horizontal");
        float verticalDir = Input.GetAxis("Vertical");
        if (horizontalDir == 0.0f && verticalDir == 0.0f)
            return;
        Transform player = GetComponent<Transform>();

        // Update position
        Vector3 newLocation = new Vector3(horizontalDir * SPEED + player.position.x, 
                                verticalDir * SPEED + player.position.y);
        player.position = Vector3.MoveTowards(player.position, newLocation, SPEED);
    }

    void Shoot()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            // Lookup the Bullet object we created in the Assests directory
            // The Bullet script is attached to this object, look there for what it will do
            GameObject newBullet = (GameObject) AssetDatabase.LoadAssetAtPath("Assets/Bullet.prefab", typeof(GameObject));
            Transform player = GetComponent<Transform>();

            Vector3 mouse_pos = Input.mousePosition;
            mouse_pos = Camera.main.ScreenToWorldPoint(mouse_pos);

            mouse_pos.x = mouse_pos.x - player.position.x;
            mouse_pos.y = mouse_pos.y - player.position.y;
            float angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(0, 0, angle);

            Instantiate(newBullet, player.position, rotation);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            int damage = collision.collider.GetComponent<Enemy>().damage;
            TakeDamage(damage);
        }
    }

}
