using DG.Tweening;
using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Progress;

public class BodyController : MonoBehaviour
{
    [SerializeField] private GameObject firstBox;

    [SerializeField] private GameObject boxPart;
    [SerializeField] private GameObject dummy;
    private GameObject lastBlockObject;

    [SerializeField] private List<GameObject> boxParts = new();
    [SerializeField] private int startingTowerHeight = 3;
    private const float boxHeight = 0.63f;

    private void Awake()
    {
        BoxTowerCreate();
    }
    private void Update()
    {
        PlayerStatus();
    }
    private void BoxTowerCreate()
    {
        boxParts.Add(firstBox);
        lastBlockObject = boxParts[boxParts.Count - 1];

        for (int i = 1; i < startingTowerHeight; i++)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + boxHeight, transform.position.z);

            var newBoxPart = Instantiate(boxPart, new Vector3(transform.position.x, lastBlockObject.transform.position.y - boxHeight, transform.position.z), Quaternion.identity, transform);
            boxParts.Add(newBoxPart);
            lastBlockObject = boxParts[boxParts.Count - 1];
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<SingleBox>(out SingleBox box))
        {
            TowerIncrease(box.growValue);
            Destroy(other.gameObject);
        }
        if (other.TryGetComponent<BoxTower>(out BoxTower boxTower))
        {
            TowerIncrease(boxTower.growValue);
            Destroy(other.gameObject);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Lava>())
        {
            TowerDecreaseByLava();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            if (contact.otherCollider.GetType() == (typeof(CapsuleCollider)))
            {
                contact.thisCollider.transform.parent = null;
                boxParts.Remove(contact.thisCollider.gameObject);
                
                lastBlockObject = boxParts[boxParts.Count - 1];
            }
        }
    }
    private void TowerIncrease(int increaseAmount)
    {
        for (; increaseAmount > 0; increaseAmount--)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + boxHeight, transform.position.z);

            var newBoxPart = Instantiate(boxPart, new Vector3(transform.position.x, lastBlockObject.transform.position.y - boxHeight, transform.position.z), Quaternion.identity, transform);
            boxParts.Add(newBoxPart);
            lastBlockObject = boxParts[boxParts.Count - 1];
        }
    }
    private void TowerDecreaseByLava()
    {
        lastBlockObject.transform.parent = null;
        boxParts.Remove(lastBlockObject);
        Destroy(lastBlockObject);
        lastBlockObject = boxParts[boxParts.Count - 1];
    }
    private void PlayerStatus()
    {
        if (boxParts.Count == 0)
        {
            EventManager.SendGameIsOver();
        }
    }
}
