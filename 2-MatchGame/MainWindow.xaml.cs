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

namespace _2_MatchGame
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            SetupGame();
        }

        private void SetupGame()
        {
            
            //Cria uma lista de 8 pares de emojis
            List<string> animalEmoji = new List<string>()           

           {
                "😺",  "😺", 
                "🐱‍🐉",  "🐱‍🐉",
                "🐵",  "🐵",
                "🐶",  "🐶",
                "🐼",  "🐼",
                "🦓",  "🦓",
                "🐠",  "🐠",
                "🐍",  "🐍",

            };

            //Cria um novo gerador de números aleatórios
            Random random = new Random();

            
            //Localiza cada TexBlock na grade pricipale e repete as declarações seguintes para cada um
            foreach(TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())
            {
                //Escolhe um número aleatório entre 0 e o número do emoji que ficou na lista e o chama de index
                int index = random.Next(animalEmoji.Count);

                //Usa o número aleatório chamado index para obter um emoji aleatório da lista
                string nextEmoji = animalEmoji[index];

                //Atualiza o TextBlock com o emoji aleatório da lista
                textBlock.Text = nextEmoji;

                //Remove o emoji aleatório da lista
                animalEmoji.RemoveAt(index);

            }
        }
    }
}
