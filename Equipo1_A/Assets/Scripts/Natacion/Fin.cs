using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fin : MonoBehaviour
{
    public GameObject victoria;

    private void Start() {
        victoria.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            victoria.SetActive(true);
        }
    }
}
