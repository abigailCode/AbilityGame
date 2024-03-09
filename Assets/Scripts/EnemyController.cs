using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyController : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if(!collision.gameObject.CompareTag("Player")){

            GameObject.Find("DodgesText").GetComponent<TMP_Text>().text = $"Dodges: {++PlayerController.dodges}";
            Destroy(gameObject);
        }
    }
}
