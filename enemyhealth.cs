using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyhealth : MonoBehaviour
{
    public float maxH;
    public float currentH;
    public GameObject healthbar;
    public GameObject ItemDrop;
    GameObject Enemy;

    ManagerScript manager;


    // Start is called before the first frame update
    void Start()
    {
        currentH = maxH;
        Sethealth();

        Enemy = GameObject.FindWithTag("Enemy");

        manager = GameObject.FindObjectOfType<ManagerScript>() as ManagerScript;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentH <= 0)
        {
            Instantiate(ItemDrop, this.transform.position + new Vector3(0.0f, 0.5f, 0.5f), Quaternion.identity);
            Destroy(gameObject);

            manager.enemies.Remove(this.gameObject);
        }
    }

    public void TakeDamage(float amount)
    {
        currentH -= amount;
        Sethealth();

        //StartCoroutine(EnemyCanTakeDamage(amount));
    }

    /*IEnumerator EnemyCanTakeDamage(float amount)
    {
        yield return new WaitForSeconds(0.07f);
        Debug.Log("working");

        //currentH -= amount;
        Sethealth();

        SwordDamage.canTakeDamage = false;
    }*/

    public void Sethealth()
    {
        float updatehealth = currentH / maxH;
        healthbar.transform.localScale = new Vector3(Mathf.Clamp(updatehealth, 0, 1), healthbar.transform.localScale.y, healthbar.transform.localScale.z);
    }
}
