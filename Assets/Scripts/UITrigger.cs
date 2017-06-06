using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UITrigger : MonoBehaviour {

    [SerializeField]
    private Text texto;
    [SerializeField]
    private Text municao;

    private int score;
    private int nBalas;
    private int vida;

    void Start () {
        texto.text = "VIDA = " + HitTarget.lim_points + " \n MATE O GOBLIN!";
        municao.text = "Recarregue sua arma";
	}
	
	void Update () {
        vida = HitTarget.lim_points - HitTarget.points;
        score = HitTarget.points;
        nBalas = VB_Atirar.balas;

		if (score >= HitTarget.lim_points) {
            texto.text = "VIDA = " + vida + " \n VOCE MATOU O GOBLIN!";
        } else if (score != 0 && score <= HitTarget.lim_points) {
            texto.text = "VIDA = " + vida;
		}

        if (nBalas > 0) {
            municao.text = "BALAS = " + nBalas;
        } else {
            municao.text = "Recarregue sua arma!";
        }
	}

    public void RestartGame()
    {
        SceneManager.LoadScene("main", LoadSceneMode.Single);
    }
}
