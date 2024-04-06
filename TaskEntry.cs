using UnityEngine;
using UnityEngine.UI;

public class TaskEntry : MonoBehaviour
{
    public Text taskNameText; // ����� ��� �������� ������
    public Button deleteButton; // ������ ��� �������� ������
    public Toggle completionToggle; // ������ ��� ������� ������ ��� �����������

    private TaskManager taskManager; // �������� �����
    private bool isCompleted = false; // ���� ���������� ������

    // ����� ������������� ������ ������ � ��������������� ����������� � ������
    public void Setup(string taskName, TaskManager manager)
    {
        taskManager = manager; // ���������� ��������� �����
        taskNameText.text = taskName; // ��������� �������� ������
        deleteButton.onClick.AddListener(DeleteTask); // ���������� ��������� ��� ������ ��������
        completionToggle.onValueChanged.AddListener(ToggleCompletionStatus); // ���������� ��������� ��� ������ ����������
    }

    // ����� ��� ������������ ������� ���������� ������
    private void ToggleCompletionStatus(bool isOn)
    {
        isCompleted = isOn; // ��������� ����� ����������
        // ��������� ����� ������ � ����������� �� ����������
        taskNameText.fontStyle = isCompleted ? FontStyle.BoldAndItalic : FontStyle.Normal;
        taskManager.UpdateTaskStatus(taskNameText.text, isCompleted); // ���������� ������� ������ � ���������
    }

    // ����� ��� �������� ������
    private void DeleteTask()
    {
        taskManager.RemoveTask(taskNameText.text); // �������� ������ �� ���������
        Destroy(gameObject); // ����������� �������� ���������� ������
    }
}
