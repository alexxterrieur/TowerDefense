using UnityEngine;
using UnityEngine.UI;

public class TurretUI : MonoBehaviour
{
    [SerializeField] GameObject turretUI;

    public GameObject selectedTurret;
    public Slider sliderSpeed;
    public Slider sliderDamage;

    private void Start()
    {
        turretUI.SetActive(false);
    }



    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("Turret"))
            {
                Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
                selectedTurret = hit.collider.gameObject;
                turretUI.SetActive(true);
                UpdateVisualStat();
                
            }
/*            else
            {
                turretUI.SetActive(false);
            }*/

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
