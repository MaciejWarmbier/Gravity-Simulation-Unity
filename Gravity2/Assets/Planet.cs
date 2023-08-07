using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public float mass = 1.0f;
    public float velocity = 0;
    public Rigidbody2D rigidbody;
    public LineRenderer lineRenderer;

    public Vector2 direction;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void ChangeScale(float value)
    {
        this.transform.localScale = new Vector2(value, value);
    }

    public void ChangeMass(float value)
    {
        mass = value;
    }

    public void ChangeVelocity(float value)
    {
        velocity = value;
    }

    public void AddRandomColor()
    {
        Color background1 = UnityEngine.Random.ColorHSV();
        Color background2 = UnityEngine.Random.ColorHSV();

        var tr = GetComponent<TrailRenderer>();

        tr.material = new Material(Shader.Find("Sprites/Default"));
        float alpha = 1.0f;

        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(background1, 0.0f), new GradientColorKey(background2, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
        );

        tr.colorGradient = gradient;
    }


    public void VelocityRenderer(Vector2 StartLine, Vector2 endLine)
    {
        List<Vector3> posititons = new List<Vector3>();
        posititons.Add(StartLine);
        posititons.Add(endLine);
        lineRenderer.SetPositions(posititons.ToArray());
        direction = (endLine -StartLine).normalized;
        var distance = Vector2.Distance(StartLine, endLine);
        velocity = distance;
    }
}
