using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 0.1f;
    public int force = 1;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);
        transform.LookAt(Camera.main.transform);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camera.main.transform);
        transform.Translate(transform.forward * speed, Space.World);
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Projectile")
        {
            Debug.Log("Boom!");
            GameManager.instance.killedEnemy += 1;
            GameManager.instance.killCounter.text = GameManager.instance.killCounter.text + GameManager.instance.killedEnemy;
            Destroy(collider.gameObject); // destroy projectile
            Destroy(gameObject); // destroy enemy
        }
    }
}
