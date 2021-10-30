using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    // Pemain yang akan bertambah skornya jika bola menyentuh dinding ini.
    public ScoreController score;
    public CharacterSoundController sound;
    public Text text;

    public float SpawnTime = 2f;
    private float _spawnTime;

    // Akan dipanggil ketika objek lain ber-collider (character) bersentuhan dengan koin.
    [System.Obsolete]
    void OnTriggerEnter2D(Collider2D anotherCollider)
    {
        // Jika objek tersebut bernama "Ball":
        if (anotherCollider.name == "Main Character")
        {
            // Tambahkan skor ke pemain
            score.IncreaseCurrentScore(5);

            sound.PlayCoin();

            text.gameObject.SetActive(true);
            _spawnTime = SpawnTime;

            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    private void Update()
    {
        _spawnTime -= Time.unscaledDeltaTime;
        if (_spawnTime <= 0f)
        {
            text.gameObject.SetActive(false);
        }
        else
        {
            text.CrossFadeAlpha(0f, 0.9f, false);
            if (text.color.a == 0f)
            {
                text.gameObject.SetActive(false);
            }
        }
    }
}