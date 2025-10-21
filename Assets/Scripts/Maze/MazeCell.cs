using UnityEngine;

public class MazeCell : MonoBehaviour
{

    public GameObject leftWall;
    public GameObject rightWall;
    public GameObject bottomWall;
    public GameObject topWall;
    public GameObject floor;

    public bool visited = false;
    public int x;
    public int z;

    public void Initialize(int xPos, int zPos)          // �� �ʱ�ȭ
    {
        x = xPos;
        z = zPos;
        visited = false;
        ShowAllWalls();
    }

    public void ShowAllWalls()          // ��� �� ǥ��
    {
        leftWall.SetActive(true);
        rightWall.SetActive(true);
        bottomWall.SetActive(true);
        topWall.SetActive(true);
        floor.SetActive(true);
    }

    public void RemoveWall(string direciton)            // Ư�� ���� �� ����
    {
        switch (direciton)
        {
            case "left":
                leftWall.SetActive(false);
                break;
            case "right":
                rightWall.SetActive(false);
                break;
            case "bottom":
                bottomWall.SetActive(false);
                break;
            case "top":
                topWall.SetActive(false);
                break;
        }
    }

    public void SetColor(Color color)           // �� ���� ���� (��� ǥ�ÿ�)
    {
        floor.GetComponent<Renderer>().material.color = color;
    }
}
