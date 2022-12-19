using DG.Tweening;
using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Progress;

public class BodyController : MonoBehaviour
{
    [SerializeField] private GameObject firstBox;
    [SerializeField] private GameObject boxPart;
    [SerializeField] private GameObject dummy;

    private List<GameObject> boxParts = new();
    private List<Vector3> boxPartsPositions = new();

    [SerializeField] private int playerLength = 3;
    private const float boxHeight = 0.63f;


    private void Start()
    {
        BoxTowerCreate();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
    public void BoxTowerCreate()
    {
        boxPartsPositions.Add(firstBox.transform.position);

        for (int i = 1; i < playerLength; i++)
        {
            var newBoxPart = Instantiate(boxPart, new Vector3(transform.position.x, boxPartsPositions[boxPartsPositions.Count - 1].y + boxHeight, transform.position.z), Quaternion.identity, transform);
            dummy.transform.DOMoveY(boxPartsPositions[boxPartsPositions.Count - 1].y + boxHeight + 0.92f, 0.03f).SetEase(Ease.Linear);
            boxParts.Add(newBoxPart);
            boxPartsPositions.Add(newBoxPart.transform.position);
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
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == null)
        {
            foreach (var item in boxParts)
            {
                item.GetComponent<Rigidbody>().AddForce(Vector3.forward * 2, ForceMode.Impulse);
            }
        }
    }
    private void TowerIncrease(int increaseAmount)
    {
        for (; increaseAmount > 0; increaseAmount--)
        {
            var newBoxPart = Instantiate(boxPart, new Vector3(transform.position.x, boxPartsPositions[boxPartsPositions.Count - 1].y + boxHeight, transform.position.z), Quaternion.identity, transform);
            dummy.transform.DOMoveY(boxPartsPositions[boxPartsPositions.Count - 1].y + boxHeight + 1, 0.02f).SetEase(Ease.Linear);
            boxParts.Add(newBoxPart);
            boxPartsPositions.Add(newBoxPart.transform.position);
            playerLength++;
        }
    }
    void SnakeDecrease(int decreaseAmount)
    {
        for (; decreaseAmount > 0; decreaseAmount--)
        {
            {
                GameObject partToDsetroy = boxParts[boxParts.Count - 1];
                Destroy(partToDsetroy);
                boxParts.RemoveAt(boxParts.Count - 1);
                boxPartsPositions.RemoveAt(boxPartsPositions.Count - 1);
                playerLength--;
            }
        }

        //for (; decreaseAmount > 0; decreaseAmount--)
        //{
        //    if (snakeParts.Count == 0)
        //    {
        //        gameManager.isGameOver = true;
        //        audioSource.Play();
        //        deathParticle.Play();
        //        head.GetComponent<MeshRenderer>().enabled = false;

        //        break;
        //    }
        //    else
        //    {
        //        GameObject partToDsetroy = boxParts[boxParts.Count - 1];
        //        Destroy(partToDsetroy);
        //        boxParts.RemoveAt(boxParts.Count - 1);
        //        boxPartsPositions.RemoveAt(boxPartsPositions.Count - 1);
        //        playerLength--;
        //    }
        //}
    }


}
