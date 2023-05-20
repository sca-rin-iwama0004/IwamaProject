using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerCreator : MonoBehaviour
{
    private static bool Loaded { get; set; }
    [SerializeField] GameObject[] gameManagerPrefabs = null;

    private void Awake()
    {
        if (Loaded) return;

        Loaded = true;

        foreach (var prefab in gameManagerPrefabs)
        {
            GameObject go = Instantiate(prefab);
            DontDestroyOnLoad(go);
        }
    }

    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
