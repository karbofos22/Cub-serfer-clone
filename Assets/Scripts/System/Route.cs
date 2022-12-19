using UnityEngine;

public class Route : MonoBehaviour
{
    [SerializeField] Transform[] waypoints;
    [SerializeField] bool isCanDraw;

    private void OnDrawGizmos()
    {
        if (isCanDraw)
        {
            int segmentsNumber = 20;
            Vector3 previousPoint = waypoints[0].position;

            for (int i = 0; i < segmentsNumber + 1; i++)
            {
                float paremeter = (float)i / segmentsNumber;
                Vector3 point = Bezier.GetPoint(waypoints[0].position, waypoints[1].position, waypoints[2].position, waypoints[3].position, paremeter);
                Gizmos.DrawLine(previousPoint, point);
                previousPoint = point;
            }
        }
    }
}
