using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MusicManager : MonoBehaviour
{
    // SINGLETON
    private static MusicManager Instance;

    // Start is called before the first frame update
    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else 
        {
            DestroyImmediate(gameObject);
            return; // removes error
        }  

        DontDestroyOnLoad(gameObject);
    }
}

