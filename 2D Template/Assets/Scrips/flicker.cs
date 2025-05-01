using UnityEngine;
using UnityEngine.Rendering.Universal;

public class flicker : MonoBehaviour
{
    private Light2D light2d;
    public AnimationCurve curve;
    public float frequency;
    public float amplitudel;
    public float minOffset;
    public float maxOffset;
    private float noiseOffset;

    void Start()
    {
        light2d = GetComponent<Light2D>();
        noiseOffset=Random.Range(0.0f, 10f);
    }

    // Update is called once per frame
    void Update()

    {
        float offset = Mathf . Lerp ( minOffset,maxOffset, Mathf.PerlinNoise1D(noiseOffset +Time.time * frequency));
        light2d.intensity = curve.Evaluate (Mathf.Repeat( noiseOffset + Time.time *  frequency,1)) * amplitudel + offset;

    }
}
