using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    public void On_OptionMultiply()
    {
        SceneManager.LoadScene("OpcionMultiple");
    }
    public void On_OptionOrdenadorPorBloques()
    {
        SceneManager.LoadScene("OrdenadoPorBloques");
    }
    public void On_OptionUniendoPorLineas()
    {
        SceneManager.LoadScene("UniendoPorLineas");
    }
}
