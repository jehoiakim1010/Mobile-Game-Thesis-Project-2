using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDamage : MonoBehaviour
{
    playerMovement playermovement;

    Uimanager uimanager;
    public static bool canTakeDamage = true;
    float damage;

    GameObject Player;

    bool runonce;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");

        playermovement = Player.GetComponent<playerMovement>();

        uimanager = GameObject.FindObjectOfType<Uimanager>() as Uimanager;

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

        if (ES3.KeyExists("Player Sword"))
        {

            if (uimanager.Sword == "Sword")
            {
                damage = uimanager.Sword_damage;
            }

            else if (uimanager.Sword == "Axe")
            {
                damage = uimanager.Axe_Damage;
            }

            else if (uimanager.Sword == "Double Axe")
            {
                damage = uimanager.Double_Axe_damage;
            }
        }

        else
        {
            damage = 10;
        }


        if (playermovement.NumberAttack >= 1)
        {
            if (other.gameObject.GetComponent<enemyhealth>() != null)
            {

                other.gameObject.GetComponent<enemyhealth>().TakeDamage(damage);

                canTakeDamage = false;

                this.gameObject.SetActive(false);

            }
        }
    }

    IEnumerator EnemyCanTakeDamage()
    {

        yield return new WaitForSeconds(0.2f);

        runonce = false;

        this.gameObject.SetActive(false);
    }
}
