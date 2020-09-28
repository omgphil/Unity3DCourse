using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    private void Awake() => DontDestroyOnLoad(this);

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
