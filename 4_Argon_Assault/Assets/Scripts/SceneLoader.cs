using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(LoadFirstLevel), 2F);
    }

    private void LoadFirstLevel()
    {
        SceneManager.LoadScene(1);
    }
}
