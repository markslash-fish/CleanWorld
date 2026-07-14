using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TrashcanScript : MonoBehaviour
{

    public float trashcanMaxCap, trashcanCurrentCap;
    [SerializeField] private Slider hpslider;
    public GameObject hpsliderfill, trashcanCapBar;
    public TMP_Text capText; 


    void Start()
    {
        trashcanMaxCap = 60f;
        trashcanCurrentCap = 0f;
        hpsliderfill.SetActive(false);
        trashcanCapBar.SetActive(false);

    }


    void Update()
    {
        capText.SetText(trashcanCurrentCap.ToString("0") + (" / ") + trashcanMaxCap.ToString("0"));
        if (trashcanCurrentCap != 0)
        {
            hpsliderfill.SetActive(true);
        }
        UpdateHealthBar();
    }
    public void UpdateHealthBar()
    {
        hpslider.value = trashcanCurrentCap / trashcanMaxCap;
    }
    public void OnTriggerEnter(Collider other)
    {
        trashcanCapBar.SetActive(true);
    }
    public void OnTriggerExit(Collider other)
    {
        trashcanCapBar.SetActive(false);
    }
}
