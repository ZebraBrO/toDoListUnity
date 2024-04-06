using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskManager : MonoBehaviour
{
    public InputField taskInputField; // Input field для названия задачи
    public Button addButton; // Button для добавления задачи
    public GameObject taskPrefab; // Prefab для записей задач
    public Transform tasksContainer; // Transform для контейнера

    private List<string> tasks = new List<string>(); // Список задач

    void Start()
    {
        addButton.onClick.AddListener(AddTask); // Добавление слушателя для кнопки
    }

    // Метод для добавления задачи
    private void AddTask()
    {
        string taskName = taskInputField.text; // Получение названия задачи из поля ввода
        if (!string.IsNullOrEmpty(taskName)) // Проверка на пустое значение
        {
            tasks.Add(taskName); // Добавление задачи в список
            GameObject newTask = Instantiate(taskPrefab, tasksContainer); // Создание новой задачи из префаба
            newTask.GetComponent<TaskEntry>().Setup(taskName, this); // Настройка новой задачи
            taskInputField.text = string.Empty; // Очистка поля ввода
        }
    }

    // Метод для удаления задачи
    public void RemoveTask(string taskName)
    {
        tasks.Remove(taskName); // Удаление задачи из списка
        // Здесь можно добавить дополнительную логику при необходимости
    }

    // Метод для обновления статуса задачи
    public void UpdateTaskStatus(string taskName, bool isCompleted)
    {

    }
}
