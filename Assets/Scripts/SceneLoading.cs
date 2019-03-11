using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoading : MonoBehaviour
{
    [SerializeField]
    private float _delayBeforeLoading = 60f;
    [SerializeField]
    private string _sceneNameToLoad;
    private float timeElapsed;

    void Update()
    {
        timeElapsed += Time.deltaTime;

        if(timeElapsed > _delayBeforeLoading)
        {
            SceneManager.LoadScene(_sceneNameToLoad);
        }
    }
}
