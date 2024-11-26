using System;

class Task
{
    private static int _idCounter = 1;
    public int Id { get; private set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public string Priority { get; set; }
    public DateTime CreatedAt { get; set; }

    public Task()
    {
        Id = _idCounter++;
    }
}
