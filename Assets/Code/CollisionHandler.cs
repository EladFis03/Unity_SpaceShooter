using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // כל עוד זה הקוד היחידי שאחראי על טעינת שלבים

public class CollisionHandler : MonoBehaviour
{
    [Tooltip("In seconds")] [SerializeField] float levelLoadDelay = 1.5f;
    [Tooltip("FX prefab on player")] [SerializeField] GameObject DeathFX;

    void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
        DeathFX.SetActive(true);
        Invoke("ReloadScene", levelLoadDelay);
    }

    private void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath");
    }

    private void ReloadScene() // אם אשנה את השם של זה פה, אצטרך לשנות גם למעלה
    {
        SceneManager.LoadScene(1);
    }

}
