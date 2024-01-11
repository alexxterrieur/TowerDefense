using UnityEngine.InputSystem;
using UnityEngine;

public class PlaceDefenses : MonoBehaviour
{
    public GameObject selectedDefense;
    Vector3 mousePos;
    bool inMapLLimit;
    bool noObstacles;

    public void DefenseSelectionButton(GameObject defense)
    {
        selectedDefense = defense;
    }

    private Vector3 GetMouseWorldPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;

        //if mousePos is in the mapLimit, set the inMapLimit bool to true and return the position
        if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("MapLimit"))
        {
            inMapLLimit = true;
            return hit.point;
        }

        inMapLLimit = false;
        return Vector3.zero;
    }

    public void PlaceBuilding(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && selectedDefense != null)
        {
            mousePos = GetMouseWorldPosition();

            //if there is only one collider (mapLimit) at a distance of 2 from the building to be constructed, then there are no obstacles
            Collider[] obstacles = Physics.OverlapBox(mousePos, new Vector3(2, 0, 2));
            if (obstacles.Length == 1) 
            {
                noObstacles = true;
            }
            else
            {
                noObstacles = false;
            }

            //if we try to build in the mapLimit and there is no obstacles, Instanciate the prefab
            if(inMapLLimit && noObstacles)
            {
                Instantiate(selectedDefense, new Vector3(mousePos.x, 1, mousePos.z), Quaternion.identity);
                selectedDefense = null;    
            }
        }
    }
}