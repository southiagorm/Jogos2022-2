using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 250;
    [SerializeField]
    private GameObject laserPrefab;
    [SerializeField]
    private Transform cannonPosition;

    private SpriteRenderer sprite;
    private float time = 0;

    [SerializeField]
    private float shootRate = 0;
    [SerializeField]
    private float shootTotalTime;

    private Rigidbody2D rb2d;
    private float horizontal, vertical;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
        //sprite.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");


        //transform.Translate(horizontal*speed*Time.deltaTime,
           // vertical*speed*Time.deltaTime, 0);

        /*transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -8.5f, 8.5f),
            Mathf.Clamp(transform.position.y, -4.5f, 4.5f),
            0
            );*/

        


        //Blink();
        Shoot();
    }

    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(horizontal * speed * Time.deltaTime, vertical * speed * Time.deltaTime);
    }

    void Shoot()
    {
        shootRate += Time.deltaTime;
        if (Input.GetMouseButton(0))
        {
            if (shootRate >= shootTotalTime)
            {
                Instantiate(laserPrefab, cannonPosition.position, Quaternion.identity);
                shootRate = 0;
            }
        }
    }

    void Blink()
    {
        time += Time.deltaTime;

        if (time >= 0.1f)
        {
            time = 0;
            if (sprite.color == Color.white)
            {
                sprite.color = Color.red;
            }
            else
            {
                sprite.color = Color.white;
            }

        }
    }
}
