using DMTools.Die.Algorithm;
using DMTools.Die.Parser;
using DMTools.Die.Rollers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DiceRoller.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static RoutedCommand RollCommand = new RoutedCommand();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ExecutedRollCommand(object sender, ExecutedRoutedEventArgs e)
        {
            TextBlock target = e.Source as TextBlock;

            if (target == null) return;

            DiceExpressionParserDetailed diceParser = new DiceExpressionParserDetailed(new StandardDiceRoller());
            IComponent diceExpression = diceParser.ParseString(e.Parameter as string);

            target.Text = $"Rolled {diceExpression.ToString()} for a result of {diceExpression.Calculate()}";
        }

        private void CanExecuteRollCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            TextBlock target = e.Source as TextBlock;

            e.CanExecute = target == null ? false : true;
        }
    }
}
