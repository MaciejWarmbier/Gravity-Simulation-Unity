using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] CreatePlanetScript createPlanet;


    public void CreateRandom()
    {
        createPlanet.CreateRandom();
    }

    public void ShowCreatePlanet()
    {
        createPlanet.Setup();
    }
}
