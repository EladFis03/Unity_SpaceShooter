using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
     // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadFisrstScene", 3.5f);
    }

    void LoadFisrstScene()
    {
        SceneManager.LoadScene(1);
    }
}
