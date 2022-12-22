using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockTower : MonoBehaviour
{
    #region Fields
    [SerializeField] private GameObject firstBox;
    [SerializeField] private GameObject blockPart;
    private List<GameObject> blockParts = new();
    private List<Vector3> blockPartsPositions = new();

    [SerializeField] private int boxTowerLength = 3;
    const float boxHeight = 0.63f;
    #endregion

    void Start()
    {
        BoxTowerCreate();
    }
    public void BoxTowerCreate()
    {
        blockParts.Add(firstBox);
        blockPartsPositions.Add(firstBox.transform.position);

        for (int i = 1; i < boxTowerLength; i++)
        {
            var newBoxPart = Instantiate(blockPart, new Vector3(transform.position.x, blockPartsPositions[blockPartsPositions.Count - 1].y + boxHeight, transform.position.z), transform.rotation, transform);
            blockParts.Add(newBoxPart);
            blockPartsPositions.Add(newBoxPart.transform.position);
        }
    }
}
