using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameGUI : MonoBehaviour
{

    public static GameGUI instance;

    [Tooltip ("Every image that shows your health should be here, in left-to-right order. We hide ones when health is missing.")]
    public Image[] healthImages;

    [HideInInspector]
    public float lifeCount;

    public Image[] gemImages;
    [HideInInspector]
    public int gemCount = 0;

    [Tooltip ("This entire GUI will be shown when we win.")]
    public GameObject wonGUI;
    [Tooltip ("This entire GUI object will be shown when we lose.")]
    public GameObject lostGUI;

    [Tooltip ("When this Destructible no longer exists, we'll show the lostGUI.")]
    public Destructible player;

    void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        //hide both of the game GUIs until we need them
        wonGUI.SetActive( false );
        lostGUI.SetActive( false );

        UpdateGemImages();
        UpdateHealthImages();
    }
    
    public void Update()
    {
        lostGUI.SetActive( DidLoseGame() );
        wonGUI.SetActive( DidWinGame() );
    }

    public bool DidLoseGame()
    {
        return  player == null || player.isDying;
    }

    public bool DidWinGame()
    {
        return !DidLoseGame() && gemCount >= 5;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene( "MainGame" );
    }

    public void UpdateHealthImages()
    {
        
        if ( player != null )
        {
            lifeCount = player.hitPoints;
            print ( lifeCount );
        }

        for ( int healthImageIndex = 0; healthImageIndex < healthImages.Length; healthImageIndex++ )
        {
            healthImages[ healthImageIndex ].gameObject.SetActive( 
                lifeCount >= ( healthImageIndex + 1 ) 
            );
        }
    }

    public void UpdateGemImages()
    {
        for (int gemImageIndex = 0; gemImageIndex < gemImages.Length; gemImageIndex++)
        {
            gemImages[gemImageIndex].gameObject.SetActive(gemCount >= (gemImageIndex + 1));
        }
    }
}
