using UnityEngine;

public class Scaler : MonoBehaviour
{
    [SerializeField] private Cube _cube;

    private int _scaleDivider = 2;

    private void OnEnable()
    {
        RescaleObject();
    }

    public void RescaleObject()
    {
        transform.localScale /= _scaleDivider;
    }
}
