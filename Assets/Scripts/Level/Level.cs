using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField]
    private Renderer _floor;
    private static Level instance;

    public static Level Instance => instance;
    public Renderer Floor => _floor;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }
}
