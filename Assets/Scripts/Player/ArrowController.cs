using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform firePoint;
    [SerializeField] float trippleOffset = 1f;

    bool isTripple = false;

    public bool IsTripple { get { return isTripple; } set { isTripple = value; } }

    /*public void FireArrow()
    {
        {
            GameObject arrow = ArrowPool.instance.GetPooledObject();

            if (arrow != null)
            {
                arrow.SetActive(true);
                arrow.transform.SetPositionAndRotation(firePoint.position, player.rotation);
                arrow.GetComponent<Arrow>().ArrowFiring();
            }
        }
    }

    public void TripleFire()
    {
        GameObject arrow1 = ArrowPool.instance.GetMultipleObjects(0);
        GameObject arrow2 = ArrowPool.instance.GetMultipleObjects(1);
        GameObject arrow3 = ArrowPool.instance.GetMultipleObjects(2);

        if (arrow1 != null && arrow2 != null && arrow3 != null)
        {
            arrow1.SetActive(true);
            arrow1.transform.SetPositionAndRotation(firePoint.position, player.rotation);
            arrow1.GetComponent<Arrow>().ArrowFiring(trippleOffset);

            arrow2.SetActive(true);
            arrow2.transform.SetPositionAndRotation(firePoint.position, player.rotation);
            arrow2.GetComponent<Arrow>().ArrowFiring();

            arrow3.SetActive(true);
            arrow3.transform.SetPositionAndRotation(firePoint.position, player.rotation);
            arrow3.GetComponent<Arrow>().ArrowFiring(-trippleOffset);

            isTripple = false;
        }
    }*/
}
