using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : Singleton<GameOverUI>
{
     [SerializeField]
    private GameObject gameOverUI;
     [SerializeField]
    private Text enemyTextDescription;
    [SerializeField]
    private Text enemyType;
     [SerializeField]
    private Image EnemyImage;

    public void EnemyWiner(GameObject enemy){
        this.enemyType.text=enemy.GetComponent<Enemy>().Type;
        this.EnemyImage.sprite = enemy.GetComponent<SpriteRenderer>().sprite;
        this.enemyTextDescription.text=GetEnemyTextDescription(this.enemyType.text);
    }

    public void GameOver(){
        gameOverUI.SetActive(true);
    }

    private string GetEnemyTextDescription(string type){
        switch (type)
        {
            case "Virus":  
                return "A forma mais comum de malware conhecida, pode ocasionar diversos problemas como: realiza o furto de informações pessoais ou clona os arquivos do computador e também se replica para as outras máquinas na rede";
            case "SpyWare":
                return "Tem o objetivo de coletar dados de um dispositivo, e encaminhá-los a terceiros sem que o usuário tenha conhecimento disso.";
            case "RansomWare":
            return "Criado para extorquir dinheiro das vítimas, ele pode criptografar dados armazenados no disco da vítima para impedir o acesso às informações e bloquear o acesso normal ao sistema.";
            default:
            return "UNKOWN ENEMY";
        }
    }
}
