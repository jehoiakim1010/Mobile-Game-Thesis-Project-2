using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    HealthBar Player;
    public int HitPoints;
    //float damage = 5;

    //GameObject Player;

    bool runonce;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthBar>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.runonce == false)
        {
            StartCoroutine(EnemyCanTakeDamage());
            this.runonce = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        /*if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<CharacterHealth>().TakeDamage(damage);
        }*/
        if (other.gameObject.tag == "Player")
        {
            Player.HurtPlayer(HitPoints);

            this.gameObject.SetActive(false);
        }
    }

    IEnumerator EnemyCanTakeDamage()
    {

        yield return new WaitForSeconds(0.2f);

        runonce = false;

        this.gameObject.SetActive(false);
    }
}
