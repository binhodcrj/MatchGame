using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace _2_MatchGame
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {

        DispatcherTimer timer = new DispatcherTimer();
        int tenthsOfSecondsElapsed;
        int matchesFound;
        public MainWindow()
        {
            InitializeComponent();

            timer.Interval = TimeSpan.FromSeconds(.1);
            timer.Tick += Timer_Tick; 

            SetupGame();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            tenthsOfSecondsElapsed++;
            timeTextBlock.Text = (tenthsOfSecondsElapsed / 10F).ToString("0.0s");
            
            if(matchesFound == 8)
            {

                timer.Stop();
                timeTextBlock.Text = timeTextBlock.Text + " - Seu Recorde!";

            }
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


                    //Localiza cada TexBlock na grade pricipal e e repete as declarações seguintes para cada um
            foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())
            {

                if (textBlock.Name != "timeTextBlock")
                {

                    textBlock.Visibility = Visibility.Visible;
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

            timer.Start();
            tenthsOfSecondsElapsed = 0;
            matchesFound = 0;
        }
        
        TextBlock lastTextBoxClicked;
        bool findingMatch = false;

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            

            TextBlock textBlock = sender as TextBlock;

            if(findingMatch == false)
            {

                textBlock.Visibility = Visibility.Hidden;
                lastTextBoxClicked = textBlock;
                findingMatch = true;

            }

            else if(textBlock.Text == lastTextBoxClicked.Text)
            {
                matchesFound++;
                textBlock.Visibility = Visibility.Hidden;
                findingMatch = false;
            }

            else
            {
              
                lastTextBoxClicked.Visibility = Visibility.Visible;
                findingMatch = false;


            }
        }

        private void TimeTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (matchesFound == 8)
            {
                SetupGame();
            }
        }
    }
}
