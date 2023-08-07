using UnityEngine;

public class Planet : MonoBehaviour
{
    float velocity = 0;
    public Rigidbody rigidbody;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void ChangePositionX(float value)
    {
        this.transform.position = new Vector3(value, transform.position.y, transform.position.z);
    }

    public void ChangePositionY(float value)
    {
        this.transform.position = new Vector3(transform.position.x, value, transform.position.z);
    }

    public void ChangePositionZ(float value)
    {
        this.transform.position = new Vector3( transform.position.x, transform.position.y, value);
    }

    public void ChangeScale(float value)
    {
        this.transform.localScale = new Vector3(value, value, value);
    }

    public void ChangeMass(float value)
    {
        rigidbody.mass = value;
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

}
