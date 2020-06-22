using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultBox : MonoBehaviour
{
    private SpriteRenderer spr;

    public GameObject mixBox1;
    public GameObject mixBox2;
    public GameObject mixBox3;
    public string cp;

    public GameObject Content;

    private string source1, source2, source3;

    // Start is called before the first frame update
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }

   
    public void ResetButtonCllicked()
    {
        
        if (mixBox1.GetComponent<SpriteRenderer>().sprite != null)
        {
            MainController.Instance.UnitCount[mixBox1.GetComponent<SpriteRenderer>().sprite.name]++;
            MainController.Instance.PaletteCountRefresh(mixBox1.GetComponent<SpriteRenderer>().sprite.name);
        }
        if (mixBox2.GetComponent<SpriteRenderer>().sprite != null)
        {
            MainController.Instance.UnitCount[mixBox2.GetComponent<SpriteRenderer>().sprite.name]++;
            MainController.Instance.PaletteCountRefresh(mixBox2.GetComponent<SpriteRenderer>().sprite.name);

        }
        if (mixBox3.GetComponent<SpriteRenderer>().sprite != null)
        {
            MainController.Instance.UnitCount[mixBox3.GetComponent<SpriteRenderer>().sprite.name]++;
            MainController.Instance.PaletteCountRefresh(mixBox3.GetComponent<SpriteRenderer>().sprite.name);

        }
        
        mixBox1.GetComponent<SpriteRenderer>().sprite = null;
        mixBox2.GetComponent<SpriteRenderer>().sprite = null;
        mixBox3.GetComponent<SpriteRenderer>().sprite = null;

        gameObject.GetComponent<SpriteRenderer>().sprite = null;

    }

    bool mixed = false;

    private void OnMouseDown()
    {
        if (mixed)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SoundEffectController.Instance.ResultBoxClickSound();

                if (spr.sprite != null)
                {
                    //조합된 유닛 팔레트에 추가
                    if (MainController.Instance.UnitCount[cp] == 0)
                    {
                        MainController.Instance.UnitToSetActive(cp, true);

                    }

                    MainController.Instance.PaletteRefresh(cp, 1);

                    if (MainController.Instance.UnitCount[source1] == 0)
                        MainController.Instance.UnitToSetActive(source1, false);
                    if (MainController.Instance.UnitCount[source2] == 0)
                        MainController.Instance.UnitToSetActive(source2, false);
                    if (!source3.Equals("null"))
                    {
                        if (MainController.Instance.UnitCount[source3] == 0)
                            MainController.Instance.UnitToSetActive(source3, false);
                        source3 = "null";
                    }


                    mixBox1.GetComponent<SpriteRenderer>().sprite = null;
                    mixBox2.GetComponent<SpriteRenderer>().sprite = null;
                    mixBox3.GetComponent<SpriteRenderer>().sprite = null;

                    spr.sprite = null;
                }
            }
        }
        mixed = false;
    }

    private void Update()
    {
        if (!(mixBox1.GetComponent<SpriteRenderer>().sprite == null))
        {

            MainController.Instance.PaletteCountRefresh(mixBox1.GetComponent<SpriteRenderer>().sprite.name);

            if(!(mixBox2.GetComponent<SpriteRenderer>().sprite == null))
            {
                MainController.Instance.PaletteCountRefresh(mixBox2.GetComponent<SpriteRenderer>().sprite.name);

                if (!(mixBox3.GetComponent<SpriteRenderer>().sprite == null))
                {
                    MainController.Instance.PaletteCountRefresh(mixBox3.GetComponent<SpriteRenderer>().sprite.name);
                    //3개 조합

                    source1 = mixBox1.GetComponent<SpriteRenderer>().sprite.name;
                    source2 = mixBox2.GetComponent<SpriteRenderer>().sprite.name;
                    source3 = mixBox3.GetComponent<SpriteRenderer>().sprite.name;

                    //4성
                    //하이랜더
                    if (source1.Equals("Reydn") && source2.Equals("Ghibli") && source3.Equals("Ife") ||
                  (source1.Equals("Reydn") && source2.Equals("Ife") && source3.Equals("Ghibli")) ||
                  (source1.Equals("Ghibli") && source2.Equals("Reydn") && source3.Equals("Ife")) ||
                  (source1.Equals("Ghibli") && source2.Equals("Ife") && source3.Equals("Reydn")) ||
                  (source1.Equals("Ife") && source2.Equals("Ghibli") && source3.Equals("Reydn")) ||
                  (source1.Equals("Ife") && source2.Equals("Reydn") && source3.Equals("Ghibli")))
                    {
                        spr.sprite = Resources.Load("HighLander", typeof(Sprite)) as Sprite;
                        cp = "HighLander";
                    }
                    //prominence
                    if (source1.Equals("Edel") && source2.Equals("Corona") && source3.Equals("Livea") ||
                  (source1.Equals("Edel") && source2.Equals("Livea") && source3.Equals("Corona")) ||
                  (source1.Equals("Livea") && source2.Equals("Edel") && source3.Equals("Corona")) ||
                  (source1.Equals("Livea") && source2.Equals("Corona") && source3.Equals("Edel")) ||
                  (source1.Equals("Corona") && source2.Equals("Livea") && source3.Equals("Edel")) ||
                  (source1.Equals("Corona") && source2.Equals("Edel") && source3.Equals("Livea")))
                    {
                        spr.sprite = Resources.Load("Prominence", typeof(Sprite)) as Sprite;
                        cp = "Prominence";
                    }
                    //lepita
                    if (source1.Equals("Mad") && source2.Equals("Ife") && source3.Equals("Ceta") ||
                  (source1.Equals("Mad") && source2.Equals("Ceta") && source3.Equals("Ife")) ||
                  (source1.Equals("Ceta") && source2.Equals("Mad") && source3.Equals("Ife")) ||
                  (source1.Equals("Ceta") && source2.Equals("Ife") && source3.Equals("Mad")) ||
                  (source1.Equals("Ife") && source2.Equals("Ceta") && source3.Equals("Mad")) ||
                  (source1.Equals("Ife") && source2.Equals("Mad") && source3.Equals("Ceta")))
                    {
                        spr.sprite = Resources.Load("Lepita", typeof(Sprite)) as Sprite;
                        cp = "Lepita";
                    }
                    //pluto
                    if (source1.Equals("Mad") && source2.Equals("Heith") && source3.Equals("Ghibli") ||
                  (source1.Equals("Mad") && source2.Equals("Ghibli") && source3.Equals("Heith")) ||
                  (source1.Equals("Ghibli") && source2.Equals("Mad") && source3.Equals("Heith")) ||
                  (source1.Equals("Ghibli") && source2.Equals("Heith") && source3.Equals("Mad")) ||
                  (source1.Equals("Heith") && source2.Equals("Mad") && source3.Equals("Ghibli")) ||
                  (source1.Equals("Heith") && source2.Equals("Ghibli") && source3.Equals("Mad")))
                    {
                        spr.sprite = Resources.Load("Pluto", typeof(Sprite)) as Sprite;
                        cp = "Pluto";
                    }

                    //drake
                    if (source1.Equals("Senn") && source2.Equals("Ife") && source3.Equals("Ceta") ||
                  (source1.Equals("Senn") && source2.Equals("Ceta") && source3.Equals("Ife")) ||
                  (source1.Equals("Ceta") && source2.Equals("Senn") && source3.Equals("Ife")) ||
                  (source1.Equals("Ceta") && source2.Equals("Ife") && source3.Equals("Senn")) ||
                  (source1.Equals("Ife") && source2.Equals("Ceta") && source3.Equals("Senn")) ||
                  (source1.Equals("Ife") && source2.Equals("Senn") && source3.Equals("Ceta")))
                    {
                        spr.sprite = Resources.Load("Drake", typeof(Sprite)) as Sprite;
                        cp = "Drake";
                    }

                    //Talencia
                    if (source1.Equals("Valte") && source2.Equals("Livea") && source3.Equals("Ceta") ||
                  (source1.Equals("Valte") && source2.Equals("Ceta") && source3.Equals("Livea")) ||
                  (source1.Equals("Livea") && source2.Equals("Valte") && source3.Equals("Ceta")) ||
                  (source1.Equals("Livea") && source2.Equals("Ceta") && source3.Equals("Valte")) ||
                  (source1.Equals("Ceta") && source2.Equals("Livea") && source3.Equals("Valte")) ||
                  (source1.Equals("Ceta") && source2.Equals("Valte") && source3.Equals("Livea")))
                    {
                        spr.sprite = Resources.Load("Talencia", typeof(Sprite)) as Sprite;
                        cp = "Talencia";
                    }
                    //merced
                    if (source1.Equals("Reydn") && source2.Equals("Russel") && source3.Equals("Ghibli") ||
                  (source1.Equals("Reydn") && source2.Equals("Ghibli") && source3.Equals("Russel")) ||
                  (source1.Equals("Ghibli") && source2.Equals("Reydn") && source3.Equals("Russel")) ||
                  (source1.Equals("Ghibli") && source2.Equals("Russel") && source3.Equals("Reydn")) ||
                  (source1.Equals("Russel") && source2.Equals("Ghibli") && source3.Equals("Reydn")) ||
                  (source1.Equals("Russel") && source2.Equals("Reydn") && source3.Equals("Ghibli")))
                    {
                        spr.sprite = Resources.Load("Merced", typeof(Sprite)) as Sprite;
                        cp = "Merced";
                    }
                    //servent
                    if (source1.Equals("Senn") && source2.Equals("Heith") && source3.Equals("Ghibli") ||
                  (source1.Equals("Senn") && source2.Equals("Ghibli") && source3.Equals("Heith")) ||
                  (source1.Equals("Ghibli") && source2.Equals("Senn") && source3.Equals("Heith")) ||
                  (source1.Equals("Ghibli") && source2.Equals("Heith") && source3.Equals("Senn")) ||
                  (source1.Equals("Heith") && source2.Equals("Ghibli") && source3.Equals("Senn")) ||
                  (source1.Equals("Heith") && source2.Equals("Senn") && source3.Equals("Ghibli")))
                    {
                        spr.sprite = Resources.Load("Servent", typeof(Sprite)) as Sprite;
                        cp = "Servent";
                    }
                    //Gale
                    if (source1.Equals("Reydn") && source2.Equals("Corona") && source3.Equals("Livea") ||
                  (source1.Equals("Reydn") && source2.Equals("Livea") && source3.Equals("Corona")) ||
                  (source1.Equals("Livea") && source2.Equals("Reydn") && source3.Equals("Corona")) ||
                  (source1.Equals("Livea") && source2.Equals("Corona") && source3.Equals("Reydn")) ||
                  (source1.Equals("Corona") && source2.Equals("Livea") && source3.Equals("Reydn")) ||
                  (source1.Equals("Corona") && source2.Equals("Reydn") && source3.Equals("Livea")))
                    {
                        spr.sprite = Resources.Load("Gale", typeof(Sprite)) as Sprite;
                        cp = "Gale";
                    }
                    //Icarus
                    if (source1.Equals("Russel") && source2.Equals("Mad") && source3.Equals("Valte") ||
                  (source1.Equals("Russel") && source2.Equals("Valte") && source3.Equals("Mad")) ||
                  (source1.Equals("Valte") && source2.Equals("Russel") && source3.Equals("Mad")) ||
                  (source1.Equals("Valte") && source2.Equals("Mad") && source3.Equals("Russel")) ||
                  (source1.Equals("Mad") && source2.Equals("Valte") && source3.Equals("Russel")) ||
                  (source1.Equals("Mad") && source2.Equals("Russel") && source3.Equals("Valte")))
                    {
                        spr.sprite = Resources.Load("Icarus", typeof(Sprite)) as Sprite;
                        cp = "Icarus";
                    }
                    //Nephisto
                    if (source1.Equals("Heith") && source2.Equals("Russel") && source3.Equals("Senn") ||
                  (source1.Equals("Heith") && source2.Equals("Senn") && source3.Equals("Russel")) ||
                  (source1.Equals("Senn") && source2.Equals("Heith") && source3.Equals("Russel")) ||
                  (source1.Equals("Senn") && source2.Equals("Russel") && source3.Equals("Heith")) ||
                  (source1.Equals("Russel") && source2.Equals("Senn") && source3.Equals("Heith")) ||
                  (source1.Equals("Russel") && source2.Equals("Heith") && source3.Equals("Senn")))
                    {
                        spr.sprite = Resources.Load("Nephisto", typeof(Sprite)) as Sprite;
                        cp = "Nephisto";
                    }
                    //Lysithea
                    if (source1.Equals("Edel") && source2.Equals("Senn") && source3.Equals("Mad") ||
                  (source1.Equals("Edel") && source2.Equals("Mad") && source3.Equals("Senn")) ||
                  (source1.Equals("Mad") && source2.Equals("Edel") && source3.Equals("Senn")) ||
                  (source1.Equals("Mad") && source2.Equals("Senn") && source3.Equals("Edel")) ||
                  (source1.Equals("Senn") && source2.Equals("Mad") && source3.Equals("Edel")) ||
                  (source1.Equals("Senn") && source2.Equals("Edel") && source3.Equals("Mad")))
                    {
                        spr.sprite = Resources.Load("Lysithea", typeof(Sprite)) as Sprite;
                        cp = "Lysithea";
                    }
                    //Curious
                    if (source1.Equals("Mad") && source2.Equals("Corona") && source3.Equals("Livea") ||
                  (source1.Equals("Mad") && source2.Equals("Livea") && source3.Equals("Corona")) ||
                  (source1.Equals("Livea") && source2.Equals("Mad") && source3.Equals("Corona")) ||
                  (source1.Equals("Livea") && source2.Equals("Corona") && source3.Equals("Mad")) ||
                  (source1.Equals("Corona") && source2.Equals("Livea") && source3.Equals("Mad")) ||
                  (source1.Equals("Corona") && source2.Equals("Mad") && source3.Equals("Livea")))
                    {
                        spr.sprite = Resources.Load("Curious", typeof(Sprite)) as Sprite;
                        cp = "Curious";
                    }


                    //5성
                    //kargos
                    if (source1.Equals("Talencia") && source2.Equals("Prominence") && source3.Equals("Curious") ||
                  (source1.Equals("Talencia") && source2.Equals("Curious") && source3.Equals("Prominence")) ||
                  (source1.Equals("Curious") && source2.Equals("Talencia") && source3.Equals("Prominence")) ||
                  (source1.Equals("Curious") && source2.Equals("Prominence") && source3.Equals("Talencia")) ||
                  (source1.Equals("Prominence") && source2.Equals("Curious") && source3.Equals("Talencia")) ||
                  (source1.Equals("Prominence") && source2.Equals("Talencia") && source3.Equals("Curious")))
                    {
                        spr.sprite = Resources.Load("Kargos", typeof(Sprite)) as Sprite;
                        cp = "Kargos";
                    }

                    //Mido
                    if (source1.Equals("Pluto") && source2.Equals("Nephisto") && source3.Equals("Icarus") ||
                       (source1.Equals("Pluto") && source2.Equals("Icarus") && source3.Equals("Nephisto")) ||
                       (source1.Equals("Icarus") && source2.Equals("Pluto") && source3.Equals("Nephisto")) ||
                       (source1.Equals("Icarus") && source2.Equals("Nephisto") && source3.Equals("Pluto")) ||
                       (source1.Equals("Nephisto") && source2.Equals("Icarus") && source3.Equals("Pluto")) ||
                       (source1.Equals("Nephisto") && source2.Equals("Pluto") && source3.Equals("Icarus")))
                    {
                        spr.sprite = Resources.Load("Mido", typeof(Sprite)) as Sprite;
                        cp = "Mido";
                    }

                    //Lephion
                    if (source1.Equals("Lysithea") && source2.Equals("Servent") && source3.Equals("Drake") ||
                       (source1.Equals("Lysithea") && source2.Equals("Drake") && source3.Equals("Servent")) ||
                       (source1.Equals("Drake") && source2.Equals("Lysithea") && source3.Equals("Servent")) ||
                       (source1.Equals("Drake") && source2.Equals("Servent") && source3.Equals("Lysithea")) ||
                       (source1.Equals("Servent") && source2.Equals("Drake") && source3.Equals("Lysithea")) ||
                       (source1.Equals("Servent") && source2.Equals("Lysithea") && source3.Equals("Drake")))
                    {
                        spr.sprite = Resources.Load("Lephion", typeof(Sprite)) as Sprite;
                        cp = "Lephion";
                    }

                    //MeryEl
                    if (source1.Equals("Lepita") && source2.Equals("HighLander") && source3.Equals("Merced") ||
                        (source1.Equals("Lepita") && source2.Equals("Merced") && source3.Equals("HighLander")) ||
                        (source1.Equals("Merced") && source2.Equals("Lepita") && source3.Equals("HighLander")) ||
                        (source1.Equals("Merced") && source2.Equals("HighLander") && source3.Equals("Lepita")) ||
                        (source1.Equals("HighLander") && source2.Equals("Merced") && source3.Equals("Lepita")) ||
                        (source1.Equals("HighLander") && source2.Equals("Lepita") && source3.Equals("Merced")))
                    {
                        spr.sprite = Resources.Load("MeryEl", typeof(Sprite)) as Sprite;
                        cp = "MeryEl";
                    }




                }
                else
                {
                    source3 = "null";

                    source1 = mixBox1.GetComponent<SpriteRenderer>().sprite.name;
                    source2 = mixBox2.GetComponent<SpriteRenderer>().sprite.name;
                    
                    //2성
                    //Cross 조합식
                    if ((source1.Equals("Ray") && source2.Equals("Vird") && source3.Equals("null")) ||
                        (source1.Equals("Vird") && source2.Equals("Ray") && source3.Equals("null")))
                    {

                        spr.sprite = Resources.Load("Cross", typeof(Sprite)) as Sprite;
                        cp = "Cross";
                    }
                    //Terrine 조합식
                    if (source1.Equals("Ray") && source2.Equals("Eli") && source3.Equals("null") ||
                        (source1.Equals("Eli") && source2.Equals("Ray") && source3.Equals("null")))
                    {

                        spr.sprite = Resources.Load("Terrine", typeof(Sprite)) as Sprite;
                        cp = "Terrine";
                    }
                    //Crete 조합식
                    if (source1.Equals("Vird") && source2.Equals("Eli") && source3.Equals("null") ||
                        (source1.Equals("Eli") && source2.Equals("Vird") && source3.Equals("null")))
                    {

                        spr.sprite = Resources.Load("Crete", typeof(Sprite)) as Sprite;
                        cp = "Crete";
                    }
                    //Roid 조합식
                    if (source1.Equals("Ray") && source2.Equals("Theis") && source3.Equals("null") ||
                        (source1.Equals("Theis") && source2.Equals("Ray") && source3.Equals("null")))
                    {

                        spr.sprite = Resources.Load("Roid", typeof(Sprite)) as Sprite;
                        cp = "Roid";
                    }
                    //May 조합식
                    if (source1.Equals("Vird") && source2.Equals("Theis") && source3.Equals("null") ||
                        (source1.Equals("Theis") && source2.Equals("Vird") && source3.Equals("null")))
                    {

                        spr.sprite = Resources.Load("May", typeof(Sprite)) as Sprite;
                        cp = "May";
                    }
                    //Akina 조합식
                    if (source1.Equals("Eli") && source2.Equals("Eli") && source3.Equals("null"))
                    {

                        spr.sprite = Resources.Load("Akina", typeof(Sprite)) as Sprite;
                        cp = "Akina";
                    }
                    //Robin 조합식
                    if (source1.Equals("Vird") && source2.Equals("Vird") && source3.Equals("null"))
                    {

                        spr.sprite = Resources.Load("Robin", typeof(Sprite)) as Sprite;
                        cp = "Robin";
                    }
                    //Caster 조합식
                    if (source1.Equals("Ray") && source2.Equals("Ray") && source3.Equals("null"))
                    {

                        spr.sprite = Resources.Load("Caster", typeof(Sprite)) as Sprite;
                        cp = "Caster";
                    }

                    //3성
                    if (source1.Equals("Caster") && source2.Equals("Terrine") && source3.Equals("null") ||
                        (source1.Equals("Terrine") && source2.Equals("Caster") && source3.Equals("null")))
                    {
                        spr.sprite = Resources.Load("Reydn", typeof(Sprite)) as Sprite;
                        cp = "Reydn";
                    }
                    if (source1.Equals("Akina") && source2.Equals("Terrine") && source3.Equals("null") ||
                        (source1.Equals("Terrine") && source2.Equals("Akina") && source3.Equals("null")))
                    {
                        spr.sprite = Resources.Load("Edel", typeof(Sprite)) as Sprite;
                        cp = "Edel";
                    }
                    if (source1.Equals("Akina") && source2.Equals("Crete") && source3.Equals("null") ||
                        (source1.Equals("Crete") && source2.Equals("Akina") && source3.Equals("null")))
                    {
                        spr.sprite = Resources.Load("Corona", typeof(Sprite)) as Sprite;
                        cp = "Corona";
                    }
                    if (source1.Equals("Akina") && source2.Equals("Robin") && source3.Equals("null") ||
                        (source1.Equals("Robin") && source2.Equals("Akina") && source3.Equals("null")))
                    {
                        spr.sprite = Resources.Load("Heith", typeof(Sprite)) as Sprite;
                        cp = "Heith";
                    }
                    if (source1.Equals("Roid") && source2.Equals("May") && source3.Equals("null") ||
                        (source1.Equals("May") && source2.Equals("Roid") && source3.Equals("null")))
                    {
                        spr.sprite = Resources.Load("Mad", typeof(Sprite)) as Sprite;
                        cp = "Mad";
                    }
                    if (source1.Equals("Akina") && source2.Equals("May") && source3.Equals("null") ||
                        (source1.Equals("May") && source2.Equals("Akina") && source3.Equals("null")))
                    {
                        spr.sprite = Resources.Load("Ghibli", typeof(Sprite)) as Sprite;
                        cp = "Ghibli";
                    }
                    if (source1.Equals("Robin") && source2.Equals("Caster") && source3.Equals("null") ||
                        (source1.Equals("Caster") && source2.Equals("Robin") && source3.Equals("null")))
                    {
                        spr.sprite = Resources.Load("Livea", typeof(Sprite)) as Sprite;
                        cp = "Livea";
                    }
                    if (source1.Equals("Cross") && source2.Equals("Crete") && source3.Equals("null") ||
                        (source1.Equals("Crete") && source2.Equals("Cross") && source3.Equals("null")))
                    {
                        spr.sprite = Resources.Load("Valte", typeof(Sprite)) as Sprite;
                        cp = "Valte";
                    }
                    if (source1.Equals("Roid") && source2.Equals("Caster") && source3.Equals("null") ||
                        (source1.Equals("Caster") && source2.Equals("Roid") && source3.Equals("null")))
                    {
                        spr.sprite = Resources.Load("Ife", typeof(Sprite)) as Sprite;
                        cp = "Ife";
                    }
                    if (source1.Equals("May") && source2.Equals("Cross") && source3.Equals("null") ||
                        (source1.Equals("Cross") && source2.Equals("May") && source3.Equals("null")))
                    {
                        spr.sprite = Resources.Load("Ceta", typeof(Sprite)) as Sprite;
                        cp = "Ceta";
                    }
                    if (source1.Equals("Akina") && source2.Equals("Akina") && source3.Equals("null"))
                    {
                        spr.sprite = Resources.Load("Senn", typeof(Sprite)) as Sprite;
                        cp = "Senn";
                    }
                    if (source1.Equals("Terrine") && source2.Equals("Crete") && source3.Equals("null") ||
                        (source1.Equals("Crete") && source2.Equals("Terrine") && source3.Equals("null")))
                    {
                        spr.sprite = Resources.Load("Russel", typeof(Sprite)) as Sprite;
                        cp = "Russel";
                    }

                
                }

            }



        }
        else
        {

        }


        mixed = true;


    }
}

    
