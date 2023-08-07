using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlacePlanet : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private CreatePlanetScript createPlanetUi;
    [SerializeField] Orbit orbit;
    [SerializeField] private Planet planetPrefab;
    bool isMoving = false;
    private Planet planet;


    private Vector3 startPosition;
    private Vector3 endPosition;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !IsOverUI.IsPointerOverUIElement())
        {
            var mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.transform.position.z;
            startPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            planet = Instantiate(planetPrefab, startPosition, Quaternion.identity);
            isMoving = true;
        }
        else if (Input.GetMouseButton(0) && isMoving && planet != null)
        {
            var mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.transform.position.z;
            endPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            planet.VelocityRenderer(startPosition, endPosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Create();
            isMoving = false;
        }
        else if (Input.GetMouseButtonDown(1))
        {
            DestroyPlanet();
            isMoving = false;
        }
    }


    public void DestroyPlanet()
    {
        if (planet != null) Destroy(planet.gameObject);
    }

    public void Create()
    {
        if (planet != null)
        {
            planet.AddRandomColor();
            planet.lineRenderer.enabled = false;
            orbit.AddPlanet(planet);
            planet = null;
        }
    }
}
