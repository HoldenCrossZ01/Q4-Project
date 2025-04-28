using UnityEngine;
using UnityEngine.Rendering.Universal;

public class flicker : MonoBehaviour
{
    private Light2D light2d;
    public AnimationCurve curve;
    public float frequency;
    public float amplitudel;
    void Start()
    {
        light2d = GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        light2d.intensity = curve.Evaluate (Mathf.Repeat( Time.time *  frequency,1)) * amplitudel;

    }
}
