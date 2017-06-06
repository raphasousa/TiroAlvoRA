using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitTarget : MonoBehaviour {
	public static int points = 0;
    public static int lim_points = 10;

    void Start () {
		points = 0;
	}
	
	void OnCollisionEnter(Collision col) {
		if (col.gameObject.name == "WWGPistol_0_Ammo(Clone)") {
            //se o tiro acertar a cabeça, ganha mais pontos
            if (gameObject.tag == "Corpo") points += 4;
            else if (gameObject.tag == "cabeça")
            {
                points = lim_points;
                VB_Atirar.headshot = true;
            }
            
            //destroi a bala
			Destroy(col.gameObject, 0.03f);
		}
	}
}
