using System.IO.Compression;
using UnityEngine;

public class CreatePlanetScript : MonoBehaviour
{
    [SerializeField] SliderController massSlider;
    [SerializeField] SliderController scaleSlider;
    [SerializeField] SliderController sunMassSlider;
    [SerializeField] Planet sun;

    [SerializeField] Planet planetPrefab;
    [SerializeField] Orbit orbit;

    private Planet planet;

    private void Start()
    {
        
        sunMassSlider.SetValue(sun.mass);
        sunMassSlider.ValueChanged += HandleOnSunValueChanged;
    }

    public float GetMass()
    {
       return massSlider.GetValue();
    }

    public float GetScale()
    {
        return scaleSlider.GetValue();
    }

    private void HandleOnSunValueChanged(float value)
    {
        sun.ChangeMass(value);
    }

    public void CreateRandom()
    {
        planet = Instantiate(planetPrefab, Vector2.zero, Quaternion.identity);
        planet.ChangeMass(massSlider.GetRandomValue());
        planet.ChangeScale(scaleSlider.GetRandomValue());
        planet.AddRandomColor();
        orbit.AddPlanet(planet);
        planet = null;
    }
}
