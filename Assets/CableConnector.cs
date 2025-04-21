using UnityEngine;

public class CableConnector : MonoBehaviour
{
    public GameObject cablePrefab;

    private Transform pointA = null;
    private Transform pointB = null;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // لما تدوس كليك شمال
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (pointA == null)
                {
                    pointA = hit.transform;
                    Debug.Log("🟢 I chose the first server: " + pointA.name);
                }
                else if (pointB == null)
                {
                    pointB = hit.transform;
                    Debug.Log("🔵 I chose the second server:" + pointB.name);
                    CreateCableBetweenPoints();
                }
            }
        }
    }

    void CreateCableBetweenPoints()
    {
        GameObject cable = Instantiate(cablePrefab);

        var cableScript = cable.GetComponent<OptimizedCable>();

        cableScript.startPoint = pointA;
        cableScript.endPoint = pointB;

        // نرجع الاختيار للوضع الافتراضي
        pointA = null;
        pointB = null;
    }
}
