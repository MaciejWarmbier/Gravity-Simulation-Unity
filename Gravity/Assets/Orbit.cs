using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    readonly float G = 1000f;
    List<Planet> planets;

    [SerializeField]
    bool Elipsis = false;

    void Start()
    {
        
        planets = GameObject.FindObjectsOfType<Planet>().ToList();

        SetInitialVelocity();
    }

    void FixedUpdate()
    {
        Gravity();
    }

    public void AddPlanet(Planet planet)
    {
        planets.Add(planet);
        SetInitialVelocity();

    }

    void SetInitialVelocity()
    {
        foreach (Planet planet in planets)
        {
            planet.rigidbody.velocity = Vector3.zero;
        }

        foreach (Planet planet in planets)
        {
            foreach (Planet centerPlanet in planets)
            {
                if (!planet.Equals(centerPlanet))
                {
                    float m2 = centerPlanet.rigidbody.mass;
                    float r = Vector3.Distance(planet.transform.position, centerPlanet.transform.position);

                    planet.transform.LookAt(centerPlanet.transform);

                    if (Elipsis)
                    {
                        planet.rigidbody.velocity += planet.transform.right * Mathf.Sqrt((G * m2) * ((2 / r) - (1 / (r * 1.5f))));
                    }
                    else
                    {
                        planet.rigidbody.velocity += planet.transform.right * Mathf.Sqrt((G * m2) / r);
                    }
                }
            }
        }
    }

    void Gravity()
    {
        foreach (Planet planet in planets)
        {
            foreach (Planet centerPlanet in planets)
            {
                if (!planet.Equals(centerPlanet))
                {
                    float m1 = planet.rigidbody.mass;
                    float m2 = centerPlanet.rigidbody.mass;
                    float r = Vector3.Distance(centerPlanet.transform.position, planet.transform.position);

                    planet.rigidbody.AddForce((centerPlanet.transform.position - planet.transform.position).normalized * (G * (m1 * m2) / (r * r)));
                }
            }
        }
    }
}