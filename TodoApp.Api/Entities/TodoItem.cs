﻿namespace TodoApp.Api.Entities;

public class TodoItem
{
    public int Id { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    
}