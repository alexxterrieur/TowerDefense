using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TurretUI : MonoBehaviour
{
    [SerializeField] GameObject turretUI;

    public GameObject selectedTurret;
    public Slider sliderSpeed;
    public Slider sliderDamage;


    public bool canOpenTurretUI = false;

    private void Start()
    {
        turretUI.SetActive(false);
    }


    public void OpenTurretUI(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("Turret"))
            {
                Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
                selectedTurret = hit.collider.gameObject;
                turretUI.SetActive(true);
                canOpenTurretUI = true;
                UpdateVisualStat();

            }
            else
            {
                //canOpenTurretUI = false;
            }

        }
    }

    private void UpdateVisualStat()
    {
        sliderSpeed.value = selectedTurret.GetComponent<TurretShoot>().speedLevel;
        sliderDamage.value = selectedTurret.GetComponent<TurretShoot>().damageLevel;
    }

    public void IncreaseSpeed()
    {
        selectedTurret.GetComponent<TurretShoot>().UpgradeSpeed();
        UpdateVisualStat();
    }
    public void IncreaseDamage()
    {
        selectedTurret.GetComponent<TurretShoot>().UpgradeDamage();
        UpdateVisualStat();
    }
    public void DeleteTurret()
    {
        selectedTurret.GetComponent<TurretShoot>().Deleteturret();
    }
    
    public void CloseWindow()
    {
        turretUI.SetActive(false);
    }
}
