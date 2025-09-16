using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class Building : MonoBehaviour
{
    [Header("건물 정보")]
    public BuildingType BuildingType;
    public string buildingName = "건물";

    [System.Serializable]
    public class BuildingEvents
    {
        public UnityEvent<string> OnDriverEnterd;
        public UnityEvent<string> OnDriverExited;
        public UnityEvent<BuildingType> OnServiceUsed;
    }

    public BuildingEvents buildingEvents;

    private DeliveryOrderSystem orderSystem;

    // Start is called before the first frame update
    void Start()
    {
        SetupBuilding();
        orderSystem = FindObjectOfType<DeliveryOrderSystem>();
        CreateNameTag();
    }

    void SetupBuilding()
    {
        Renderer renderer = GetComponent<Renderer>();
        if(renderer != null)
        {
            Material mat = renderer.material;
            switch (BuildingType)
            {
                case BuildingType.Restaurant:
                    mat.color = Color.red;
                    break;
                case BuildingType.Customer:
                    mat.color = Color.green;
                    break;
                case BuildingType.ChargingStation:
                    mat.color = Color.yellow;
                    break;
            }
        }

        Collider collider = GetComponent<Collider>();
        if(collider != null) { collider.isTrigger = true; }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        DeliveryDriver driver = other.GetComponent<DeliveryDriver>();
        if(driver != null)
        {
            buildingEvents.OnDriverEnterd?.Invoke(buildingName);
            HandleDriverService(driver);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        DeliveryDriver driver = other.GetComponent<DeliveryDriver>();
        if (driver != null)
        {
            buildingEvents.OnDriverExited?.Invoke(buildingName);
            Debug.Log($"{buildingName} 을 떠났습니다.");
        }
    }

    void CreateNameTag()
    {
        // 건물 위에 이름표 생성
        GameObject nameTag = new GameObject("NameTag");
        nameTag.transform.SetParent(transform);
        nameTag.transform.localPosition = Vector3.up * 1.5f;

        TextMesh textmesh = nameTag.AddComponent<TextMesh>();
        textmesh.text = buildingName;
        textmesh.characterSize = 0.2f;
        textmesh.anchor = TextAnchor.MiddleCenter;
        textmesh.color = Color.black;
        textmesh.fontSize = 20;

        nameTag.AddComponent<Bildboard>();
    }

    void HandleDriverService(DeliveryDriver driver)
    {
        switch (BuildingType)
        {
            case BuildingType.Restaurant:
                if(orderSystem != null)
                {
                    orderSystem.OnDriverEnteredRestaurant(this);
                }
                    break;
            case BuildingType.Customer:
                if (orderSystem != null)
                {
                    orderSystem.OnDriverEnteredCustomer(this);
                }
                else
                {
                    driver.CompleteDelivery();
                }
                break;
            case BuildingType.ChargingStation:
                
                driver.CompleteDelivery();
                break;
        }

        buildingEvents.OnServiceUsed?.Invoke(BuildingType);
    }
}
