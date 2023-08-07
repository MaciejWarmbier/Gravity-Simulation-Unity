using System.IO.Compression;
using UnityEngine;

public class CreatePlanetScript : MonoBehaviour
{
    [SerializeField] SliderController massSlider;
    [SerializeField] SliderController scaleSlider;
    [SerializeField] SliderController xSlider;
    [SerializeField] SliderController ySlider;
    [SerializeField] SliderController zSlider;

    [SerializeField] Planet planetPrefab;
    [SerializeField] Orbit orbit;

    private Planet planet;
    [SerializeField] GameObject panel;
    private void Start()
    {
        panel.SetActive(false); 
    }

    public void Setup()
    {
        panel.SetActive(true);
        planet = Instantiate(planetPrefab, Vector3.zero, Quaternion.identity);

        massSlider.ValueChanged += planet.ChangeMass;
        scaleSlider.ValueChanged += planet.ChangeScale;
        xSlider.ValueChanged += planet.ChangePositionX;
        ySlider.ValueChanged += planet.ChangePositionY;
        zSlider.ValueChanged += planet.ChangePositionZ;
    }


    public void DestroyPlanet()
    {
        if (planet != null) Destroy(planet.gameObject);
        panel.SetActive(false);
    }

    public void Create()
    {
        if(planet!= null)
        {
            massSlider.ValueChanged -= planet.ChangeMass;
            scaleSlider.ValueChanged -= planet.ChangeScale;
            xSlider.ValueChanged -= planet.ChangePositionX;
            ySlider.ValueChanged -= planet.ChangePositionY;
            zSlider.ValueChanged -= planet.ChangePositionZ;
            orbit.AddPlanet(planet);
            planet = null;
        }
    }


    public void CreateRandom()
    {
        planet = Instantiate(planetPrefab, Vector3.zero, Quaternion.identity);
        planet.ChangeMass(massSlider.GetRandomValue());
        planet.ChangeScale(scaleSlider.GetRandomValue());
        planet.ChangePositionX(xSlider.GetRandomValue());
        planet.ChangePositionY(ySlider.GetRandomValue());
        planet.ChangePositionZ(zSlider.GetRandomValue());
        planet.AddRandomColor();
        orbit.AddPlanet(planet);
        planet = null;
    }
}
