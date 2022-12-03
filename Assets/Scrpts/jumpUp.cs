using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class jumpUp : MonoBehaviour
{
    [SerializeField] float jumping = 10000f;

    [SerializeField] Animator animator;
    [SerializeField] int levelToLoad;
    [SerializeField] private float loadDelay = 5f;
    [SerializeField] private string sceneNameToLoad;
    [SerializeField] private float timeElapsed;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        { collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * jumping, ForceMode.Impulse);
            SceneManager.LoadScene("End", LoadSceneMode.Additive);
            Invoke("SceneLoad", 6f);
        }
    }

    void SceneLoad()
    {
        SceneManager.LoadScene(sceneNameToLoad);
    }
}




