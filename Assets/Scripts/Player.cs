using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform projectileSpawn;
    public GameObject projectilePrefab;

    public int life = 100;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //GameObject proj = Instantiate(projectilePrefab, projectileSpawn.position, projectileSpawn.rotation);
            //Camera.ScreenPointToRay();
            RaycastHit rh;
            if(Physics.Raycast(transform.position, transform.forward, out rh))
            {
                if(rh.collider != null && rh.collider.gameObject.tag == "Enemy")
                {
                    Debug.Log("Boom!");
                    Destroy(rh.collider.gameObject);
                }
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            
            life -= collider.gameObject.GetComponent<Enemy>().force;
            GameManager.instance.healthBar.BarValue = life;
            Destroy(collider.gameObject); // Destruction de l'ennemi
            Debug.Log("Aie !");
            Debug.Log("Player's HP : " + life);

        }
    }
}
