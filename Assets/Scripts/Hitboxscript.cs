using UnityEngine;
using System.Collections;

public class Hitboxscript : MonoBehaviour
{
    private GameObject damager;

    public void setmommy(GameObject mom)
    {
        damager = mom;
    }
}
