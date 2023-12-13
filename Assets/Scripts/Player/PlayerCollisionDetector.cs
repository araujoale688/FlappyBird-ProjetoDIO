using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        OnCustomCollisionEnter(other.gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        OnCustomCollisionEnter(other.gameObject);
    }

    private void OnCustomCollisionEnter(GameObject other)
    {
        if (other.CompareTag("Sensor"))
        {
            GameManager.Instance.score++;
        }
        else
        {
            GameManager.Instance.EndGame();
        }
    }
}