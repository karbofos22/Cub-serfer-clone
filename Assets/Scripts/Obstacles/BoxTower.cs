using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BoxTower : MonoBehaviour
{
    #region Fields
    [SerializeField] private GameObject firstBox;
    [SerializeField] private GameObject boxPart;
    private List<GameObject> boxParts = new();
    private List<Vector3> boxPartsPositions = new();

    [SerializeField] private int boxTowerLength = 3;
    const float boxHeight = 0.63f;

    public int growValue;
    #endregion

    void Start()
    {
        BoxTowerCreate();
    }
    public void BoxTowerCreate()
    {
        boxParts.Add(firstBox);
        boxPartsPositions.Add(firstBox.transform.position);

        for (int i = 1; i < boxTowerLength; i++)
        {
            var newBoxPart = Instantiate(boxPart, new Vector3(transform.position.x, boxPartsPositions[boxPartsPositions.Count - 1].y + boxHeight, transform.position.z), Quaternion.identity, transform);
            boxParts.Add(newBoxPart);
            boxPartsPositions.Add(newBoxPart.transform.position);
        }
        growValue = boxParts.Count;
    }
}
