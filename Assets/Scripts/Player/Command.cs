using System;
using System.Collections.Generic;
using System.Text;
namespace Command
{
    public class MoveUpCommand : ICommand
    {
        public void Execute(PlayerMovement playerMovement)
        {
            playerMovement.MoveUp();
        }
    }
    public class MoveDownCommand : ICommand
    {
        public void Execute(PlayerMovement playerMovement)
        {
            playerMovement.MoveDown();
        }
    }
    public class MoveLeftCommand : ICommand
    {
        public void Execute(PlayerMovement playerMovement)
        {
            playerMovement.MoveLeft();
        }
    }
    public class MoveRightCommand : ICommand
    {
        public void Execute(PlayerMovement playerMovement)
        {
            playerMovement.MoveRight();
        }
    }
}
