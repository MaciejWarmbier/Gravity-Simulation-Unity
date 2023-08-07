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
        SetInitialVelocity(planet);

    }

    void SetInitialVelocity()
    {
        foreach (Planet planet in planets)
        {
            foreach (Planet centerPlanet in planets)
            {
                if (!planet.Equals(centerPlanet))
                {
                    float m2 = centerPlanet.mass;
                    float r = Vector2.Distance(planet.transform.position, centerPlanet.transform.position);

                    planet.transform.LookAt(centerPlanet.transform);

                    if (Elipsis)
                    {
                        planet.rigidbody.velocity += (Vector2) planet.transform.up * Mathf.Sqrt((G * m2) * ((2 / r) - (1 / (r * 1.5f))));
                    }
                    else
                    {
                        planet.rigidbody.velocity += new Vector2(planet.transform.up.x, planet.transform.up.y) * Mathf.Sqrt((G * m2) / r);
                    }
                }
            }
        }
    }

    void SetInitialVelocity(Planet newPlanet)
    {
        if (newPlanet.velocity != null && newPlanet.direction != null)
            newPlanet.rigidbody.velocity += newPlanet.direction * newPlanet.velocity;
        else
        {
            foreach (Planet centerPlanet in planets)
            {
                if (!newPlanet.Equals(centerPlanet))
                {
                    float m2 = centerPlanet.mass;
                    float r = Vector2.Distance(newPlanet.transform.position, centerPlanet.transform.position);

                    newPlanet.transform.LookAt(centerPlanet.transform);

                    if (Elipsis)
                    {
                        newPlanet.rigidbody.velocity += (Vector2)newPlanet.transform.up * Mathf.Sqrt((G * m2) * ((2 / r) - (1 / (r * 1.5f))));
                    }
                    else
                    {
                        newPlanet.rigidbody.velocity += new Vector2(newPlanet.transform.up.x, newPlanet.transform.up.y) * Mathf.Sqrt((G * m2) / r);
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
                    float m1 = planet.mass;
                    float m2 = centerPlanet.mass;
                    float r = Vector2.Distance(centerPlanet.transform.position, planet.transform.position);

                    planet.rigidbody.AddForce((centerPlanet.transform.position - planet.transform.position).normalized * (G * (m1 * m2) / (r * r)));
                }
            }
        }
    }
}