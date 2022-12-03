using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanging : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] int levelToLoad;

    void Update()
    {
        void OnTriggerEnter(Collider other)
        {
            FadeToLevel(1);
        }

        void FadeToLevel(int levelIndex)
        {
            levelToLoad = levelIndex;
            animator.SetTrigger("FadeOut");
        }
        
        void OnFadeComplete()
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }
}
