using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

[RequireComponent(typeof(AudioSource))]

public class VB_Recarregar : MonoBehaviour, IVirtualButtonEventHandler {

    private AudioSource som;
    public AudioClip audio_reload;

    // Use this for initialization
    void Start () {
        //procura o componente de audio
        som = GetComponent<AudioSource>();
        //procura o botao virtual
        VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour>();

        for (int i = 0; i < vbs.Length; ++i)
        {
            vbs[i].RegisterEventHandler(this);
        }
    }

    public void OnButtonPressed(VirtualButtonAbstractBehaviour vb)
    {
        //se apertar o botao e tiver poucas balas
        if (vb.VirtualButtonName == "VB Balas" && VB_Atirar.balas < 6)
        {
            VB_Atirar.balas += 5;
            //toca som reload
            TocaSom(audio_reload);
        }
    }

    public void OnButtonReleased(VirtualButtonAbstractBehaviour vb)
    {
        //Debug.Log("Botao solto");
    }

    void TocaSom(AudioClip audio)
    {
        som.Stop();
        som.clip = audio;
        som.Play();
    }
}
