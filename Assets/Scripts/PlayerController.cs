using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 10;
    [SerializeField]
    private GameObject laserPrefab;
    [SerializeField]
    private Transform cannonPosition;

    private SpriteRenderer sprite;

    private float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        transform.Translate(horizontal*speed*Time.deltaTime,
            vertical*speed*Time.deltaTime, 0);

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -8.5f, 8.5f),
            Mathf.Clamp(transform.position.y, -4.5f, 4.5f),
            0
            );

        time += Time.deltaTime;

        if(time >= 0.1f)
        {
            time = 0;
            if(sprite.color == Color.white)
            {
                sprite.color = Color.red;
            }
            else
            {
                sprite.color = Color.white;
            }
            
        }

        Shoot();
    }

    void Shoot()
    {
        if (Input.GetMouseButton(0))
        {
            Instantiate(laserPrefab, cannonPosition.position, Quaternion.identity);
        }
    }
}
