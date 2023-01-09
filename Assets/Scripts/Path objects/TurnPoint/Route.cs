using UnityEngine;

public class Route : MonoBehaviour
{
    #region Fields
    [SerializeField] private Transform[] waypoints;
    [SerializeField] bool isCanDraw;

    [SerializeField] private Transform playerPos;
    #endregion

    private void Update()
    {
        UpdatePosition();
    }
    private void OnDrawGizmos()
    {
        if (isCanDraw)
        {
            int segmentsNumber = 20;
            Vector3 previousPoint = waypoints[0].position;

            for (int i = 0; i < segmentsNumber + 1; i++)
            {
                float parameter = (float)i / segmentsNumber;
                Vector3 point = Bezier.GetPoint(waypoints[0].position, waypoints[1].position, waypoints[2].position, waypoints[3].position, parameter);
                Gizmos.DrawLine(previousPoint, point);
                previousPoint = point;
            }
        }
    }
    private void UpdatePosition()
    {
        if (playerPos != null)
        {
            transform.position = new Vector3(playerPos.position.x, playerPos.position.y, transform.position.z);
        }
        if (playerPos.transform.eulerAngles.y == 90 || playerPos.transform.eulerAngles.y == -90)
        {
            gameObject.SetActive(false);
        }
    }
}
