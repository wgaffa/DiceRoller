using DMTools.Die.Algorithm;
using DMTools.Die.Parser;
using DMTools.Die.Rollers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DiceRoller.UI
{
    public class RollCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            DiceExpressionParserDetailed diceParser = new DiceExpressionParserDetailed(new StandardDiceRoller());
            IComponent diceExpression = diceParser.ParseString(parameter as string);

            MessageBox.Show($"You got a roll of {diceExpression.Calculate()}");
        }
    }
}
