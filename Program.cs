using System;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8; 
        TaskManager taskManager = new TaskManager();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== To-Do List ===");
            Console.WriteLine("1. Добавить задачу");
            Console.WriteLine("2. Показать все задачи");
            Console.WriteLine("3. Редактировать задачу");
            Console.WriteLine("4. Удалить задачу");
            Console.WriteLine("5. Выход");
            Console.Write("Выберите опцию: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    AddTask(taskManager);
                    break;
                case "2":
                    ShowTasks(taskManager);
                    break;
                case "3":
                    EditTask(taskManager);
                    break;
                case "4":
                    DeleteTask(taskManager);
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Неверный выбор. Нажмите Enter, чтобы попробовать снова.");
                    Console.ReadLine();
                    break;
            }
        }
    }

    static void AddTask(TaskManager taskManager)
    {
        Console.Clear();
        Console.WriteLine("=== Добавить задачу ===");
        Console.Write("Введите описание задачи: ");
        string description = Console.ReadLine();

        Console.Write("Введите категорию задачи: ");
        string category = Console.ReadLine(); 

        Console.Write("Введите приоритет (H - высокий, M - средний, L - низкий): ");
        string priority = Console.ReadLine();

        taskManager.AddTask(new Task
        {
            Description = description,
            Category = category,
            Priority = priority,
            CreatedAt = DateTime.Now
        });

        Console.WriteLine("Задача добавлена! Нажмите Enter, чтобы вернуться в меню.");
        Console.ReadLine();
    }

    static void ShowTasks(TaskManager taskManager)
    {
        Console.Clear();
        Console.WriteLine("=== Список задач ===");

        var tasks = taskManager.GetTasks();
        if (!tasks.Any())
        {
            Console.WriteLine("Нет задач.");
        }
        else
        {
            foreach (var task in tasks)
            {
                Console.WriteLine($"ID: {task.Id}, Описание: {task.Description}, Категория: {task.Category}, Приоритет: {task.Priority}, Создано: {task.CreatedAt}");
            }
        }

        Console.WriteLine("Нажмите Enter, чтобы вернуться в меню.");
        Console.ReadLine();
    }

    static void EditTask(TaskManager taskManager)
    {
        Console.Clear();
        Console.WriteLine("=== Редактировать задачу ===");
        Console.Write("Введите ID задачи: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var task = taskManager.GetTaskById(id);
            if (task != null)
            {
                Console.Write("Введите новое описание задачи: ");
                task.Description = Console.ReadLine();
                Console.Write("Введите новую категорию задачи: ");
                task.Category = Console.ReadLine();
                Console.Write("Введите новый приоритет задачи: ");
                task.Priority = Console.ReadLine();
                Console.WriteLine("Задача обновлена! Нажмите Enter, чтобы вернуться в меню.");
            }
            else
            {
                Console.WriteLine("Задача с таким ID не найдена. Нажмите Enter, чтобы вернуться в меню.");
            }
        }
        else
        {
            Console.WriteLine("Некорректный ID. Нажмите Enter, чтобы вернуться в меню.");
        }
        Console.ReadLine();
    }

    static void DeleteTask(TaskManager taskManager)
    {
        Console.Clear();
        Console.WriteLine("=== Удалить задачу ===");
        Console.Write("Введите ID задачи: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            if (taskManager.RemoveTask(id))
            {
                Console.WriteLine("Задача удалена! Нажмите Enter, чтобы вернуться в меню.");
            }
            else
            {
                Console.WriteLine("Задача с таким ID не найдена. Нажмите Enter, чтобы вернуться в меню.");
            }
        }
        else
        {
            Console.WriteLine("Некорректный ID. Нажмите Enter, чтобы вернуться в меню.");
        }
        Console.ReadLine();
    }
}
