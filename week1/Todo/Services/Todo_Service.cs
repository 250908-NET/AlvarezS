public class Todo_Service
{
    private List<Todo_Item> todo_Manager;
    private static int id;

    public Todo_Service()
    {
        todo_Manager = new List<Todo_Item>();
        id = 1;
    }

    public bool inbounds(int index)
    {
        return index >= 0 && index < todo_Manager.Count() ? true : false;
    }
    public void addItem(string desc)
    {
        todo_Manager.Add(new Todo_Item(id,desc, false, DateTime.Now));
        id += 1;
    }

    public void deleteItem(int index)
    {
        if (inbounds(index))
        {
            todo_Manager.RemoveAt(index);
            for (int i = 0; i < todo_Manager.Count; i++)
                todo_Manager[i].id = i + 1; 
            
            id = todo_Manager.Count + 1;
        }
        else
            throw new IndexOutOfRangeException();
    }

    public void markItem(int index)
    {
        if (inbounds(index))
            todo_Manager[index].switchMark();
        else
            throw new IndexOutOfRangeException();
    }

    public override string ToString()
    {
        string output = "=== YOUR TO-DO ITEMS === \n";
        foreach (Todo_Item item in todo_Manager)
        {
            output += item + "\n";
        }
        return output;
    }
}