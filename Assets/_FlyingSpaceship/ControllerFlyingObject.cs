using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Unity​Engine.InputSystem.OnScreen;
public class ControllerFlyingObject : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    Vector2 startingPoint;
    Vector2 draggingPoint;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnDrag(PointerEventData eventData)
    {
        draggingPoint = eventData.position;
        Vector3 newInput = (startingPoint - draggingPoint).normalized *40;

        GameController.MoveSpaceShip(new Vector3(-newInput.x,0,-newInput.y));
      //  startingPoint = draggingPoint;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        startingPoint = eventData.position;
    }
}
