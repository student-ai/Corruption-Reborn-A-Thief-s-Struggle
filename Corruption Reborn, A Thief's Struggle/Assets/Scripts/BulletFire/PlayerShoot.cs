using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;
    [SerializeField]
    float shootSpeed = 10f;
    [SerializeField]
    float bulletLifetime = 2.0f;
    float timer = 0;
    [SerializeField]
    float shootDelay = 0.5f;
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; // 0.01666666666 if 60fps
        // IF we press "the shoot button" (left mouse?)
        if (Input.GetButton("Fire1") && timer > shootDelay && Time.timeScale == 1)
        {
            timer = 0;
            // Fire a projectile in a straight line in the direction of the mouse
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            mousePos.z = 0;

            Debug.Log( "Fired towards " + mousePos);

            mousePos = mousePos - transform.position;
            mousePos.Normalize();
            //spawn in the bullet

            GameObject bulletPrefab = prefab;

            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().linearVelocity = mousePos * shootSpeed;

            Vector2 bulletPos = bullet.transform.position;
            Debug.Log(bulletPos);

            Destroy(bullet, bulletLifetime);
            //Debug.Log(mousePos);
        }
    }
}
