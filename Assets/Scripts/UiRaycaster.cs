using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class UiRaycaster : MonoBehaviour
{
    [SerializeField] private GraphicRaycaster raycaster;
    [SerializeField] private EventSystem eventSystem;
    [SerializeField] private TradeController tradeController;
    private PointerEventData pointerEventData;
    

#if UNITY_EDITOR

    private void Reset()
    {
        raycaster = GetComponent<GraphicRaycaster>();
        eventSystem = FindObjectOfType<EventSystem>();
        tradeController = GetComponent<TradeController>();

        if (raycaster == null || eventSystem == null)
        {
            EditorUtility.DisplayDialog("Ui raycaster", "please add ui on canvas only", "OK");
            DestroyImmediate(this);
        }
    }
#endif

    private void Update()
    {
        if (!Input.GetKey(KeyCode.Mouse0))
        {
            return;
        }

        pointerEventData = new PointerEventData(eventSystem)
        {
            position = Input.mousePosition
        };
        var result = new List<RaycastResult>();
        raycaster.Raycast(pointerEventData, result);


        foreach (var raycastResalt in result)
        {
            if (raycastResalt.gameObject.GetComponent<Inventory>())
            {
                tradeController.CompareInventory(raycastResalt.gameObject.GetComponent<Inventory>());
                break;
            }

            tradeController.CompareInventory(null);
        }
    }
}