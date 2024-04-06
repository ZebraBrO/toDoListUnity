using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskManager : MonoBehaviour
{
    public InputField taskInputField; // Input field ��� �������� ������
    public Button addButton; // Button ��� ���������� ������
    public GameObject taskPrefab; // Prefab ��� ������� �����
    public Transform tasksContainer; // Transform ��� ����������

    private List<string> tasks = new List<string>(); // ������ �����

    void Start()
    {
        addButton.onClick.AddListener(AddTask); // ���������� ��������� ��� ������
    }

    // ����� ��� ���������� ������
    private void AddTask()
    {
        string taskName = taskInputField.text; // ��������� �������� ������ �� ���� �����
        if (!string.IsNullOrEmpty(taskName)) // �������� �� ������ ��������
        {
            tasks.Add(taskName); // ���������� ������ � ������
            GameObject newTask = Instantiate(taskPrefab, tasksContainer); // �������� ����� ������ �� �������
            newTask.GetComponent<TaskEntry>().Setup(taskName, this); // ��������� ����� ������
            taskInputField.text = string.Empty; // ������� ���� �����
        }
    }

    // ����� ��� �������� ������
    public void RemoveTask(string taskName)
    {
        tasks.Remove(taskName); // �������� ������ �� ������
        // ����� ����� �������� �������������� ������ ��� �������������
    }

    // ����� ��� ���������� ������� ������
    public void UpdateTaskStatus(string taskName, bool isCompleted)
    {

    }
}
