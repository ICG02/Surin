using UnityEngine;
using UnityEngine.UI;

public class PlayerRay : MonoBehaviour
{
    public Transform pointer;
    private Selectable currentSelectable;

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward * 10, Color.red);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            pointer.position = hit.point;

            Selectable selectable = hit.collider.gameObject.GetComponent<Selectable>();
            if (selectable)
            {
                if (currentSelectable && currentSelectable != selectable)
                {
                    currentSelectable.Deselect();
                }
                currentSelectable = selectable;
                selectable.Select();
            }
            else if (currentSelectable)
            {
                currentSelectable.Deselect();
                currentSelectable = null;
            }
        }
        else if (currentSelectable)
        {
            currentSelectable.Deselect();
            currentSelectable = null;
        }
    }
}
