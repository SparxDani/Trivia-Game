using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    [SerializeField] SceneData dataScene;
    private void Start()
    {
        dataScene.OpcionMultiple = false;
        dataScene.UniendoPorLineas = false;
        dataScene.OrdenadoPorBloques = false;
    }
    public void On_OptionMultiply()
    {
        dataScene.OpcionMultiple = true;
        dataScene.UniendoPorLineas = false;
        dataScene.OrdenadoPorBloques = false;
        SceneManager.LoadScene("OpcionMultiple");
    }
    public void On_OptionOrdenadorPorBloques()
    {
        dataScene.OpcionMultiple = false;
        dataScene.UniendoPorLineas = false;
        dataScene.OrdenadoPorBloques = true;
        SceneManager.LoadScene("OrdenadoPorBloques");
    }
    public void On_OptionUniendoPorLineas()
    {
        dataScene.OpcionMultiple = false;
        dataScene.UniendoPorLineas = true;
        dataScene.OrdenadoPorBloques = false;
        SceneManager.LoadScene("UniendoPorLineas");
    }
}
