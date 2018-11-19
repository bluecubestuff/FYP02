using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCollision : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            Debug.Log("Player Hits");
            other.GetComponent<Enemy>().UpdateHealth(-4f);
            if (gameObject.activeSelf)
                gameObject.SetActive(false);
        }
    }
}
