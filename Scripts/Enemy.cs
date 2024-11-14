using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D whatIHit)
    {
        if (whatIHit.tag == "Player")
        {
            //I hit the Player!
            GameObject.Find("GameManager").GetComponent<GameManager>().LoseALife();
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        else if (whatIHit.tag == "Weapon" && this.tag == "Enemy1")
        {
            //I am shot!
            GameObject.Find("GameManager").GetComponent<GameManager>().EarnScore(5);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(whatIHit.gameObject);
            Destroy(this.gameObject);
        }
        else if (whatIHit.tag == "Weapon" && this.tag == "Enemy2")
        {
            //I am shot!
            GameObject.Find("GameManager").GetComponent<GameManager>().EarnScore(8);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(whatIHit.gameObject);
            Destroy(this.gameObject);
        }

    }
}