using UnityEngine;

public class Pillars : MonoBehaviour
{
    [SerializeField] private PillarColors pillarColors;
    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void Start()
    {
        SetColorByEnum();
    }

    private void SetColorByEnum()
    {
        switch (pillarColors)
        {
            case PillarColors.red:
                _renderer.material.color = Color.red;
                break;
            case PillarColors.blue:
                _renderer.material.color = Color.blue;
                break;
            case PillarColors.green:
                _renderer.material.color = Color.green;
                break;
            case PillarColors.yellow:
                _renderer.material.color = Color.yellow;
                break;
            default:
                _renderer.material.color = Color.white;
                Debug.Log("No Color");
                break;
        }
    }
    [System.Serializable]
    public enum PillarColors
    {
        red,
        blue,
        green,
        yellow
       
    }
}
