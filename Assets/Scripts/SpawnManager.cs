using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] ARRaycastManager raycastManager;
    [SerializeField] GameObject obj;

    List<ARRaycastHit> hits;
    GameObject spawnedObj;

    private void Awake()
    {
        hits = new List<ARRaycastHit>();
        spawnedObj = null;
    }

    private void Start()
    {
        if (!cam)
            cam = FindObjectOfType<Camera>();
        if (!raycastManager)
            raycastManager = FindObjectOfType<ARRaycastManager>();
    }

    private void Update()
    {
        if (Input.touchCount == 0) return;

        RaycastHit hit;

        Touch touch = Input.GetTouch(0);
        Ray ray = cam.ScreenPointToRay(touch.position);


        if (
            !EventSystem.current.IsPointerOverGameObject(touch.fingerId)
            && raycastManager.Raycast(touch.position, hits)
        )
        {
            if (
                touch.phase == TouchPhase.Began
                && !spawnedObj
                && Physics.Raycast(ray, out hit)
            )
            {
                SpawnObject(hits[0].pose.position);
            }
            else if (
                (
                    touch.phase == TouchPhase.Moved
                    || touch.phase == TouchPhase.Began
                )
                && spawnedObj
            )
            {
                spawnedObj.transform.position = hits[0].pose.position;
            }
        }
    }

    private void SpawnObject(Vector3 position)
    {
        if (spawnedObj) Destroy(spawnedObj);
        spawnedObj = Instantiate(obj, position, Quaternion.identity);
    }
}
