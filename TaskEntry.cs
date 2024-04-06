using UnityEngine;
using UnityEngine.UI;

public class TaskEntry : MonoBehaviour
{
    public Text taskNameText; // Текст для названия задачи
    public Button deleteButton; // Кнопка для удаления задачи
    public Toggle completionToggle; // Флажок для отметки задачи как выполненной

    private TaskManager taskManager; // Менеджер задач
    private bool isCompleted = false; // Флаг выполнения задачи

    // Метод устанавливает запись задачи с предоставленной информацией о задаче
    public void Setup(string taskName, TaskManager manager)
    {
        taskManager = manager; // Присвоение менеджера задач
        taskNameText.text = taskName; // Установка названия задачи
        deleteButton.onClick.AddListener(DeleteTask); // Добавление слушателя для кнопки удаления
        completionToggle.onValueChanged.AddListener(ToggleCompletionStatus); // Добавление слушателя для флажка выполнения
    }

    // Метод для переключения статуса выполнения задачи
    private void ToggleCompletionStatus(bool isOn)
    {
        isCompleted = isOn; // Установка флага выполнения
        // Изменение стиля текста в зависимости от выполнения
        taskNameText.fontStyle = isCompleted ? FontStyle.BoldAndItalic : FontStyle.Normal;
        taskManager.UpdateTaskStatus(taskNameText.text, isCompleted); // Обновление статуса задачи в менеджере
    }

    // Метод для удаления задачи
    private void DeleteTask()
    {
        taskManager.RemoveTask(taskNameText.text); // Удаление задачи из менеджера
        Destroy(gameObject); // Уничтожение элемента интерфейса задачи
    }
}
