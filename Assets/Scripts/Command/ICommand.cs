using UnityEngine;

public interface ICommand
{
    bool CanExecute();
    
    void Execute();
}
